/* JEsMS (Romeo) -  A Java soccer management game
* Copyright (C) 2004  Angelo Scotto (scotto_a@hotmail.com)
* 
* This program is free software; you can redistribute it and/or
* modify it under the terms of the GNU General Public License
* as published by the Free Software Foundation; either version 2
* of the License, or (at your option) any later version.
* 
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License
* along with this program; if not, write to the Free Software
* Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/

/*
* Comment.java
*
* Created on 25 dicembre 2003, 15.57
*/
using System;
//UPGRADE_TODO: The package 'java.util.regex' could not be found. If it was not included in the conversion, there may be compiler issues. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1262'"
//using java.util.regex;

namespace CSEsMS.ESMS
{
    /// <summary> The Comment class is a _singleton wrapping the content of the new language.dat
    /// (language.xml).
    /// It's part of the ESMS package and not of the Engine package because its services 
    /// are requested only by the ESMS to generate the match commentaries.
    /// </summary>
    /// <author>   Angelo Scotto
    /// </author>
    public class Comment : XmlSaxContentHandler
    {
		
        private System.Random _rnd;
		
        private static Comment _singleton;
		
        private System.Collections.Hashtable _table;
        private System.Collections.ArrayList _tagStack;
        private string _currentType;
		
        public static void  loadComment(string fileName)
        {
            _singleton = new Comment(fileName);
        }
		
        public static Comment getComment()
        {
            if (_singleton == null)
                _singleton = new Comment("language.xml");
            return _singleton;
        }
		
        //[STAThread]
        //public static void  Main(string[] args)
        //{
        //    //UPGRADE_ISSUE: Constructor 'java.text.SimpleDateFormat.SimpleDateFormat' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javatextSimpleDateFormat'"
        //    //UPGRADE_TODO: The equivalent in .NET for method 'java.util.Calendar.getTime' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
        //    System.Console.Out.WriteLine(Version.Name + " Language.dat Importer Version " + Version.getVersion() + " - " + Version.Codename + " (" + SupportClass.FormatDateTime(new SimpleDateFormat("dd MMM yyyy"), SupportClass.CalendarManager.manager.GetDateTime(Version.LastBuild)) + ")\r\n" + Version.Features + "\r\n" + Version.Author);
        //    try
        //    {
        //        convertFromESMS(new System.IO.FileInfo(args[0]), new System.IO.FileInfo(args[1]));
        //    }
        //    catch (System.IO.IOException err)
        //    {
        //        //UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Throwable.toString' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
        //        System.Console.Out.WriteLine(err.ToString());
        //    }
        //}
		
        //private static void  convertFromESMS(System.IO.FileInfo source, System.IO.FileInfo destination)
        //{
        //    //UPGRADE_TODO: The differences in the expected value  of parameters for constructor 'java.io.BufferedReader.BufferedReader'  may cause compilation errors.  "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1092'"
        //    //UPGRADE_WARNING: At least one expression was used more than once in the target code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1181'"
        //    //UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
        //    System.IO.StreamReader read = new System.IO.StreamReader(new System.IO.StreamReader(source.FullName, System.Text.Encoding.Default).BaseStream, new System.IO.StreamReader(source.FullName, System.Text.Encoding.Default).CurrentEncoding);
        //    //UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
        //    //UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javaioFile'"
        //    System.IO.StreamWriter w = new System.IO.StreamWriter(new System.IO.FileStream(destination.FullName, System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
			
        //    w.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
        //    w.Write("<Language>");
        //    Pattern p = Pattern.compile("\\[([A-Z,_]*)\\]\\ \\{\\\\n\\ *(...|.*)(.*)\\}");
        //    string text;
        //    while (read.Peek() != -1 && (text = read.ReadLine()) != null)
        //    {
        //        //String text = read.readLine();
        //        Matcher m = p.matcher(text);
        //        while (!m.matches())
        //        {
        //            if (!(read.Peek() != -1))
        //            {
        //                w.Write("</Language>");
        //                w.Flush();
        //                w.Close();
        //                return ;
        //            }
        //            text = read.ReadLine();
        //            m = p.matcher(text);
        //        }
        //        w.Write("<Comment type=\"" + m.group(1) + "\" followup=\"");
        //        w.Write(Boolean.toString(m.group(2).equals("...")) + "\">");
        //        if (!m.group(2).equals("..."))
        //            w.write(m.group(2));
        //        w.write(m.group(3));
        //        w.Write("</Comment>");
        //        w.Write("\r\n");
        //        w.Flush();
        //    }
        //    w.Write("</Language>");
        //    w.Flush();
        //    w.Close();
        //}
		
