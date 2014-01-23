//namespace ConsoleApplication16
//{
//    using System.Runtime.CompilerServices;
//    using System.Runtime.InteropServices;
//    using IKVM.Attributes;
//    using IKVM.Runtime;
//    using com.fasterxml.aalto;
//    using com.fasterxml.aalto.impl;
//    using com.fasterxml.aalto.@in;
//    using com.fasterxml.aalto.util;
//    using java.io;
//    using java.lang;
//    using java.math;
//    using java.util;
//    using javax.xml.@namespace;
//    using javax.xml.stream;
//    using org.codehaus.stax2;
//    using org.codehaus.stax2.ri;
//    using org.codehaus.stax2.ri.typed;
//    using org.codehaus.stax2.typed;
//    using org.codehaus.stax2.validation;
//    using StringBuilder = System.Text.StringBuilder;

//    public class StreamReaderImpl : XMLStreamReader2, TypedXMLStreamReader, XMLStreamReader, XMLStreamConstants, Validatable, AttributeInfo,
//        DTDInfo, LocationInfo
//    {
//        internal const int STATE_PROLOG = 0;
//        internal const int STATE_TREE = 1;
//        internal const int STATE_EPILOG = 2;
//        internal const int STATE_CLOSED = 3;
//        internal XmlScanner _scanner;
//        internal bool _cfgCoalesceText;
//        internal bool _cfgReportTextAsChars;
//        protected internal int _currToken;
//        protected internal int _parseState;
//        protected internal PName _currName;
//        protected internal int _attrCount;
//        protected internal ValueDecoderFactory _decoderFactory1;
//        protected internal CharArrayBase64Decoder _base64Decoder1;
//        protected internal PName _dtdRootName;
//        private const int MASK_GET_TEXT = 6768;
//        private const int MASK_GET_TEXT_XXX = 4208;
//        private const int MASK_GET_TEXT_WITH_WRITER = 6776;
//        private const int MASK_GET_ELEMENT_TEXT = 4688;
//        private const int MASK_TYPED_ACCESS_ARRAY = 4182;
//        private const int MASK_TYPED_ACCESS_BINARY = 4178;

//        public StreamReaderImpl(XmlScanner scanner)
//        {
//            _base64Decoder1 = null;
//            _scanner = scanner;
//            _currToken = 7;
//            ReaderConfig config = scanner.getConfig();
//            _cfgCoalesceText = config.willCoalesceText();
//            _cfgReportTextAsChars = !config.willReportCData();
//        }

//        protected internal virtual void reportInvalidAttrIndex(int index)
//        {
//            string s =
//                new StringBuilder().Append("Illegal attribute index, ")
//                    .Append(index)
//                    .Append(", current START_ELEMENT has ")
//                    .Append(_attrCount)
//                    .Append(" attributes")
//                    .ToString();
            
//            throw new IllegalArgumentException(s);
//        }

//        protected internal virtual void throwWfe(string msg)
//        {
//            string msg1 = msg;
//            Location lastCharLocation = getLastCharLocation();
            
//            throw new WFCException(msg1, lastCharLocation);
//        }

//        public int next()
//        {
//            if (_parseState == 1)
//            {
//                int num = _scanner.nextFromTree();
//                if (num == -1)
//                    handleTreeEoi();
//                _currToken = num;
//                if (num == 12)
//                {
//                    if (_cfgCoalesceText || _cfgReportTextAsChars)
//                        return 4;
//                }
//                else
//                {
//                    _currName = _scanner.getName();
//                    if (num == 2)
//                    {
//                        if (_scanner.hasEmptyStack())
//                            _parseState = 2;
//                    }
//                    else if (num == 1)
//                        _attrCount = _scanner.getAttrCount();
//                }
//                return num;
//            }
//            else
//            {
//                int num1;
//                if (_parseState == 0)
//                {
//                    num1 = _scanner.nextFromProlog(true);
//                    switch (num1)
//                    {
//                        case 1:
//                            _parseState = 1;
//                            _attrCount = _scanner.getAttrCount();
//                            break;
//                        case 11:
//                            if (_dtdRootName != null)
//                                throwWfe("Duplicate DOCTYPE declaration");
//                            _dtdRootName = _scanner.getName();
//                            break;
//                    }
//                }
//                else if (_parseState == 2)
//                    num1 = _scanner.nextFromProlog(false);
//                else
//                {
                    
//                    throw new NoSuchElementException();
//                }
//                if (num1 < 0)
//                    return handlePrologEoi(_parseState == 0);
//                else
//                {
//                    _currName = _scanner.getName();
//                    StreamReaderImpl streamReaderImpl = this;
//                    int num2 = num1;
//                    int num3 = num2;
//                    _currToken = num2;
//                    return num3;
//                }
//            }
//        }

//        public string getText()
//        {
//            if ((1 << _currToken & 6768) == 0)
//                ThrowNotTextual(_currToken);
//            string text;
//            XMLStreamException sex;
//            try
//            {
//                text = _scanner.getText();
//            }
//            catch (XMLStreamException ex)
//            {
//                int num = 1;
//                sex = ByteCodeHelper.MapException<XMLStreamException>(ex, (ByteCodeHelper.MapFlags) num);
//                throw Throwable.__\u003Cunmap\u003E(UncheckedStreamException.createFrom(sex));
//            }
//            return text;
//        }

//        private void ThrowNotTextual([In] int obj0)
//        {
//            string s =
//                new StringBuilder().Append("Not a textual event (").Append(ErrorConsts.tokenTypeDesc(_currToken)).Append(")").ToString();
            
//            throw new IllegalStateException(s);
//        }

//        private void ThrowNotTextXxx([In] int obj0)
//        {
//            string s =
//                new StringBuilder().Append("getTextXxx() methods can not be called on ")
//                    .Append(ErrorConsts.tokenTypeDesc(_currToken))
//                    .ToString();
            
//            throw new IllegalStateException(s);
//        }

//        public int getEventType()
//        {
//            if (_currToken == 12 && (_cfgCoalesceText || _cfgReportTextAsChars))
//                return 4;
//            return _currToken;
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 79, (byte) 156, (byte) 142
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getLocalName()
//        {
//            if (_currToken == 1 || _currToken == 2 || _currToken == 9)
//                return _currName.getLocalName();
//            string s = "Current state not START_ELEMENT, END_ELEMENT or ENTITY_REFERENCE";
            
