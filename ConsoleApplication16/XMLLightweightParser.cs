//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ConsoleApplication16
//{
//    using System.Globalization;
//    using System.Text.RegularExpressions;
//    using System.Xml;
//    using java.nio;

//    internal class XMLLightweightParser
//    {

//        private static Regex XML_HAS_CHARREF = new Regex("&#(0*([0-9]+)|[xX]0*([0-9a-fA-F]+));", RegexOptions.Compiled);

//        private static int maxBufferSize;
//        // Chars that rappresent CDATA section start
//        protected static char[] CDATA_START =
//            {
//                '<', '!', '[', 'C', 'D', 'A', 'T', 'A', '['
//            };

//        // Chars that rappresent CDATA section end
//        protected static char[] CDATA_END =
//            {
//                ']', ']', '>'
//            };

//        // Buffer with all data retrieved
//        protected StringBuilder buffer = new StringBuilder();

//        // ---- INTERNAL STATUS -------
//        // Initial status
//        protected static readonly int INIT = 0;
//        // Status used when the first tag name is retrieved
//        protected static readonly int HEAD = 2;
//        // Status used when robot is inside the xml and it looking for the tag conclusion
//        protected static readonly int INSIDE = 3;
//        // Status used when a '<' is found and try to find the conclusion tag.
//        protected static readonly int PRETAIL = 4;
//        // Status used when the ending tag is equal to the head tag
//        protected static readonly int TAIL = 5;
//        // Status used when robot is inside the main tag and found an '/' to check '/>'.
//        protected static readonly int VERIFY_CLOSE_TAG = 6;
//        //  Status used when you are inside a parameter
//        protected static readonly int INSIDE_PARAM_VALUE = 7;
//        //  Status used when you are inside a cdata section
//        protected static readonly int INSIDE_CDATA = 8;
//        // Status used when you are outside a tag/reading text
//        protected static readonly int OUTSIDE = 9;

//        private readonly String[] sstatus =
//            {
//                "INIT", "", "HEAD", "INSIDE", "PRETAIL", "TAIL", "VERIFY", "INSIDE_PARAM", "INSIDE_CDATA", "OUTSIDE"
//            };


//        // Current robot status
//        protected int status = XMLLightweightParser.INIT;

//        // Index to looking for a CDATA section start or end.
//        protected int cdataOffset = 0;

//        // Number of chars that machs with the head tag. If the tailCount is equal to
//        // the head Length so a close tag is found.
//        protected int tailCount = 0;
//        // Indicate the starting point in the buffer for the next message.
//        protected int startLastMsg = 0;
//        // Flag used to discover tag in the form <tag />.
//        protected bool insideRootTag = false;
//        // Object conteining the head tag
//        protected StringBuilder head = new StringBuilder(5);
//        // List with all finished messages found.
//        protected List<String> msgs = new List<String>();
//        private int depth = 0;

//        protected bool insideChildrenTag = false;

//        //CharsetDecoder encoder;
//        private Encoding encoder;

//        static XMLLightweightParser()
//        {
//            // todo: review
//            // Set default max buffer size to 1MB. If limit is reached then close connection
//            //maxBufferSize = JiveGlobals.getIntProperty(MAX_PROPERTY_NAME, 1048576);
//            //// Listen for changes to this property
//            //PropertyEventDispatcher.addListener(new PropertyListener());
//        }

//        public XMLLightweightParser(String charset)
//        {
//            encoder = Encoding.GetEncoding(charset);
//            encoder.DecoderFallback = new DecoderReplacementFallback();
//            //.onMalformedInput(CodingErrorAction.REPLACE)
//            //.onUnmappableCharacter(CodingErrorAction.REPLACE);
//        }

//        /*
//        * true if the parser has found some complete xml message.
//        */

//        public bool areThereMsgs()
//        {
//            return (msgs.Count > 0);
//        }

//        /*
//        * @return an array with all messages found
//        */

