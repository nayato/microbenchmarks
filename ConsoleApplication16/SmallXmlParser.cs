namespace ConsoleApplication16
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;

    public class SmallXmlParser
    {
        public interface IContentHandler
        {
            void OnStartParsing(SmallXmlParser parser);

            void OnEndParsing(SmallXmlParser parser);

            void OnStartElement(string name, IAttrList attrs);

            void OnEndElement(string name);

            void OnProcessingInstruction(string name, string text);

            void OnChars(string text);

            void OnIgnorableWhitespace(string text);
        }

        public interface IAttrList
        {
            int Length { get; }

            bool IsEmpty { get; }

            string GetName(int i);

            string GetValue(int i);

            string GetValue(string name);

            string[] Names { get; }

            string[] Values { get; }
        }

        class AttrListImpl : IAttrList
        {
            public int Length
            {
                get { return this.attrNames.Count; }
            }

            public bool IsEmpty
            {
                get { return this.attrNames.Count == 0; }
            }

            public string GetName(int i)
            {
                return this.attrNames[i];
            }

            public string GetValue(int i)
            {
                return this.attrValues[i];
            }

            public string GetValue(string name)
            {
                for (int i = 0; i < this.attrNames.Count; i++)
                    if (this.attrNames[i] == name)
                        return this.attrValues[i];
                return null;
            }

            public string[] Names
            {
                get { return this.attrNames.ToArray(); }
            }

            public string[] Values
            {
                get { return this.attrValues.ToArray(); }
            }

            readonly List<string> attrNames = new List<string>();
            readonly List<string> attrValues = new List<string>();

            internal void Clear()
            {
                this.attrNames.Clear();
                this.attrValues.Clear();
            }

            internal void Add(string name, string value)
            {
                this.attrNames.Add(name);
                this.attrValues.Add(value);
            }
        }

        IContentHandler handler;
        TextReader reader;
        readonly Stack elementNames = new Stack();
        readonly Stack xmlSpaces = new Stack();
        string xmlSpace;
        readonly StringBuilder buffer = new StringBuilder(200);
        char[] nameBuffer = new char[30];
        bool isWhitespace;

        readonly AttrListImpl attributes = new AttrListImpl();
        int line = 1, column;
        bool resetColumn;

        public SmallXmlParser()
        {
        }

        Exception Error(string msg)
        {
            return new SmallXmlParserException(msg, this.line, this.column);
        }

        Exception UnexpectedEndError()
        {
            var arr = new string[this.elementNames.Count];
            this.elementNames.CopyTo(arr, 0);
            return this.Error(string.Format(
                "Unexpected end of stream. Element stack content is {0}", string.Join(",", arr)));
        }

        bool IsNameChar(char c, bool start)
        {
            switch (c)
            {
                case ':':
                case '_':
                    return true;
                case '-':
                case '.':
                    return !start;
            }
            if (c > 0x100)
            {
                // optional condition for optimization
                switch (c)
                {
                    case '\u0559':
                    case '\u06E5':
                    case '\u06E6':
                        return true;
                }
                if ('\u02BB' <= c && c <= '\u02C1')
                    return true;
            }
            switch (char.GetUnicodeCategory(c))
            {
                case UnicodeCategory.LowercaseLetter:
                case UnicodeCategory.UppercaseLetter:
                case UnicodeCategory.OtherLetter:
                case UnicodeCategory.TitlecaseLetter:
                case UnicodeCategory.LetterNumber:
                    return true;
                case UnicodeCategory.SpacingCombiningMark:
                case UnicodeCategory.EnclosingMark:
                case UnicodeCategory.NonSpacingMark:
                case UnicodeCategory.ModifierLetter:
                case UnicodeCategory.DecimalDigitNumber:
                    return !start;
                default:
                    return false;
            }
        }

        bool IsWhitespace(int c)
        {
            switch (c)
            {
                case ' ':
                case '\r':
                case '\t':
                case '\n':
                    return true;
                default:
                    return false;
            }
        }

        public void SkipWhitespaces()
        {
            this.SkipWhitespaces(false);
        }

        void HandleWhitespaces()
        {
            while (this.IsWhitespace(this.Peek()))
                this.buffer.Append((char)this.Read());
            if (this.Peek() != '<' && this.Peek() >= 0)
                this.isWhitespace = false;
        }

        public void SkipWhitespaces(bool expected)
        {
            while (true)
            {
                switch (this.Peek())
                {
                    case ' ':
                    case '\r':
                    case '\t':
                    case '\n':
                        this.Read();
                        if (expected)
                            expected = false;
                        continue;
                }
                if (expected)
                    throw this.Error("Whitespace is expected.");
                return;
            }
        }

        int Peek()
        {
            return this.reader.Peek();
        }

        int Read()
        {
            int i = this.reader.Read();
            if (i == '\n')
                this.resetColumn = true;
            if (this.resetColumn)
            {
                this.line++;
                this.resetColumn = false;
                this.column = 1;
            }
            else
                this.column++;
            return i;
        }

        public void Expect(int c)
        {
            int p = this.Read();
            if (p < 0)
                throw this.UnexpectedEndError();
            else if (p != c)
                throw this.Error(string.Format("Expected '{0}' but got {1}", (char)c, (char)p));
        }

        string ReadUntil(char until, bool handleReferences)
        {
            while (true)
            {
                if (this.Peek() < 0)
                    throw this.UnexpectedEndError();
                char c = (char)this.Read();
                if (c == until)
                    break;
                else if (handleReferences && c == '&')
                    this.ReadReference();
                else
                    this.buffer.Append(c);
            }
            string ret = this.buffer.ToString();
            this.buffer.Length = 0;
            return ret;
        }

        public string ReadName()
        {
            int idx = 0;
            if (this.Peek() < 0 || !this.IsNameChar((char)this.Peek(), true))
                throw this.Error("XML name start character is expected.");
            for (int i = this.Peek(); i >= 0; i = this.Peek())
            {
                char c = (char)i;
                if (!this.IsNameChar(c, false))
                    break;
                if (idx == this.nameBuffer.Length)
                {
                    var tmp = new char[idx * 2];
                    Array.Copy(this.nameBuffer, tmp, idx);
                    this.nameBuffer = tmp;
                }
                this.nameBuffer[idx++] = c;
                this.Read();
            }
            if (idx == 0)
                throw this.Error("Valid XML name is expected.");
            return new string(this.nameBuffer, 0, idx);
        }

        public void Parse(TextReader input, IContentHandler handler)
        {
            this.reader = input;
            this.handler = handler;

            handler.OnStartParsing(this);

            while (this.Peek() >= 0)
                this.ReadContent();
            this.HandleBufferedContent();
            if (this.elementNames.Count > 0)
                throw this.Error(string.Format("Insufficient close tag: {0}", this.elementNames.Peek()));

            handler.OnEndParsing(this);

            this.Cleanup();
        }

        void Cleanup()
        {
            this.line = 1;
            this.column = 0;
            this.handler = null;
            this.reader = null;
            this.elementNames.Clear();
            this.xmlSpaces.Clear();
            this.attributes.Clear();
            this.buffer.Length = 0;
            this.xmlSpace = null;
            this.isWhitespace = false;
        }

        public void ReadContent()
        {
            string name;
            if (this.IsWhitespace(this.Peek()))
            {
                if (this.buffer.Length == 0)
                    this.isWhitespace = true;
                this.HandleWhitespaces();
            }
            if (this.Peek() == '<')
            {
                this.Read();
                switch (this.Peek())
                {
                    case '!': // declarations
                        this.Read();
                        if (this.Peek() == '[')
                        {
                            this.Read();
                            if (this.ReadName() != "CDATA")
                                throw this.Error("Invalid declaration markup");
                            this.Expect('[');
                            this.ReadCDATASection();
                            return;
                        }
                        else if (this.Peek() == '-')
                        {
                            this.ReadComment();
                            return;
                        }
                        else if (this.ReadName() != "DOCTYPE")
                            throw this.Error("Invalid declaration markup.");
                        else
                            throw this.Error("This parser does not support document type.");
                    case '?': // PIs
                        this.HandleBufferedContent();
                        this.Read();
                        name = this.ReadName();
                        this.SkipWhitespaces();
                        string text = string.Empty;
                        if (this.Peek() != '?')
                        {
                            while (true)
                            {
                                text += this.ReadUntil('?', false);
                                if (this.Peek() == '>')
                                    break;
                                text += "?";
                            }
                        }
                        this.handler.OnProcessingInstruction(
                            name, text);
                        this.Expect('>');
                        return;
                    case '/': // end tags
                        this.HandleBufferedContent();
                        if (this.elementNames.Count == 0)
                            throw this.UnexpectedEndError();
                        this.Read();
                        name = this.ReadName();
                        this.SkipWhitespaces();
                        string expected = (string)this.elementNames.Pop();
                        this.xmlSpaces.Pop();
                        if (this.xmlSpaces.Count > 0)
                            this.xmlSpace = (string)this.xmlSpaces.Peek();
                        else
                            this.xmlSpace = null;
                        if (name != expected)
                            throw this.Error(string.Format("End tag mismatch: expected {0} but found {1}", expected, name));
                        this.handler.OnEndElement(name);
                        this.Expect('>');
                        return;
                    default: // start tags (including empty tags)
                        this.HandleBufferedContent();
                        name = this.ReadName();
                        while (this.Peek() != '>' && this.Peek() != '/')
                            this.ReadAttribute(this.attributes);
                        this.handler.OnStartElement(name, this.attributes);
                        this.attributes.Clear();
                        this.SkipWhitespaces();
                        if (this.Peek() == '/')
                        {
                            this.Read();
                            this.handler.OnEndElement(name);
                        }
                        else
                        {
                            this.elementNames.Push(name);
                            this.xmlSpaces.Push(this.xmlSpace);
                        }
                        this.Expect('>');
                        return;
                }
            }
            else
                this.ReadCharacters();
        }

        void HandleBufferedContent()
        {
            if (this.buffer.Length == 0)
                return;
            if (this.isWhitespace)
                this.handler.OnIgnorableWhitespace(this.buffer.ToString());
            else
                this.handler.OnChars(this.buffer.ToString());
            this.buffer.Length = 0;
            this.isWhitespace = false;
        }

        void ReadCharacters()
        {
            this.isWhitespace = false;
            while (true)
            {
                int i = this.Peek();
                switch (i)
                {
                    case -1:
                        return;
                    case '<':
                        return;
                    case '&':
                        this.Read();
                        this.ReadReference();
                        continue;
                    default:
                        this.buffer.Append((char)this.Read());
                        continue;
                }
            }
        }

        void ReadReference()
        {
            if (this.Peek() == '#')
            {
                // character reference
                this.Read();
                this.ReadCharacterReference();
            }
            else
            {
                string name = this.ReadName();
                this.Expect(';');
                switch (name)
                {
                    case "amp":
                        this.buffer.Append('&');
                        break;
                    case "quot":
                        this.buffer.Append('"');
                        break;
                    case "apos":
                        this.buffer.Append('\'');
                        break;
                    case "lt":
                        this.buffer.Append('<');
                        break;
                    case "gt":
                        this.buffer.Append('>');
                        break;
                    default:
                        throw this.Error("General non-predefined entity reference is not supported in this parser.");
                }
            }
        }

        int ReadCharacterReference()
        {
            int n = 0;
            if (this.Peek() == 'x')
            {
                // hex
                this.Read();
                for (int i = this.Peek(); i >= 0; i = this.Peek())
                {
                    if ('0' <= i && i <= '9')
                        n = n << (4 + i - '0');
                    else if ('A' <= i && i <= 'F')
                        n = n << (4 + i - 'A' + 10);
                    else if ('a' <= i && i <= 'f')
                        n = n << (4 + i - 'a' + 10);
                    else
                        break;
                    this.Read();
                }
            }
            else
            {
                for (int i = this.Peek(); i >= 0; i = this.Peek())
                {
                    if ('0' <= i && i <= '9')
                        n = n << (4 + i - '0');
                    else
                        break;
                    this.Read();
                }
            }
            return n;
        }

        void ReadAttribute(AttrListImpl a)
        {
            this.SkipWhitespaces(true);
            if (this.Peek() == '/' || this.Peek() == '>')
                // came here just to spend trailing whitespaces
                return;

            string name = this.ReadName();
            string value;
            this.SkipWhitespaces();
            this.Expect('=');
            this.SkipWhitespaces();
            switch (this.Read())
            {
                case '\'':
                    value = this.ReadUntil('\'', true);
                    break;
                case '"':
                    value = this.ReadUntil('"', true);
                    break;
                default:
                    throw this.Error("Invalid attribute value markup.");
            }
            if (name == "xml:space")
                this.xmlSpace = value;
            a.Add(name, value);
        }

        void ReadCDATASection()
        {
            int nBracket = 0;
            while (true)
            {
                if (this.Peek() < 0)
                    throw this.UnexpectedEndError();
                char c = (char)this.Read();
                if (c == ']')
                    nBracket++;
                else if (c == '>' && nBracket > 1)
                {
                    for (int i = nBracket; i > 2; i--)
                        this.buffer.Append(']');
                    break;
                }
                else
                {
                    for (int i = 0; i < nBracket; i++)
                        this.buffer.Append(']');
                    nBracket = 0;
                    this.buffer.Append(c);
                }
            }
        }

        void ReadComment()
        {
            this.Expect('-');
            this.Expect('-');
            while (true)
            {
                if (this.Read() != '-')
                    continue;
                if (this.Read() != '-')
                    continue;
                if (this.Read() != '>')
                    throw this.Error("'--' is not allowed inside comment markup.");
                break;
            }
        }
    }

#if INSIDE_CORLIB
	internal
#else
    [CLSCompliant(false)]
    public
#endif
        class SmallXmlParserException : SystemException
    {
        readonly int line;
        readonly int column;

        public SmallXmlParserException(string msg, int line, int column)
            : base(string.Format("{0}. At ({1},{2})", msg, line, column))
        {
            this.line = line;
            this.column = column;
        }

        public int Line
        {
            get { return this.line; }
        }

        public int Column
        {
            get { return this.column; }
        }
    }
}