//            throw new IllegalStateException(s);
//        }

//        public string getNamespaceURI()
//        {
//            if (_currToken == 1 || _currToken == 2)
//                return _scanner.getNamespaceURI() ?? "";
//            string s = ErrorConsts.ERR_STATE_NOT_ELEM;
            
//            throw new IllegalStateException(s);
//        }

//        protected internal virtual void handleTreeEoi()
//        {
//            _currToken = 8;
//            throwUnexpectedEOI(ErrorConsts.SUFFIX_IN_TREE);
//        }

//        protected internal virtual int handlePrologEoi(bool isProlog)
//        {
//            int num = isProlog ? 1 : 0;
//            close();
//            if (num != 0)
//                throwUnexpectedEOI(ErrorConsts.SUFFIX_IN_PROLOG);
//            return 8;
//        }

//        public bool isWhiteSpace()
//        {
//            if (_currToken != 4)
//            {
//                if (_currToken != 12)
//                    return _currToken == 6;
//            }
//            int num1;
//            XMLStreamException sex;
//            try
//            {
//                num1 = _scanner.isTextWhitespace() ? 1 : 0;
//            }
//            catch (XMLStreamException ex)
//            {
//                int num2 = 1;
//                sex = ByteCodeHelper.MapException<XMLStreamException>(ex, (ByteCodeHelper.MapFlags) num2);
//                goto label_5;
//            }
//            return num1 != 0;
//            label_5:
//            throw Throwable.__\u003Cunmap\u003E(UncheckedStreamException.createFrom(sex));
//        }

//        protected internal virtual void _closeScanner(bool forceStreamClose)
//        {
//            int num = forceStreamClose ? 1 : 0;
//            if (_parseState != 3)
//            {
//                _parseState = 3;
//                if (_currToken != 8)
//                    _currToken = 8;
//            }
//            _scanner.close(num != 0);
//        }

//        public XMLStreamLocation2 getStartLocation()
//        {
//            return _scanner.getStartLocation();
//        }

//        protected internal ValueDecoderFactory _decoderFactory()
//        {
//            if (_decoderFactory1 == null)
//                _decoderFactory1 = new ValueDecoderFactory();
//            return _decoderFactory1;
//        }

//        public void getElementAs(TypedValueDecoder tvd)
//        {
//            string str = String.instancehelper_trim(getElementText());
//            if (String.instancehelper_length(str) == 0)
//                HandleEmptyValue(tvd);
//            else
//            {
//                IllegalArgumentException argumentException;
//                try
//                {
//                    tvd.decode(str);
//                    return;
//                }
//                catch (IllegalArgumentException ex)
//                {
//                    int num = 1;
//                    argumentException = ByteCodeHelper.MapException<IllegalArgumentException>(ex, (ByteCodeHelper.MapFlags) num);
//                }
//                throw Throwable.__\u003Cunmap\u003E(ConstructTypeException(argumentException, str));
//            }
//        }

//        public NamespaceContext getNamespaceContext()
//        {
//            return _scanner;
//        }

//        protected internal virtual QName verifyQName(QName n)
//        {
//            string localPart = n.getLocalPart();
//            int illegalNameChar = XmlNames.findIllegalNameChar(localPart, false);
//            if (illegalNameChar < 0)
//                return n;
//            string prefix = n.getPrefix();
//            string str = prefix == null || String.instancehelper_length(prefix) <= 0
//                ? localPart
//                : new StringBuilder().Append(prefix).Append(":").Append(localPart).ToString();
//            throw Throwable.__\u003Cunmap\u003E(
//                ConstructTypeException(
//                    new StringBuilder().Append("Invalid local name \"")
//                        .Append(localPart)
//                        .Append("\" (character at #")
//                        .Append(illegalNameChar)
//                        .Append(" is invalid)")
//                        .ToString(), str));
//        }

//        public byte[] getElementAsBinary(Base64Variant v)
//        {
//            Stax2Util.ByteAggregator byteAggregator = (_base64Decoder()).getByteAggregator();
//            byte[] numArray = byteAggregator.startAggregation();
//            while (true)
//            {
//                int num1 = 0;
//                int length = numArray.Length;
//                do
//                {
//                    int num2 = readElementAsBinary(numArray, num1, length, v);
//                    if (num2 < 1)
//                        return byteAggregator.aggregateAll(numArray, num1);
//                    else
//                    {
//                        num1 += num2;
//                        length -= num2;
//                    }
//                } while (length > 0);
//                numArray = byteAggregator.addFullBlock(numArray);
//            }
//        }

//        public string getElementText()
//        {
//            if (_currToken != 1)
//                throwWfe(ErrorConsts.ERR_STATE_NOT_STELEM);
//            int type1;
//            do
//            {
//                type1 = next();
//                if (type1 == 2)
//                    return "";
//            } while (type1 == 5 || type1 == 3);
//            if ((1 << type1 & 4688) == 0)
//                throwWfe(
//                    new StringBuilder().Append("Expected a text token, got ")
//                        .Append(ErrorConsts.tokenTypeDesc(type1))
//                        .Append(".")
//                        .ToString());
//            string text = _scanner.getText();
//            TextAccumulator textAccumulator = null;
//            int type2;
//            while ((type2 = next()) != 2)
//            {
//                if ((1 << type2 & 4688) != 0)
//                {
//                    if (textAccumulator == null)
//                    {
//                        textAccumulator = new TextAccumulator();
//                        textAccumulator.addText(text);
//                    }
//                    textAccumulator.addText(getText());
//                }
//                else if (type2 != 5 && type2 != 3)
//                    throwWfe(
//                        new StringBuilder().Append("Expected a text token, got ")
//                            .Append(ErrorConsts.tokenTypeDesc(type2))
//                            .Append(".")
//                            .ToString());
//            }
//            return textAccumulator != null ? textAccumulator.getAndClear() : text;
//        }