//        public String[] getMsgs()
//        {
//            String[] res = new String[msgs.Count];
//            for (int i = 0; i < res.Length; i++)
//            {
//                res[i] = msgs[i];
//            }
//            msgs.Clear();
//            invalidateBuffer();
//            return res;
//        }

//        /*
//        * Method use to re-initialize the buffer
//        */

//        protected void invalidateBuffer()
//        {
//            if (buffer.Length > 0)
//            {
//                String str = buffer.ToString(startLastMsg);
//                buffer.Remove(0, buffer.Length);
//                buffer.Append(str);
//                buffer.trimToSize();
//            }
//            startLastMsg = 0;
//        }


//        /*
//        * Method that add a message to the list and reinit parser.
//        */

//        protected void foundMsg(String msg)
//        {
//            // Add message to the complete message list
//            if (msg != null)
//            {
//                if (hasIllegalCharacterReferences(msg))
//                {
//                    throw new XmlException("Illegal character reference found in: " + msg);
//                }
//                msgs.Add(msg);
//            }
//            // Move the position into the buffer
//            status = XMLLightweightParser.INIT;
//            tailCount = 0;
//            cdataOffset = 0;
//            head.Clear();
//            insideRootTag = false;
//            insideChildrenTag = false;
//            depth = 0;
//        }

//        /*
//        * Main reading method
//        */

//        public void read(byte[] bytes, int offset, int count)
//        {
//            invalidateBuffer();
//            // Check that the buffer is not bigger than 1 Megabyte. For security reasons
//            // we will abort parsing when 1 Mega of queued chars was found.
//            if (buffer.Length > maxBufferSize)
//            {
//                throw new Exception("Stopped parsing never ending stanza");
//            }
//            //CharBuffer charBuffer = CharBuffer.allocate(byteBuffer.capacity());
//            //encoder.decode(byteBuffer.buf(), charBuffer, false);
//            //char[] buf = new char[charBuffer.position()];
//            var chars = encoder.GetChars(bytes, offset, count);
//            int readChar = chars.Length;

//            // Just return if nothing was read
//            if (readChar == 0)
//            {
//                return;
//            }

//            buffer.Append(chars);

//            // Robot.
//            char ch;
//            bool isHighSurrogate = false;
//            for (int i = 0; i < readChar; i++)
//            {
//                ch = chars[i];
//                if (ch < 0x20 && ch != 0x9 && ch != 0xA && ch != 0xD && ch != 0x0)
//                {
//                    //Unicode characters in the range 0x0000-0x001F other than 9, A, and D are not allowed in XML
//                    //We need to allow the NULL character, however, for Flash XMLSocket clients to work.
//                    throw new XmlException("Character is invalid in: " + ch);
//                }
//                if (isHighSurrogate)
//                {
//                    if (Char.IsLowSurrogate(ch))
//                    {
//                        // Everything is fine. Clean up traces for surrogates
//                        isHighSurrogate = false;
//                    }
//                    else
//                    {
//                        // Trigger error. Found high surrogate not followed by low surrogate
//                        throw new Exception("Found high surrogate not followed by low surrogate");
//                    }
//                }
//                else if (Char.IsHighSurrogate(ch))
//                {
//                    isHighSurrogate = true;
//                }
//                else if (Char.IsLowSurrogate(ch))
//                {
//                    // Trigger error. Found low surrogate char without a preceding high surrogate
//                    throw new Exception("Found low surrogate char without a preceding high surrogate");
//                }
//                if (status == XMLLightweightParser.TAIL)
//                {
//                    // Looking for the close tag
//                    if (depth < 1 && ch == head[tailCount])
//                    {
//                        tailCount++;
//                        if (tailCount == head.Length)
//                        {
//                            // Close stanza found!
//                            // Calculate the correct start,end position of the message into the buffer
//                            int end = buffer.Length - readChar + (i + 1);
//                            String msg = buffer.ToString(startLastMsg, end);
//                            // Add message to the list
//                            foundMsg(msg);
//                            startLastMsg = end;
//                        }
//                    }
//                    else
//                    {
//                        tailCount = 0;
//                        status = XMLLightweightParser.INSIDE;
//                    }
//                }
//                else if (status == XMLLightweightParser.PRETAIL)
//                {
//                    if (ch == XMLLightweightParser.CDATA_START[cdataOffset])
//                    {
//                        cdataOffset++;
//                        if (cdataOffset == XMLLightweightParser.CDATA_START.Length)
//                        {
//                            status = XMLLightweightParser.INSIDE_CDATA;
//                            cdataOffset = 0;
//                            continue;
//                        }
//                    }
//                    else
//                    {
//                        cdataOffset = 0;
//                        status = XMLLightweightParser.INSIDE;
//                    }
//                    if (ch == '/')
//                    {
//                        status = XMLLightweightParser.TAIL;
//                        depth--;
//                    }
//                    else if (ch == '!')
//                    {
//                        // This is a <! (comment) so ignore it
//                        status = XMLLightweightParser.INSIDE;
//                    }
//                    else
//                    {
//                        depth++;
//                    }
//                }
//                else if (status == XMLLightweightParser.VERIFY_CLOSE_TAG)
//                {
//                    if (ch == '>')
//                    {
//                        depth--;
//                        status = XMLLightweightParser.OUTSIDE;
//                        if (depth < 1)
//                        {
//                            // Found a tag in the form <tag />
//                            int end = buffer.Length - readChar + (i + 1);
//                            String msg = buffer.ToString(startLastMsg, end);
//                            // Add message to the list
//                            foundMsg(msg);
//                            startLastMsg = end;
//                        }
//                    }
//                    else if (ch == '<')
//                    {
//                        status = XMLLightweightParser.PRETAIL;
//                        insideChildrenTag = true;
//                    }
//                    else
//                    {
//                        status = XMLLightweightParser.INSIDE;
//                    }
//                }
//                else if (status == XMLLightweightParser.INSIDE_PARAM_VALUE)
//                {

