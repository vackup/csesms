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
* Fixtures.java
*
* Created on 1 gennaio 2004, 16.40
*/
using System;

namespace CSEsMS.Engine
{
    /// <summary>
    /// HZ: Representa el el fixture de la fecha del campeonato, por ejemplo: la fecha 1.
    /// En los constructures se encuentra la logica de cargado de la misma, el ID seria el XML que contiene la fecha (reemplazarlo por DAL)
    /// Esta clase no contiene mayor logica salvo algo con las semana asi que se podria reemplazar facilmente como un domain object.
    /// Sacar demas propiedades de este objeto y estados del metodo writeFixtures(string filename, string externalUrl)
    /// </summary>
    public class Fixtures : XmlSaxContentHandler
    {
        #region Propiedades
        virtual public string CompetitionName
        {
            get
            {
                return _competition;
            }
			
        }
        virtual public Week[] Weeks
        {
            get
            {
                return (Week[]) SupportClass.ICollectionSupport.ToArray(_weeks, new Week[0]);
            }
			
        }
        virtual public Week LastWeek
        {
            get
            {
                int index = _weeks.IndexOf(_nextWeek) - 1;
                if (index > 0)
                    return (Week) _weeks[index];
                else
                    return null;
            }

        }
        #endregion

        #region Campos
        public const int _LEAGUE = 0;
		
        private string[] _teams;
        private string _competition;
        private string _weekName;
        private int _type;
        private System.Collections.ArrayList _weeks;
        private Week _currentWeek;
        private Week _nextWeek = null;

        /*---------- Interface ContentHandler ----------*/
        private System.Collections.ArrayList _tagStack;
        #endregion