//        private void HandleEmptyValue([In] TypedValueDecoder obj0)
//        {
//            IllegalArgumentException argumentException;
//            try
//            {
//                obj0.handleEmptyValue();
//                return;
//            }
//            catch (IllegalArgumentException ex)
//            {
//                int num = 1;
//                argumentException = ByteCodeHelper.MapException<IllegalArgumentException>(ex, (ByteCodeHelper.MapFlags) num);
//            }
//            throw Throwable.__\u003Cunmap\u003E(ConstructTypeException(argumentException, ""));
//        }

//        private TypedXMLStreamException ConstructTypeException([In] IllegalArgumentException obj0, [In] string obj1)
//        {
//            return new TypedXMLStreamException(obj1, Throwable.instancehelper_getMessage(obj0), getStartLocation(), obj0);
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 166, (byte) 124, (byte) 104, (byte) 139
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        protected internal virtual CharArrayBase64Decoder _base64Decoder()
//        {
//            if (_base64Decoder1 == null)
//                _base64Decoder1 = new CharArrayBase64Decoder();
//            return _base64Decoder1;
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 163, (byte) 148, (byte) 99, (byte) 144, (byte) 100, (byte) 159, (byte) 33, (byte) 107, (byte) 99, (byte) 130,
//                (byte) 191, (byte) 23, (byte) 103, (byte) 135, (byte) 110, (byte) 132, (byte) 107, (byte) 162, (byte) 144, (byte) 103,
//                (byte) 141, (byte) 103, (byte) 194, (byte) 103, (byte) 100, (byte) 130, (byte) 104, (byte) 130, (byte) 105, (byte) 162,
//                (byte) 141, (byte) 175, (byte) 226, (byte) 71, (byte) 222, (byte) 226, (byte) 61, (byte) 130, (byte) 152, (byte) 101,
//                (byte) 100, (byte) 229, (byte) 69, (byte) 112, (byte) 197, (byte) 103, (byte) 140, (byte) 130, (byte) 228, (byte) 71,
//                (byte) 104, (byte) 101, (byte) 118, (byte) 101, (byte) 229, (byte) 69, (byte) 111, (byte) 130, (byte) 165
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int readElementAsBinary(byte[] resultBuffer, int offset, int maxLength, Base64Variant v)
//        {
//            if (resultBuffer == null)
//            {
//                string s = "resultBuffer is null";
                
//                throw new IllegalArgumentException(s);
//            }
//            else if (offset < 0)
//            {
//                string s =
//                    new StringBuilder().Append("Illegal offset (")
//                        .Append(offset)
//                        .Append("), must be [0, ")
//                        .Append(resultBuffer.Length)
//                        .Append("[")
//                        .ToString();
                
//                throw new IllegalArgumentException(s);
//            }
//            else if (maxLength < 1 || offset + maxLength > resultBuffer.Length)
//            {
//                if (maxLength == 0)
//                    return 0;
//                string s =
//                    new StringBuilder().Append("Illegal maxLength (")
//                        .Append(maxLength)
//                        .Append("), has to be positive number, and offset+maxLength can not exceed")
//                        .Append(resultBuffer.Length)
//                        .ToString();
                
//                throw new IllegalArgumentException(s);
//            }
//            else
//            {
//                CharArrayBase64Decoder dec = _base64Decoder();
//                int num1 = _currToken;
//                if ((1 << num1 & 4178) == 0)
//                {
//                    if (num1 == 2)
//                    {
//                        if (!(dec).hasData())
//                            return -1;
//                    }
//                    else
//                    {
//                        string s = ErrorConsts.ERR_STATE_NOT_STELEM_OR_TEXT;
                        
//                        throw new IllegalStateException(s);
//                    }
//                }
//                else if (num1 == 1)
//                {
//                    if (_scanner.isEmptyTag())
//                    {
//                        next();
//                        return -1;
//                    }
//                    else
//                    {
//                        int nextToken;
//                        do
//                        {
//                            nextToken = next();
//                            if (nextToken == 2)
//                                return -1;
//                        } while (nextToken == 5 || nextToken == 3);
//                        if (nextToken != 4 && nextToken != 12)
//                            throw Throwable.__\u003Cunmap\u003E(_constructUnexpectedInTyped(nextToken));
//                        _scanner.resetForDecoding(v, dec, true);
//                    }
//                }
//                int num2 = 0;
//                while (true)
//                {
//                    int num3;
//                    do
//                    {
//                        int num4;
//                        IllegalArgumentException argumentException;
//                        try
//                        {
//                            num4 = dec.decode(resultBuffer, offset, maxLength);
//                            goto label_26;
//                        }
//                        catch (IllegalArgumentException ex)
//                        {
//                            int num5 = 1;
//                            argumentException = ByteCodeHelper.MapException<IllegalArgumentException>(ex, (ByteCodeHelper.MapFlags) num5);
//                        }
//                        throw Throwable.__\u003Cunmap\u003E(ConstructTypeException(Throwable.instancehelper_getMessage(argumentException),
//                            ""));
//                        label_26:
//                        offset += num4;
//                        num2 += num4;
//                        maxLength -= num4;
//                        if (maxLength >= 1 && _currToken != 2)
//                        {
//                            int num5;
//                            do
//                            {
//                                num5 = next();
//                            } while (num5 == 5 || num5 == 3 || num5 == 6);
//                            if (num5 == 2)
//                            {
//                                num3 = dec.endOfContent();
//                                if (num3 < 0)
//                                    throw Throwable.__\u003Cunmap\u003E(
//                                        ConstructTypeException("Incomplete base64 triplet at the end of decoded content", ""));
//                            }
//                            else
//                                goto label_32;
//                        }
//                        else
//                            break;
//                    } while (num3 > 0);
//                    break;
//                    label_32:
//                    _scanner.resetForDecoding(v, dec, false);
//                }
//                if (num2 > 0)
//                    return num2;
//                else
//                    return -1;
//            }
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 163, (byte) 72, (byte) 135, (byte) 110, (byte) 240, (byte) 71, (byte) 132, (byte) 141, (byte) 103, (byte) 194,
//                (byte) 103, (byte) 100, (byte) 130, (byte) 104, (byte) 130, (byte) 105, (byte) 162, (byte) 141, (byte) 132, (byte) 162,
//                (byte) 98, (byte) 199, (byte) 109, (byte) 112, (byte) 104, (byte) 130, (byte) 170, (byte) 141, (byte) 98, (byte) 204
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int readElementAsArray(TypedArrayDecoder dec)
//        {
//            int nextToken = _currToken;
//            if ((1 << nextToken & 4182) == 0)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM_OR_TEXT;
                
