//
// In order to convert some functionality to Visual C#, the Java Language Conversion Assistant
// creates "support classes" that duplicate the original functionality.  
//
// Support classes replicate the functionality of the original code, but in some cases they are 
// substantially different architecturally. Although every effort is made to preserve the 
// original architecture of the application in the converted project, the user should be aware that 
// the primary goal of these support classes is to replicate functionality, and that at times 
// the architecture of the resulting solution may differ somewhat.
//

using System;

namespace CSEsMS
{
    /// <summary>
    /// Basic interface for resolving entities.
    /// </summary>
    public interface XmlSaxEntityResolver
    {
        /// <summary>
        /// Allow the application to resolve external entities.
        /// </summary>
        /// <param name="publicId">The public identifier of the external entity being referenced, or null if none was supplied.</param>
        /// <param name="systemId">The system identifier of the external entity being referenced.</param>
        /// <returns>A XmlSourceSupport object describing the new input source, or null to request that the parser open a regular URI connection to the system identifier.</returns>
        XmlSourceSupport resolveEntity(string publicId, string systemId);
    }

    /// <summary>
    /// This interface will manage the Content events of a XML document.
    /// </summary>
    public interface XmlSaxContentHandler
    {
        /// <summary>
        /// This method manage the notification when Characters elements were found.
        /// </summary>
        /// <param name="ch">The array with the characters found.</param>
        /// <param name="start">The index of the first position of the characters found.</param>
        /// <param name="length">Specify how many characters must be read from the array.</param>
        void characters(char[] ch, int start, int length);

        /// <summary>
        /// This method manage the notification when the end document node were found.
        /// </summary>
        void endDocument();

        /// <summary>
        /// This method manage the notification when the end element node was found.
        /// </summary>
        /// <param name="namespaceURI">The namespace URI of the element.</param>
        /// <param name="localName">The local name of the element.</param>
        /// <param name="qName">The long (qualified) name of the element.</param>
        void endElement(string namespaceURI, string localName, string qName);

        /// <summary>
        /// This method manage the event when an area of expecific URI prefix was ended.
        /// </summary>
        /// <param name="prefix">The prefix that ends.</param>
        void endPrefixMapping(string prefix);

        /// <summary>
        /// This method manage the event when a ignorable whitespace node was found.
        /// </summary>
        /// <param name="Ch">The array with the ignorable whitespaces.</param>
        /// <param name="Start">The index in the array with the ignorable whitespace.</param>
        /// <param name="Length">The length of the whitespaces.</param>
        void ignorableWhitespace(char[] Ch, int Start, int Length);

        /// <summary>
        /// This method manage the event when a processing instruction was found.
        /// </summary>
        /// <param name="target">The processing instruction target.</param>
        /// <param name="data">The processing instruction data.</param>
        void processingInstruction(string target, string data);

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// </summary>
        void setDocumentLocator(XmlSaxLocator locator);

        /// <summary>
        /// This method manage the event when a skipped entity was found.
        /// </summary>
        /// <param name="name">The name of the skipped entity.</param>
        void skippedEntity(string name);

        /// <summary>
        /// This method manage the event when a start document node was found.
        /// </summary>
        void startDocument();

        /// <summary>
        /// This method manage the event when a start element node was found.
        /// </summary>
        /// <param name="namespaceURI">The namespace uri of the element tag.</param>
        /// <param name="localName">The local name of the element.</param>
        /// <param name="qName">The long (qualified) name of the element.</param>
        /// <param name="atts">The list of attributes of the element.</param>
        void startElement(string namespaceURI, string localName, string qName, SaxAttributesSupport atts);

        /// <summary>
        /// This methods indicates the start of a prefix area in the XML document.
        /// </summary>
        /// <param name="prefix">The prefix of the area.</param>
        /// <param name="uri">The namespace URI of the prefix area.</param>
        void startPrefixMapping(string prefix, string uri);
    }

    /// <summary>
    /// This interface will manage errors during the parsing of a XML document.
    /// </summary>
    public interface XmlSaxErrorHandler
    {
        /// <summary>
        /// This method manage an error exception ocurred during the parsing process.
        /// </summary>
        /// <param name="exception">The exception thrown by the parser.</param>
        void error(System.Xml.XmlException exception);

        /// <summary>
        /// This method manage a fatal error exception ocurred during the parsing process.
        /// </summary>
        /// <param name="exception">The exception thrown by the parser.</param>
        void fatalError(System.Xml.XmlException exception);

        /// <summary>
        /// This method manage a warning exception ocurred during the parsing process.
        /// </summary>
        /// <param name="exception">The exception thrown by the parser.</param>
        void warning(System.Xml.XmlException exception);
    }

    /// <summary>
    /// This interface is created to emulate the SAX Locator interface behavior.
    /// </summary>
    public interface XmlSaxLocator
    {
        /// <summary>
        /// This method return the column number where the current document event ends.
        /// </summary>
        /// <returns>The column number where the current document event ends.</returns>
        int getColumnNumber();

        /// <summary>
        /// This method return the line number where the current document event ends.
        /// </summary>
        /// <returns>The line number where the current document event ends.</returns>
        int getLineNumber();

        /// <summary>
        /// This method is not supported, it is included for compatibility.	
        /// </summary>
        /// <returns>The saved public identifier.</returns>
        string getPublicId();

        /// <summary>
        /// This method is not supported, it is included for compatibility.		
        /// </summary>
        /// <returns>The saved system identifier.</returns>
        string getSystemId();
    }

    /// <summary>
    /// This class is created for emulates the SAX LocatorImpl behaviors.
    /// </summary>
    public class XmlSaxLocatorImpl : XmlSaxLocator
    {
        /// <summary>
        /// This method returns a new instance of 'XmlSaxLocatorImpl'.
        /// </summary>
        /// <returns>A new 'XmlSaxLocatorImpl' instance.</returns>
        public XmlSaxLocatorImpl()
        {
        }

        /// <summary>
        /// This method returns a new instance of 'XmlSaxLocatorImpl'.
        /// Create a persistent copy of the current state of a locator.
        /// </summary>
        /// <param name="locator">The current state of a locator.</param>
        /// <returns>A new 'XmlSaxLocatorImpl' instance.</returns>
        public XmlSaxLocatorImpl(XmlSaxLocator locator)
        {
            setPublicId(locator.getPublicId());
            setSystemId(locator.getSystemId());
            setLineNumber(locator.getLineNumber());
            setColumnNumber(locator.getColumnNumber());
        }

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// Return the saved public identifier.
        /// </summary>
        /// <returns>The saved public identifier.</returns>
        public virtual string getPublicId()
        {
            return publicId;
        }

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// Return the saved system identifier.
        /// </summary>
        /// <returns>The saved system identifier.</returns>
        public virtual string getSystemId()
        {
            return systemId;
        }

        /// <summary>
        /// Return the saved line number.
        /// </summary>
        /// <returns>The saved line number.</returns>
        public virtual int getLineNumber()
        {
            return lineNumber;
        }

        /// <summary>
        /// Return the saved column number.
        /// </summary>
        /// <returns>The saved column number.</returns>
        public virtual int getColumnNumber()
        {
            return columnNumber;
        }

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// Set the public identifier for this locator.
        /// </summary>
        /// <param name="publicId">The new public identifier.</param>
        public virtual void setPublicId(string publicId)
        {
            this.publicId = publicId;
        }

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// Set the system identifier for this locator.
        /// </summary>
        /// <param name="systemId">The new system identifier.</param>
        public virtual void setSystemId(string systemId)
        {
            this.systemId = systemId;
        }

        /// <summary>
        /// Set the line number for this locator.
        /// </summary>
        /// <param name="lineNumber">The line number.</param>
        public virtual void setLineNumber(int lineNumber)
        {
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Set the column number for this locator.
        /// </summary>
        /// <param name="columnNumber">The column number.</param>
        public virtual void setColumnNumber(int columnNumber)
        {
            this.columnNumber = columnNumber;
        }

        // Internal state.
        private string publicId;
        private string systemId;
        private int lineNumber;
        private int columnNumber;
    }

    /// <summary>
    /// This interface will manage the Content events of a XML document.
    /// </summary>
    public interface XmlSaxLexicalHandler
    {
        /// <summary>
        /// This method manage the notification when Characters elements were found.
        /// </summary>
        /// <param name="ch">The array with the characters found.</param>
        /// <param name="start">The index of the first position of the characters found.</param>
        /// <param name="length">Specify how many characters must be read from the array.</param>
        void comment(char[] ch, int start, int length);

        /// <summary>
        /// This method manage the notification when the end of a CDATA section were found.
        /// </summary>
        void endCDATA();

        /// <summary>
        /// This method manage the notification when the end of DTD declarations were found.
        /// </summary>
        void endDTD();

        /// <summary>
        /// This method report the end of an entity.
        /// </summary>
        /// <param name="name">The name of the entity that is ending.</param>
        void endEntity(string name);

        /// <summary>
        /// This method manage the notification when the start of a CDATA section were found.
        /// </summary>
        void startCDATA();

        /// <summary>
        /// This method manage the notification when the start of DTD declarations were found.
        /// </summary>
        /// <param name="name">The name of the DTD entity.</param>
        /// <param name="publicId">The public identifier.</param>
        /// <param name="systemId">The system identifier.</param>
        void startDTD(string name, string publicId, string systemId);

        /// <summary>
        /// This method report the start of an entity.
        /// </summary>
        /// <param name="name">The name of the entity that is ending.</param>
        void startEntity(string name);
    }

    /// <summary>
    /// This class will manage all the parsing operations emulating the SAX parser behavior
    /// </summary>
    public class SaxAttributesSupport
    {
        private System.Collections.ArrayList MainList;

        /// <summary>
        /// Builds a new instance of SaxAttributesSupport.
        /// </summary>
        public SaxAttributesSupport()
        {
            MainList = new System.Collections.ArrayList();
        }

        /// <summary>
        /// Creates a new instance of SaxAttributesSupport from an ArrayList of Att_Instance class.
        /// </summary>
        /// <param name="arrayList">An ArraList of Att_Instance class instances.</param>
        /// <returns>A new instance of SaxAttributesSupport</returns>
        public SaxAttributesSupport(SaxAttributesSupport List)
        {
            SaxAttributesSupport temp = new SaxAttributesSupport();
            temp.MainList = (System.Collections.ArrayList) List.MainList.Clone();
        }

        /// <summary>
        /// Adds a new attribute elment to the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="Uri">The Uri of the attribute to be added.</param>
        /// <param name="Lname">The Local name of the attribute to be added.</param>
        /// <param name="Qname">The Long(qualify) name of the attribute to be added.</param>
        /// <param name="Type">The type of the attribute to be added.</param>
        /// <param name="Value">The value of the attribute to be added.</param>
        public virtual void Add(string Uri, string Lname, string Qname, string Type, string Value)
        {
            Att_Instance temp_Attributes = new Att_Instance(Uri, Lname, Qname, Type, Value);
            MainList.Add(temp_Attributes);
        }

        /// <summary>
        /// Clears the list of attributes in the given AttributesSupport instance.
        /// </summary>
        public virtual void Clear()
        {
            MainList.Clear();
        }

        /// <summary>
        /// Obtains the index of an attribute of the AttributeSupport from its qualified (long) name.
        /// </summary>
        /// <param name="Qname">The qualified name of the attribute to search.</param>
        /// <returns>An zero-based index of the attribute if it is found, otherwise it returns -1.</returns>
        public virtual int GetIndex(string Qname)
        {
            int index = GetLength() - 1;
            while ((index >= 0) && !(((Att_Instance) (MainList[index])).att_fullName.Equals(Qname)))
                index--;
            if (index >= 0)
                return index;
            else
                return -1;
        }

        /// <summary>
        /// Obtains the index of an attribute of the AttributeSupport from its namespace URI and its localname.
        /// </summary>
        /// <param name="Uri">The namespace URI of the attribute to search.</param>
        /// <param name="Lname">The local name of the attribute to search.</param>
        /// <returns>An zero-based index of the attribute if it is found, otherwise it returns -1.</returns>
        public virtual int GetIndex(string Uri, string Lname)
        {
            int index = GetLength() - 1;
            while ((index >= 0) && !(((Att_Instance) (MainList[index])).att_localName.Equals(Lname) && ((Att_Instance)(MainList[index])).att_URI.Equals(Uri)))
                index--;
            if (index >= 0)
                return index;
            else
                return -1;
        }

        /// <summary>
        /// Returns the number of attributes saved in the SaxAttributesSupport instance.
        /// </summary>
        /// <returns>The number of elements in the given SaxAttributesSupport instance.</returns>
        public virtual int GetLength()
        {
            return MainList.Count;
        }

