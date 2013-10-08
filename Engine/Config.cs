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
* Config.java
*
* Created on 25 dicembre 2003, 11.47
*/
using System;
using System.Collections.Generic;
using CSEsMS.Domain;
using CSEsMS.Domain.Entities;

namespace CSEsMS.Engine
{
    /// <summary> The Config class is a Singleton wrapping config info extracted by the
    /// new league.dat (league.xml) file
    /// </summary>
    public class Config // : XmlSaxContentHandler
    {
        virtual public System.Collections.ArrayList Teams
        {
            get
            {
                if (table == null)
                    throw new System.Exception("Config object still not initialized");
                System.Collections.ArrayList vTeams = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
                int counter = 0;
                System.Collections.IEnumerator keys = table.Keys.GetEnumerator();
                //UPGRADE_TODO: Method 'java.util.Enumeration.hasMoreElements' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationhasMoreElements'"
                while (keys.MoveNext())
                {
                    //UPGRADE_TODO: Method 'java.util.Enumeration.nextElement' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationnextElement'"
                    string key = (string) keys.Current;
                    if (key.Length == 3 && !key.Equals("CUP"))
                    {
                        vTeams.Add(table[key]); counter++;
                    }
                }
				
                return vTeams;
            }
			
        }
		
        public const int SHOOTOUT_NEVER = 0;
        public const int SHOOTOUT_ASK = 1;
        public const int SHOOTOUT_ALWAYS = 2;
		
        private System.Collections.Hashtable table;
		
        //public virtual System.Object getConfigValue(string key)
        //{
        //    throw new NotSupportedException("CSEsMS.Engine.Config.getConfigValue: HZ - Hay que cambiar este metedo por el nuevo metodo de configura, la entidad Liga por ejemplo");

        //    if (table == null)
        //        throw new System.Exception("Config object still not initialized");
        //    System.Object answer = table[key];
        //    if (answer == null)
        //        throw new System.Exception("Value " + key + " still has a null value");
        //    return answer;
        //}
		
        public virtual string getAbbreviationFromName(string name)
        {
            System.Collections.IEnumerator E = table.Keys.GetEnumerator();
            //UPGRADE_TODO: Method 'java.util.Enumeration.hasMoreElements' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationhasMoreElements'"
            while (E.MoveNext())
            {
                //UPGRADE_TODO: Method 'java.util.Enumeration.nextElement' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationnextElement'"
                string key = (string) E.Current;
                if (table[key].Equals(name))
                    return key;
            }
            return null;
        }
		
        //private Config(System.IO.Stream stream)
        //{
        //    throw new NotImplementedException("Error en Engine.Config.Config(System.IO.Stream stream). HZ: este metodo se usa para cargar la configuracion desde un XML. Reemplazar por el DAL");
            //table = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
            //tagStack = new System.Collections.ArrayList();
			
            //try
            //{
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //    XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
            //    //UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
            //    //UPGRADE_TODO: Constructor 'java.io.InputStreamReader.InputStreamReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioInputStreamReaderInputStreamReader_javaioInputStream_javalangString'"
            //    System.IO.StreamReader r = new System.IO.StreamReader(stream, System.Text.Encoding.GetEncoding("iso-8859-1"));
            //    parser.setContentHandler(this);
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
            //    System.Console.Out.WriteLine("Error while parsing XML in league.xml");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading file league.xml");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //setDefaults();
        //}
		
        private Config()
        {
            //throw new NotImplementedException("Error en Engine.Config.Config(string fileName). HZ: este metodo se usa para cargar la configuracion desde un XML. Reemplazar por el DAL");
            //table = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
            //tagStack = new System.Collections.ArrayList();
			
            //try
            //{
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //    XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
            //    //UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
            //    //UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //    System.IO.StreamReader r = new System.IO.StreamReader(fileName, System.Text.Encoding.Default);
            //    parser.setContentHandler(this);
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
            //    System.Console.Out.WriteLine("Error while parsing XML in league.xml");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading file league.xml");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //setDefaults();

            var sessionFactory = SessionFactory.CreateSessionFactory();

            // Cargo la configuracion de la liga (reemplaza a Config.loadConfig("league.xml") y
            // lo respectivo a buscar valores de configuracion
            // TODO: aca le asigno la liga de incide 0, hay que ver como quedaría, si se puede hacer la 
            // liga activa, etc.
            IList<League> Ligas;

            using (var session = sessionFactory.OpenSession())
            {
                // retreive all stores and display them
                using (session.BeginTransaction())
                {
                    Ligas = session.CreateCriteria(typeof(League)).List<League>();
                    _LigaSingleton = Ligas[0];

                    //foreach (var liga in Ligas)
                    //{
                    //    WriteStorePretty(liga);
                    //}
                }
            }
        }
		
		
        /* Procedure used to test only !!! */
        public virtual void  printTable()
        {
            System.Collections.IEnumerator E = table.Keys.GetEnumerator();
            //UPGRADE_TODO: Method 'java.util.Enumeration.hasMoreElements' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationhasMoreElements'"
            while (E.MoveNext())
            {
                //UPGRADE_TODO: Method 'java.util.Enumeration.nextElement' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationnextElement'"
                string key = (string) E.Current;
                //UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
                System.Console.Out.WriteLine(key + " : " + table[key]);
            }
        }
		