//                    if (ch == '"')
//                    {
//                        status = XMLLightweightParser.INSIDE;
//                    }
//                }
//                else if (status == XMLLightweightParser.INSIDE_CDATA)
//                {
//                    if (ch == XMLLightweightParser.CDATA_END[cdataOffset])
//                    {
//                        cdataOffset++;
//                        if (cdataOffset == XMLLightweightParser.CDATA_END.Length)
//                        {
//                            status = XMLLightweightParser.OUTSIDE;
//                            cdataOffset = 0;
//                        }
//                    }
//                    else
//                    {
//                        cdataOffset = 0;
//                    }
//                }
//                else if (status == XMLLightweightParser.INSIDE)
//                {
//                    if (ch == XMLLightweightParser.CDATA_START[cdataOffset])
//                    {
//                        cdataOffset++;
//                        if (cdataOffset == XMLLightweightParser.CDATA_START.Length)
//                        {
//                            status = XMLLightweightParser.INSIDE_CDATA;
//                            cdataOffset = 0;
//                            continue;
//                        }
//                    }
//                    else
//                    {
//                        cdataOffset = 0;
//                        status = XMLLightweightParser.INSIDE;
//                    }
//                    if (ch == '"')
//                    {
//                        status = XMLLightweightParser.INSIDE_PARAM_VALUE;
//                    }
//                    else if (ch == '>')
//                    {
//                        status = XMLLightweightParser.OUTSIDE;
//                        if (insideRootTag && ("stream:stream>".Equals(head.ToString()) ||
//                            ("?xml>".Equals(head.ToString())) || ("flash:stream>".Equals(head.ToString()))))
//                        {
//                            // Found closing stream:stream
//                            int end = buffer.Length - readChar + (i + 1);
//                            // Skip LF, CR and other "weird" characters that could appear
//                            while (startLastMsg < end && '<' != buffer[startLastMsg])
//                            {
//                                startLastMsg++;
//                            }
//                            String msg = buffer.ToString(startLastMsg, end);
//                            foundMsg(msg);
//                            startLastMsg = end;
//                        }
//                        insideRootTag = false;
//                    }
//                    else if (ch == '/')
//                    {
//                        status = XMLLightweightParser.VERIFY_CLOSE_TAG;
//                    }
//                }
//                else if (status == XMLLightweightParser.HEAD)
//                {
//                    if (ch == ' ' || ch == '>')
//                    {
//                        // Append > to head to allow searching </tag>
//                        head.Append('>');
//                        if (ch == '>')
//                            status = XMLLightweightParser.OUTSIDE;
//                        else
//                            status = XMLLightweightParser.INSIDE;
//                        insideRootTag = true;
//                        insideChildrenTag = false;
//                        continue;
//                    }
//                    else if (ch == '/' && head.Length > 0)
//                    {
//                        status = XMLLightweightParser.VERIFY_CLOSE_TAG;
//                        depth--;
//                    }
//                    head.Append(ch);