        #region Constructores
        public Fixtures(string filename)
        {
            throw new NotImplementedException("Error en Engine.Fixtures.Fixtures(string filename). HZ: este metodo se usa cargar un fixture desde un XML. Reemplazar por el DAL");

            //weeks = new System.Collections.ArrayList();
            //try
            //{
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //    XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
            //    //UPGRADE_TODO: Constructor 'java.io.FileInputStream.FileInputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileInputStreamFileInputStream_javalangString'"
            //    System.IO.Stream isr = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //    //UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
            //    //UPGRADE_TODO: Constructor 'java.io.InputStreamReader.InputStreamReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioInputStreamReaderInputStreamReader_javaioInputStream_javalangString'"
            //    System.IO.StreamReader r = new System.IO.StreamReader(isr, System.Text.Encoding.GetEncoding("iso-8859-1"));
            //    parser.setContentHandler(this);
            //    parser.parse(new XmlSourceSupport(r));
            //    setNextWeek();
            //}
            ////UPGRADE_ISSUE: Class 'javax.xml.parsers.ParserConfigurationException' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersParserConfigurationException'"
            //catch (javax.xml.parsers.ParserConfigurationException err)
            //{
            //    System.Console.Out.WriteLine("Error while parsing XML in fixtures.xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            ////UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //catch (System.Xml.XmlException err)
            //{
            //    System.Console.Out.WriteLine("Error while parsing XML in fixtures.xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading fixtures.xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
		
        /// <summary>Creates a new instance of Fixtures </summary>
        public Fixtures(System.IO.Stream str)
        {
            throw new NotImplementedException("Error en Engine.Fixtures.Fixtures(System.IO.Stream str). HZ: este metodo se usa cargar un fixture desde un XML. Reemplazar por el DAL");

            //weeks = new System.Collections.ArrayList();
            //try
            //{
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //    XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
            //    //UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
            //    //UPGRADE_TODO: Constructor 'java.io.InputStreamReader.InputStreamReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioInputStreamReaderInputStreamReader_javaioInputStream_javalangString'"
            //    System.IO.StreamReader r = new System.IO.StreamReader(str, System.Text.Encoding.GetEncoding("iso-8859-1"));
            //    parser.setContentHandler(this);
            //    parser.parse(new XmlSourceSupport(r));
            //    setNextWeek();
            //}
            ////UPGRADE_ISSUE: Class 'javax.xml.parsers.ParserConfigurationException' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersParserConfigurationException'"
            //catch (javax.xml.parsers.ParserConfigurationException err)
            //{
            //    System.Console.Out.WriteLine("Error while parsing XML in fixtures.xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            ////UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //catch (System.Xml.XmlException err)
            //{
            //    System.Console.Out.WriteLine("Error while parsing XML in fixtures.xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading fixtures.xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
        #endregion

        private void  setNextWeek()
        {
            for (int i = 0; i < _weeks.Count; i++)
            {
                Week w = ((Week) _weeks[i]);
                if (!w.hasBeenPlayed())
                {
                    _nextWeek = w; break;
                }
            }
        }
        public virtual Week getNextWeek()
        {
            return _nextWeek;
        }

        #region Metodos que trabajan con el XML (cambiar por el DAL)
        /// <summary>
        /// HZ: escribe un fixture en el XML
        /// </summary>
        public virtual void writeFixtures(string filename, string externalUrl)
        {
            // I need to merge xml...
            System.IO.FileInfo f = new System.IO.FileInfo(filename);
            //UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
            //UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javaioFile'"
            System.IO.StreamWriter str = new System.IO.StreamWriter(new System.IO.FileStream(f.FullName, System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
			
            str.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
            if (externalUrl != null)
                str.Write("<?xml-stylesheet type=\"text/xsl\" href=\"" + externalUrl + "\"?>");
            str.Write("<Fixtures competition=\"" + _competition + "\" weekName=\"" + _weekName + "\" type=\"League\">");
            for (int week = 0; week < this._weeks.Count; week++)
            {
                Week w = (Week) this._weeks[week];
                str.Write("<Week id=\"" + w.Id + "\" played=\"" + w.hasBeenPlayed() + "\">");
                Match[] m = w.Matches;
                if (!w.hasBeenPlayed())
                {
                    for (int match = 0; match < m.Length; match++)
                    {
                        str.Write("<Match id=\"" + m[match].Id + "\" homeTeam=\"" + m[match].HomeTeam + "\" awayTeam=\"" + m[match].AwayTeam + "\"/>");
                    }
                }
                else
                {
                    for (int match = 0; match < m.Length; match++)
                    {
                        str.Write("<Match id=\"" + m[match].Id + "\" homeTeam=\"" + m[match].HomeTeam + "\" awayTeam=\"" + m[match].AwayTeam + "\" homeScore=\"" + m[match].HomeScore + "\" awayScore=\"" + m[match].AwayScore + "\"/>");
                    }
                }
				
                str.Write("</Week>");
            }
            str.Write("</Fixtures>");
            str.Flush();
            str.Close();
        }

        public virtual void startDocument()
        {
            _tagStack = new System.Collections.ArrayList();
        }

        public virtual void startElement(string str, string str2, string tag, SaxAttributesSupport attributes)
        {
            _tagStack.Add(tag);
            if (tag.Equals("Fixtures"))
            {
                _competition = attributes.GetValue("competition");
                _weekName = attributes.GetValue("weekName");
                if (attributes.GetValue("type").Equals("League"))
                    _type = Fixtures._LEAGUE;
            }
            else if (tag.Equals("Week"))
            {
                _currentWeek = new Week(attributes.GetValue("id"));
                //UPGRADE_NOTE: Exceptions thrown by the equivalent in .NET of method 'java.lang.Boolean.valueOf' may be different. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1099'"
                _currentWeek.Played = System.Boolean.Parse(attributes.GetValue("played"));
                _weeks.Add(_currentWeek);
            }
            else if (tag.Equals("Match"))
            {
                Match m;
                if (_currentWeek.hasBeenPlayed())
                    m = new Match(attributes.GetValue("id"), attributes.GetValue("homeTeam"), System.Int32.Parse(attributes.GetValue("homeScore")), attributes.GetValue("awayTeam"), System.Int32.Parse(attributes.GetValue("awayScore")));
                else
                    m = new Match(attributes.GetValue("id"), attributes.GetValue("homeTeam"), attributes.GetValue("awayTeam"));
                _currentWeek.addMatch(m);
            }
        }
        
        public virtual void endElement(string str, string str1, string str2)
        {
            SupportClass.StackSupport.Pop(_tagStack);
        }
        #endregion

        #region Metodos vacios
        public virtual void  characters(System.Char[] values, int param, int param2)
        {
        }
		
        public virtual void  endDocument()
        {
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
		
        public virtual void  startPrefixMapping(string str, string str1)
        {
        }
        #endregion
    }
}