        //private static Config singleton;
        private static League _LigaSingleton;

        public static League getConfig()
        {
            if (_LigaSingleton == null)
                new Config();
            return _LigaSingleton;
        }
		
        //public static void  loadConfig(string fileName)
        //{
        //    singleton = new Config(fileName);
        //}
		
        //public static void  loadConfig(System.IO.Stream stream)
        //{
        //    singleton = new Config(stream);
        //}
		
        /// <summary>Method called after loadConfig to set variables not defined in league.xml to
        /// default values
        /// </summary>
        private void  setDefaults()
        {
            /* Here i've to set default value if some is still unassigned */
            if (table["AB_GOAL"] == null)
                table["AB_GOAL"] = 0;
            if (table["AB_ASSIST"] == null)
                table["AB_ASSIST"] = 0;
            if (table["AB_VICTORY_RANDOM"] == null)
                table["AB_VICTORY_RANDOM"] = 0;
            if (table["AB_DEFEAT_RANDOM"] == null)
                table["AB_DEFEAT_RANDOM"] = 0;
            if (table["AB_CLEAN_SHEET"] == null)
                table["AB_CLEAN_SHEET"] = 0;
            if (table["AB_KTK"] == null)
                table["AB_KTK"] = 0;
            if (table["AB_KPS"] == null)
                table["AB_KPS"] = 0;
            if (table["AB_SHT_ON"] == null)
                table["AB_SHT_ON"] = 0;
            if (table["AB_SHT_OFF"] == null)
                table["AB_SHT_OFF"] = 0;
            if (table["AB_SAV"] == null)
                table["AB_SAV"] = 0;
            if (table["AB_CONCDE"] == null)
                table["AB_CONCDE"] = 0;
            if (table["AB_YELLOW"] == null)
                table["AB_YELLOW"] = 0;
            if (table["AB_RED"] == null)
                table["AB_RED"] = 0;
            if (table["MAX_INJURY"] == null)
                table["MAX_INJURY"] = 9;
            if (table["CUP"] == null)
                table["CUP"] = (System.Int32) SHOOTOUT_NEVER;
            if (table["WINPTS"] == null)
                table["WINPTS"] = 3;
            if (table["DRAWPTS"] == null)
                table["DRAWPTS"] = 1;
            if (table["DEBUG"] == null)
                table["DEBUG"] = false;
        }
        /*------- Interface ContentHandler -------*/
		
        private System.Collections.ArrayList tagStack;
        private string teamName;
		