//                throw new IllegalStateException(s);
//            }
//            else
//            {
//                int num1;
//                if (nextToken == 1)
//                {
//                    if (_scanner.isEmptyTag())
//                    {
//                        next();
//                        return -1;
//                    }
//                    else
//                    {
//                        do
//                        {
//                            nextToken = next();
//                            if (nextToken == 2)
//                                return -1;
//                        } while (nextToken == 5 || nextToken == 3);
//                        if (nextToken != 4 && nextToken != 12)
//                            throw Throwable.__\u003Cunmap\u003E(_constructUnexpectedInTyped(nextToken));
//                        num1 = 1;
//                    }
//                }
//                else
//                    num1 = 0;
//                int num2 = 0;
//                for (; nextToken != 2; nextToken = next())
//                {
//                    if (nextToken == 4 || nextToken == 12 || nextToken == 6)
//                    {
//                        num2 += _scanner.decodeElements(dec, num1 != 0);
//                        if (!dec.hasRoom())
//                            break;
//                    }
//                    else if (nextToken != 5 && nextToken != 3)
//                        throw Throwable.__\u003Cunmap\u003E(_constructUnexpectedInTyped(nextToken));
//                    num1 = 1;
//                }
//                if (num2 > 0)
//                    return num2;
//                else
//                    return -1;
//            }
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 166, (byte) 52, (byte) 100, (byte) 143
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        protected internal virtual XMLStreamException _constructUnexpectedInTyped(int nextToken)
//        {
//            if (nextToken == 1)
//                return ConstructTypeException("Element content can not contain child START_ELEMENT when using Typed Access methods", null);
//            else
//            {
//                return
//                    ConstructTypeException(
//                        new StringBuilder().Append("Expected a text token, got ").Append(ErrorConsts.tokenTypeDesc(nextToken)).ToString(),
//                        null);
//            }
//        }

//        [LineNumberTable((ushort) 1723)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        private TypedXMLStreamException ConstructTypeException([In] string obj0, [In] string obj1)
//        {
//            return new TypedXMLStreamException(obj1, obj0, getStartLocation());
//        }

//        [LineNumberTable((ushort) 1584)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int findAttributeIndex(string nsURI, string localName)
//        {
//            return _scanner.findAttrIndex(nsURI, localName);
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 69, (byte) 105, (byte) 176, (byte) 191, (byte) 0, (byte) 2, (byte) 97, (byte) 148
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public void getAttributeAs(int index, TypedValueDecoder tvd)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//            {
//                IllegalArgumentException argumentException;
//                try
//                {
//                    _scanner.decodeAttrValue(index, tvd);
//                    return;
//                }
//                catch (IllegalArgumentException ex)
//                {
//                    int num = 1;
//                    argumentException = ByteCodeHelper.MapException<IllegalArgumentException>(ex, (ByteCodeHelper.MapFlags) num);
//                }
//                throw Throwable.__\u003Cunmap\u003E(ConstructTypeException(argumentException, getAttributeValue(index)));
//            }
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 160, (byte) 246, (byte) 105, (byte) 144, (byte) 109, (byte) 135
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getAttributeValue(int index)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//            {
//                if (index >= _attrCount || index < 0)
//                    reportInvalidAttrIndex(index);
//                return _scanner.getAttrValue(index);
//            }
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 115, (byte) 105, (byte) 144
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int getAttributeAsArray(int index, TypedArrayDecoder tad)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//                return _scanner.decodeAttrValues(index, tad);
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 128, (byte) 105, (byte) 144
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public byte[] getAttributeAsBinary(int index, Base64Variant v)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//                return _scanner.decodeAttrBinaryValue(index, v, _base64Decoder());
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 164, (byte) 105, (byte) 144
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getPITarget()
//        {
//            if (_currToken != 3)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_PI;
                
//                throw new IllegalStateException(s);
//            }
//            else
//                return _currName.getLocalName();
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 165, (byte) 94, (byte) 106, (byte) 130
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getDTDRootName()
//        {
//            if (_currToken != 11)
//                return null;
//            return _currName != null ? _currName.getPrefixedName() : null;
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 187, (byte) 105
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public void close()
//        {
//            _closeScanner(false);
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 166, (byte) 47, (byte) 127, (byte) 3
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        protected internal virtual void throwUnexpectedEOI(string msg)
//        {
//            throwWfe(new StringBuilder().Append("Unexpected End-of-input").Append(msg).ToString());
//        }

//        [LineNumberTable((ushort) 1641)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        protected internal virtual Location getLastCharLocation()
//        {
//            return _scanner.getCurrentLocation();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable((ushort) 165)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public static StreamReaderImpl construct(InputBootstrapper bs)
//        {
//            return new StreamReaderImpl(bs.bootstrap());
//        }

//        public virtual XmlScanner getScanner()
//        {
//            return _scanner;
//        }

//        [LineNumberTable((ushort) 237)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getCharacterEncodingScheme()
//        {
//            return _scanner.getConfig().getXmlDeclEncoding();
//        }

//        [LineNumberTable((ushort) 247)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getEncoding()
//        {
//            return _scanner.getConfig().getActualEncoding();
//        }

//        [LineNumberTable((ushort) 252)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public virtual string getVersion()
//        {
//            return _scanner.getConfig().getXmlDeclVersion();
//        }

//        [LineNumberTable((ushort) 257)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public bool isStandalone()
//        {
//            return _scanner.getConfig().getXmlDeclStandalone() == 1;
//        }

//        [LineNumberTable((ushort) 262)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public bool standaloneSet()
//        {
//            return _scanner.getConfig().getXmlDeclStandalone() != 0;
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 160, (byte) 159, (byte) 141, (byte) 134, (byte) 141, (byte) 166
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public virtual object getProperty(string name)
//        {
//            if (String.instancehelper_equals(name, "javax.xml.stream.entities"))
//                return Collections.EMPTY_LIST;
//            if (String.instancehelper_equals(name, "javax.xml.stream.notations"))
//                return Collections.EMPTY_LIST;
//            return _scanner.getConfig().getProperty(name, false);
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 160, (byte) 181, (byte) 105, (byte) 144
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int getAttributeCount()
//        {
//            if (_currToken == 1)
//                return _attrCount;
//            string s = ErrorConsts.ERR_STATE_NOT_STELEM;
            
