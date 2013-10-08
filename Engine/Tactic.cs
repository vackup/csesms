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
* Tactic.java
*
* Created on 26 dicembre 2003, 9.46
*/
using System;

namespace CSEsMS.Engine
{
    /// <summary> This class probably can be moved into the ESMS package, but since it is used
    /// in the TeamStatus object (which must be in Engine) it is in Engine too
    /// </summary>
    public class Tactic : XmlSaxContentHandler
    {
        #region Propiedades
        virtual public string Name
        {
            get
            {
                return _name;
            }

        }
        #endregion

        #region Campos
        public static System.Collections.Hashtable _Tactics;

        private string _name;

        private Mult[] _mults;
        private Bonus[] _bonuses;

        /*---------- Interface ContentHandler ----------*/
        private System.Collections.ArrayList _tagStack;
        private System.Collections.ArrayList _vMults;
        private System.Collections.ArrayList _vBonuses;
        private string _currentName;
        #endregion

        #region Constructores
        /// <summary>Creates a new instance of Tactic </summary>
        public Tactic(string tacticName, Mult[] mults, Bonus[] bonuses)
        {
            this._name = tacticName;
            this._mults = mults;
            this._bonuses = bonuses;
        }


        /// <summary>This private constructor should be called just inside the <CODE>parseTactics</CODE>
        /// static method, where it is used to parse tactics.xml file.
        /// Probably not very elegant, these functions could be moved in a separate
        /// TacticsParser class, we'll see...
        /// </summary>
        private Tactic()
        {
            _tagStack = new System.Collections.ArrayList();
            _vBonuses = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
            _vMults = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
        }
        #endregion

        public virtual double getMult(string oppTactic, string position, string skill)
        {
            double answer = 0.0;
            for (int i = 0; i < _mults.Length; i++)
                answer += _mults[i].getValue(position, skill);
            for (int i = 0; i < _bonuses.Length; i++)
                answer += _bonuses[i].getValue(oppTactic, position, skill);
            return answer;
        }
		
        public virtual void  remove(MatchStatus status)
        {
            for (int i = 0; i < _mults.Length; i++)
                _mults[i].remove(status);
            for (int i = 0; i < _bonuses.Length; i++)
                _bonuses[i].remove(status);
        }

        #region Metodos para trabajar con el XML (rremplazar con DAL)
        public static void  parseTactics(System.IO.Stream str)
        {
            throw new NotImplementedException("Error en Engine.Fixtures.parseTactics(System.IO.Stream str). HZ: este metodo se usa para parsear (??? ver la logica) la tactica. Reemplazar por el DAL");

            //Tactics = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
			
            //try
            //{
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //    XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
            //    parser.setContentHandler(new Tactic());
            //    parser.parse(new XmlSourceSupport(str));
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
            //    System.Console.Out.WriteLine("Error while parsing XML in tactic file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading tactic file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
		
        /// <summary>Method used to load tactics from the new tactics.dat file (tactics.xml) inside
        /// the <CODE>Tactics</CODE> hashtable
        /// </summary>
        public static void  parseTactics(string fileName)
        {
            throw new NotImplementedException("Error en Engine.Fixtures.parseTactics(string fileName). HZ: este metodo se usa para parsear (??? ver la logica) la tactica. Reemplazar por el DAL");
            
            //Tactics = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
			
            //try
            //{
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //    XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
            //    //UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
            //    //UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //    System.IO.StreamReader r = new System.IO.StreamReader(fileName, System.Text.Encoding.Default);
            //    parser.setContentHandler(new Tactic());
            //    parser.parse(new XmlSourceSupport(r));
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
            //    System.Console.Out.WriteLine("Error while parsing XML in tactic file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading tactic file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }

        public virtual void endElement(string str, string str2, string tag)
        {
            if ((System.Object)tag == (System.Object)"Tactic")
            {
                Tactic tac = new Tactic(_currentName, (Mult[])SupportClass.ICollectionSupport.ToArray(_vMults, new Mult[0]), (Bonus[])SupportClass.ICollectionSupport.ToArray(_vBonuses, new Bonus[0]));
                Tactic._Tactics[_currentName] = tac;

                //Dump arrays and other functions
                _vMults.Clear();
                _vBonuses.Clear();
                _currentName = null;
            }
            SupportClass.StackSupport.Pop(_tagStack);
        }

        public virtual void startElement(string str, string str2, string tag, SaxAttributesSupport attributes)
        {
            _tagStack.Add(tag);

            if ((System.Object)tag == (System.Object)"Tactic")
            {
                _currentName = attributes.GetValue("name");
            }
            else if ((System.Object)tag == (System.Object)"Bonus" || (System.Object)tag == (System.Object)"Mult")
            {
                string position = attributes.GetValue("position");
                string skill = attributes.GetValue("skill");
                string multiplier = attributes.GetValue("multiplier");
                if ((System.Object)tag == (System.Object)"Bonus")
                {
                    string oppTactic = attributes.GetValue("oppTactic");
                    Bonus temp = new Bonus(oppTactic, position, skill, multiplier);
                    _vBonuses.Add(temp);
                }
                else
                {
                    Mult temp = new Mult(position, skill, multiplier);
                    _vMults.Add(temp);
                }
            }
        }
        #endregion

        #region Metodos Vacios
        public virtual void  characters(System.Char[] text, int start, int length)
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
		
        public virtual void  startDocument()
        {
        }
		
        public virtual void  startPrefixMapping(string str, string str1)
        {
        }
        #endregion

        #region Metodo de testing
        /* Use during test only!!!*/
        public static void printTactics()
        {
            System.Collections.IEnumerator E = _Tactics.Keys.GetEnumerator();
            //UPGRADE_TODO: Method 'java.util.Enumeration.hasMoreElements' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationhasMoreElements'"
            while (E.MoveNext())
            {
                //UPGRADE_TODO: Method 'java.util.Enumeration.nextElement' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationnextElement'"
                string key = (string)E.Current;
                System.Console.Out.WriteLine(key);
                System.Console.Out.WriteLine(((Tactic)_Tactics[key])._bonuses.Length);
            }
        }
        #endregion

        /*    public void apply(MatchStatus status)
		{
		for(int i=0;i<mults.length;i++)
		mults[i].apply(status);
		for(int i=0;i<bonuses.length;i++)
		bonuses[i].apply(status);        
		}*/
    }
}