        /// <summary>Reads a field from the league.xml file and loads its value into the hashtable
        /// <CODE>table</CODE>, keys of the hashtable are the same used by original ESMS
        /// software and NOT the names of the XML tags.
        /// </summary>
        public virtual void  characters(System.Char[] text, int start, int length)
        {
            if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "TeamStatsTotal")
                table["TEAM_STATS_TOTAL"] = new string(text, start, length).ToUpper().Equals("TRUE");
            else
            {
                if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "NumSubs")
                    table["NUM_SUBS"] = System.Int32.Parse(new string(text, start, length));
                else
                {
                    if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "HomeBonus")
                        table["HOME_BONUS"] = System.Int32.Parse(new string(text, start, length));
                    else
                    {
                        if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "CupMatch")
                            table["CUP"] = System.Int32.Parse(new string(text, start, length));
                        else
                        {
                            if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "Substitutions")
                                table["SUBSTITUTIONS"] = System.Int32.Parse(new string(text, start, length));
                            else
                            {
                                if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbGoal")
                                    table["AB_GOAL"] = System.Int32.Parse(new string(text, start, length));
                                else
                                {
                                    if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbAssist")
                                        table["AB_ASSIST"] = System.Int32.Parse(new string(text, start, length));
                                    else
                                    {
                                        if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbVictoryRandom")
                                            table["AB_VICTORY_RANDOM"] = System.Int32.Parse(new string(text, start, length));
                                        else
                                        {
                                            if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbDefeatRandom")
                                                table["AB_DEFEAT_RANDOM"] = System.Int32.Parse(new string(text, start, length));
                                            else
                                            {
                                                if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbCleanSheet")
                                                    table["AB_CLEAN_SHEET"] = System.Int32.Parse(new string(text, start, length));
                                                else
                                                {
                                                    if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbKeyTackling")
                                                        table["AB_KTK"] = System.Int32.Parse(new string(text, start, length));
                                                    else
                                                    {
                                                        if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbKeyPasses")
                                                            table["AB_KPS"] = System.Int32.Parse(new string(text, start, length));
                                                            /*        else if (((String)tagStack.peek()) == "AbKeyPasses") 
														table.put("AB_KPS", new Integer(new String(text,start,length)));*/
                                                        else
                                                        {
                                                            if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbShotsOn")
                                                                table["AB_SHT_ON"] = System.Int32.Parse(new string(text, start, length));
                                                                /*        else if (((String)tagStack.peek()) == "AbShotsOn") 
															table.put("AB_SHT_ON", new Integer(new String(text,start,length)));*/
                                                            else
                                                            {
                                                                if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbShotsOff")
                                                                    table["AB_SHT_OFF"] = System.Int32.Parse(new string(text, start, length));
                                                                else
                                                                {
                                                                    if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbSaves")
                                                                        table["AB_SAV"] = System.Int32.Parse(new string(text, start, length));
                                                                    else
                                                                    {
                                                                        if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbConceded")
                                                                            table["AB_CONCDE"] = System.Int32.Parse(new string(text, start, length));
                                                                        else
                                                                        {
                                                                            if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbYellow")
                                                                                table["AB_YELLOW"] = System.Int32.Parse(new string(text, start, length));
                                                                            else
                                                                            {
                                                                                if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "AbRed")
                                                                                    table["AB_RED"] = System.Int32.Parse(new string(text, start, length));
                                                                                else
                                                                                {
                                                                                    if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "DpForYellow")
                                                                                        table["DP_FOR_YELLOW"] = System.Int32.Parse(new string(text, start, length));
                                                                                    else
                                                                                    {
                                                                                        if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "DpForRed")
                                                                                            table["DP_FOR_RED"] = System.Int32.Parse(new string(text, start, length));
                                                                                        else
                                                                                        {
                                                                                            if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "WaitOnExit")
                                                                                                table["WAIT_ON_EXIT"] = new string(text, start, length).ToUpper().Equals("TRUE");
                                                                                            else
                                                                                            {
                                                                                                if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "Team")
                                                                                                    table[teamName] = new string(text, start, length);
                                                                                                else
                                                                                                {
                                                                                                    if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "SuspensionMargin")
                                                                                                        table["SUSPENSION_MARGIN"] = System.Int32.Parse(new string(text, start, length));
                                                                                                    else
                                                                                                    {
                                                                                                        if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "MaxInjuryLength")
                                                                                                            table["MAX_INJURY"] = System.Int32.Parse(new string(text, start, length));
                                                                                                        else
                                                                                                        {
                                                                                                            if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "VictoryPoints")
                                                                                                                table["WINPTS"] = System.Int32.Parse(new string(text, start, length));
                                                                                                            else
                                                                                                            {
                                                                                                                if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "DrawPoints")
                                                                                                                    table["DRAWPTS"] = System.Int32.Parse(new string(text, start, length));
                                                                                                                else
                                                                                                                {
                                                                                                                    if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "Promotions")
                                                                                                                        table["PROMOTNR"] = System.Int32.Parse(new string(text, start, length));
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "Relegations")
                                                                                                                            table["RELEGNR"] = System.Int32.Parse(new string(text, start, length));
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if ((System.Object) ((string) tagStack[tagStack.Count - 1]) == (System.Object) "Debug")
                                                                                                                                table["DEBUG"] = new string(text, start, length).ToUpper().Equals("TRUE");
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
		
        public virtual void  endDocument()
        {
        }
		
        public virtual void  endElement(string str, string str1, string str2)
        {
            SupportClass.StackSupport.Pop(tagStack);
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
			
            tagStack.Add(tag);
            /* Attributes must be managed here */
            if ((System.Object) tag == (System.Object) "Team")
                teamName = attributes.GetValue("abbr");
        }
		
        public virtual void  startPrefixMapping(string str, string str1)
        {
        }
    }
}