//            throw new IllegalStateException(s);
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 160, (byte) 189, (byte) 105, (byte) 144, (byte) 109, (byte) 135
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getAttributeLocalName(int index)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//            {
//                if (index >= _attrCount || index < 0)
//                    reportInvalidAttrIndex(index);
//                return _scanner.getAttrLocalName(index);
//            }
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 160, (byte) 200, (byte) 105, (byte) 144, (byte) 109, (byte) 135
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public QName getAttributeName(int index)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//            {
//                if (index >= _attrCount || index < 0)
//                    reportInvalidAttrIndex(index);
//                return _scanner.getAttrQName(index);
//            }
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 160, (byte) 211, (byte) 105, (byte) 144, (byte) 109, (byte) 135, (byte) 109
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getAttributeNamespace(int index)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//            {
//                if (index >= _attrCount || index < 0)
//                    reportInvalidAttrIndex(index);
//                return _scanner.getAttrNsURI(index) ?? "";
//            }
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 160, (byte) 223, (byte) 105, (byte) 144, (byte) 109, (byte) 135, (byte) 109
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getAttributePrefix(int index)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//            {
//                if (index >= _attrCount || index < 0)
//                    reportInvalidAttrIndex(index);
//                return _scanner.getAttrPrefix(index) ?? "";
//            }
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 160, (byte) 235, (byte) 105, (byte) 144, (byte) 109, (byte) 135
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getAttributeType(int index)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//            {
//                if (index >= _attrCount || index < 0)
//                    reportInvalidAttrIndex(index);
//                return _scanner.getAttrType(index);
//            }
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 1, (byte) 105, (byte) 144
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getAttributeValue(string nsURI, string localName)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//                return _scanner.getAttrValue(nsURI, localName);
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 90, (byte) 114, (byte) 144
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public QName getName()
//        {
//            if (_currToken != 1 && _currToken != 2)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_ELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//                return _scanner.getQName();
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 110, (byte) 114, (byte) 144
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int getNamespaceCount()
//        {
//            if (_currToken != 1 && _currToken != 2)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_ELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//                return _scanner.getNsCount();
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 117, (byte) 114, (byte) 144, (byte) 109
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getNamespacePrefix(int index)
//        {
//            if (_currToken == 1 || _currToken == 2)
//                return _scanner.getNamespacePrefix(index) ?? "";
//            string s = ErrorConsts.ERR_STATE_NOT_ELEM;
            
//            throw new IllegalStateException(s);
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 133, (byte) 114, (byte) 144, (byte) 109
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getNamespaceURI(int index)
//        {
//            if (_currToken == 1 || _currToken == 2)
//                return _scanner.getNamespaceURI(index) ?? "";
//            string s = ErrorConsts.ERR_STATE_NOT_ELEM;
            
//            throw new IllegalStateException(s);
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 142, (byte) 114, (byte) 240, (byte) 69
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getNamespaceURI(string prefix)
//        {
//            if (_currToken != 1 && _currToken != 2)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_ELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//                return _scanner.getNamespaceURI(prefix);
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 153, (byte) 105, (byte) 176, (byte) 127, (byte) 2, (byte) 97
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getPIData()
//        {
//            if (_currToken != 3)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_PI;
                
//                throw new IllegalStateException(s);
//            }
//            else
//            {
//                string text;
//                XMLStreamException sex;
//                try
//                {
//                    text = _scanner.getText();
//                }
//                catch (XMLStreamException ex)
//                {
//                    int num = 1;
//                    sex = ByteCodeHelper.MapException<XMLStreamException>(ex, (ByteCodeHelper.MapFlags) num);
//                    goto label_5;
//                }
//                return text;
//                label_5:
//                throw Throwable.__\u003Cunmap\u003E(UncheckedStreamException.createFrom(sex));
//            }
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 171, (byte) 114, (byte) 176, (byte) 108
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public string getPrefix()
//        {
//            if (_currToken == 1 || _currToken == 2)
//                return _currName.getPrefix() ?? "";
//            string s = ErrorConsts.ERR_STATE_NOT_ELEM;
            
//            throw new IllegalStateException(s);
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 193, (byte) 115, (byte) 172, (byte) 127, (byte) 2, (byte) 97
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public char[] getTextCharacters()
//        {
//            if ((1 << _currToken & 4208) == 0)
//                ThrowNotTextXxx(_currToken);
//            char[] textCharacters;
//            XMLStreamException sex;
//            try
//            {
//                textCharacters = _scanner.getTextCharacters();
//            }
//            catch (XMLStreamException ex)
//            {
//                int num = 1;
//                sex = ByteCodeHelper.MapException<XMLStreamException>(ex, (ByteCodeHelper.MapFlags) num);
//                goto label_5;
//            }
//            return textCharacters;
//            label_5:
//            throw Throwable.__\u003Cunmap\u003E(UncheckedStreamException.createFrom(sex));
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 205, (byte) 115, (byte) 172, (byte) 127, (byte) 7, (byte) 97
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int getTextCharacters(int srcStart, char[] target, int targetStart, int len)
//        {
//            if ((1 << _currToken & 4208) == 0)
//                ThrowNotTextXxx(_currToken);
//            int textCharacters;
//            XMLStreamException sex;
//            try
//            {
//                textCharacters = _scanner.getTextCharacters(srcStart, target, targetStart, len);
//            }
//            catch (XMLStreamException ex)
//            {
//                int num = 1;
//                sex = ByteCodeHelper.MapException<XMLStreamException>(ex, (ByteCodeHelper.MapFlags) num);
//                goto label_5;
//            }
//            return textCharacters;
//            label_5:
//            throw Throwable.__\u003Cunmap\u003E(UncheckedStreamException.createFrom(sex));
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 217, (byte) 115, (byte) 172, (byte) 127, (byte) 2, (byte) 97
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int getTextLength()
//        {
//            if ((1 << _currToken & 4208) == 0)
//                ThrowNotTextXxx(_currToken);
//            int textLength;
//            XMLStreamException sex;
//            try
//            {
//                textLength = _scanner.getTextLength();
//            }
//            catch (XMLStreamException ex)
//            {
//                int num = 1;
//                sex = ByteCodeHelper.MapException<XMLStreamException>(ex, (ByteCodeHelper.MapFlags) num);
//                goto label_5;
//            }
//            return textLength;
//            label_5:
//            throw Throwable.__\u003Cunmap\u003E(UncheckedStreamException.createFrom(sex));
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 229, (byte) 115, (byte) 236, (byte) 69
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int getTextStart()
//        {
//            if ((1 << _currToken & 4208) == 0)
//                ThrowNotTextXxx(_currToken);
//            return 0;
//        }