        /// <summary>Creates a new instance of Comment </summary>
        private Comment(string fileName)
        {
            throw new NotImplementedException("Error en ESMS.Comment.Comment(string fileName) - HZ: este metodo no se si sirve de mucho, ver donde se utiliza. Cambiar el XML por el DAL.");
            /* Usually this function is called
			from inside the ESMS so the RandomGenerator has been already 
			instantiated but, just in case, if the RandomGenerator has still to be
			instantiated we will raise an instance with randomized seed */
            //      try
            //      {
            _rnd = CSEsMS.ESMS.ESMS.Random;
            //      }
            //      catch(NullPointerException err)
            //      {
            //          ESMS.setRandomEngine();
            //          _rnd = ESMS.getRandom();
            //      }
			
            _table = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
            _tagStack = new System.Collections.ArrayList();
			
            try
            {
                //UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
                XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
                //UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
                //UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
                System.IO.StreamReader r = new System.IO.StreamReader(fileName, System.Text.Encoding.Default);
                parser.setContentHandler(this);
                parser.parse(new XmlSourceSupport(r));
            }
                //UPGRADE_ISSUE: Class 'javax.xml.parsers.ParserConfigurationException' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersParserConfigurationException'"
                //catch (javax.xml.parsers.ParserConfigurationException err)
            catch (Exception err)
            {
                System.Console.Out.WriteLine("Error while parsing XML in language.xml");
                SupportClass.WriteStackTrace(err, Console.Error);
            }
            //UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //catch (System.Xml.XmlException err)
            //{
            //    System.Console.Out.WriteLine("Error while parsing XML in language.xml");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading file language.xml");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
		
        /* Procedure used to test only !!! */
        public virtual void  printTable()
        {
            throw new NotImplementedException("Error en ESMS.Comment.printTable() - HZ: ver donde se utiliza. Cambiar el XML por el DAL.");
            
            
            System.Collections.IEnumerator E = _table.Keys.GetEnumerator();
            //UPGRADE_TODO: Method 'java.util.Enumeration.hasMoreElements' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationhasMoreElements'"
            while (E.MoveNext())
            {
                //UPGRADE_TODO: Method 'java.util.Enumeration.nextElement' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationnextElement'"
                string key = (string) E.Current;
                System.Console.Out.WriteLine(key + ":");
                System.Collections.ArrayList v = ((System.Collections.ArrayList) _table[key]);
                System.Console.Out.WriteLine(v.Count);
                for (int i = 0; i < v.Count; i++)
                {
                    //UPGRADE_TODO: Method 'java.io.PrintStream.println' was converted to 'System.Console.Out.WriteLine' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioPrintStreamprintln_javalangObject'"
                    //UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
                    System.Console.Out.WriteLine(v[i]);
                }
            }
        }
		
        public virtual string getCommentString(string type, string[] params_Renamed)
        {
            throw new NotImplementedException("Error en ESMS.Comment.getCommentString(string type, string[] params_Renamed) - HZ: Esta dando error en 'answer.replaceFirst' debe haber en internet algun Helper para este metodo de los string, igualmente ver como se usa y reemplazar con DAL si es necesario.");
            
            System.Collections.ArrayList v = (System.Collections.ArrayList) _table[type];
            if (v == null)
                throw new System.NullReferenceException("no comments for type " + type + " loaded!");
            /* Extract a comment from vector v */
            string answer = ((string) v[_rnd.Next(v.Count)]);
            /* Replace %s with parameters */
            for (int i = 0; i < params_Renamed.Length; i++)
            {
                // TODO: HZ: Aca esta dando un error, vel el mensaje del NotImplementedException
                //answer = answer.replaceFirst("%s", params_Renamed[i]);
            }
            answer = answer.Replace("\\\\n", "\n");
            return answer;
        }
		
        public virtual string getCommentString(string type)
        {
            System.Collections.ArrayList v = (System.Collections.ArrayList) _table[type];
            if (v == null)
                throw new System.NullReferenceException("no comments for type " + type + " loaded!");
            /* Extract a comment from vector v */
            string answer = ((string) v[_rnd.Next(v.Count)]);
            answer = answer.Replace("\\\\n", "\n");
            return answer;
        }
		
        /*---------- Interface ContentHandler ----------*/
		
        private System.Text.StringBuilder sb;
		
        public virtual void  characters(System.Char[] text, int start, int length)
        {
            sb.Append(text, start, length);
            /*if (_tagStack.peek() == "Comment")
			{
			Vector commentList = (Vector)_table.get(_currentType);
			if (commentList == null) 
			{
			commentList = new Vector();
			_table.put(_currentType,commentList);
			}
			commentList.add(new String(text,start,length));
			}
			*/
        }
		
        public virtual void  endDocument()
        {
        }
		
        public virtual void  endElement(string str, string str1, string str2)
        {
			
            if (_tagStack[_tagStack.Count - 1] == (System.Object) "Comment")
            {
                System.Collections.ArrayList commentList = (System.Collections.ArrayList) _table[_currentType];
                if (commentList == null)
                {
                    commentList = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
                    _table[_currentType] = commentList;
                }
                commentList.Add(sb.ToString());
            }
			
            SupportClass.StackSupport.Pop(_tagStack);
        }
		
        public virtual void  endPrefixMapping(string str)
        {
        }
		
        //UPGRADE_TODO: Method 'org.xml.sax.ContentHandler.ignorableWhitespace' was converted to 'XmlSaxContentHandler.ignorableWhitespace' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
        public virtual void ignorableWhitespace(System.Char[] values, int param, int param2)
        {
        }
		
        public virtual void  processingInstruction(string str, string str1)
        {
        }
		
        //UPGRADE_TODO: The equivalent in .NET for method 'org.xml.sax.Locator' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
        public virtual void  setDocumentLocator(XmlSaxLocator locator)
        {
        }
		
        public virtual void  skippedEntity(string str)
        {
        }
		
        public virtual void  startDocument()
        {
        }
		
        public virtual void  startElement(string str, string str2, string tag, SaxAttributesSupport attributes)
        {
            _tagStack.Add(tag);
            sb = new System.Text.StringBuilder();
            if ((System.Object) tag == (System.Object) "Comment")
                _currentType = attributes.GetValue("type");
        }
		
        public virtual void  startPrefixMapping(string str, string str1)
        {
        }
    }
}