        /// <summary>
        /// Returns the local name of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The local name of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual string GetLocalName(int index)
        {
            try
            {
                return ((Att_Instance) MainList[index]).att_localName;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the qualified name of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The qualified name of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual string GetFullName(int index)
        {
            try
            {
                return ((Att_Instance) MainList[index]).att_fullName;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the type of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The type of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual string GetType(int index)
        {
            try
            {
                return ((Att_Instance) MainList[index]).att_type;
            }
            catch(System.ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the namespace URI of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The namespace URI of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual string GetURI(int index)
        {
            try
            {
                return ((Att_Instance) MainList[index]).att_URI;
            }
            catch(System.ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the value of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The value of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual string GetValue(int index)
        {
            try
            {
                return ((Att_Instance) MainList[index]).att_value;
            }
            catch(System.ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        /// <summary>
        /// Modifies the local name of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="LocalName">The new Local name for the attribute.</param>
        public virtual void SetLocalName(int index, string LocalName)
        {
            ((Att_Instance) MainList[index]).att_localName = LocalName;
        }

        /// <summary>
        /// Modifies the qualified name of the attribute in the given SaxAttributesSupport instance.
        /// </summary>	
        /// <param name="index">The attribute index.</param>
        /// <param name="FullName">The new qualified name for the attribute.</param>
        public virtual void SetFullName(int index, string FullName)
        {
            ((Att_Instance) MainList[index]).att_fullName = FullName;
        }

        /// <summary>
        /// Modifies the type of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="Type">The new type for the attribute.</param>
        public virtual void SetType(int index, string Type)
        {
            ((Att_Instance) MainList[index]).att_type = Type;
        }

        /// <summary>
        /// Modifies the namespace URI of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="URI">The new namespace URI for the attribute.</param>
        public virtual void SetURI(int index, string URI)
        {
            ((Att_Instance) MainList[index]).att_URI = URI;
        }

        /// <summary>
        /// Modifies the value of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="Value">The new value for the attribute.</param>
        public virtual void SetValue(int index, string Value)
        {
            ((Att_Instance) MainList[index]).att_value = Value;
        }

        /// <summary>
        /// This method eliminates the Att_Instance instance at the specified index.
        /// </summary>
        /// <param name="index">The index of the attribute.</param>
        public virtual void RemoveAttribute(int index)
        {
            try
            {
                MainList.RemoveAt(index);
            }
            catch(System.ArgumentOutOfRangeException)
            {
                throw new System.IndexOutOfRangeException("The index is out of range");
            }
        }

        /// <summary>
        /// This method eliminates the Att_Instance instance in the specified index.
        /// </summary>
        /// <param name="indexName">The index name of the attribute.</param>
        public virtual void RemoveAttribute(string indexName)
        {
            try
            {
                int pos = GetLength() - 1;
                while ((pos >= 0) && !(((Att_Instance) (MainList[pos])).att_localName.Equals(indexName)))
                    pos--;
                if (pos >= 0)
                    MainList.RemoveAt(pos);
            }
            catch(System.ArgumentOutOfRangeException)
            {
                throw new System.IndexOutOfRangeException("The index is out of range");
            }
        }

        /// <summary>
        /// Replaces an Att_Instance in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The index of the attribute.</param>
        /// <param name="Uri">The namespace URI of the new Att_Instance.</param>
        /// <param name="Lname">The local name of the new Att_Instance.</param>
        /// <param name="Qname">The namespace URI of the new Att_Instance.</param>
        /// <param name="Type">The type of the new Att_Instance.</param>
        /// <param name="Value">The value of the new Att_Instance.</param>
        public virtual void SetAttribute(int index, string Uri, string Lname, string Qname, string Type, string Value)
        {
            MainList[index] = new Att_Instance(Uri, Lname, Qname, Type, Value);
        }

        /// <summary>
        /// Replaces all the list of Att_Instance of the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="Source">The source SaxAttributesSupport instance.</param>
        public virtual void SetAttributes(SaxAttributesSupport Source)
        {
            MainList = Source.MainList;
        }

        /// <summary>
        /// Returns the type of the Attribute that match with the given qualified name.
        /// </summary>
        /// <param name="Qname">The qualified name of the attribute to search.</param>
        /// <returns>The type of the attribute if it exist otherwise returns null.</returns>
        public virtual string GetType(string Qname)
        {
            int temp_Index = GetIndex(Qname);
            if (temp_Index != -1)
                return ((Att_Instance) MainList[temp_Index]).att_type;
            else
                return "";
        }

        /// <summary>
        /// Returns the type of the Attribute that match with the given namespace URI and local name.
        /// </summary>
        /// <param name="Uri">The namespace URI of the attribute to search.</param>
        /// <param name="Lname">The local name of the attribute to search.</param>
        /// <returns>The type of the attribute if it exist otherwise returns null.</returns>
        public virtual string GetType(string Uri, string Lname)
        {
            int temp_Index = GetIndex(Uri, Lname);
            if (temp_Index != -1)
                return ((Att_Instance) MainList[temp_Index]).att_type;
            else
                return "";
        }

        /// <summary>
        /// Returns the value of the Attribute that match with the given qualified name.
        /// </summary>
        /// <param name="Qname">The qualified name of the attribute to search.</param>
        /// <returns>The value of the attribute if it exist otherwise returns null.</returns>
        public virtual string GetValue(string Qname)
        {
            int temp_Index = GetIndex(Qname);
            if (temp_Index != -1)
                return ((Att_Instance) MainList[temp_Index]).att_value;
            else
                return "";
        }

        /// <summary>
        /// Returns the value of the Attribute that match with the given namespace URI and local name.
        /// </summary>
        /// <param name="Uri">The namespace URI of the attribute to search.</param>
        /// <param name="Lname">The local name of the attribute to search.</param>
        /// <returns>The value of the attribute if it exist otherwise returns null.</returns>
        public virtual string GetValue(string Uri, string Lname)
        {
            int temp_Index = GetIndex(Uri, Lname);
            if (temp_Index != -1)
                return ((Att_Instance) MainList[temp_Index]).att_value;
            else
                return "";
        }

        /*******************************/
        /// <summary>
        /// This class is created to save the information of each attributes in the SaxAttributesSupport.
        /// </summary>
        public class Att_Instance 
        {
            public string att_URI;
            public string att_localName;
            public string att_fullName;
            public string att_type;
            public string att_value;				

            /// <summary>
            /// This is the constructor of the Att_Instance
            /// </summary>
            /// <param name="Uri">The namespace URI of the attribute</param>
            /// <param name="Lname">The local name of the attribute</param>
            /// <param name="Qname">The long(Qualify) name of attribute</param>
            /// <param name="Type">The type of the attribute</param>
            /// <param name="Value">The value of the attribute</param>
            public Att_Instance(string Uri, string Lname, string Qname, string Type, string Value)
            {
                this.att_URI = Uri;
                this.att_localName = Lname;
                this.att_fullName = Qname;
                this.att_type = Type;
                this.att_value = Value;
            }
        }
    }

    /// <summary>
    /// This class is used to encapsulate a source of Xml code in an single class.
    /// </summary>
    public class XmlSourceSupport
    {
        private System.IO.Stream bytes;
        private System.IO.StreamReader characters;
        private string uri;

        /// <summary>
        /// Constructs an empty XmlSourceSupport instance.
        /// </summary>
        public XmlSourceSupport()
        {
            bytes = null;
            characters = null;
            uri = null;
        }

        /// <summary>
        /// Constructs a XmlSource instance with the specified source System.IO.Stream.
        /// </summary>
        /// <param name="stream">The stream containing the document.</param>
        public XmlSourceSupport(System.IO.Stream stream)
        {
            bytes = stream;
            characters = null;
            uri = null;
        }

        /// <summary>
        /// Constructs a XmlSource instance with the specified source System.IO.StreamReader.
        /// </summary>
        /// <param name="reader">The reader containing the document.</param>
        public XmlSourceSupport(System.IO.StreamReader reader)
        {
            bytes = null;
            characters = reader;
            uri = null;
        }

        /// <summary>
        /// Construct a XmlSource instance with the specified source Uri string.
        /// </summary>
        /// <param name="source">The source containing the document.</param>
        public XmlSourceSupport(string source)
        {
            bytes = null;
            characters = null;
            uri = source;
        }

        /// <summary>
        /// Represents the source Stream of the XmlSource.
        /// </summary>
        public System.IO.Stream Bytes	
        {
            get
            {
                return bytes;
            }
            set
            {
                bytes = value;
            }
        }

        /// <summary>
        /// Represents the source StreamReader of the XmlSource.
        /// </summary>
        public System.IO.StreamReader Characters
        {
            get
            {
                return characters;
            }
            set
            {
                characters = value;
            }
        }

        /// <summary>
        /// Represents the source URI of the XmlSource.
        /// </summary>
        public string Uri
        {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
            }
        }
    }

    /// <summary>
    /// This exception is thrown by the XmlSaxDocumentManager in the SetProperty and SetFeature 
    /// methods if a property or method couldn't be found.
    /// </summary>
    public class ManagerNotRecognizedException : System.Exception
    {
        /// <summary>
        /// Creates a new ManagerNotRecognizedException with the message specified.
        /// </summary>
        /// <param name="Message">Error message of the exception.</param>
        public ManagerNotRecognizedException(string Message) : base(Message)
        {
        }
    }

    /// <summary>
    /// This exception is thrown by the XmlSaxDocumentManager in the SetProperty and SetFeature methods 
    /// if a property or method couldn't be supported.
    /// </summary>
    public class ManagerNotSupportedException : System.Exception
    {
        /// <summary>
        /// Creates a new ManagerNotSupportedException with the message specified.
        /// </summary>
        /// <param name="Message">Error message of the exception.</param>
        public ManagerNotSupportedException(string Message) : base(Message)
        {
        }
    }

    /// <summary>
    /// This class provides the base implementation for the management of XML documents parsing.
    /// </summary>
    public class XmlSaxDefaultHandler : XmlSaxContentHandler, XmlSaxErrorHandler, XmlSaxEntityResolver
    {
        /// <summary>
        /// This method manage the notification when Characters element were found.
        /// </summary>
        /// <param name="ch">The array with the characters founds</param>
        /// <param name="start">The index of the first position of the characters found</param>
        /// <param name="length">Specify how many characters must be read from the array</param>
        public virtual void characters(char[] ch, int start, int length) 
        {
        }

        /// <summary>
        /// This method manage the notification when the end document node were found
        /// </summary>
        public virtual void endDocument() 
        {
        }

        /// <summary>
        /// This method manage the notification when the end element node were found
        /// </summary>
        /// <param name="namespaceURI">The namespace URI of the element</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The long name (qualify name) of the element</param>
        public virtual void endElement(string uri, string localName, string qName)
        {
        }
	
        /// <summary>
        /// This method manage the event when an area of expecific URI prefix was ended.
        /// </summary>
        /// <param name="prefix">The prefix that ends</param>
        public virtual void endPrefixMapping(string prefix)
        {
        }

        /// <summary>
        /// This method manage when an error exception ocurrs in the parsing process
        /// </summary>
        /// <param name="exception">The exception throws by the parser</param>
        public virtual void error(System.Xml.XmlException e)
        {
        }

        /// <summary>
        /// This method manage when a fatal error exception ocurrs in the parsing process
        /// </summary>
        /// <param name="exception">The exception Throws by the parser</param>
        public virtual void fatalError(System.Xml.XmlException e) 
        {
        }

        /// <summary>
        /// This method manage the event when a ignorable whitespace node were found
        /// </summary>
        /// <param name="Ch">The array with the ignorable whitespaces</param>
        /// <param name="Start">The index in the array with the ignorable whitespace</param>
        /// <param name="Length">The length of the whitespaces</param>
        public virtual void ignorableWhitespace(char[] ch, int start, int length)
        {
        }

        /// <summary>
        /// This method is not supported only is created for compatibility
        /// </summary>
        public virtual void notationDecl(string name, string publicId, string systemId) 
        {
        }

        /// <summary>
        /// This method manage the event when a processing instruction were found
        /// </summary>
        /// <param name="target">The processing instruction target</param>
        /// <param name="data">The processing instruction data</param>
        public virtual void processingInstruction(string target, string data) 
        {
        }

        /// <summary>
        /// Allow the application to resolve external entities.
        /// </summary>
        /// <param name="publicId">The public identifier of the external entity being referenced, or null if none was supplied.</param>
        /// <param name="systemId">The system identifier of the external entity being referenced.</param>
        /// <returns>A XmlSourceSupport object describing the new input source, or null to request that the parser open a regular URI connection to the system identifier.</returns>
        public virtual XmlSourceSupport resolveEntity(string publicId, string systemId)
        {
            return null;
        }

        /// <summary>
        /// This method is not supported, is include for compatibility
        /// </summary>		 
        public virtual void setDocumentLocator(XmlSaxLocator locator)
        {
        }

        /// <summary>
        /// This method manage the event when a skipped entity were found
        /// </summary>
        /// <param name="name">The name of the skipped entity</param>
        public virtual void skippedEntity(string name)
        {
        }

        /// <summary>
        /// This method manage the event when a start document node were found 
        /// </summary>
        public virtual void startDocument()
        {
        }

        /// <summary>
        /// This method manage the event when a start element node were found
        /// </summary>
        /// <param name="namespaceURI">The namespace uri of the element tag</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The Qualify (long) name of the element</param>
        /// <param name="atts">The list of attributes of the element</param>
        public virtual void startElement(string uri, string localName, string qName, SaxAttributesSupport attributes) 
        {
        }

        /// <summary>
        /// This methods indicates the start of a prefix area in the XML document.
        /// </summary>
        /// <param name="prefix">The prefix of the area</param>
        /// <param name="uri">The namespace uri of the prefix area</param>
        public virtual void startPrefixMapping(string prefix, string uri) 
        {
        }

        /// <summary>
        /// This method is not supported only is created for compatibility
        /// </summary>        
        public virtual void unparsedEntityDecl(string name, string publicId, string systemId, string notationName)
        {
        }

        /// <summary>
        /// This method manage when a warning exception ocurrs in the parsing process
        /// </summary>
        /// <param name="exception">The exception Throws by the parser</param>
        public virtual void warning(System.Xml.XmlException e)
        {
        }
    }

    /// <summary>
    /// This class provides the base implementation for the management of XML documents parsing.
    /// </summary>
    public class XmlSaxParserAdapter : XmlSAXDocumentManager, XmlSaxContentHandler 
    {

        /// <summary>
        /// This method manage the notification when Characters element were found.
        /// </summary>
        /// <param name="ch">The array with the characters founds</param>
        /// <param name="start">The index of the first position of the characters found</param>
        /// <param name="length">Specify how many characters must be read from the array</param>
        public virtual void characters(char[] ch, int start, int length){}

        /// <summary>
        /// This method manage the notification when the end document node were found
        /// </summary>
        public virtual void endDocument(){}

        /// <summary>
        /// This method manage the notification when the end element node were found
        /// </summary>
        /// <param name="namespaceURI">The namespace URI of the element</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The long name (qualify name) of the element</param>
        public virtual void endElement(string namespaceURI, string localName, string qName){}

        /// <summary>
        /// This method manage the event when an area of expecific URI prefix was ended.
        /// </summary>
        /// <param name="prefix">The prefix that ends.</param>
        public virtual void endPrefixMapping(string prefix){}

        /// <summary>
        /// This method manage the event when a ignorable whitespace node were found
        /// </summary>
        /// <param name="ch">The array with the ignorable whitespaces</param>
        /// <param name="start">The index in the array with the ignorable whitespace</param>
        /// <param name="length">The length of the whitespaces</param>
        public virtual void ignorableWhitespace(char[] ch, int start, int length){}

        /// <summary>
        /// This method manage the event when a processing instruction were found
        /// </summary>
        /// <param name="target">The processing instruction target</param>
        /// <param name="data">The processing instruction data</param>
        public virtual void processingInstruction(string target, string data){}

        /// <summary>
        /// Receive an object for locating the origin of events into the XML document
        /// </summary>
        /// <param name="locator">A 'XmlSaxLocator' object that can return the location of any events into the XML document</param>
        public virtual void setDocumentLocator(XmlSaxLocator locator){}

        /// <summary>
        /// This method manage the event when a skipped entity was found.
        /// </summary>
        /// <param name="name">The name of the skipped entity.</param>
        public virtual void skippedEntity(string name){}

        /// <summary>
        /// This method manage the event when a start document node were found 
        /// </summary>
        public virtual void startDocument(){}

        /// <summary>
        /// This method manage the event when a start element node were found
        /// </summary>
        /// <param name="namespaceURI">The namespace uri of the element tag</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The Qualify (long) name of the element</param>
        /// <param name="qAtts">The list of attributes of the element</param>
        public virtual void startElement(string namespaceURI, string localName, string qName, SaxAttributesSupport qAtts){}

        /// <summary>
        /// This methods indicates the start of a prefix area in the XML document.
        /// </summary>
        /// <param name="prefix">The prefix of the area.</param>
        /// <param name="uri">The namespace URI of the prefix area.</param>
        public virtual void startPrefixMapping(string prefix, string uri){}

    }

    /// <summary>
    /// Emulates the SAX parsers behaviours.
    /// </summary>
    public class XmlSAXDocumentManager
    {	
        protected bool isValidating;
        protected bool namespaceAllowed;
        protected System.Xml.XmlValidatingReader reader;
        protected XmlSaxContentHandler callBackHandler;
        protected XmlSaxErrorHandler errorHandler;
        protected XmlSaxLocatorImpl locator;
        protected XmlSaxLexicalHandler lexical;
        protected XmlSaxEntityResolver entityResolver;
        protected string parserFileName;

        /// <summary>
        /// Public constructor for the class.
        /// </summary>
        public XmlSAXDocumentManager()
        {
            isValidating = false;
            namespaceAllowed = false;
            reader = null;
            callBackHandler = null;
            errorHandler = null;
            locator = null;
            lexical = null;
            entityResolver = null;
            parserFileName = "";
        }

        /// <summary>
        /// Returns a new instance of 'XmlSAXDocumentManager'.
        /// </summary>
        /// <returns>A new 'XmlSAXDocumentManager' instance.</returns>
        public static XmlSAXDocumentManager NewInstance()
        {
            return new XmlSAXDocumentManager();
        }

        /// <summary>
        /// Returns a clone instance of 'XmlSAXDocumentManager'.
        /// </summary>
        /// <returns>A clone 'XmlSAXDocumentManager' instance.</returns>
        public static XmlSAXDocumentManager CloneInstance(XmlSAXDocumentManager instance)
        {
            XmlSAXDocumentManager temp = new XmlSAXDocumentManager();
            temp.NamespaceAllowed = instance.NamespaceAllowed;
            temp.isValidating = instance.isValidating;
            XmlSaxContentHandler contentHandler = instance.getContentHandler();
            if (contentHandler != null)
                temp.setContentHandler(contentHandler);
            XmlSaxErrorHandler errorHandler = instance.getErrorHandler();
            if (errorHandler != null)
                temp.setErrorHandler(errorHandler);
            temp.setFeature("http://xml.org/sax/features/namespaces", instance.getFeature("http://xml.org/sax/features/namespaces"));
            temp.setFeature("http://xml.org/sax/features/namespace-prefixes", instance.getFeature("http://xml.org/sax/features/namespace-prefixes"));
            temp.setFeature("http://xml.org/sax/features/validation", instance.getFeature("http://xml.org/sax/features/validation"));
            temp.setProperty("http://xml.org/sax/properties/lexical-handler", instance.getProperty("http://xml.org/sax/properties/lexical-handler"));
            temp.parserFileName = instance.parserFileName;
            return temp;
        }

        /// <summary>
        /// Indicates whether the 'XmlSAXDocumentManager' are validating the XML over a DTD.
        /// </summary>
        public bool IsValidating
        {
            get
            {
                return isValidating;
            }
            set
            {
                isValidating = value;
            }
        }

        /// <summary>
        /// Indicates whether the 'XmlSAXDocumentManager' manager allows namespaces.
        /// </summary>
        public  bool NamespaceAllowed
        {
            get
            {
                return namespaceAllowed;
            }
            set
            {
                namespaceAllowed = value;
            }
        }

        /// <summary>
        /// Emulates the behaviour of a SAX LocatorImpl object.
        /// </summary>
        /// <param name="locator">The 'XmlSaxLocatorImpl' instance to assing the document location.</param>
        /// <param name="textReader">The XML document instance to be used.</param>
        private void UpdateLocatorData(XmlSaxLocatorImpl locator, System.Xml.XmlTextReader textReader)
        {
            if ((locator != null) && (textReader != null))
            {
                locator.setColumnNumber(textReader.LinePosition);
                locator.setLineNumber(textReader.LineNumber);
                locator.setSystemId(parserFileName);
            }
        }

        /// <summary>
        /// Emulates the behavior of a SAX parsers. Set the value of a feature.
        /// </summary>
        /// <param name="name">The feature name, which is a fully-qualified URI.</param>
        /// <param name="value">The requested value for the feature.</param>
        public virtual void setFeature(string name, bool value)
        {
            switch (name)
            {
                case "http://xml.org/sax/features/namespaces":
                    {
                        try
                        {
                            this.NamespaceAllowed = value;
                            break;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }
                case "http://xml.org/sax/features/namespace-prefixes":
                    {
                        try
                        {
                            this.NamespaceAllowed = value;
                            break;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }
                case "http://xml.org/sax/features/validation":
                    {
                        try
                        {
                            this.isValidating = value;
                            break;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }
                default:
                    throw new ManagerNotRecognizedException("The specified feature: " + name + " are not supported");
            }
        }

        /// <summary>
        /// Emulates the behavior of a SAX parsers. Gets the value of a feature.
        /// </summary>
        /// <param name="name">The feature name, which is a fully-qualified URI.</param>
        /// <returns>The requested value for the feature.</returns>
        public virtual bool getFeature(string name)
        {
            switch (name)
            {
                case "http://xml.org/sax/features/namespaces":
                    {
                        try
                        {
                            return this.NamespaceAllowed;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }
                case "http://xml.org/sax/features/namespace-prefixes":
                    {
                        try
                        {
                            return this.NamespaceAllowed;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }
                case "http://xml.org/sax/features/validation":
                    {
                        try
                        {
                            return this.isValidating;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }
                default:
                    throw new ManagerNotRecognizedException("The specified feature: " + name +" are not supported");
            }
        }

        /// <summary>
        /// Emulates the behavior of a SAX parsers. Sets the value of a property.
        /// </summary>
        /// <param name="name">The property name, which is a fully-qualified URI.</param>
        /// <param name="value">The requested value for the property.</param>
        public virtual void setProperty(string name, System.Object value)
        {
            switch (name)
            {
                case "http://xml.org/sax/properties/lexical-handler":
                    {
                        try
                        {
                            lexical = (XmlSaxLexicalHandler) value;
                            break;
                        }
                        catch (System.Exception e)
                        {
                            throw new ManagerNotSupportedException("The property is not supported as an internal exception was thrown when trying to set it: " + e.Message);
                        }
                    }
                default:
                    throw new ManagerNotRecognizedException("The specified feature: " + name + " is not recognized");
            }
        }

        /// <summary>
        /// Emulates the behavior of a SAX parsers. Gets the value of a property.
        /// </summary>
        /// <param name="name">The property name, which is a fully-qualified URI.</param>
        /// <returns>The requested value for the property.</returns>
        public virtual System.Object getProperty(string name)
        {
            switch (name)
            {
                case "http://xml.org/sax/properties/lexical-handler":
                    {
                        try
                        {
                            return this.lexical;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }
                default:
                    throw new ManagerNotRecognizedException("The specified feature: " + name + " are not supported");
            }
        }

        /// <summary>
        /// Emulates the behavior of a SAX parser, it realizes the callback events of the parser.
        /// </summary>
        private void DoParsing()
        {
            System.Collections.Hashtable prefixes = new System.Collections.Hashtable();
            System.Collections.Stack stackNameSpace = new System.Collections.Stack();
            locator = new XmlSaxLocatorImpl();
            try 
            {
                UpdateLocatorData(this.locator, (System.Xml.XmlTextReader) (this.reader.Reader));
                if (this.callBackHandler != null)
                    this.callBackHandler.setDocumentLocator(locator);
                if (this.callBackHandler != null)
                    this.callBackHandler.startDocument();
                while (this.reader.Read())
                {
                    UpdateLocatorData(this.locator, (System.Xml.XmlTextReader) (this.reader.Reader));
                    switch (this.reader.NodeType)
                    {
                        case System.Xml.XmlNodeType.Element:
                            bool Empty = reader.IsEmptyElement;
                            string namespaceURI = "";
                            string localName = "";
                            if (this.namespaceAllowed)
                            {
                                namespaceURI = reader.NamespaceURI;
                                localName = reader.LocalName;
                            }
                            string name = reader.Name;
                            SaxAttributesSupport attributes = new SaxAttributesSupport();
                            if (reader.HasAttributes)
                            {
                                for (int i = 0; i < reader.AttributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    string prefixName = (reader.Name.IndexOf(":") > 0) ? reader.Name.Substring(reader.Name.IndexOf(":") + 1, reader.Name.Length - reader.Name.IndexOf(":") - 1) : "";
                                    string prefix = (reader.Name.IndexOf(":") > 0) ? reader.Name.Substring(0, reader.Name.IndexOf(":")) : reader.Name;
                                    bool IsXmlns = prefix.ToLower().Equals("xmlns");
                                    if (this.namespaceAllowed)
                                    {
                                        if (!IsXmlns)
                                            attributes.Add(reader.NamespaceURI, reader.LocalName, reader.Name, "" + reader.NodeType, reader.Value);
                                    }
                                    else
                                        attributes.Add("", "", reader.Name, "" + reader.NodeType, reader.Value);
                                    if (IsXmlns)
                                    {
                                        string namespaceTemp = "";
                                        namespaceTemp = (namespaceURI.Length == 0) ? reader.Value : namespaceURI;
                                        if (this.namespaceAllowed && !prefixes.ContainsKey(namespaceTemp) && namespaceTemp.Length > 0 )
                                        {
                                            stackNameSpace.Push(name);
                                            System.Collections.Stack namespaceStack = new System.Collections.Stack();
                                            namespaceStack.Push(prefixName);
                                            prefixes.Add(namespaceURI, namespaceStack);
                                            if (this.callBackHandler != null)
                                                ((XmlSaxContentHandler) this.callBackHandler).startPrefixMapping(prefixName, namespaceTemp);
                                        }
                                        else
                                        {
                                            if (this.namespaceAllowed && namespaceTemp.Length > 0  && !((System.Collections.Stack) prefixes[namespaceTemp]).Contains(reader.Name))
                                            {
                                                ((System.Collections.Stack) prefixes[namespaceURI]).Push(prefixName);
                                                if (this.callBackHandler != null)
                                                    ((XmlSaxContentHandler) this.callBackHandler).startPrefixMapping(prefixName, reader.Value);
                                            }
                                        }
                                    }
                                }
                            }
                            if (this.callBackHandler != null)
                                this.callBackHandler.startElement(namespaceURI, localName, name, attributes);
                            if (Empty)
                            {
                                if (this.NamespaceAllowed)
                                {
                                    if (this.callBackHandler != null)
                                        this.callBackHandler.endElement(namespaceURI, localName, name);
                                }
                                else
                                    if (this.callBackHandler != null)
                                        this.callBackHandler.endElement("", "", name);
                            }
                            break;

                        case System.Xml.XmlNodeType.EndElement:
                            if (this.namespaceAllowed)
                            {
                                if (this.callBackHandler != null)
                                    this.callBackHandler.endElement(reader.NamespaceURI, reader.LocalName, reader.Name);
                            }
                            else
                                if (this.callBackHandler != null)
                                    this.callBackHandler.endElement("", "", reader.Name);
                            if (this.namespaceAllowed && prefixes.ContainsKey(reader.NamespaceURI) && ((System.Collections.Stack) stackNameSpace).Contains(reader.Name))
                            {
                                stackNameSpace.Pop();
                                System.Collections.Stack namespaceStack = (System.Collections.Stack) prefixes[reader.NamespaceURI];
                                while (namespaceStack.Count > 0)
                                {
                                    string tempString = (string) namespaceStack.Pop();
                                    if (this.callBackHandler != null )
                                        ((XmlSaxContentHandler) this.callBackHandler).endPrefixMapping(tempString);
                                }
                                prefixes.Remove(reader.NamespaceURI);
                            }
                            break;

                        case System.Xml.XmlNodeType.Text:
                            if (this.callBackHandler != null)
                                this.callBackHandler.characters(reader.Value.ToCharArray(), 0, reader.Value.Length);
                            break;

                        case System.Xml.XmlNodeType.Whitespace:
                            if (this.callBackHandler != null)
                                this.callBackHandler.ignorableWhitespace(reader.Value.ToCharArray(), 0, reader.Value.Length);
                            break;

                        case System.Xml.XmlNodeType.ProcessingInstruction:
                            if (this.callBackHandler != null)
                                this.callBackHandler.processingInstruction(reader.Name, reader.Value);
                            break;

                        case System.Xml.XmlNodeType.Comment:
                            if (this.lexical != null)
                                this.lexical.comment(reader.Value.ToCharArray(), 0, reader.Value.Length);
                            break;

                        case System.Xml.XmlNodeType.CDATA:
                            if (this.lexical != null)
                            {
                                lexical.startCDATA();
                                if (this.callBackHandler != null)
                                    this.callBackHandler.characters(this.reader.Value.ToCharArray(), 0, this.reader.Value.ToCharArray().Length);
                                lexical.endCDATA();
                            }
                            break;

                        case System.Xml.XmlNodeType.DocumentType:
                            if (this.lexical != null)
                            {
                                string lname = this.reader.Name;
                                string systemId = null;
                                if (this.reader.Reader.AttributeCount > 0)
                                    systemId = this.reader.Reader.GetAttribute(0);
                                this.lexical.startDTD(lname, null, systemId);
                                this.lexical.startEntity("[dtd]");
                                this.lexical.endEntity("[dtd]");
                                this.lexical.endDTD();
                            }
                            break;
                    }
                }
                if (this.callBackHandler != null)
                    this.callBackHandler.endDocument();
            }
            catch (System.Xml.XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified file and process the events over the specified handler.
        /// </summary>
        /// <param name="filepath">The file to be used.</param>
        /// <param name="handler">The handler that manages the parser events.</param>
        public virtual void parse(System.IO.FileInfo filepath, XmlSaxContentHandler handler)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    this.errorHandler = (XmlSaxDefaultHandler) handler;
                    this.entityResolver =  (XmlSaxDefaultHandler) handler;
                }
                if (!(this is XmlSaxParserAdapter))
                    this.callBackHandler = handler;
                else
                {
                    if(this.callBackHandler == null)
                        this.callBackHandler = handler;
                }
                System.Xml.XmlTextReader tempTextReader = new System.Xml.XmlTextReader(filepath.OpenRead());
                System.Xml.XmlValidatingReader tempValidatingReader = new System.Xml.XmlValidatingReader(tempTextReader);
                parserFileName = filepath.FullName;
                tempValidatingReader.ValidationType = (this.isValidating) ? System.Xml.ValidationType.DTD : System.Xml.ValidationType.None;
                tempValidatingReader.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
                this.reader = tempValidatingReader;
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified file path and process the events over the specified handler.
        /// </summary>
        /// <param name="filepath">The path of the file to be used.</param>
        /// <param name="handler">The handler that manage the parser events.</param>
        public virtual void parse(string filepath, XmlSaxContentHandler handler)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    this.errorHandler = (XmlSaxDefaultHandler) handler;
                    this.entityResolver =  (XmlSaxDefaultHandler) handler;
                }
                if (!(this is XmlSaxParserAdapter))
                    this.callBackHandler = handler;
                else
                {
                    if(this.callBackHandler == null)
                        this.callBackHandler = handler;
                }
                System.Xml.XmlTextReader tempTextReader = new System.Xml.XmlTextReader(filepath);
                System.Xml.XmlValidatingReader tempValidatingReader = new System.Xml.XmlValidatingReader(tempTextReader);
                parserFileName = filepath;
                tempValidatingReader.ValidationType = (this.isValidating) ? System.Xml.ValidationType.DTD : System.Xml.ValidationType.None;
                tempValidatingReader.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
                this.reader = tempValidatingReader;
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and process the events over the specified handler.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        /// <param name="handler">The handler that manage the parser events.</param>
        public virtual void parse(System.IO.Stream stream, XmlSaxContentHandler handler)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    this.errorHandler = (XmlSaxDefaultHandler) handler;
                    this.entityResolver =  (XmlSaxDefaultHandler) handler;
                }
                if (!(this is XmlSaxParserAdapter))
                    this.callBackHandler = handler;
                else
                {
                    if(this.callBackHandler == null)
                        this.callBackHandler = handler;
                }
                System.Xml.XmlTextReader tempTextReader = new System.Xml.XmlTextReader(stream);
                System.Xml.XmlValidatingReader tempValidatingReader = new System.Xml.XmlValidatingReader(tempTextReader);
                parserFileName = null;
                tempValidatingReader.ValidationType = (this.isValidating) ? System.Xml.ValidationType.DTD : System.Xml.ValidationType.None;
                tempValidatingReader.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
                this.reader = tempValidatingReader;
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and process the events over the specified handler, and resolves the 
        /// entities with the specified URI.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        /// <param name="handler">The handler that manage the parser events.</param>
        /// <param name="URI">The namespace URI for resolve external etities.</param>
        public virtual void parse(System.IO.Stream stream, XmlSaxContentHandler handler, string URI)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    this.errorHandler = (XmlSaxDefaultHandler) handler;
                    this.entityResolver =  (XmlSaxDefaultHandler) handler;
                }
                if (!(this is XmlSaxParserAdapter))
                    this.callBackHandler = handler;
                else
                {
                    if(this.callBackHandler == null)
                        this.callBackHandler = handler;
                }
                System.Xml.XmlTextReader tempTextReader = new System.Xml.XmlTextReader(URI, stream);
                System.Xml.XmlValidatingReader tempValidatingReader = new System.Xml.XmlValidatingReader(tempTextReader);
                parserFileName = null;
                tempValidatingReader.ValidationType = (this.isValidating) ? System.Xml.ValidationType.DTD : System.Xml.ValidationType.None;
                tempValidatingReader.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
                this.reader = tempValidatingReader;
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified 'XmlSourceSupport' instance and process the events over the specified handler, 
        /// and resolves the entities with the specified URI.
        /// </summary>
        /// <param name="source">The 'XmlSourceSupport' that contains the XML.</param>
        /// <param name="handler">The handler that manages the parser events.</param>
        public virtual void parse(XmlSourceSupport source, XmlSaxContentHandler handler)
        {
            if (source.Characters != null)
                parse(source.Characters.BaseStream, handler);
            else
            {
                if (source.Bytes != null)
                    parse(source.Bytes, handler);
                else
                {
                    if(source.Uri != null)
                        parse(source.Uri, handler);
                    else
                        throw new System.Xml.XmlException("The XmlSource class can't be null");
                }
            }
        }

        /// <summary>
        /// Parses the specified file and process the events over previously specified handler.
        /// </summary>
        /// <param name="filepath">The file with the XML.</param>
        public virtual void parse(System.IO.FileInfo filepath)
        {
            try
            {
                System.Xml.XmlTextReader tempTextReader = new System.Xml.XmlTextReader(filepath.OpenRead());
                System.Xml.XmlValidatingReader tempValidatingReader = new System.Xml.XmlValidatingReader(tempTextReader);
                parserFileName = filepath.FullName;
                tempValidatingReader.ValidationType = (this.isValidating) ? System.Xml.ValidationType.DTD : System.Xml.ValidationType.None;
                tempValidatingReader.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
                this.reader = tempValidatingReader;
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified file path and processes the events over previously specified handler.
        /// </summary>
        /// <param name="filepath">The path of the file with the XML.</param>
        public virtual void parse(string filepath)
        {
            try
            {
                System.Xml.XmlTextReader tempTextReader = new System.Xml.XmlTextReader(filepath);
                System.Xml.XmlValidatingReader tempValidatingReader = new System.Xml.XmlValidatingReader(tempTextReader);
                parserFileName = filepath;
                tempValidatingReader.ValidationType = (this.isValidating) ? System.Xml.ValidationType.DTD : System.Xml.ValidationType.None;
                tempValidatingReader.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
                this.reader = tempValidatingReader;
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and process the events over previusly specified handler.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        public virtual void parse(System.IO.Stream stream)
        {
            try
            {
                System.Xml.XmlTextReader tempTextReader = new System.Xml.XmlTextReader(stream);
                System.Xml.XmlValidatingReader tempValidatingReader = new System.Xml.XmlValidatingReader(tempTextReader);
                parserFileName = null;
                tempValidatingReader.ValidationType = (this.isValidating) ? System.Xml.ValidationType.DTD : System.Xml.ValidationType.None;
                tempValidatingReader.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
                this.reader = tempValidatingReader;
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and processes the events over previously specified handler, and resolves the 
        /// external entities with the specified URI.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        /// <param name="URI">The namespace URI for resolve external etities.</param>
        public virtual void parse(System.IO.Stream stream, string URI)
        {
            try
            {
                System.Xml.XmlTextReader tempTextReader = new System.Xml.XmlTextReader(URI, stream);
                System.Xml.XmlValidatingReader tempValidatingReader = new System.Xml.XmlValidatingReader(tempTextReader);
                parserFileName = null;
                tempValidatingReader.ValidationType = (this.isValidating) ? System.Xml.ValidationType.DTD : System.Xml.ValidationType.None;
                tempValidatingReader.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
                this.reader = tempValidatingReader;
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified 'XmlSourceSupport' and processes the events over the specified handler, and 
        /// resolves the entities with the specified URI.
        /// </summary>
        /// <param name="source">The 'XmlSourceSupport' instance with the XML.</param>
        public virtual void parse(XmlSourceSupport source)
        {
            if (source.Characters != null)
                parse(source.Characters.BaseStream);
            else
            {
                if (source.Bytes != null)
                    parse(source.Bytes);
                else
                {
                    if (source.Uri != null)
                        parse(source.Uri);
                    else
                        throw new System.Xml.XmlException("The XmlSource class can't be null");
                }
            }
        }

        /// <summary>
        /// Manages all the exceptions that were thrown when the validation over XML fails.
        /// </summary>
        public void ValidationEventHandle(System.Object sender, System.Xml.Schema.ValidationEventArgs args)
        {
            System.Xml.Schema.XmlSchemaException tempException = args.Exception;
            if (args.Severity == System.Xml.Schema.XmlSeverityType.Warning)
            {
                if (this.errorHandler != null)
                    this.errorHandler.warning(new System.Xml.XmlException(tempException.Message, tempException, tempException.LineNumber, tempException.LinePosition));
            }
            else
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(new System.Xml.XmlException(tempException.Message, tempException, tempException.LineNumber, tempException.LinePosition));
            }
        }
				
        /// <summary>
        /// Assigns the object that will handle all the content events.
        /// </summary>
        /// <param name="handler">The object that handles the content events.</param>
        public virtual void setContentHandler(XmlSaxContentHandler handler)
        {
            if (handler != null)
                this.callBackHandler = handler;
            else
                throw new System.Xml.XmlException("Error assigning the Content handler: a null Content Handler was received");
        }

        /// <summary>
        /// Assigns the object that will handle all the error events. 
        /// </summary>
        /// <param name="handler">The object that handles the errors events.</param>
        public virtual void setErrorHandler(XmlSaxErrorHandler handler)
        {
            if (handler != null)
                this.errorHandler = handler;
            else
                throw new System.Xml.XmlException("Error assigning the Error handler: a null Error Handler was received");
        }

        /// <summary>
        /// Obtains the object that will handle all the content events.
        /// </summary>
        /// <returns>The object that handles the content events.</returns>
        public virtual XmlSaxContentHandler getContentHandler()
        {
            return this.callBackHandler;
        }

        /// <summary>
        /// Assigns the object that will handle all the error events. 
        /// </summary>
        /// <returns>The object that handles the error events.</returns>
        public virtual XmlSaxErrorHandler getErrorHandler()
        {
            return this.errorHandler;
        }

        /// <summary>
        /// Returns the current entity resolver.
        /// </summary>
        /// <returns>The current entity resolver, or null if none has been registered.</returns>
        public virtual XmlSaxEntityResolver getEntityResolver()
        {
            return this.entityResolver;
        }

        /// <summary>
        /// Allows an application to register an entity resolver.
        /// </summary>
        /// <param name="resolver">The entity resolver.</param>
        public virtual void setEntityResolver(XmlSaxEntityResolver resolver)
        {
            this.entityResolver = resolver;
        }
    }

    /// <summary>
    /// Supports the basic desing of a Source for XML transformations.
    /// </summary>
    public interface BasicSourceSupport
    {
        /// <summary>
        /// Gets and sets the Id of the current instance.
        /// </summary>
        string Id 
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Manages the source XML document that will be transformed.
    /// </summary>
    public class DomSourceSupport:BasicSourceSupport
    {
        private string id;
        private System.Xml.XmlNode node;

        /// <summary>
        /// Gets and sets the Id of the DomSourceSupport instance.
        /// </summary>
        public virtual string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets and sets the XmlNode instance associated to the DomSourceSupport.
        /// </summary>
        public virtual System.Xml.XmlNode Node
        {
            get
            {
                return this.node;
            }
            set
            {
                this.node = value;
            }
        }

        /// <summary>
        /// Creates a new instance from a XmlNode with the specified Id.
        /// </summary>
        /// <param name="node">The XmlNode instance with the XML.</param>
        /// <param name="Id">The Id of the instance.</param>
        public DomSourceSupport(System.Xml.XmlNode Node, string Id)
        {
            this.id = Id;
            this.node = Node;
        }

        /// <summary>
        /// Creates a new instance from a XmlNode instance.
        /// </summary>
        /// <param name="node">The XmlNode instance to be used.</param>
        public DomSourceSupport(System.Xml.XmlNode Node)
        {
            this.id = "";
            this.node = Node;
        }
    }

    /// <summary>
    /// Supports the basic desing of a Result for XML transformations.
    /// </summary>
    public interface BasicResultSupport
    {
        /// <summary>
        /// Gets and sets the Id of the current instance.
        /// </summary>
        string Id 
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Manages the target where the result of the transformation will be saved.
    /// </summary>
    public class GenericResultSupport:BasicResultSupport
    {  
        /// <summary>
        /// Represents the type of the result.
        /// </summary>
        public enum TYPE {Uri, Stream, Writer, File, Null}

        private string id;
        private string name;
        private System.IO.StreamWriter writer;
        private System.IO.Stream stream;
        private TYPE type;
		
        /// <summary>
        /// Basic Constructor for the class.
        /// </summary>
        public GenericResultSupport()
        {
            id = null;
            name = "";
            writer = null;
            stream = null;
            type = TYPE.Null;
        }

        /// <summary>
        ///  Gets and sets the Id of the GenericResultSupport instance.
        /// </summary>
        public virtual string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                this.name = value;
                this.writer = null;
                this.stream = null;
                this.type = TYPE.Uri;
            }
        }

        /// <summary>
        /// Gets and sets the StreamWriter associated to the instance.
        /// </summary>
        public virtual System.IO.StreamWriter Writer
        {
            get
            {
                return this.writer;
            }
            set
            {
                this.id = null;
                this.name = "";
                this.writer = value;
                this.type = TYPE.Writer;
            }
        }

        /// <summary>
        /// Gets and sets the Stream associated to the instance.
        /// </summary>
        public virtual System.IO.Stream Stream 
        {
            get 
            {
                return this.stream;
            }
            set
            {
                this.id = null;
                this.name = "";
                this.stream = value;
                this.type = TYPE.Stream;
            }
        }

        /// <summary>
        /// Gets and sets the type of the instance.
        /// </summary>
        public virtual TYPE Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        /// <summary>
        /// Creates a new instance from the specified Uri.
        /// </summary>
        /// <param name="Uri">The Uri to be used.</param>
        public GenericResultSupport(string Uri)
        {
            this.id = Uri;
            this.name = Uri;
            this.writer = null;
            this.stream = null;
            this.type = TYPE.Uri;
        }

        /// <summary>
        /// Creates a new instance from the specified StreamWriter.
        /// </summary>
        /// <param name="writer">The StreamWriter instance to be used.</param>
        public GenericResultSupport(System.IO.StreamWriter Writer)
        {
            this.id = null;
            this.name = "";
            this.writer = Writer;
            this.stream = null;
            this.type = TYPE.Writer;
        }

        /// <summary>
        /// Creates a new instance from the specified Stream.
        /// </summary>
        /// <param name="stream">The Stream instance to be used.</param>
        public GenericResultSupport(System.IO.Stream Stream)
        {
            this.id = null;
            this.name = "";
            this.writer = new System.IO.StreamWriter(Stream);
            this.stream = Stream;
            this.type = TYPE.Stream;
        }

        /// <summary>
        /// Creates a new instance from the specified FileInfo.
        /// </summary>
        /// <param name="file">The FileInfo instance to be used.</param>
        public GenericResultSupport(System.IO.FileInfo File)
        {
            this.id = File.FullName;
            this.name = File.FullName;
            this.writer = null;
            this.stream = null;
            this.type = TYPE.File;
        }
    }

    /// <summary>
    /// Manages the source XML document that will be transformed.
    /// </summary>
    public class GenericSourceSupport:BasicSourceSupport
    {
        /// <summary>
        /// Represents the type of the source.
        /// </summary>
        public enum TYPE {Uri, Stream, Reader, File}

        private string id;
        private string path;
        private System.IO.StreamReader reader;
        private System.IO.Stream stream;
        private TYPE type;

        /// <summary>
        /// Gets and sets the Id of the GenericSourceSupport instance.
        /// </summary>
        public virtual string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                this.path = value;
                this.reader = null;
                this.stream = null;
                this.type = TYPE.Uri;
            }
        }

        /// <summary>
        /// Gets and sets the type of the instance.
        /// </summary>
        public virtual TYPE Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        /// <summary>
        /// Gets and sets the path of the GenericSourceSupport instance.
        /// </summary>
        public virtual string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value;				
            }
        }

        /// <summary>
        /// Get and sets the stream of the instance.
        /// </summary>
        public virtual System.IO.Stream Stream
        {
            get
            {
                return this.stream;
            }
            set
            {				
                this.stream = value;
                this.type = TYPE.Stream;
            }
        }

        /// <summary>
        /// Get and sets the stream of the instance.
        /// </summary>
        public virtual System.IO.StreamReader Reader
        {
            get
            {
                return this.reader;
            }
            set
            {				
                this.reader = value;
                this.type = TYPE.Reader;
            }
        }


        /// <summary>
        /// Creates a new instance from an URI.
        /// </summary>
        /// <param name="Uri"></param>
        public GenericSourceSupport(string Uri)
        {
            this.id = Uri;
            this.path = Uri;
            this.reader = null;
            this.stream = null;
            this.type = TYPE.Uri;
        }

        /// <summary>
        /// Creates a new instance form the specified StreamReader with the specified Id.
        /// </summary>
        /// <param name="reader">The StreamReader instance with the XML.</param>
        /// <param name="Id">The Id of the instance.</param>
        public GenericSourceSupport(System.IO.StreamReader Reader, string Id)
        {
            this.id = Id;
            this.path = "";
            this.reader = Reader;
            this.stream = reader.BaseStream;
            this.type = TYPE.Stream;
        }

        /// <summary>
        /// Creates a new instance from the specified StreamReader.
        /// </summary>
        /// <param name="reader">The StreamReader instance with the XML.</param>
        public GenericSourceSupport(System.IO.StreamReader Reader)
        {
            this.id = null;
            this.path = "";
            this.reader = Reader;
            this.stream = reader.BaseStream;
            this.type = TYPE.Stream;
        }

        /// <summary>
        /// Creates a new instance from the specified Stream with the specified Id.
        /// </summary>
        /// <param name="stream">The Stream instance with the XML.</param>
        /// <param name="Id">The Id of the instance.</param>
        public GenericSourceSupport(System.IO.Stream Stream, string Id)
        {
            this.id = Id;
            this.path = "";
            this.reader = null;
            this.stream = Stream;
            this.type = TYPE.Stream;
        }

        /// <summary>
        /// Creates a new instance from the specified Stream.
        /// </summary>
        /// <param name="stream">The Stream intance with the XML.</param>
        public GenericSourceSupport(System.IO.Stream Stream)
        {
            this.id = null;
            this.path = "";
            this.stream = Stream;
            this.reader = null;
            this.type = TYPE.Stream;
        }

        /// <summary>
        /// Creates a new instance from a FileInfo.
        /// </summary>
        /// <param name="file">The fileInfo instance with the XML.</param>
        public GenericSourceSupport(System.IO.FileInfo File)
        {
            this.id = File.FullName;
            this.path = File.FullName;
            this.reader = null;
            this.stream = null;
            this.type = TYPE.File;
        }

        /// <summary>
        /// Basic Constructor for the class.
        /// </summary>
        public GenericSourceSupport()
        {
            this.id = null;
            this.path = "";
            this.reader = null;
            this.stream = null;
        }
    }

    /// <summary>
    /// Manages the target where the result of the tranformation will be saved.
    /// </summary>
    public class DomResultSupport:BasicResultSupport
    {
        private string id;
        private System.Xml.XmlNode node;

        /// <summary>
        ///  Gets and sets the Id of the GenericResultSupport instance.
        /// </summary>
        public virtual string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets and sets the Document for the GenericResultSupport instance.
        /// </summary>
        public virtual System.Xml.XmlNode Node
        {
            get
            {
                return this.node;
            }
            set
            {
                this.node = value;
            }
        }

        /// <summary>
        /// Creates a new instance of DomSourceSupport with the specified XmlDocument instance and the 
        /// specified Id.
        /// </summary>
        /// <param name="Document">The XmlDocument instance for the class.</param>
        /// <param name="Id">The Id for the DomSourceSupport.</param>
        public DomResultSupport(System.Xml.XmlNode Node, string Id)
        {
            this.id = Id;
            this.node = Node;
        }

        /// <summary>
        /// Creates a new instance of DomSourceSupport with the specified XmlDocument instance.
        /// </summary>
        /// <param name="Document">The XmlDocument instance for the class.</param>
        public DomResultSupport(System.Xml.XmlNode Node)
        {
            this.id = "";
            this.node = Node;
        }
    }

    /// <summary>
    /// Manages the source XML document that will be transformed.
    /// </summary>
    public class SaxSourceSupport:BasicSourceSupport
    {
        private string id;
        private XmlSourceSupport source;
        private XmlSAXDocumentManager reader;		

        /// <summary>
        /// Gets and sets the Id of the SaxSourceSupport instance.
        /// </summary>
        public virtual string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                if (this.source == null)
                    this.source = new XmlSourceSupport(this.id);
            }
        }

        /// <summary>
        /// Gets and sets the XmlSourceSupport of the SaxSourceSupport instance.
        /// </summary>
        public virtual XmlSourceSupport Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
            }
        }

        /// <summary>
        /// Gets and sets the XmlSAXDocumentManager of the SaxSourceSupport instance.
        /// </summary>
        public virtual XmlSAXDocumentManager Reader
        {
            get
            {
                return this.reader;
            }
            set
            {
                this.reader = value;
            }
        }

        /// <summary>
        /// Creates a new instance of SaxSourceSupport with the specified XmlSAXDocumentManager and 
        /// XmlSourceSupport.
        /// </summary>
        /// <param name="Reader">The XmlSAXDocumentManager used to parse the XML.</param>
        /// <param name="Source">The XmlSourceSupport with the XML.</param>
        public SaxSourceSupport(XmlSAXDocumentManager Reader, XmlSourceSupport Source)
        {
            this.id = (Source.Uri != null) ? Source.Uri : "";
            this.source = Source;
            this.reader = Reader;
        }

        /// <summary>
        /// Creates a new instance of SaxSourceSupport with the specified XmlSource support.
        /// </summary>
        /// <param name="Source">The XmlSourceSupport with the XML.</param>
        public SaxSourceSupport(XmlSourceSupport Source)
        {
            this.id = (Source.Uri != null) ? Source.Uri : "";
            this.source = Source;
            this.reader = new XmlSAXDocumentManager();
        }

        /// <summary>
        /// Creates an empty new instance of SaxSourceSupport.
        /// </summary>	
        public SaxSourceSupport()
        {
            this.id = "";		
            this.source = null;
            this.reader = null;
        }

        /// <summary>
        /// Creates a new instance of XmlSourceSupport from a BasicSourceSupport class.
        /// </summary>
        /// <param name="Source">The BasicSourceSupportClass to be used.</param>
        /// <returns>A new instance of XmlSourceSupport class.</returns>
        public static XmlSourceSupport FromGenericSource(BasicSourceSupport Source)
        {			
            XmlSourceSupport result = null;
            if(Source is GenericSourceSupport)
            {
                GenericSourceSupport temp_Source = (GenericSourceSupport)Source;
                if (temp_Source.Path != null)
                    result = new XmlSourceSupport(temp_Source.Path);
                else
                {
                    if (temp_Source.Reader != null)
                        result = new XmlSourceSupport(temp_Source.Reader);
                    else
                        if (temp_Source.Stream != null)
                            result = new XmlSourceSupport(temp_Source.Stream);
                }
            }			
            else
            {
                if(Source is SaxSourceSupport)
                {
                    result = ((SaxSourceSupport)Source).Source;
                }

            }
            return result;
        }
    }

    /// <summary>
    /// Manages the target where the result of the transformation will be saved.
    /// </summary>
    public class SaxResultSupport:BasicResultSupport
    {
        private string id;
        private XmlSaxContentHandler handler;
        private XmlSaxLexicalHandler lexHandler;
		
        /// <summary>
        /// Basic Constructor for the class.
        /// </summary>
        public SaxResultSupport(){
            id = "";
            handler = null;
            lexHandler = null;
        }

        /// <summary>
        ///  Gets and sets the Id of the SaxResultSupport instance.
        /// </summary>
        public virtual string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        ///  Gets and sets the XmlSaxContentHandler of the SaxResultSupport instance.
        /// </summary>
        public virtual XmlSaxContentHandler Handler
        {
            get
            {
                return this.handler;
            }
            set
            {
                this.handler = value;
            }
        }

        /// <summary>
        ///  Gets and sets the XmlSaxLexicalHandler of the SaxResultSupport instance.
        /// </summary>
        public virtual XmlSaxLexicalHandler LexHandler
        {
            get
            {
                return this.lexHandler;
            }
            set
            {
                this.lexHandler = value;
            }
        }

        /// <summary>
        /// Creates a new instance of SaxResultSupport, with the specified XmlSaxContentHandler.
        /// </summary>
        /// <param name="Handler">The XmlSaxContentHandler to be used.</param>
        public SaxResultSupport(XmlSaxContentHandler Handler)
        {
            this.handler = Handler;
        }
    }

    /// <summary>
    /// Supports the Errors thrown by the TransformerSupport class.
    /// </summary>
    public interface XsltExceptionManager
    {
        /// <summary>
        /// Manages when an exception was thrown in the Transform operation of the TranformerSupport class.
        /// </summary>
        /// <param name="Exception">The exception thrown by the TransformerSupport instance.</param>
        void Error(System.Xml.Xsl.XsltException Exception);

        /// <summary>
        /// This method is not supported only was created for compatibility.
        /// </summary>
        void FatalError(System.Xml.Xsl.XsltException Exception);

        /// <summary>
        /// This method is not supported only was created for compatibility.
        /// </summary>
        void Warning(System.Xml.Xsl.XsltException Exception);
    }

    /// <summary>
    /// Inteface that resolves the URI of external resources in transformations.
    /// </summary>
    public interface TransformerResolver
    {
        BasicSourceSupport ResolveURI(string hrefUri, string baseUri);		
    }

    /// <summary>
    /// Resolves the URI of external resources in transformations.
    /// </summary>
    public class DefaultTransformerResolver : System.Xml.XmlUrlResolver
    {
        private TransformerResolver uriResolver;

        public TransformerResolver UriResolver
        {
            get
            {
                return this.uriResolver;
            }
            set
            {
                this.uriResolver = value;
            }
        }
		
        private BasicSourceSupport style;
        public BasicSourceSupport Style
        {
            get
            {
                return this.style;
            }
            set
            {
                this.style = value;
            }
        }	
		

        /// <summary>
        /// Resolves URI of parent and calls user implementation method.
        /// </summary>
        public override System.Uri ResolveUri(System.Uri BaseUri, string relativeUri)
        {
            string baseUri = null;

            if( BaseUri != null )
                baseUri = BaseUri.AbsolutePath;
            else
                baseUri = this.style.Id;

            if( this.uriResolver != null )
            {
                BasicSourceSupport resolvedSource = this.uriResolver.ResolveURI( relativeUri, baseUri );
                System.Uri resolvedUri = null;

                if( BaseUri != null )
                    resolvedUri = new System.Uri( BaseUri, resolvedSource.Id );
                else
                    resolvedUri = new System.Xml.XmlUrlResolver().ResolveUri(null, resolvedSource.Id);

                return resolvedUri;
            }

            else
                return new System.Xml.XmlUrlResolver().ResolveUri( BaseUri, relativeUri );
        }
    }

    /// <summary>
    /// Supports the XSL transformations.
    /// </summary>
    public class TransformerSupport
    {
        private System.Xml.Xsl.XsltArgumentList Parameters = null;
        private TransformerResolver resolverFactory = null;
        private TransformerResolver resolverTransformer = null;		

        private System.Xml.XmlResolver DefaultResolverFactory=null;
        private System.Xml.XmlResolver DefaultResolverTransformer=null;

        private XsltExceptionManager errorListenerFactory = null;
        private XsltExceptionManager errorListenerTransformer = null;
        private System.Xml.Xsl.XslTransform Transformer = null;
        private BasicSourceSupport Stylesheet = null;

        /// <summary>
        /// The constructor of the support class.
        /// </summary>
        public TransformerSupport()
        {
            this.Transformer = new System.Xml.Xsl.XslTransform();			
            this.errorListenerFactory = new DefaultXsltExceptionManager();
            this.errorListenerTransformer = new DefaultXsltExceptionManager();
            this.ResolverFactory=null;
        }

        /// <summary>
        /// A static constructor for this class.
        /// </summary>
        /// <returns>A new instance of tranformer support.</returns>
        public static TransformerSupport NewInstance()
        {
            return new TransformerSupport();
        }

        /// <summary>
        /// Creates a new instance of TransformerSupport and sets it ResolverFactory and errorListenerFactory.
        /// </summary>
        /// <param name="transformer">Instance of TransformerSupport to get its attributes to create the new 
        /// instance.</param>
        /// <returns>The new instance.</returns>
        public static TransformerSupport NewTransform(TransformerSupport transformer)
        {
            TransformerSupport temp = new TransformerSupport();
            temp.ResolverFactory = transformer.ResolverFactory;			
            temp.errorListenerFactory = transformer.errorListenerFactory;
            return temp;
        }

        /// <summary>
        /// Clears the parameters asociated with the XslTransform instance.
        /// </summary>
        public void ClearArguments()
        {
            Parameters.Clear();
            Parameters = null;
        }		

        /// <summary>
        /// Gets and sets the class that manages the errors reported by the XslTransform.
        /// </summary>
        public XsltExceptionManager ErrorListenerFactory
        {
            get
            {
                return this.errorListenerFactory;
            }
            set
            {
                if(value != null)
                    this.errorListenerFactory = value;
                else
                    throw new System.ArgumentException("Error assigning the error listener: a null ErrorListener was received");
            }
        }
		
        /// <summary>
        /// Gets and sets the class that manages the errors reported by the XslTransform.
        /// </summary>
        public XsltExceptionManager ErrorListenerTransformer
        {
            get
            {
                return this.errorListenerTransformer;
            }
            set
            {
                if(value != null)
                    this.errorListenerTransformer = value;
                else
                    throw new System.ArgumentException("Error assigning the error listener: a null ErrorListener was received");
            }
        }

        /// <summary>
        /// Gets and sets the class that is used to resolve externs references.
        /// </summary>
        public TransformerResolver ResolverTransformer
        {
            get
            {
                return this.resolverTransformer;
            }
            set
            {
                this.resolverTransformer = value;
                this.DefaultResolverTransformer = new DefaultTransformerResolver();
                ((DefaultTransformerResolver)DefaultResolverTransformer).UriResolver = this.resolverTransformer;				
            }
        }

        /// <summary>
        /// Gets and sets the class that is used to resolve externs references in load methods.
        /// </summary>
        public TransformerResolver ResolverFactory
        {
            get
            {
                return this.resolverFactory;
            }
            set
            {
                this.resolverFactory = value;
                this.DefaultResolverFactory = new DefaultTransformerResolver();
                ((DefaultTransformerResolver)DefaultResolverFactory).UriResolver = this.resolverFactory;
                if(this.ResolverTransformer == null)
                    this.ResolverTransformer = value;
            }
        }

        /// <summary>
        /// Loads the StyleSheet that will be used for the transformations operations.
        /// </summary>
        /// <param name="StyleSheet">A XPathDocument that contains the StyleSheet.</param>
        public void Load(System.Xml.XPath.XPathDocument StyleSheet)
        {
            try
            {
                Transformer.Load(StyleSheet, DefaultResolverFactory, this.GetType().Assembly.Evidence);
                this.Stylesheet = new GenericSourceSupport();
            }
            catch (System.Xml.XmlException exception)
            {
                throw new System.Xml.Xsl.XsltException(exception.Message, exception);
            }
            catch (System.Xml.Xsl.XsltException exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Emulates the behavior of Templates creating a XPathDocument instance.
        /// </summary>
        /// <param name="Source">The source with the Xsl.</param>
        /// <returns>A XPathDocument instance that could be used as Templates.</returns>
        public System.Xml.XPath.XPathDocument ToXPathDocument(BasicSourceSupport Source)
        {
            System.Xml.XPath.XPathDocument Template = null;
            if (Source is GenericSourceSupport)
            {
                GenericSourceSupport Generic = (GenericSourceSupport)Source;
                switch(Generic.Type)
                {
                    case GenericSourceSupport.TYPE.Uri:
                    case GenericSourceSupport.TYPE.File:
                        Template = new System.Xml.XPath.XPathDocument(Generic.Path);
                        break;
                    case GenericSourceSupport.TYPE.Stream:
                        Template = new System.Xml.XPath.XPathDocument(Generic.Stream);
                        break;
                    case GenericSourceSupport.TYPE.Reader:
                        Template = new System.Xml.XPath.XPathDocument(Generic.Reader);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (Source is DomSourceSupport)
                {
                    string temp_String = ((DomSourceSupport) Source).Node.OuterXml;
                    Template = new System.Xml.XPath.XPathDocument(new System.Xml.XmlTextReader(new System.IO.StringReader(temp_String)));
                }
                else
                {
                    if (Source is SaxSourceSupport)
                    {
                        XmlSourceSupport XmlSource = ((SaxSourceSupport) Source).Source;
                        if (XmlSource.Characters != null)
                            Template = new System.Xml.XPath.XPathDocument(XmlSource.Characters);
                        else
                        {
                            if (XmlSource.Bytes != null)
                                Template = new System.Xml.XPath.XPathDocument(XmlSource.Bytes);
                            else
                            {
                                if (XmlSource.Uri != null)
                                    Template = new System.Xml.XPath.XPathDocument(XmlSource.Uri);
                            }
                        }
                    }
                }
            }
            return Template;
        }

        /// <summary>
        /// Loads the StyleSheet that will be used for the transformations operations.
        /// </summary>
        /// <param name="StyleSheet">A GenericSourceSupport that contains the StyleSheet.</param>
        public void Load(BasicSourceSupport StyleSheet)
        {
            ((DefaultTransformerResolver)DefaultResolverFactory).Style = StyleSheet;
            if (StyleSheet is GenericSourceSupport)
            {
                GenericSourceSupport Generic = (GenericSourceSupport) StyleSheet;
                try
                {
                    switch(Generic.Type)
                    {
                        case GenericSourceSupport.TYPE.Uri:
                        case GenericSourceSupport.TYPE.File:
                            Transformer.Load(Generic.Path,DefaultResolverFactory);
                            break;						case GenericSourceSupport.TYPE.Stream:
                            Transformer.Load(new System.Xml.XmlTextReader(Generic.Stream), DefaultResolverFactory, this.GetType().Assembly.Evidence);
                            break;
                        case GenericSourceSupport.TYPE.Reader:
                            Transformer.Load(new System.Xml.XmlTextReader(Generic.Reader), DefaultResolverFactory, this.GetType().Assembly.Evidence);
                            break;
                        default:
                            break;
                    }
                    this.Stylesheet = StyleSheet;
                }
                catch (System.Xml.XmlException exception)
                {
                    if (this.ErrorListenerFactory == null)
                        throw new System.Xml.Xsl.XsltException(exception.Message, exception);
                    else
                        this.ErrorListenerFactory.FatalError(new System.Xml.Xsl.XsltException(exception.Message, exception));
                }
                catch (System.Xml.Xsl.XsltException exception)
                {
                    if (this.ErrorListenerFactory == null)
                        throw exception;
                    else
                        this.ErrorListenerFactory.FatalError(exception);
                }
            }
            else
            {
                if(StyleSheet is SaxSourceSupport)
                {
                    XmlSourceSupport Source = ((SaxSourceSupport) StyleSheet).Source;
                    try
                    {
                        if (Source.Characters != null)
                            Transformer.Load(new System.Xml.XmlTextReader(Source.Characters), DefaultResolverFactory, this.GetType().Assembly.Evidence);
                        else
                        {
                            if(Source.Bytes != null)
                                Transformer.Load(new System.Xml.XmlTextReader(Source.Bytes), DefaultResolverFactory, this.GetType().Assembly.Evidence);
                            else
                            {
                                if(Source.Uri != null)
                                {
                                    System.IO.FileStream tmp = new System.IO.FileStream(Source.Uri,System.IO.FileMode.Open,System.IO.FileAccess.Read);
                                    Transformer.Load(new System.Xml.XmlTextReader(tmp),DefaultResolverFactory, this.GetType().Assembly.Evidence);
                                    tmp.Close();
                                }
                            }
                        }
                        this.Stylesheet = StyleSheet;
                    }
                    catch (System.Xml.XmlException exception)
                    {
                        if (this.ErrorListenerFactory == null)
                            throw new System.Xml.Xsl.XsltException(exception.Message, exception);
                        else
                            this.ErrorListenerFactory.FatalError(new System.Xml.Xsl.XsltException(exception.Message, exception));
                    }
                    catch (System.Xml.Xsl.XsltException exception)
                    {
                        if (this.ErrorListenerFactory == null)
                            throw exception;
                        else
                            this.ErrorListenerFactory.FatalError(exception);
                    }
                }
                else
                {
                    if (StyleSheet is DomSourceSupport)
                    {
                        try
                        {
                            string temp_String = ((DomSourceSupport) StyleSheet).Node.OuterXml;
                            Transformer.Load(new System.Xml.XmlTextReader(new System.IO.StringReader(temp_String)), DefaultResolverFactory, this.GetType().Assembly.Evidence);
                            this.Stylesheet = StyleSheet;
                        }
                        catch (System.Xml.XmlException exception)
                        {
                            if (this.ErrorListenerFactory == null)
                                throw new System.Xml.Xsl.XsltException(exception.Message, exception);
                            else
                                this.ErrorListenerFactory.FatalError(new System.Xml.Xsl.XsltException(exception.Message, exception));
                        }
                        catch (System.Xml.Xsl.XsltException exception)
                        {
                            if (this.ErrorListenerFactory == null)
                                throw exception;
                            else
                                this.ErrorListenerFactory.FatalError(exception);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Returns the value of a parameter in the parameters list.
        /// </summary>
        /// <param name="ParamName">The Name of the parameter.</param>
        /// <returns>An object that contains the value of the specified paramenter.</returns>
        public System.Object GetParameter(string ParamName)
        {
            if (Parameters != null)
                return Parameters.GetParam(ParamName, "");
            else
                return null;
        }

        /// <summary>
        /// Introduces a new parameter to the parameters list or modify the value of a parameter previously 
        /// introduced.
        /// </summary>
        /// <param name="ParamName">The name of the parameter.</param>
        /// <param name="ParamValue">An object instance with the parameter value.</param>
        public void SetParameter(string ParamName, System.Object ParamValue)
        {
            if (Parameters == null)
                Parameters = new System.Xml.Xsl.XsltArgumentList();
            Parameters.AddParam(ParamName, "", ParamValue);
        }

        /// <summary>
        /// Makes the tranformation from the specified source, to the specified target.
        /// </summary>
        /// <param name="Source">The XML source to be transformed.</param>
        /// <param name="Result">The result of the transformation.</param>
        public void DoTransform(BasicSourceSupport Source, BasicResultSupport Result)
        {
            if (Source is GenericSourceSupport)
            {
                if(Result is GenericResultSupport)
                    DoTransform((GenericSourceSupport) Source, (GenericResultSupport) Result);
                else
                {
                    if (Result is DomResultSupport)
                        DoTransform((GenericSourceSupport) Source, (DomResultSupport) Result);
                    else
                        if (Result is SaxResultSupport)
                            DoTransform((GenericSourceSupport) Source, (SaxResultSupport) Result);
                }
            }
            else
            {
                if (Source is DomSourceSupport)
                {
                    if (Result is GenericResultSupport)
                        DoTransform((DomSourceSupport) Source, (GenericResultSupport) Result);
                    else
                    {
                        if (Result is DomResultSupport)
                            DoTransform((DomSourceSupport) Source, (DomResultSupport) Result);
                        else
                            if (Result is SaxResultSupport)
                                DoTransform((DomSourceSupport)Source,(SaxResultSupport)Result);
                    }
                }
                else
                {
                    if (Source is SaxSourceSupport)
                    {
                        if (Result is GenericResultSupport)
                            DoTransform((SaxSourceSupport) Source, (GenericResultSupport) Result);
                        else
                        {
                            if (Result is DomResultSupport)
                                DoTransform((SaxSourceSupport) Source, (DomResultSupport) Result);
                            else
                                if (Result is SaxResultSupport)
                                    DoTransform((SaxSourceSupport) Source, (SaxResultSupport) Result);
                        }
                    }
                }
            }
        }		

        /// <summary>
        /// Makes the tranformation from the specified source, to the specified target.
        /// </summary>
        /// <param name="Source">The XML source to be transformed.</param>
        /// <param name="Result">The result of the transformation.</param>
        public void DoTransform(GenericSourceSupport Source, GenericResultSupport Result)
        {
            try
            {
                System.Xml.XmlDocument SourceDocument = new System.Xml.XmlDocument();
                switch(Source.Type)
                {
                    case GenericSourceSupport.TYPE.Uri:
                    case GenericSourceSupport.TYPE.File:
                        SourceDocument.Load(Source.Path);
                        break;
                    case GenericSourceSupport.TYPE.Stream:
                        SourceDocument.Load(Source.Stream);
                        break;
                    case GenericSourceSupport.TYPE.Reader:
                        SourceDocument.Load(Source.Reader);
                        break;
                    default:
                        SourceDocument = null;
                        ErrorListenerTransformer.Error(new System.Xml.Xsl.XsltException("The Xml Source can't be null", null));
                        break;
                }
                if (this.Stylesheet != null)
                {
                    try
                    {
                        switch (Result.Type)
                        {
                            case GenericResultSupport.TYPE.Null:
                                break;
                            case GenericResultSupport.TYPE.Stream:
                                Transformer.Transform(SourceDocument, Parameters, Result.Stream, DefaultResolverTransformer);
                                break;
                            case GenericResultSupport.TYPE.File:
                            case GenericResultSupport.TYPE.Uri:
                                System.IO.StreamWriter Temp_Writer = new System.IO.StreamWriter(Result.Id);
                                Transformer.Transform(SourceDocument, Parameters,Temp_Writer, DefaultResolverTransformer);								
                                Temp_Writer.Close();
                                break;
                            case GenericResultSupport.TYPE.Writer:
                                Transformer.Transform(SourceDocument, Parameters, Result.Writer, DefaultResolverTransformer);
                                Result.Writer.Close();
                                break;
                        }
                    }
                    catch (System.Xml.Xsl.XsltException exception)
                    {
                        ErrorListenerTransformer.FatalError(exception);
                    }
                }
                else
                    ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException("A Xsl stylesheet file must be defined before transform operation", null));
            }
            catch(System.Exception e)
            {
                if (this.ErrorListenerTransformer == null)
                    throw new System.Xml.Xsl.XsltException(e.Message, e);
                else
                    this.ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException(e.Message, e));
            }
        }


        /// <summary>
        /// Makes the tranformation from the specified source, to the specified target.
        /// </summary>
        /// <param name="Source">The XML source to be transformed.</param>
        /// <param name="Result">The result of the transformation.</param>
        public void DoTransform(DomSourceSupport Source, GenericResultSupport Result)
        {
            if (this.Stylesheet != null)
            {
                try
                {
                    switch (Result.Type)
                    {
                        case GenericResultSupport.TYPE.Null:
                            break;
                        case GenericResultSupport.TYPE.Stream:
                            Transformer.Transform(Source.Node, Parameters, Result.Stream, DefaultResolverTransformer);
                            break;
                        case GenericResultSupport.TYPE.File:
                        case GenericResultSupport.TYPE.Uri:
                            System.IO.StreamWriter Temp_Writer = new System.IO.StreamWriter(Result.Id);
                            Transformer.Transform(Source.Node, Parameters, Temp_Writer, DefaultResolverTransformer);
                            Temp_Writer.Close();
                            break;					
                        case GenericResultSupport.TYPE.Writer:
                            Transformer.Transform(Source.Node, Parameters, Result.Writer, DefaultResolverTransformer);
                            Result.Writer.Close();
                            break;					
                    }
                }
                catch (System.Xml.Xsl.XsltException exception)
                {
                    ErrorListenerTransformer.FatalError(exception);
                }
                catch (System.Exception e)
                {		
                    if (this.ErrorListenerTransformer == null)
                        throw new System.Xml.Xsl.XsltException(e.Message, e);
                    else
                        this.ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException(e.Message, e));
                }
            }
            else
            {
                if (Source.Node is System.Xml.XmlDocument)
                {
                    switch (Result.Type)
                    {
                        case GenericResultSupport.TYPE.Null:
                            break;
                        case GenericResultSupport.TYPE.Stream:
                            ((System.Xml.XmlDocument) Source.Node).Save(Result.Stream);
                            Result.Stream.Close();							
                            break;
                        case GenericResultSupport.TYPE.File:
                        case GenericResultSupport.TYPE.Uri:
                            ((System.Xml.XmlDocument) Source.Node).Save(Result.Id);
                            break;
                        case GenericResultSupport.TYPE.Writer:
                            ((System.Xml.XmlDocument) Source.Node).Save(Result.Writer);
                            Result.Writer.Close();
                            break;
                    }
                }
                else
                {
                    switch (Result.Type)
                    {
                        case GenericResultSupport.TYPE.Null:
                            break;
                        case GenericResultSupport.TYPE.Stream:
                            System.IO.StreamWriter Writer = new System.IO.StreamWriter(Result.Stream);
                            Writer.Write(Source.Node.OuterXml);							
                            Result.Stream.Close();							
                            break;
                        case GenericResultSupport.TYPE.File:
                        case GenericResultSupport.TYPE.Uri:
                            System.IO.StreamWriter Temp_Writer = new System.IO.StreamWriter(Result.Id);
                            Temp_Writer.Write(Source.Node.OuterXml);
                            Temp_Writer.Close();
                            break;
                        case GenericResultSupport.TYPE.Writer:
                            Result.Writer.Write(Source.Node.OuterXml);
                            Result.Writer.Close();
                            break;
                    }
                }
            }
        }


        /// <summary>
        /// Makes the tranformation from the specified source, to the specified target.
        /// </summary>
        /// <param name="Source">The XML source to be transformed.</param>
        /// <param name="Result">The result of the transformation.</param>
        public void DoTransform(DomSourceSupport Source, DomResultSupport Result)
        {
            System.IO.MemoryStream tempStream = new System.IO.MemoryStream();			
            try
            {
                if (this.Stylesheet != null)
                {
                    try
                    {
                        Transformer.Transform(Source.Node, Parameters, tempStream, DefaultResolverTransformer);
                    }
                    catch (System.Xml.Xsl.XsltException exception)
                    {
                        ErrorListenerTransformer.Error(exception);
                    }
                    tempStream.Position = 0;
                    System.Xml.XmlDocument TempDocument = (System.Xml.XmlDocument)Result.Node.OwnerDocument;
                    if(TempDocument == null)
                    {
                        TempDocument = (System.Xml.XmlDocument)Result.Node;
                    }
                    TempDocument.Load(tempStream);					
                }
                else
                    ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException("A Xsl stylesheet file must be defined before transform operation", null));
            }
            catch (System.Exception e)
            {
                if (this.ErrorListenerTransformer == null)
                    throw new System.Xml.Xsl.XsltException(e.Message, e);
                else
                    this.ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException(e.Message, e));
            }
        }

        /// <summary>
        /// Makes the tranformation from the specified source, to the specified target.
        /// </summary>
        /// <param name="Source">The XML source to be transformed.</param>
        /// <param name="Result">The result of the transformation.</param>
        public void DoTransform(GenericSourceSupport Source, DomResultSupport Result)
        {
            try
            {
                System.Xml.XmlDocument SourceDocument = new System.Xml.XmlDocument();
                switch(Source.Type)
                {
                    case GenericSourceSupport.TYPE.Uri:
                    case GenericSourceSupport.TYPE.File:
                        SourceDocument.Load(Source.Path);
                        break;
                    case GenericSourceSupport.TYPE.Stream:
                        SourceDocument.Load(Source.Stream);
                        break;
                    case GenericSourceSupport.TYPE.Reader:
                        SourceDocument.Load(Source.Reader);
                        break;
                    default:
                        SourceDocument = null;
                        ErrorListenerTransformer.Error(new System.Xml.Xsl.XsltException("The Xml Source can't be null", null));
                        break;
                }
                System.IO.MemoryStream tempStream = new System.IO.MemoryStream();				
                if (this.Stylesheet != null)
                {
                    try
                    {
                        Transformer.Transform(SourceDocument, Parameters, tempStream, DefaultResolverTransformer);
                    }
                    catch (System.Xml.Xsl.XsltException exception)
                    {
                        ErrorListenerTransformer.FatalError(exception);
                    }
                    tempStream.Position = 0;
                    System.Xml.XmlDocument TempDocument = (System.Xml.XmlDocument)Result.Node.OwnerDocument;
                    if(TempDocument == null)
                    {
                        TempDocument = (System.Xml.XmlDocument)Result.Node;
                    }
                    TempDocument.Load(tempStream);
                }
                else
                    ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException("A Xsl stylesheet file must be defined before transform operation", null));
            }
            catch(System.Exception e)
            {
                if (this.ErrorListenerTransformer == null)
                    throw new System.Xml.Xsl.XsltException(e.Message, e);
                else
                    this.ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException(e.Message, e));
            }
        }

        /// <summary>
        /// Makes the tranformation from the specified source, to the specified target.
        /// </summary>
        /// <param name="Source">The XML source to be transformed.</param>
        /// <param name="Result">The result of the transformation.</param>
        public void DoTransform(SaxSourceSupport Source, SaxResultSupport Result)
        {
            try
            {
                System.Xml.XmlDocument SourceDocument = new System.Xml.XmlDocument();			
                System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
                XmlSAXDocumentManager tempManager = new XmlSAXDocumentManager();
                tempManager.setContentHandler(Result.Handler);

                if (Result.LexHandler != null)
                    Source.Reader.setProperty("http://xml.org/sax/properties/lexical-handler", Result.LexHandler);

                if (Source.Source.Characters != null)
                    SourceDocument.Load(Source.Source.Characters);
                else
                {
                    if(Source.Source.Bytes != null)
                        SourceDocument.Load(Source.Source.Bytes);
                    else
                    {
                        if(Source.Source.Uri != null)
                            SourceDocument.Load(Source.Source.Uri);
                        else
                            return;
                    }
                }
                Transformer.Transform(SourceDocument, Parameters, tempStream, DefaultResolverTransformer);
                tempStream.Position = 0;
                tempManager.parse(tempStream);
            }
            catch (System.Exception e)
            {
                if (this.ErrorListenerTransformer == null)
                    throw new System.Xml.Xsl.XsltException(e.Message, e);
                else
                    this.ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException(e.Message, e));
            }
        }

        /// <summary>
        /// Makes the tranformation from the specified source, to the specified target.
        /// </summary>
        /// <param name="Source">The XML source to be transformed.</param>
        /// <param name="Result">The result of the transformation.</param>
        public void DoTransform(SaxSourceSupport Source, DomResultSupport Result)
        {
            try
            {
                System.IO.MemoryStream tempStream = new System.IO.MemoryStream();				
                System.Xml.XmlDocument tempGSource = new System.Xml.XmlDocument();
                if (Source.Source.Characters != null)
                    tempGSource.Load(Source.Source.Characters.BaseStream);
                else
                {
                    if (Source.Source.Bytes != null)
                        tempGSource.Load(Source.Source.Bytes);
                    else
                    {
                        if (Source.Source.Uri != null)
                            tempGSource.Load(Source.Source.Uri);
                        else
                            return;
                    }
                }
                if (this.Stylesheet != null)
                {
                    try
                    {
                        Transformer.Transform(tempGSource, Parameters, tempStream, DefaultResolverTransformer);
                    }
                    catch (System.Xml.Xsl.XsltException exception)
                    {
                        ErrorListenerTransformer.FatalError(exception);
                    }
                    tempStream.Position = 0;
                    System.Xml.XmlDocument TempDocument = (System.Xml.XmlDocument)Result.Node.OwnerDocument;
                    if(TempDocument == null)
                    {
                        TempDocument = (System.Xml.XmlDocument)Result.Node;
                    }
                    TempDocument.Load(tempStream);					
                }
                else
                    ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException("A Xsl stylesheet file must be defined before transform operation", null));
            }
            catch (System.Exception e)
            {		
                if (this.ErrorListenerTransformer == null)
                    throw new System.Xml.Xsl.XsltException(e.Message, e);
                else
                    this.ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException(e.Message, e));
            }
        }

        /// <summary>
        /// Makes the tranformation from the specified source, to the specified target.
        /// </summary>
        /// <param name="Source">The XML source to be transformed.</param>
        /// <param name="Result">The result of the transformation.</param>
        public void DoTransform(SaxSourceSupport Source, GenericResultSupport Result)
        {
            try
            {
                System.Xml.XmlDocument tempGSource = new System.Xml.XmlDocument();
                if (Source.Source.Characters != null)
                    tempGSource.Load(Source.Source.Characters.BaseStream);
                else
                {
                    if (Source.Source.Bytes != null)
                        tempGSource.Load(Source.Source.Bytes);
                    else
                    {
                        if (Source.Source.Uri != null)
                            tempGSource.Load(Source.Source.Uri);
                        else
                            return;
                    }
                }
                if (this.Stylesheet != null)
                {
                    try
                    {
                        switch(Result.Type)
                        {
                            case GenericResultSupport.TYPE.Null:
                                break;
                            case GenericResultSupport.TYPE.Stream:
                                Transformer.Transform(tempGSource, Parameters, Result.Stream, DefaultResolverTransformer);
                                break;
                            case GenericResultSupport.TYPE.File:
                            case GenericResultSupport.TYPE.Uri:
                                System.IO.StreamWriter Temp_Writer = new System.IO.StreamWriter(Result.Id);
                                Transformer.Transform(tempGSource, Parameters, Temp_Writer, DefaultResolverTransformer);								
                                Temp_Writer.Close();
                                break;
                            case GenericResultSupport.TYPE.Writer:
                                Transformer.Transform(tempGSource, Parameters, Result.Writer, DefaultResolverTransformer);
                                Result.Writer.Close();
                                break;
                        }
                    }
                    catch (System.Xml.Xsl.XsltException exception)
                    {
                        ErrorListenerTransformer.FatalError(exception);
                    }
                }
                else
                    ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException("A Xsl stylesheet file must be defined before transform operation", null));
            }
            catch (System.Exception e)
            {
                if (this.ErrorListenerTransformer == null)
                    throw new System.Xml.Xsl.XsltException(e.Message, e);
                else
                    this.ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException(e.Message, e));
            }
        }

        /// <summary>
        /// Makes the tranformation from the specified source, to the specified target.
        /// </summary>
        /// <param name="Source">The XML source to be transformed.</param>
        /// <param name="Result">The result of the transformation.</param>
        public void DoTransform(GenericSourceSupport Source, SaxResultSupport Result)
        {
            try
            {
                XmlSAXDocumentManager tempManager = new XmlSAXDocumentManager();
                tempManager.setContentHandler(Result.Handler);
                if (Result.LexHandler != null)
                    tempManager.setProperty("http://xml.org/sax/properties/lexical-handler", Result.LexHandler);
                if (this.Stylesheet != null)
                {
                    System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
                    System.Xml.XmlDocument SourceDocument = new System.Xml.XmlDocument();
                    switch(Source.Type)
                    {
                        case GenericSourceSupport.TYPE.Uri:
                        case GenericSourceSupport.TYPE.File:
                            SourceDocument.Load(Source.Path);
                            break;
                        case GenericSourceSupport.TYPE.Stream:
                            SourceDocument.Load(Source.Stream);
                            break;
                        case GenericSourceSupport.TYPE.Reader:
                            SourceDocument.Load(Source.Reader);
                            break;
                        default:
                            SourceDocument = null;
                            ErrorListenerTransformer.Error(new System.Xml.Xsl.XsltException("The Xml Source can't be null", null));
                            break;
                    }
                    try
                    {
                        Transformer.Transform(SourceDocument, Parameters, tempStream, DefaultResolverTransformer);
                    }
                    catch (System.Xml.Xsl.XsltException exception)
                    {
                        ErrorListenerTransformer.FatalError(exception);
                    }
                    tempStream.Position = 0;
                    tempManager.parse(tempStream);

                }
                else
                {
                    if (Source.Reader != null)
                        tempManager.parse(Source.Reader.BaseStream);
                    else
                    {
                        if (Source.Stream != null)
                            tempManager.parse(Source.Stream);
                        else
                        {
                            if (Source.Path != null)
                                tempManager.parse(Source.Path);
                            else
                                return;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                if (this.ErrorListenerTransformer == null)
                    throw new System.Xml.Xsl.XsltException(e.Message, e);
                else
                    this.ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException(e.Message, e));
            }
        }


        /// <summary>
        /// Makes the tranformation from the specified source, to the specified target.
        /// </summary>
        /// <param name="Source">The XML source to be transformed.</param>
        /// <param name="Result">The result of the transformation.</param>
        public void DoTransform(DomSourceSupport Source, SaxResultSupport Result)
        {
            try
            {
                System.IO.MemoryStream tempStream;
                if (this.Stylesheet != null)
                {
                    tempStream = new System.IO.MemoryStream();
                    try
                    {
                        Transformer.Transform(Source.Node, Parameters, tempStream, DefaultResolverTransformer);
                    }
                    catch (System.Xml.Xsl.XsltException exception)
                    {
                        ErrorListenerTransformer.FatalError(exception);
                    }
                    tempStream.Position = 0;
                }
                else
                {
                    char[] c = Source.Node.OuterXml.ToCharArray();
                    byte[] x = new byte[c.Length];
                    for (int i = 0; i < c.Length;i++)
                        x[i] = System.Convert.ToByte(c[i]);
                    tempStream = new System.IO.MemoryStream(x);
                }
                XmlSAXDocumentManager tempManager = new XmlSAXDocumentManager();
                tempManager.setContentHandler(Result.Handler);
                if (Result.LexHandler != null)
                    tempManager.setProperty("http://xml.org/sax/properties/lexical-handler", Result.LexHandler);
                tempManager.parse(tempStream);
            }
            catch (System.Exception e)
            {
                if (this.ErrorListenerTransformer == null)
                    throw new System.Xml.Xsl.XsltException(e.Message, e);
                else
                    this.ErrorListenerTransformer.FatalError(new System.Xml.Xsl.XsltException(e.Message, e));
            }
        }

        /// <summary>
        /// This method indicates if a feature is supported by the current instance.
        /// </summary>
        /// <param name="feature">A string asociated to a feature.</param>
        /// <returns>True if the feature is supported otherwise false.</returns>
        public bool IsSupported(string feature)
        {
            bool result;
            switch(feature)
            {
                case "GENERICSOURCE":
                case "GENERICRESULT":
                case "DOMSOURCE":
                case "DOMRESULT":
                case "SAXSOURCE":
                case "SAXRESULT":
                case "TRANSFORMERHANDLER":
                case "XMLFILTERSUPPORT":
                    result = true;
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Represent the Default error handling for transform operations
        /// </summary>
        public class DefaultXsltExceptionManager : XsltExceptionManager
        {
            public System.IO.StreamWriter StandardError = null;

            /// <summary>
            /// Default constructor for the class.
            /// </summary>
            public DefaultXsltExceptionManager()
            {
                StandardError = new System.IO.StreamWriter(System.Console.OpenStandardError());
            }

            /// <summary>
            /// Manages when an exception was thrown in the Transform operation of the TranformerSupport class.
            /// </summary>
            /// <param name="exception">The exception thrown by the TransformerSupport instance.</param>
            public void Error(System.Xml.Xsl.XsltException exception)
            {
                StandardError.WriteLine(exception);
            }

            /// <summary>
            /// Manages when an exception was thrown in the Transform operation of the TranformerSupport class.
            /// </summary>
            /// <param name="exception">The exception thrown by the TransformerSupport instance.</param>
            public void FatalError(System.Xml.Xsl.XsltException exception)
            {
                StandardError.WriteLine(exception);
                throw exception;
            }

            /// <summary>
            /// Manages when an exception was thrown in the Transform operation of the TranformerSupport class.
            /// </summary>
            /// <param name="exception">The exception thrown by the TransformerSupport instance.</param>
            public void Warning(System.Xml.Xsl.XsltException exception)
            {
                StandardError.WriteLine(exception);
            }
        }
    }

    /// <summary>
    /// This class is created for emulates the SAX XMLFilter behaviors.
    /// </summary>
    public class XmlSaxXMLFilter : XmlSAXDocumentManager
    {
        /// <summary>
        /// Set the parent reader.
        /// </summary>
        /// <param name="parent">The parent reader.</param>
        public virtual void setParent(XmlSAXDocumentManager parent)
        {
        }

        /// <summary>
        /// Get the parent reader.
        /// </summary>
        /// <returns>The parent filter, or null if none has been set.</returns>
        public virtual XmlSAXDocumentManager getParent()
        {
            return null;
        }
    }

    /// <summary>
    /// Emulates XmlFilter behaviors over piped transformations.
    /// </summary>
    public class TransformXmlFilterSupport:XmlSaxXMLFilter
    {
        private TransformerSupport transformer;
        private BasicSourceSupport XslSource;
        private XmlSAXDocumentManager parent;


        /// <summary>
        /// Creates a new instance of TransformXmlFilterSupport from a BasicSourceSupport.
        /// </summary>
        /// <param name="source">The BasicSourceSupport instance to be used.</param>
        public TransformXmlFilterSupport(BasicSourceSupport source)
        {
            XslSource = source;
            transformer = new TransformerSupport();
            transformer.Load(source);
        }


        /// <summary>
        /// This method is used for Piped transformations using the XmlReaders instance.
        /// </summary>
        /// <param name="Source">The XmlSource with the XML document.</param>
        /// <param name="Filter">The TransformXmlFilterSupport for piped Transformations.</param>
        /// <returns>An XmlSourceSupport instance</returns>
        public virtual XmlSourceSupport Parse(XmlSourceSupport Source,TransformXmlFilterSupport Filter)
        {
            if(Filter.getParent() is TransformXmlFilterSupport)
            {			
                System.IO.MemoryStream tempStream = new System.IO.MemoryStream();			
                GenericResultSupport tempResult = new GenericResultSupport(tempStream);						
                SaxSourceSupport SaxSource = new SaxSourceSupport(Parse(Source,(TransformXmlFilterSupport)Filter.getParent()));			
                Filter.transformer.DoTransform(SaxSource,tempResult);						
                return new XmlSourceSupport(tempStream);
            }
            else
            {				
                Filter.getParent().parse(Source);
                System.IO.MemoryStream tempStream = new System.IO.MemoryStream();			
                GenericResultSupport tempResult = new GenericResultSupport(tempStream);
                SaxSourceSupport SaxSource = new SaxSourceSupport(Source);
                Filter.transformer.DoTransform(SaxSource,tempResult);
                Filter.parse(tempStream);
                tempStream.Position =0;
                return new XmlSourceSupport(tempStream);
            }
        }

        /// <summary>
        /// This method overrides the method parse of the XmlSaxXMLFilter class.
        /// </summary>
        /// <param name="filepath">A string with the file path of the XML source.</param>
        public override void parse(String filepath)
        {
            base.parse(Parse(new XmlSourceSupport(filepath),this));		
        }

        /// <summary>
        /// This method overrides the method parse of the XmlSaxXMLFilter class.
        /// </summary>
        /// <param name="source">The XmlSourceSupport instance with the Xml source.</param>
        public override void parse(XmlSourceSupport source)
        {
            base.parse(Parse(source,this));		
        }

        /// <summary>
        /// Overrides the SetParent method of the XmlSaxXMLFilter.
        /// </summary>
        /// <param name="parent">A XmlSAXDocumentManager instance that is parent of this instance.</param>
        public override void setParent(XmlSAXDocumentManager parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Overrides the GetParent method of the XmlSaxXMLFilter.
        /// </summary>
        /// <returns>A XmlSAXDocumentManager instance that is parent of this instance.</returns>
        public override XmlSAXDocumentManager getParent()
        {
            return this.parent;
        }
    }

    /// <summary>
    /// Contains conversion support elements such as classes, interfaces and static methods.
    /// </summary>
    public class SupportClass
    {
        /// <summary>
        /// Writes the exception stack trace to the received stream
        /// </summary>
        /// <param name="throwable">Exception to obtain information from</param>
        /// <param name="stream">Output sream used to write to</param>
        public static void WriteStackTrace(System.Exception throwable, System.IO.TextWriter stream)
        {
            stream.Write(throwable.StackTrace);
            stream.Flush();
        }

        /*******************************/
        /// <summary>
        /// SupportClass for the Stack class.
        /// </summary>
        public class StackSupport
        {
            /// <summary>
            /// Removes the element at the top of the stack and returns it.
            /// </summary>
            /// <param name="stack">The stack where the element at the top will be returned and removed.</param>
            /// <returns>The element at the top of the stack.</returns>
            public static System.Object Pop(System.Collections.ArrayList stack)
            {
                System.Object obj = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);

                return obj;
            }
        }


        /*******************************/
        /// <summary>
        /// This class provides functionality not found in .NET collection-related interfaces.
        /// </summary>
        public class ICollectionSupport
        {
            /// <summary>
            /// Adds a new element to the specified collection.
            /// </summary>
            /// <param name="c">Collection where the new element will be added.</param>
            /// <param name="obj">Object to add.</param>
            /// <returns>true</returns>
            public static bool Add(System.Collections.ICollection c, System.Object obj)
            {
                bool added = false;
                //Reflection. Invoke either the "add" or "Add" method.
                System.Reflection.MethodInfo method;
                try
                {
                    //Get the "add" method for proprietary classes
                    method = c.GetType().GetMethod("Add");
                    if (method == null)
                        method = c.GetType().GetMethod("add");
                    int index = (int) method.Invoke(c, new System.Object[] {obj});
                    if (index >=0)	
                        added = true;
                }
                catch (System.Exception e)
                {
                    throw e;
                }
                return added;
            }

            /// <summary>
            /// Adds all of the elements of the "c" collection to the "target" collection.
            /// </summary>
            /// <param name="target">Collection where the new elements will be added.</param>
            /// <param name="c">Collection whose elements will be added.</param>
            /// <returns>Returns true if at least one element was added, false otherwise.</returns>
            public static bool AddAll(System.Collections.ICollection target, System.Collections.ICollection c)
            {
                System.Collections.IEnumerator e = new System.Collections.ArrayList(c).GetEnumerator();
                bool added = false;

                //Reflection. Invoke "addAll" method for proprietary classes
                System.Reflection.MethodInfo method;
                try
                {
                    method = target.GetType().GetMethod("addAll");

                    if (method != null)
                        added = (bool) method.Invoke(target, new System.Object[] {c});
                    else
                    {
                        method = target.GetType().GetMethod("Add");
                        while (e.MoveNext() == true)
                        {
                            bool tempBAdded =  (int) method.Invoke(target, new System.Object[] {e.Current}) >= 0;
                            added = added ? added : tempBAdded;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                return added;
            }

            /// <summary>
            /// Removes all the elements from the collection.
            /// </summary>
            /// <param name="c">The collection to remove elements.</param>
            public static void Clear(System.Collections.ICollection c)
            {
                //Reflection. Invoke "Clear" method or "clear" method for proprietary classes
                System.Reflection.MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("Clear");

                    if (method == null)
                        method = c.GetType().GetMethod("clear");

                    method.Invoke(c, new System.Object[] {});
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }

            /// <summary>
            /// Determines whether the collection contains the specified element.
            /// </summary>
            /// <param name="c">The collection to check.</param>
            /// <param name="obj">The object to locate in the collection.</param>
            /// <returns>true if the element is in the collection.</returns>
            public static bool Contains(System.Collections.ICollection c, System.Object obj)
            {
                bool contains = false;

                //Reflection. Invoke "contains" method for proprietary classes
                System.Reflection.MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("Contains");

                    if (method == null)
                        method = c.GetType().GetMethod("contains");

                    contains = (bool)method.Invoke(c, new System.Object[] {obj});
                }
                catch (System.Exception e)
                {
                    throw e;
                }

                return contains;
            }

            /// <summary>
            /// Determines whether the collection contains all the elements in the specified collection.
            /// </summary>
            /// <param name="target">The collection to check.</param>
            /// <param name="c">Collection whose elements would be checked for containment.</param>
            /// <returns>true id the target collection contains all the elements of the specified collection.</returns>
            public static bool ContainsAll(System.Collections.ICollection target, System.Collections.ICollection c)
            {						
                System.Collections.IEnumerator e =  c.GetEnumerator();

                bool contains = false;

                //Reflection. Invoke "containsAll" method for proprietary classes or "Contains" method for each element in the collection
                System.Reflection.MethodInfo method;
                try
                {
                    method = target.GetType().GetMethod("containsAll");

                    if (method != null)
                        contains = (bool)method.Invoke(target, new Object[] {c});
                    else
                    {					
                        method = target.GetType().GetMethod("Contains");
                        while (e.MoveNext() == true)
                        {
                            if ((contains = (bool)method.Invoke(target, new Object[] {e.Current})) == false)
                                break;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

                return contains;
            }

            /// <summary>
            /// Removes the specified element from the collection.
            /// </summary>
            /// <param name="c">The collection where the element will be removed.</param>
            /// <param name="obj">The element to remove from the collection.</param>
            public static bool Remove(System.Collections.ICollection c, System.Object obj)
            {
                bool changed = false;

                //Reflection. Invoke "remove" method for proprietary classes or "Remove" method
                System.Reflection.MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("remove");

                    if (method != null)
                        method.Invoke(c, new System.Object[] {obj});
                    else
                    {
                        method = c.GetType().GetMethod("Contains");
                        changed = (bool)method.Invoke(c, new System.Object[] {obj});
                        method = c.GetType().GetMethod("Remove");
                        method.Invoke(c, new System.Object[] {obj});
                    }
                }
                catch (System.Exception e)
                {
                    throw e;
                }

                return changed;
            }

            /// <summary>
            /// Removes all the elements from the specified collection that are contained in the target collection.
            /// </summary>
            /// <param name="target">Collection where the elements will be removed.</param>
            /// <param name="c">Elements to remove from the target collection.</param>
            /// <returns>true</returns>
            public static bool RemoveAll(System.Collections.ICollection target, System.Collections.ICollection c)
            {
                System.Collections.ArrayList al = ToArrayList(c);
                System.Collections.IEnumerator e = al.GetEnumerator();

                //Reflection. Invoke "removeAll" method for proprietary classes or "Remove" for each element in the collection
                System.Reflection.MethodInfo method;
                try
                {
                    method = target.GetType().GetMethod("removeAll");

                    if (method != null)
                        method.Invoke(target, new System.Object[] {al});
                    else
                    {
                        method = target.GetType().GetMethod("Remove");
                        System.Reflection.MethodInfo methodContains = target.GetType().GetMethod("Contains");

                        while (e.MoveNext() == true)
                        {
                            while ((bool) methodContains.Invoke(target, new System.Object[] {e.Current}) == true)
                                method.Invoke(target, new System.Object[] {e.Current});
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                return true;
            }

            /// <summary>
            /// Retains the elements in the target collection that are contained in the specified collection
            /// </summary>
            /// <param name="target">Collection where the elements will be removed.</param>
            /// <param name="c">Elements to be retained in the target collection.</param>
            /// <returns>true</returns>
            public static bool RetainAll(System.Collections.ICollection target, System.Collections.ICollection c)
            {
                System.Collections.IEnumerator e = new System.Collections.ArrayList(target).GetEnumerator();
                System.Collections.ArrayList al = new System.Collections.ArrayList(c);

                //Reflection. Invoke "retainAll" method for proprietary classes or "Remove" for each element in the collection
                System.Reflection.MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("retainAll");

                    if (method != null)
                        method.Invoke(target, new System.Object[] {c});
                    else
                    {
                        method = c.GetType().GetMethod("Remove");

                        while (e.MoveNext() == true)
                        {
                            if (al.Contains(e.Current) == false)
                                method.Invoke(target, new System.Object[] {e.Current});
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

                return true;
            }

            /// <summary>
            /// Returns an array containing all the elements of the collection.
            /// </summary>
            /// <returns>The array containing all the elements of the collection.</returns>
            public static System.Object[] ToArray(System.Collections.ICollection c)
            {	
                int index = 0;
                System.Object[] objects = new System.Object[c.Count];
                System.Collections.IEnumerator e = c.GetEnumerator();

                while (e.MoveNext())
                    objects[index++] = e.Current;

                return objects;
            }

            /// <summary>
            /// Obtains an array containing all the elements of the collection.
            /// </summary>
            /// <param name="objects">The array into which the elements of the collection will be stored.</param>
            /// <returns>The array containing all the elements of the collection.</returns>
            public static System.Object[] ToArray(System.Collections.ICollection c, System.Object[] objects)
            {	
                int index = 0;

                System.Type type = objects.GetType().GetElementType();
                System.Object[] objs = (System.Object[]) Array.CreateInstance(type, c.Count );

                System.Collections.IEnumerator e = c.GetEnumerator();

                while (e.MoveNext())
                    objs[index++] = e.Current;

                //If objects is smaller than c then do not return the new array in the parameter
                if (objects.Length >= c.Count)
                    objs.CopyTo(objects, 0);

                return objs;
            }

            /// <summary>
            /// Converts an ICollection instance to an ArrayList instance.
            /// </summary>
            /// <param name="c">The ICollection instance to be converted.</param>
            /// <returns>An ArrayList instance in which its elements are the elements of the ICollection instance.</returns>
            public static System.Collections.ArrayList ToArrayList(System.Collections.ICollection c)
            {
                System.Collections.ArrayList tempArrayList = new System.Collections.ArrayList();
                System.Collections.IEnumerator tempEnumerator = c.GetEnumerator();
                while (tempEnumerator.MoveNext())
                    tempArrayList.Add(tempEnumerator.Current);
                return tempArrayList;
            }
        }


        /*******************************/
        /// <summary>
        /// Provides support for DateFormat
        /// </summary>
        public class DateTimeFormatManager
        {
            static public DateTimeFormatHashTable manager = new DateTimeFormatHashTable();

            /// <summary>
            /// Hashtable class to provide functionality for dateformat properties
            /// </summary>
            public class DateTimeFormatHashTable :System.Collections.Hashtable 
            {
                /// <summary>
                /// Sets the format for datetime.
                /// </summary>
                /// <param name="format">DateTimeFormat instance to set the pattern</param>
                /// <param name="newPattern">A string with the pattern format</param>
                public void SetDateFormatPattern(System.Globalization.DateTimeFormatInfo format, string newPattern)
                {
                    if (this[format] != null)
                        ((DateTimeFormatProperties) this[format]).DateFormatPattern = newPattern;
                    else
                    {
                        DateTimeFormatProperties tempProps = new DateTimeFormatProperties();
                        tempProps.DateFormatPattern  = newPattern;
                        Add(format, tempProps);
                    }
                }

                /// <summary>
                /// Gets the current format pattern of the DateTimeFormat instance
                /// </summary>
                /// <param name="format">The DateTimeFormat instance which the value will be obtained</param>
                /// <returns>The string representing the current datetimeformat pattern</returns>
                public string GetDateFormatPattern(System.Globalization.DateTimeFormatInfo format)
                {
                    if (this[format] == null)
                        return "d-MMM-yy";
                    else
                        return ((DateTimeFormatProperties) this[format]).DateFormatPattern;
                }
		
                /// <summary>
                /// Sets the datetimeformat pattern to the giving format
                /// </summary>
                /// <param name="format">The datetimeformat instance to set</param>
                /// <param name="newPattern">The new datetimeformat pattern</param>
                public void SetTimeFormatPattern(System.Globalization.DateTimeFormatInfo format, string newPattern)
                {
                    if (this[format] != null)
                        ((DateTimeFormatProperties) this[format]).TimeFormatPattern = newPattern;
                    else
                    {
                        DateTimeFormatProperties tempProps = new DateTimeFormatProperties();
                        tempProps.TimeFormatPattern  = newPattern;
                        Add(format, tempProps);
                    }
                }

                /// <summary>
                /// Gets the current format pattern of the DateTimeFormat instance
                /// </summary>
                /// <param name="format">The DateTimeFormat instance which the value will be obtained</param>
                /// <returns>The string representing the current datetimeformat pattern</returns>
                public string GetTimeFormatPattern(System.Globalization.DateTimeFormatInfo format)
                {
                    if (this[format] == null)
                        return "h:mm:ss tt";
                    else
                        return ((DateTimeFormatProperties) this[format]).TimeFormatPattern;
                }

                /// <summary>
                /// Internal class to provides the DateFormat and TimeFormat pattern properties on .NET
                /// </summary>
                class DateTimeFormatProperties
                {
                    public string DateFormatPattern = "d-MMM-yy";
                    public string TimeFormatPattern = "h:mm:ss tt";
                }
            }	
        }
        /*******************************/
        /// <summary>
        /// Gets the DateTimeFormat instance and date instance to obtain the date with the format passed
        /// </summary>
        /// <param name="format">The DateTimeFormat to obtain the time and date pattern</param>
        /// <param name="date">The date instance used to get the date</param>
        /// <returns>A string representing the date with the time and date patterns</returns>
        public static string FormatDateTime(System.Globalization.DateTimeFormatInfo format, System.DateTime date)
        {
            string timePattern = DateTimeFormatManager.manager.GetTimeFormatPattern(format);
            string datePattern = DateTimeFormatManager.manager.GetDateFormatPattern(format);
            return date.ToString(datePattern + " " + timePattern, format);            
        }

        /*******************************/
        /// <summary>
        /// This class manages different features for calendars.
        /// The different calendars are internally managed using a hashtable structure.
        /// </summary>
        public class CalendarManager
        {
            /// <summary>
            /// Field used to get or set the year.
            /// </summary>
            public const int YEAR = 1;

            /// <summary>
            /// Field used to get or set the month.
            /// </summary>
            public const int MONTH = 2;
		
            /// <summary>
            /// Field used to get or set the day of the month.
            /// </summary>
            public const int DATE = 5;
		
            /// <summary>
            /// Field used to get or set the hour of the morning or afternoon.
            /// </summary>
            public const int HOUR = 10;
		
            /// <summary>
            /// Field used to get or set the minute within the hour.
            /// </summary>
            public const int MINUTE = 12;
		
            /// <summary>
            /// Field used to get or set the second within the minute.
            /// </summary>
            public const int SECOND = 13;
		
            /// <summary>
            /// Field used to get or set the millisecond within the second.
            /// </summary>
            public const int MILLISECOND = 14;
		
            /// <summary>
            /// Field used to get or set the day of the year.
            /// </summary>
            public const int DAY_OF_YEAR = 4;
		
            /// <summary>
            /// Field used to get or set the day of the month.
            /// </summary>
            public const int DAY_OF_MONTH = 6;
		
            /// <summary>
            /// Field used to get or set the day of the week.
            /// </summary>
            public const int DAY_OF_WEEK = 7;
		
            /// <summary>
            /// Field used to get or set the hour of the day.
            /// </summary>
            public const int HOUR_OF_DAY = 11;
		
            /// <summary>
            /// Field used to get or set whether the HOUR is before or after noon.
            /// </summary>
            public const int AM_PM = 9;
		
            /// <summary>
            /// Field used to get or set the value of the AM_PM field which indicates the period of the day from midnight to just before noon.
            /// </summary>
            public const int AM = 0;
		
            /// <summary>
            /// Field used to get or set the value of the AM_PM field which indicates the period of the day from noon to just before midnight.
            /// </summary>
            public const int PM = 1;
		
            /// <summary>
            /// The hashtable that contains the calendars and its properties.
            /// </summary>
            static public CalendarHashTable manager = new CalendarHashTable();

            /// <summary>
            /// Internal class that inherits from HashTable to manage the different calendars.
            /// This structure will contain an instance of System.Globalization.Calendar that represents 
            /// a type of calendar and its properties (represented by an instance of CalendarProperties 
            /// class).
            /// </summary>
            public class CalendarHashTable:System.Collections.Hashtable 
            {
                /// <summary>
                /// Gets the calendar current date and time.
                /// </summary>
                /// <param name="calendar">The calendar to get its current date and time.</param>
                /// <returns>A System.DateTime value that indicates the current date and time for the 
                /// calendar given.</returns>
                public System.DateTime GetDateTime(System.Globalization.Calendar calendar)
                {
                    if (this[calendar] != null)
                        return ((CalendarProperties) this[calendar]).dateTime;
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        return this.GetDateTime(calendar);
                    }
                }

                /// <summary>
                /// Sets the specified System.DateTime value to the specified calendar.
                /// </summary>
                /// <param name="calendar">The calendar to set its date.</param>
                /// <param name="date">The System.DateTime value to set to the calendar.</param>
                public void SetDateTime(System.Globalization.Calendar calendar, System.DateTime date)
                {
                    if (this[calendar] != null)
                    {
                        ((CalendarProperties) this[calendar]).dateTime = date;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = date;
                        this.Add(calendar, tempProps);
                    }
                }

                /// <summary>
                /// Sets the corresponding field in an specified calendar with the value given.
                /// If the specified calendar does not have exist in the hash table, it creates a 
                /// new instance of the calendar with the current date and time and then assings it 
                /// the new specified value.
                /// </summary>
                /// <param name="calendar">The calendar to set its date or time.</param>
                /// <param name="field">One of the fields that composes a date/time.</param>
                /// <param name="fieldValue">The value to be set.</param>
                public void Set(System.Globalization.Calendar calendar, int field, int fieldValue)
                {
                    if (this[calendar] != null)
                    {
                        System.DateTime tempDate = ((CalendarProperties) this[calendar]).dateTime;
                        switch (field)
                        {
                            case CalendarManager.DATE:
                                tempDate = tempDate.AddDays(fieldValue - tempDate.Day);
                                break;
                            case CalendarManager.HOUR:
                                tempDate = tempDate.AddHours(fieldValue - tempDate.Hour);
                                break;
                            case CalendarManager.MILLISECOND:
                                tempDate = tempDate.AddMilliseconds(fieldValue - tempDate.Millisecond);
                                break;
                            case CalendarManager.MINUTE:
                                tempDate = tempDate.AddMinutes(fieldValue - tempDate.Minute);
                                break;
                            case CalendarManager.MONTH:
                                //Month value is 0-based. e.g., 0 for January
                                tempDate = tempDate.AddMonths((fieldValue + 1) - tempDate.Month);
                                break;
                            case CalendarManager.SECOND:
                                tempDate = tempDate.AddSeconds(fieldValue - tempDate.Second);
                                break;
                            case CalendarManager.YEAR:
                                tempDate = tempDate.AddYears(fieldValue - tempDate.Year);
                                break;
                            case CalendarManager.DAY_OF_MONTH:
                                tempDate = tempDate.AddDays(fieldValue - tempDate.Day);
                                break;
                            case CalendarManager.DAY_OF_WEEK:
                                tempDate = tempDate.AddDays((fieldValue - 1) - (int)tempDate.DayOfWeek);
                                break;
                            case CalendarManager.DAY_OF_YEAR:
                                tempDate = tempDate.AddDays(fieldValue - tempDate.DayOfYear);
                                break;
                            case CalendarManager.HOUR_OF_DAY:
                                tempDate = tempDate.AddHours(fieldValue - tempDate.Hour);
                                break;

                            default:
                                break;
                        }
                        ((CalendarProperties) this[calendar]).dateTime = tempDate;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        this.Set(calendar, field, fieldValue);
                    }
                }

                /// <summary>
                /// Sets the corresponding date (day, month and year) to the calendar specified.
                /// If the calendar does not exist in the hash table, it creates a new instance and sets 
                /// its values.
                /// </summary>
                /// <param name="calendar">The calendar to set its date.</param>
                /// <param name="year">Integer value that represent the year.</param>
                /// <param name="month">Integer value that represent the month.</param>
                /// <param name="day">Integer value that represent the day.</param>
                public void Set(System.Globalization.Calendar calendar, int year, int month, int day)
                {
                    if (this[calendar] != null)
                    {
                        this.Set(calendar, CalendarManager.YEAR, year);
                        this.Set(calendar, CalendarManager.MONTH, month);
                        this.Set(calendar, CalendarManager.DATE, day);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        this.Set(calendar, year, month, day);
                    }
                }

                /// <summary>
                /// Sets the corresponding date (day, month and year) and hour (hour and minute) 
                /// to the calendar specified.
                /// If the calendar does not exist in the hash table, it creates a new instance and sets 
                /// its values.
                /// </summary>
                /// <param name="calendar">The calendar to set its date and time.</param>
                /// <param name="year">Integer value that represent the year.</param>
                /// <param name="month">Integer value that represent the month.</param>
                /// <param name="day">Integer value that represent the day.</param>
                /// <param name="hour">Integer value that represent the hour.</param>
                /// <param name="minute">Integer value that represent the minutes.</param>
                public void Set(System.Globalization.Calendar calendar, int year, int month, int day, int hour, int minute)
                {
                    if (this[calendar] != null)
                    {
                        this.Set(calendar, CalendarManager.YEAR, year);
                        this.Set(calendar, CalendarManager.MONTH, month);
                        this.Set(calendar, CalendarManager.DATE, day);
                        this.Set(calendar, CalendarManager.HOUR, hour);
                        this.Set(calendar, CalendarManager.MINUTE, minute);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        this.Set(calendar, year, month, day, hour, minute);
                    }
                }

                /// <summary>
                /// Sets the corresponding date (day, month and year) and hour (hour, minute and second) 
                /// to the calendar specified.
                /// If the calendar does not exist in the hash table, it creates a new instance and sets 
                /// its values.
                /// </summary>
                /// <param name="calendar">The calendar to set its date and time.</param>
                /// <param name="year">Integer value that represent the year.</param>
                /// <param name="month">Integer value that represent the month.</param>
                /// <param name="day">Integer value that represent the day.</param>
                /// <param name="hour">Integer value that represent the hour.</param>
                /// <param name="minute">Integer value that represent the minutes.</param>
                /// <param name="second">Integer value that represent the seconds.</param>
                public void Set(System.Globalization.Calendar calendar, int year, int month, int day, int hour, int minute, int second)
                {
                    if (this[calendar] != null)
                    {
                        this.Set(calendar, CalendarManager.YEAR, year);
                        this.Set(calendar, CalendarManager.MONTH, month);
                        this.Set(calendar, CalendarManager.DATE, day);
                        this.Set(calendar, CalendarManager.HOUR, hour);
                        this.Set(calendar, CalendarManager.MINUTE, minute);
                        this.Set(calendar, CalendarManager.SECOND, second);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        this.Set(calendar, year, month, day, hour, minute, second);
                    }
                }

                /// <summary>
                /// Gets the value represented by the field specified.
                /// </summary>
                /// <param name="calendar">The calendar to get its date or time.</param>
                /// <param name="field">One of the field that composes a date/time.</param>
                /// <returns>The integer value for the field given.</returns>
                public int Get(System.Globalization.Calendar calendar, int field)
                {
                    if (this[calendar] != null)
                    {
                        int tempHour;
                        switch (field)
                        {
                            case CalendarManager.DATE:
                                return ((CalendarProperties) this[calendar]).dateTime.Day;
                            case CalendarManager.HOUR:
                                tempHour = ((CalendarProperties) this[calendar]).dateTime.Hour;
                                return tempHour > 12 ? tempHour - 12 : tempHour;
                            case CalendarManager.MILLISECOND:
                                return ((CalendarProperties) this[calendar]).dateTime.Millisecond;
                            case CalendarManager.MINUTE:
                                return ((CalendarProperties) this[calendar]).dateTime.Minute;
                            case CalendarManager.MONTH:
                                //Month value is 0-based. e.g., 0 for January
                                return ((CalendarProperties) this[calendar]).dateTime.Month - 1;
                            case CalendarManager.SECOND:
                                return ((CalendarProperties) this[calendar]).dateTime.Second;
                            case CalendarManager.YEAR:
                                return ((CalendarProperties) this[calendar]).dateTime.Year;
                            case CalendarManager.DAY_OF_MONTH:
                                return ((CalendarProperties) this[calendar]).dateTime.Day;
                            case CalendarManager.DAY_OF_YEAR:							
                                return (int)(((CalendarProperties) this[calendar]).dateTime.DayOfYear);
                            case CalendarManager.DAY_OF_WEEK:
                                return (int)(((CalendarProperties) this[calendar]).dateTime.DayOfWeek) + 1;
                            case CalendarManager.HOUR_OF_DAY:
                                return ((CalendarProperties) this[calendar]).dateTime.Hour;
                            case CalendarManager.AM_PM:
                                tempHour = ((CalendarProperties) this[calendar]).dateTime.Hour;
                                return tempHour > 12 ? CalendarManager.PM : CalendarManager.AM;

                            default:
                                return 0;
                        }
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        return this.Get(calendar, field);
                    }
                }

                /// <summary>
                /// Sets the time in the specified calendar with the long value.
                /// </summary>
                /// <param name="calendar">The calendar to set its date and time.</param>
                /// <param name="milliseconds">A long value that indicates the milliseconds to be set to 
                /// the hour for the calendar.</param>
                public void SetTimeInMilliseconds(System.Globalization.Calendar calendar, long milliseconds)
                {
                    if (this[calendar] != null)
                    {
                        ((CalendarProperties) this[calendar]).dateTime = new System.DateTime(milliseconds);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = new System.DateTime(System.TimeSpan.TicksPerMillisecond * milliseconds);
                        this.Add(calendar, tempProps);
                    }
                }
				
                /// <summary>
                /// Gets what the first day of the week is; e.g., Sunday in US, Monday in France.
                /// </summary>
                /// <param name="calendar">The calendar to get its first day of the week.</param>
                /// <returns>A System.DayOfWeek value indicating the first day of the week.</returns>
                public System.DayOfWeek GetFirstDayOfWeek(System.Globalization.Calendar calendar)
                {
                    if (this[calendar] != null)
                    {
                        if (((CalendarProperties)this[calendar]).dateTimeFormat == null)
                        {
                            ((CalendarProperties)this[calendar]).dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
                            ((CalendarProperties)this[calendar]).dateTimeFormat.FirstDayOfWeek = System.DayOfWeek.Sunday;
                        }
                        return ((CalendarProperties) this[calendar]).dateTimeFormat.FirstDayOfWeek;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        tempProps.dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
                        tempProps.dateTimeFormat.FirstDayOfWeek = System.DayOfWeek.Sunday;
                        this.Add(calendar, tempProps);
                        return this.GetFirstDayOfWeek(calendar);
                    }
                }

                /// <summary>
                /// Sets what the first day of the week is; e.g., Sunday in US, Monday in France.
                /// </summary>
                /// <param name="calendar">The calendar to set its first day of the week.</param>
                /// <param name="firstDayOfWeek">A System.DayOfWeek value indicating the first day of the week
                /// to be set.</param>
                public void SetFirstDayOfWeek(System.Globalization.Calendar calendar, System.DayOfWeek  firstDayOfWeek)
                {
                    if (this[calendar] != null)
                    {
                        if (((CalendarProperties)this[calendar]).dateTimeFormat == null)
                            ((CalendarProperties)this[calendar]).dateTimeFormat = new System.Globalization.DateTimeFormatInfo();

                        ((CalendarProperties) this[calendar]).dateTimeFormat.FirstDayOfWeek = firstDayOfWeek;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        tempProps.dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
                        this.Add(calendar, tempProps);
                        this.SetFirstDayOfWeek(calendar, firstDayOfWeek);
                    }
                }

                /// <summary>
                /// Removes the specified calendar from the hash table.
                /// </summary>
                /// <param name="calendar">The calendar to be removed.</param>
                public void Clear(System.Globalization.Calendar calendar)
                {
                    if (this[calendar] != null)
                        this.Remove(calendar);
                }

                /// <summary>
                /// Removes the specified field from the calendar given.
                /// If the field does not exists in the calendar, the calendar is removed from the table.
                /// </summary>
                /// <param name="calendar">The calendar to remove the value from.</param>
                /// <param name="field">The field to be removed from the calendar.</param>
                public void Clear(System.Globalization.Calendar calendar, int field)
                {
                    if (this[calendar] != null)
                        this.Set(calendar, field, 0);
                }

                /// <summary>
                /// Internal class that represents the properties of a calendar instance.
                /// </summary>
                class CalendarProperties
                {
                    /// <summary>
                    /// The date and time of a calendar.
                    /// </summary>
                    public System.DateTime dateTime;
				
                    /// <summary>
                    /// The format for the date and time in a calendar.
                    /// </summary>
                    public System.Globalization.DateTimeFormatInfo dateTimeFormat;
                }
            }
        }
        /*******************************/
        /// <summary>
        /// Creates a new positive random number. Fijarse la clase RandomProvider de FutbolMatch 
        /// </summary>
        /// <param name="random">The last random obtained</param>
        /// <returns>Returns a new positive random number</returns>
        public static long NextLong(System.Random random)
        {
            long temporaryLong = random.Next();
            temporaryLong = (temporaryLong << 32)+ random.Next();
            if (random.Next(-1,1) < 0)
                return -temporaryLong;
            else
                return temporaryLong;
        }
    }
}