//        public bool hasName()
//        {
//            return _currToken == 1 || _currToken == 2;
//        }

//        public bool hasNext()
//        {
//            return _currToken != 8;
//        }

//        public bool hasText()
//        {
//            return (1 << _currToken & 6768) != 0;
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 161, (byte) 253, (byte) 105, (byte) 144
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public bool isAttributeSpecified(int index)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//                return (_scanner.isAttrSpecified(index) ? 1 : 0) != 0;
//        }

//        [LineNumberTable((ushort) 631)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public bool isCharacters()
//        {
//            return getEventType() == 4;
//        }

//        public bool isEndElement()
//        {
//            return _currToken == 2;
//        }

//        public bool isStartElement()
//        {
//            return _currToken == 1;
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 31, (byte) 231, (byte) 70, (byte) 100, (byte) 101, (byte) 112, (byte) 132, (byte) 228, (byte) 71,
//                (byte) 100, (byte) 255, (byte) 27, (byte) 69, (byte) 102, (byte) 141, (byte) 159, (byte) 21, (byte) 103, (byte) 109,
//                (byte) 191, (byte) 27, (byte) 102, (byte) 104, (byte) 159, (byte) 16, (byte) 135, (byte) 104, (byte) 114, (byte) 191,
//                (byte) 13, (byte) 109, (byte) 255, (byte) 29, (byte) 70
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public void require(int type, string nsUri, string localName)
//        {
//            int type1 = _currToken;
//            if (type1 != type)
//            {
//                if (type1 == 12)
//                {
//                    if (_cfgCoalesceText || _cfgReportTextAsChars)
//                        type1 = 4;
//                }
//                else if (type1 != 6)
//                    ;
//            }
//            if (type != type1)
//            {
//                throwWfe(
//                    new StringBuilder().Append("Expected type ")
//                        .Append(ErrorConsts.tokenTypeDesc(type))
//                        .Append(", current type ")
//                        .Append(ErrorConsts.tokenTypeDesc(type1))
//                        .ToString());
//            }
//            if (localName != null)
//            {
//                if (type1 != 1 && type1 != 2 && type1 != 9)
//                {
//                    throwWfe(
//                        new StringBuilder().Append(
//                            "Expected non-null local name, but current token not a START_ELEMENT, END_ELEMENT or ENTITY_REFERENCE (was ")
//                            .Append(ErrorConsts.tokenTypeDesc(_currToken))
//                            .Append(")")
//                            .ToString());
//                }
//                string localName1 = getLocalName();
//                if (localName1 != localName && !String.instancehelper_equals(localName1, localName))
//                {
//                    throwWfe(
//                        new StringBuilder().Append("Expected local name '")
//                            .Append(localName)
//                            .Append("'; current local name '")
//                            .Append(localName1)
//                            .Append("'.")
//                            .ToString());
//                }
//            }
//            if (nsUri == null)
//                return;
//            if (type1 != 1 && type1 != 2)
//            {
//                throwWfe(
//                    new StringBuilder().Append("Expected non-null NS URI, but current token not a START_ELEMENT or END_ELEMENT (was ")
//                        .Append(ErrorConsts.tokenTypeDesc(type1))
//                        .Append(")")
//                        .ToString());
//            }
//            string namespaceUri = getNamespaceURI();
//            if (String.instancehelper_length(nsUri) == 0)
//            {
//                if (namespaceUri == null || String.instancehelper_length(namespaceUri) <= 0)
//                    return;
//                throwWfe(new StringBuilder().Append("Expected empty namespace, instead have '").Append(namespaceUri).Append("'.").ToString());
//            }
//            else
//            {
//                if (nsUri == namespaceUri || String.instancehelper_equals(nsUri, namespaceUri))
//                    return;
//                throwWfe(
//                    new StringBuilder().Append("Expected namespace '")
//                        .Append(nsUri)
//                        .Append("'; have '")
//                        .Append(namespaceUri)
//                        .Append("'.")
//                        .ToString());
//            }
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 154, (byte) 135, (byte) 223, (byte) 27, (byte) 162, (byte) 104, (byte) 130, (byte) 107, (byte) 162,
//                (byte) 130, (byte) 159, (byte) 16
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int nextTag()
//        {
//            int type;
//            while (true)
//            {
//                do
//                {
//                    type = next();
//                    switch (type - 1)
//                    {
//                        case 0:
//                        case 1:
//                            goto label_3;
//                        case 2:
//                        case 4:
//                        case 5:
//                            continue;
//                        case 3:
//                        case 11:
//                            continue;
//                        default:
//                            goto label_4;
//                    }
//                } while (isWhiteSpace());
//                throwWfe("Received non-all-whitespace CHARACTERS or CDATA event in nextTag().");
//                label_4:
//                throwWfe(
//                    new StringBuilder().Append("Received event ")
//                        .Append(ErrorConsts.tokenTypeDesc(type))
//                        .Append(", instead of START_ELEMENT or END_ELEMENT.")
//                        .ToString());
//            }
//            label_3:
//            return type;
//        }