//                }
//                else if (status == XMLLightweightParser.INIT)
//                {
//                    if (ch == '<')
//                    {
//                        status = XMLLightweightParser.HEAD;
//                        depth = 1;
//                    }
//                    else
//                    {
//                        startLastMsg++;
//                    }
//                }
//                else if (status == XMLLightweightParser.OUTSIDE)
//                {
//                    if (ch == '<')
//                    {
//                        status = XMLLightweightParser.PRETAIL;
//                        cdataOffset = 1;
//                        insideChildrenTag = true;
//                    }
//                }
//            }
//            if (head.Length > 0 &&
//                ("/stream:stream>".Equals(head.ToString()) || ("/flash:stream>".Equals(head.ToString()))))
//            {
//                // Found closing stream:stream
//                foundMsg("</stream:stream>");
//            }
//        }

//        /**
//         * This method verifies if the provided argument contains at least one numeric character reference (
//         * <code>CharRef	   ::=   	'&#' [0-9]+ ';' | '&#x' [0-9a-fA-F]+ ';</code>) for which the decimal or hexidecimal
//         * character value refers to an invalid XML 1.0 character.
//         * 
//         * @param string
//         *            The input string
//         * @return <tt>true</tt> if the input string contains an invalid numeric character reference, <tt>false</tt>
//         *         otherwise.
//         * @see http://www.w3.org/TR/2008/REC-xml-20081126/#dt-charref
//         */

//        public static bool hasIllegalCharacterReferences(String str)
//        {
//            // If there's no character reference, don't bother to do more specific checking.
//            var matches = XML_HAS_CHARREF.Matches(str);

//            foreach (Match match in matches)
//            {
//                String decValue = match.Groups.Count >= 3 ? match.Groups[2].Value : null;
//                if (decValue != null)
//                {
//                    int value = Int32.Parse(decValue);
//                    if (!isLegalXmlCharacter(value))
//                        return true;
//                    continue;
//                }

//                String hexValue = match.Groups.Count >= 4 ? match.Groups[3].Value : null;
//                if (hexValue != null)
//                {
//                    int value = Int32.Parse(hexValue, NumberStyles.HexNumber);
//                    if (!isLegalXmlCharacter(value))
//                        return true;
//                    continue;
//                }

//                // This is bad. The XML_HAS_CHARREF expression should have a hit for either the decimal
//                // or the heximal notation.
//                throw new XmlException(
//                    "An error occurred while searching for illegal character references in the value [" + str + "].");
//            }

//            return false;
//        }

//        /**
//         * Verifies if the codepoint value represents a valid character as defined in paragraph 2.2 of
//         * "Extensible Markup Language (XML) 1.0 (Fifth Edition)"
//         * 
//         * @param value
//         *            the codepoint
//         * @return <tt>true</tt> if the codepoint is a valid charater per XML 1.0 definition, <tt>false</tt> otherwise.
//         * @see http://www.w3.org/TR/2008/REC-xml-20081126/#NT-Char
//         */

//        public static bool isLegalXmlCharacter(int value)
//        {
//            return value == 0x9 || value == 0xA || value == 0xD || (value >= 0x20 && value <= 0xD7FF)
//                || (value >= 0xE000 && value <= 0xFFFD) || (value >= 0x10000 && value <= 0x10FFFF);
//        }
//    }
//}