//        [LineNumberTable((ushort) 818)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public Location getLocation()
//        {
//            return getStartLocation();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 203, (byte) 108, (byte) 103
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public bool getElementAsBoolean()
//        {
//            ValueDecoderFactory.BooleanDecoder booleanDecoder = _decoderFactory().getBooleanDecoder();
//            getElementAs(booleanDecoder);
//            return (booleanDecoder.getValue() ? 1 : 0) != 0;
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 210, (byte) 108, (byte) 103
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int getElementAsInt()
//        {
//            ValueDecoderFactory.IntDecoder intDecoder = _decoderFactory().getIntDecoder();
//            getElementAs(intDecoder);
//            return intDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 217, (byte) 108, (byte) 103
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public long getElementAsLong()
//        {
//            ValueDecoderFactory.LongDecoder longDecoder = _decoderFactory().getLongDecoder();
//            getElementAs(longDecoder);
//            return longDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 224, (byte) 108, (byte) 103
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public float getElementAsFloat()
//        {
//            ValueDecoderFactory.FloatDecoder floatDecoder = _decoderFactory().getFloatDecoder();
//            getElementAs(floatDecoder);
//            return floatDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 231, (byte) 108, (byte) 103
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public double getElementAsDouble()
//        {
//            ValueDecoderFactory.DoubleDecoder doubleDecoder = _decoderFactory().getDoubleDecoder();
//            getElementAs(doubleDecoder);
//            return doubleDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 238, (byte) 108, (byte) 103
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public BigInteger getElementAsInteger()
//        {
//            ValueDecoderFactory.IntegerDecoder integerDecoder = _decoderFactory().getIntegerDecoder();
//            getElementAs(integerDecoder);
//            return integerDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 245, (byte) 108, (byte) 103
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public BigDecimal getElementAsDecimal()
//        {
//            ValueDecoderFactory.DecimalDecoder decimalDecoder = _decoderFactory().getDecimalDecoder();
//            getElementAs(decimalDecoder);
//            return decimalDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 162, (byte) 252, (byte) 114, (byte) 103
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public QName getElementAsQName()
//        {
//            ValueDecoderFactory.QNameDecoder qnameDecoder = _decoderFactory().getQNameDecoder(getNamespaceContext());
//            getElementAs(qnameDecoder);
//            return verifyQName(qnameDecoder.getValue());
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable((ushort) 885)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public byte[] getElementAsBinary()
//        {
//            return getElementAsBinary(Base64Variants.getDefaultVariant());
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable((ushort) 933)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int readElementAsIntArray(int[] value, int from, int length)
//        {
//            return readElementAsArray(_decoderFactory().getIntArrayDecoder(value, @from, length));
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable((ushort) 938)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int readElementAsLongArray(long[] value, int from, int length)
//        {
//            return readElementAsArray(_decoderFactory().getLongArrayDecoder(value, @from, length));
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable((ushort) 943)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int readElementAsFloatArray(float[] value, int from, int length)
//        {
//            return readElementAsArray(_decoderFactory().getFloatArrayDecoder(value, @from, length));
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable((ushort) 948)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int readElementAsDoubleArray(double[] value, int from, int length)
//        {
//            return readElementAsArray(_decoderFactory().getDoubleArrayDecoder(value, @from, length));
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable((ushort) 1024)]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int readElementAsBinary(byte[] resultBuffer, int offset, int maxLength)
//        {
//            return readElementAsBinary(resultBuffer, offset, maxLength, Base64Variants.getDefaultVariant());
//        }

//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 3, (byte) 105, (byte) 176
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int getAttributeIndex(string namespaceURI, string localName)
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//                return findAttributeIndex(namespaceURI, localName);
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 12, (byte) 108, (byte) 104
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public bool getAttributeAsBoolean(int index)
//        {
//            ValueDecoderFactory.BooleanDecoder booleanDecoder = _decoderFactory().getBooleanDecoder();
//            getAttributeAs(index, booleanDecoder);
//            return (booleanDecoder.getValue() ? 1 : 0) != 0;
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 19, (byte) 108, (byte) 104
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int getAttributeAsInt(int index)
//        {
//            ValueDecoderFactory.IntDecoder intDecoder = _decoderFactory().getIntDecoder();
//            getAttributeAs(index, intDecoder);
//            return intDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 26, (byte) 108, (byte) 104
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public long getAttributeAsLong(int index)
//        {
//            ValueDecoderFactory.LongDecoder longDecoder = _decoderFactory().getLongDecoder();
//            getAttributeAs(index, longDecoder);
//            return longDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 33, (byte) 108, (byte) 104
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public float getAttributeAsFloat(int index)
//        {
//            ValueDecoderFactory.FloatDecoder floatDecoder = _decoderFactory().getFloatDecoder();
//            getAttributeAs(index, floatDecoder);
//            return floatDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 40, (byte) 108, (byte) 104
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public double getAttributeAsDouble(int index)
//        {
//            ValueDecoderFactory.DoubleDecoder doubleDecoder = _decoderFactory().getDoubleDecoder();
//            getAttributeAs(index, doubleDecoder);
//            return doubleDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 47, (byte) 108, (byte) 104
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public BigInteger getAttributeAsInteger(int index)
//        {
//            ValueDecoderFactory.IntegerDecoder integerDecoder = _decoderFactory().getIntegerDecoder();
//            getAttributeAs(index, integerDecoder);
//            return integerDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 54, (byte) 108, (byte) 104
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public BigDecimal getAttributeAsDecimal(int index)
//        {
//            ValueDecoderFactory.DecimalDecoder decimalDecoder = _decoderFactory().getDecimalDecoder();
//            getAttributeAs(index, decimalDecoder);
//            return decimalDecoder.getValue();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 61, (byte) 114, (byte) 104
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public QName getAttributeAsQName(int index)
//        {
//            ValueDecoderFactory.QNameDecoder qnameDecoder = _decoderFactory().getQNameDecoder(getNamespaceContext());
//            getAttributeAs(index, qnameDecoder);
//            return verifyQName(qnameDecoder.getValue());
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 81, (byte) 108, (byte) 105
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public int[] getAttributeAsIntArray(int index)
//        {
//            ValueDecoderFactory.IntArrayDecoder intArrayDecoder = _decoderFactory().getIntArrayDecoder();
//            getAttributeAsArray(index, intArrayDecoder);
//            return intArrayDecoder.getValues();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 88, (byte) 108, (byte) 105
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public long[] getAttributeAsLongArray(int index)
//        {
//            ValueDecoderFactory.LongArrayDecoder longArrayDecoder = _decoderFactory().getLongArrayDecoder();
//            getAttributeAsArray(index, longArrayDecoder);
//            return longArrayDecoder.getValues();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 95, (byte) 108, (byte) 105
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public float[] getAttributeAsFloatArray(int index)
//        {
//            ValueDecoderFactory.FloatArrayDecoder floatArrayDecoder = _decoderFactory().getFloatArrayDecoder();
//            getAttributeAsArray(index, floatArrayDecoder);
//            return floatArrayDecoder.getValues();
//        }

//        [Throws(new[]
//            {
//                "javax.xml.stream.XMLStreamException"
//            })]
//        [LineNumberTable(new[]
//            {
//                (byte) 164, (byte) 102, (byte) 108, (byte) 105
//            })]
//        [MethodImpl(MethodImplOptions.NoInlining)]
//        public double[] getAttributeAsDoubleArray(int index)
//        {
//            ValueDecoderFactory.DoubleArrayDecoder doubleArrayDecoder = _decoderFactory().getDoubleArrayDecoder();
//            getAttributeAsArray(index, doubleArrayDecoder);
//            return doubleArrayDecoder.getValues();
//        }

//        public byte[] getAttributeAsBinary(int index)
//        {
//            return getAttributeAsBinary(index, Base64Variants.getDefaultVariant());
//        }

//        public object getFeature(string name)
//        {
//            return null;
//        }

//        public void setFeature(string name, object value)
//        {
//        }

//        public bool isPropertySupported(string name)
//        {
//            return (_scanner.getConfig().isPropertySupported(name) ? 1 : 0) != 0;
//        }

//        public bool setProperty(string name, object value)
//        {
//            return (_scanner.getConfig().setProperty(name, value) ? 1 : 0) != 0;
//        }

//        public void skipElement()
//        {
//            if (_currToken != 1)
//            {
//                string s = ErrorConsts.ERR_STATE_NOT_STELEM;
                
//                throw new IllegalStateException(s);
//            }
//            else
//            {
//                int num1 = 1;
//                do
//                {
//                    int num2;
//                    do
//                    {
//                        num2 = next();
//                        if (num2 == 1)
//                            ++num1;
//                    } while (num2 != 2);
//                    num1 += -1;
//                } while (num1 != 0);
//            }
//        }

//        public AttributeInfo getAttributeInfo()
//        {
//            if (_currToken == 1)
//                return this;
//            string s = ErrorConsts.ERR_STATE_NOT_STELEM;
            
//            throw new IllegalStateException(s);
//        }

//        public DTDInfo getDTDInfo()
//        {
//            if (_currToken != 11)
//                return null;
//            else
//                return this;
//        }

//        public LocationInfo getLocationInfo()
//        {
//            return this;
//        }

//        public int getText(Writer w, bool preserveContents)
//        {
//            int num = preserveContents ? 1 : 0;
//            if ((1 << _currToken & 6776) == 0)
//                ThrowNotTextual(_currToken);
//            return _scanner.getText(w, num != 0);
//        }

//        public int getDepth()
//        {
//            int depth = _scanner.getDepth();
//            if (_currToken == 2)
//                ++depth;
//            return depth;
//        }

//        public bool isEmptyElement()
//        {
//            if (_currToken == 1)
//                return _scanner.isEmptyTag();
//            return false;
//        }

//        public NamespaceContext getNonTransientNamespaceContext()
//        {
//            return _scanner.getNonTransientNamespaceContext();
//        }

//        public string getPrefixedName()
//        {
//            switch (_currToken)
//            {
//                case 1:
//                case 2:
//                    return _currName.getPrefixedName();
//                case 3:
//                    return getPITarget();
//                case 9:
//                    return getLocalName();
//                case 11:
//                    return getDTDRootName();
//                default:
//                    string s = "Current state not START_ELEMENT, END_ELEMENT, ENTITY_REFERENCE, PROCESSING_INSTRUCTION or DTD";
                    
//                    throw new IllegalStateException(s);
//            }
//        }

//        public void closeCompletely()
//        {
//            _closeScanner(true);
//        }

//        public object getProcessedDTD()
//        {
//            return null;
//        }

//        public string getDTDPublicId()
//        {
//            return _scanner.getDTDPublicId();
//        }

//        public string getDTDSystemId()
//        {
//            return _scanner.getDTDSystemId();
//        }

//        public string getDTDInternalSubset()
//        {
//            if (_currToken != 11)
//                return null;
//            string text;
//            XMLStreamException sex;
//            try
//            {
//                text = _scanner.getText();
//            }
//            catch (XMLStreamException ex)
//            {
//                int num = 1;
//                sex = ByteCodeHelper.MapException<XMLStreamException>(ex, (ByteCodeHelper.MapFlags) num);
//                throw Throwable.__\u003Cunmap\u003E(UncheckedStreamException.createFrom(sex));
//            }
//            return text;
//        }

//        public DTDValidationSchema getProcessedDTDSchema()
//        {
//            return null;
//        }

//        public long getStartingByteOffset()
//        {
//            return -1L;
//        }

//        public long getStartingCharOffset()
//        {
//            return -1L;
//        }

//        public long getEndingByteOffset()
//        {
//            return -1L;
//        }

//        public long getEndingCharOffset()
//        {
//            return -1L;
//        }

//        public XMLStreamLocation2 getEndLocation()
//        {
//            return _scanner.getEndLocation();
//        }

//        public XMLStreamLocation2 getCurrentLocation()
//        {
//            return _scanner.getStartLocation();
//        }

//        public int getIdAttributeIndex()
//        {
//            return -1;
//        }

//        public int getNotationAttributeIndex()
//        {
//            return -1;
//        }

//        public XMLValidator validateAgainst(XMLValidationSchema schema)
//        {
//            return null;
//        }

//        public XMLValidator stopValidatingAgainst(XMLValidationSchema schema)
//        {
//            return null;
//        }

//        public XMLValidator stopValidatingAgainst(XMLValidator validator)
//        {
//            return null;
//        }

//        public ValidationProblemHandler setValidationProblemHandler(ValidationProblemHandler h)
//        {
//            return null;
//        }

//        protected internal virtual void throwFromIOE(IOException ioe)
//        {
//            IOException ie = ioe;
            
//            throw new IoStreamException(ie);
//        }

//        public override string ToString()
//        {
//            return new StringBuilder().Append("[Aalto stream reader, scanner: ").Append(_scanner).Append("]").ToString();
//        }
//    }
//}