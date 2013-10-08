// HZ: El roster es la plantilla de jugadores, el conjunto, o sea el equipo (formado por jugadores - players)


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
* Roster.java
*
* Created on 26 dicembre 2003, 12.05
*/
using System;
//UPGRADE_TODO: The type 'com.sun.org.apache.xpath.internal_Renamed.NodeSet' could not be found. If it was not included in the conversion, there may be compiler issues. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1262'"
using System.Collections.Generic;

//using NodeSet = com.sun.org.apache.xpath.internal_Renamed.NodeSet;
////UPGRADE_TODO: The package 'javax.xml.xpath' could not be found. If it was not included in the conversion, there may be compiler issues. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1262'"
//using javax.xml.xpath;
////UPGRADE_TODO: The package 'java.util.regex' could not be found. If it was not included in the conversion, there may be compiler issues. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1262'"
//using java.util.regex;

namespace CSEsMS.Engine
{
    /// <summary> 
    /// Roster files are used to represent a team in JEsMS, each roster contains infos about team and
    /// a list of all team players completed with their attributes.
    /// In fact a roster file consists in a Roster tag containing a list of Player tags.
    /// 
    /// HZ: es la plantilla total de jugadores que componen un equipo, todos los jugadores disponibles 
    /// y no solo los titulares + suplentes.
    /// </summary>
    public class Roster
    {
        #region Campos
        /// <summary> This private field contains DOM Representation of Roster instance</summary>
        /// <since> 1.0.10
        /// </since>
        //protected internal System.Xml.XmlDocument innerDOMDocument;
        //protected internal XPath xpath = XPathFactory.newInstance().newXPath();

        //UPGRADE_ISSUE: The following fragment of code could not be parsed and was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1156'"
        private List<Player> _team;

        /// <summary> Team Abbreviation (usually a 3-char abbreviation)</summary>
        private string _abbr;

        /// <summary> A simple double representing team budget</summary>
        /// <since> 1.0.9
        /// </since>
        private double _budget = 0;

        private string xsl_processing = null;
        #endregion

        #region Propiedades
        virtual public string Abbreviation
        {
            get
            {
                return _abbr;
            }
			
        }
        virtual public double Budget
        {
            get
            {
                return _budget;
            }
			
            set
            {
                throw new NotImplementedException("Error en Engine.Roster.Budget. HZ: Esto habria que reemplazarlo por el DAL si es que corresponde.");
                //try
                //{
                //    System.Xml.XmlNode n = (System.Xml.XmlNode) xpath.evaluate("/Roster/@budget", innerDOMDocument, XPathConstants.NODE);
                //    n.setTextContent(value.ToString());
                //}
                //catch (XPathExpressionException ex)
                //{
                //    //UPGRADE_TODO: Method 'java.io.PrintStream.println' was converted to 'System.Console.Out.WriteLine' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioPrintStreamprintln_javalangObject'"
                //    System.Console.Out.WriteLine(ex.getMessage());
                //    ex.printStackTrace();
                //}
                _budget = value;
            }
			
        }
        virtual public string Name
        {
            get
            {
                try
                {
                    throw new NotImplementedException("Aca hay que reemplazar pr la entidad Rooster");
                    //return ((string) Config.getConfig().getConfigValue(_abbr));
                }
                catch (System.Exception err)
                {
                    System.Console.Out.WriteLine("Unable to read name from abbreviation " + _abbr);
                    SupportClass.WriteStackTrace(err, Console.Error);
                    return _abbr;
                }
            }
			
        }
        virtual public string Xsl
        {
            get
            {
                throw new NotImplementedException("Error en Engine.Roster.Xsl. HZ: Esto ya no se usaria mas.");
                //bool found = false;
                //System.Xml.XmlNode n = innerDOMDocument.FirstChild;
                //while (!found)
                //{
                //    if (n == null)
                //        return null;
                //    if (System.Convert.ToInt16(n.NodeType) == (short) System.Xml.XmlNodeType.ProcessingInstruction && ((System.Xml.XmlProcessingInstruction) n).Target.Equals("xml-stylesheet"))
                //    {
                //        string answer = ((System.Xml.XmlProcessingInstruction) n).Data;
                //        answer = answer.Substring(answer.IndexOf("href=\"") + 6);
                //        answer = answer.Substring(0, (answer.IndexOf('"')) - (0));
                //        return answer;
                //    }
                //    n = n.NextSibling;
                //}
                //return null;
            }

        }
        #endregion

        #region Constructores
        protected internal Roster()
        {

            InitBlock();
            throw new NotImplementedException("Error en Engine.Roster.InitBlock. HZ: Ver en la version JAVA que intento hacer con esto.");
            //UPGRADE_ISSUE: The following fragment of code could not be parsed and was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1156'"
            //_team = new ArrayList < Player >();
        }

        /// <summary>Creates a new instance of Roster </summary>
        public Roster(System.IO.Stream str)
        {
            InitBlock();
            throw new NotImplementedException("Error en Engine.Roster.InitBlock. HZ: Ver en la version JAVA que intento hacer con esto.");
            //UPGRADE_ISSUE: The following fragment of code could not be parsed and was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1156'"
            //_team = new ArrayList < Player >();


            parseXML(str);
        }

        public Roster(string filename)
        {
            InitBlock();

            throw new NotImplementedException("Error en Engine.Roster.InitBlock. HZ: Ver en la version JAVA que intento hacer con esto.");
            //UPGRADE_ISSUE: The following fragment of code could not be parsed and was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1156'"
            //_team = new ArrayList<Player>();

            //try
            //{
            //    System.Xml.XmlDocument tempDocument;
            //    //UPGRADE_ISSUE: Method 'javax.xml.parsers.DocumentBuilderFactory.newInstance' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersDocumentBuilderFactory'"
            //    DocumentBuilderFactory.newInstance();
            //    //UPGRADE_TODO: Constructor 'java.io.FileInputStream.FileInputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileInputStreamFileInputStream_javalangString'"
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.DocumentBuilder.parse' was converted to 'System.Xml.XmlDocument.Load' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmlparsersDocumentBuilderparse_javaioInputStream'"
            //    tempDocument = (System.Xml.XmlDocument)new System.Xml.XmlDocument().Clone();
            //    tempDocument.Load(new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read));
            //    innerDOMDocument = tempDocument;
            //    this.parseDocument(innerDOMDocument);
            //}
            ////UPGRADE_ISSUE: Class 'javax.xml.parsers.ParserConfigurationException' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersParserConfigurationException'"
            //catch (ParserConfigurationException err)
            //{
            //    System.Console.Out.WriteLine("ParserConfigurationException when parsing " + _abbr + ".xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            ////UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //catch (System.Xml.XmlException err)
            //{
            //    System.Console.Out.WriteLine("Error while parsing XML in " + _abbr + ".xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading " + _abbr + ".xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
        #endregion

        private void InitBlock()
        {
            throw new NotImplementedException("Error en Engine.Roster.InitBlock. HZ: Ver en la version JAVA que intento hacer con esto.");
            //return this._team;
            //this._team = playerList;
        }

        public virtual Player getPlayer(string name)
        {
            throw new NotImplementedException("Error en Engine.Roster.getPlayer(string name). HZ: Ver en la version JAVA que intento hacer con esto.");
            //UPGRADE_NOTE: There is an untranslated Statement.  Please refer to original code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1153'"
            throw new System.Exception("Player " + name + " is not present in roster of " + Name + " _team.");
        }
        //UPGRADE_ISSUE: The following fragment of code could not be parsed and was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1156'"
        public List < Player > getPlayers()
        {
            return this._team;
        }

        // obtenet esta logica del programa en JAVA
        public virtual void  decreaseSuspensions()
        {
            //UPGRADE_NOTE: There is an untranslated Statement.  Please refer to original code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1153'"
            throw new NotImplementedException("Error en Engine.Roster.decreaseSuspensions. HZ: Ver en la version JAVA que intento hacer con esto.");
        }

        // obtenet esta logica del programa en JAVA
        public virtual void  decreaseInjuries()
        {
            //UPGRADE_NOTE: There is an untranslated Statement.  Please refer to original code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1153'"
            throw new NotImplementedException("Error en Engine.Roster.decreaseInjuries. HZ: Ver en la version JAVA que intento hacer con esto.");
        }

        public void setPlayers(List < Player > playerList)
        {
            this._team = playerList;
        }

        #region Metodo DAL del XML que hay que pasar a Nhibernate
        public virtual void  WriteRoster()
        {
			
            /* TOD.O Check if Roster has been initialized */
            /*        OutputStreamWriter w = new OutputStreamWriter(new FileOutputStream(_abbr+".xml"),"iso-8859-1");
			w.write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
			w.write("<Roster team=\"");w.write(_abbr);w.write("\">");w.flush();
			for (int i=0;i<_team.length;i++)
			{
			_team[i].WriteRoster(w);
			}
			w.write("</Roster>");
			w.flush();
			w.close();
			*/
            WriteRoster(_abbr + ".xml", null);
        }
		
        public virtual void  WriteRoster(string externalXSL)
        {
            throw new NotImplementedException("Error en Engine.Roster.WriteRoster(string outputName, string externalXSL). HZ: hay que reemplazar la logica del XML por la del DAL que graba los registros del equipo.");
            ///* TOD.O Check if Roster has been initialized */
            ////UPGRADE_TODO: Class 'javax.xml.transform.dom.DOMSource' was converted to 'DomSourceSupport' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmltransformdomDOMSource'"
            //DomSourceSupport source = new DomSourceSupport(innerDOMDocument);
            //GenericResultSupport result = new GenericResultSupport(new System.IO.FileInfo(_abbr + ".xml"));
			
            ////UPGRADE_TODO: Method 'javax.xml.transform.TransformerFactory.newTransformer' was converted to 'SupportClass.TransformerSupport.NewTransform' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmltransformTransformerFactorynewTransformer'"
            //TransformerSupport transformer = TransformerSupport.NewTransform(TransformerSupport.NewInstance());
            //if (externalXSL != null)
            //{
            //    //add XSL
            //    System.Xml.XmlNode xsl = innerDOMDocument.CreateProcessingInstruction("xml-stylesheet", " type=\"text/xsl\" href=\"" + externalXSL + "\"");
            //    innerDOMDocument.AppendChild(xsl);
            //}
			
            //transformer.DoTransform(source, result);
        }
		
        /// <summary> Writes the roster object back to file.</summary>
        /// <param name="outputName">String containing output filename.
        /// </param>
        /// <param name="externalXSL">String containing URL address of XSL file to use.
        /// * 'null' means that XSL declaration must be left untouched 
        /// (it remains the same as input file)
        /// * an empty string ("") means that if an XSL declaration exists it must be removed.
        /// </param>
        /// <throws>  java.io.IOException Thrown if some IO error happens while writing file. </throws>
        /// <throws>  javax.xml.transform.TransformerException Thrown if some error happens while converting DOM structure to char string. </throws>
        public virtual void  WriteRoster(string outputName, string externalXSL)
        {
            throw new NotImplementedException("Error en Engine.Roster.WriteRoster(string outputName, string externalXSL). HZ: hay que reemplazar la logica del XML por la del DAL que graba los registros del equipo.");

            ///* TOD.O Check if Roster has been initialized */
            ////UPGRADE_TODO: Class 'javax.xml.transform.dom.DOMSource' was converted to 'DomSourceSupport' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmltransformdomDOMSource'"
            //DomSourceSupport source = new DomSourceSupport(innerDOMDocument);
            //GenericResultSupport result = new GenericResultSupport(new System.IO.FileInfo(outputName));
			
            ////UPGRADE_TODO: Method 'javax.xml.transform.TransformerFactory.newTransformer' was converted to 'SupportClass.TransformerSupport.NewTransform' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmltransformTransformerFactorynewTransformer'"
            //TransformerSupport transformer = TransformerSupport.NewTransform(TransformerSupport.NewInstance());
            //if ((System.Object) externalXSL == (System.Object) "")
            //{
            //    this.removeXsl();
            //}
            //else if (externalXSL != null)
            //{
            //    //add XSL
            //    System.Xml.XmlNode xsl = innerDOMDocument.CreateProcessingInstruction("xml-stylesheet", " type=\"text/xsl\" href=\"" + externalXSL + "\"");
            //    innerDOMDocument.AppendChild(xsl);
            //}
			
            //transformer.DoTransform(source, result);
        }
		
        public virtual void  AddPlayer(Player player)
        {
            _team.Add(player);

            throw new NotImplementedException("Error en Engine.Roster.AddPlayer(Player player). HZ: hay que reemplazar la logica del XML por la del DAL que agrega el jugador el equipo.");
            //try
            //{
            //    System.Xml.XmlNode n = (System.Xml.XmlNode) xpath.evaluate("/Roster", innerDOMDocument, XPathConstants.NODE);
            //    n.AppendChild(innerDOMDocument.ImportNode(player.Node, false));
            //}
            //catch (XPathExpressionException ex)
            //{
            //    ex.printStackTrace();
            //}
        }
		
        // TODO Se non è in squadra cosa succede?
        public virtual void  RemovePlayer(Player player)
        {
            _team.Remove(player);
            //try
            //{
            throw new NotImplementedException("Error en Engine.Roster.RemovePlayer(Player player). HZ: hay que reemplazar la logica del XML por la del DAL que elimina el jugador el equipo.");
            //System.Xml.XmlNode n = (System.Xml.XmlNode) xpath.evaluate("/Roster", innerDOMDocument, XPathConstants.NODE);
            //n.RemoveChild(player.Node);
            //}
            //catch (XPathExpressionException ex)
            //{
            //    ex.printStackTrace();
            //}
        }
        #endregion

        #region Metodos XML que no se usarian mas
        protected internal virtual bool removeXsl()
        {
            throw new NotImplementedException("Error en Engine.Roster.removeXsl . HZ: que el XML no se va a usar mas este metodo habria que quitarlo de donde se use");
            
            //bool found = false;
            //System.Xml.XmlNode n = innerDOMDocument.FirstChild;
            //while (!found)
            //{
            //    if (n == null)
            //        return false;
            //    if (System.Convert.ToInt16(n.NodeType) == (short) System.Xml.XmlNodeType.ProcessingInstruction && ((System.Xml.XmlProcessingInstruction) n).Target.Equals("xml-stylesheet"))
            //    {
            //        n.ParentNode.RemoveChild(n);
            //        return true;
            //    }
            //    n = n.NextSibling;
            //}
            //return false;
        }

        public virtual void parseDocument(System.Xml.XmlDocument roster)
        {
            /*
             * Carga las siguientes propiedades del XML de un Rooster:
             * _abbr
             * _budget
             * _team (LIST)
             */
            throw new NotImplementedException("Error en Engine.Roster.parseDocument(System.Xml.XmlDocument roster). HZ: hay que reemplazar la logica del XML por la del DAL que carga el equipo en memoria.");

            // Extract team abbreviation;        
            //try
            //{

            //    this._abbr = ((string) xpath.evaluate("/Roster/@team", roster, XPathConstants.STRING));
            //}
            //catch (XPathExpressionException ex)
            //{
            //    System.Console.Out.WriteLine("Unable to extract team abbreviation!");
            //    ex.printStackTrace();
            //    throw new SAXException();
            //}
            //try
            //{
            //    //Check if _abbr is null!

            //    // Extract team budget;
            //    if (xpath.evaluate("number(/Roster/@budget)", roster, XPathConstants.NUMBER) == null)
            //        this._budget = 0;
            //    else
            //        this._budget = ((System.Double) xpath.evaluate("number(/Roster/@_budget)", roster, XPathConstants.NUMBER));
            //}
            //catch (XPathExpressionException ex)
            //{
            //    System.Console.Out.WriteLine("Unable to extract team budget!");
            //    ex.printStackTrace();
            //    throw new SAXException();
            //}
            //System.Xml.XmlNodeList set_Renamed;
            //try
            //{
            //    set_Renamed = (System.Xml.XmlNodeList) xpath.evaluate("/Roster/Player", roster, XPathConstants.NODESET);
            //}
            //catch (XPathExpressionException ex)
            //{
            //    System.Console.Out.WriteLine("Unable to extract team players!");
            //    ex.printStackTrace();
            //    throw new SAXException();
            //}

            //for (int i = 0; i < set_Renamed.Count; i++)
            //{
            //    System.Xml.XmlElement n = (System.Xml.XmlElement) set_Renamed.Item(i);
            //    Player player = new Player(n);

            //    _team.add(player);
            //}
        }

        protected internal virtual void parseXML(System.IO.Stream str)
        {
            throw new NotImplementedException("Error en Engine.Roster.parseXML(System.IO.Stream str). HZ: Creo que este metodo se usa solo para validar el archivo XML por lo que no se estaria usando mas.");
            
            // What to do if abbr is not set?
            //try
            //{
            //    System.Xml.XmlDocument tempDocument;
            //    //UPGRADE_ISSUE: Method 'javax.xml.parsers.DocumentBuilderFactory.newInstance' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersDocumentBuilderFactory'"
            //    DocumentBuilderFactory.newInstance();
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.DocumentBuilder.parse' was converted to 'System.Xml.XmlDocument.Load' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmlparsersDocumentBuilderparse_javaioInputStream'"
            //    tempDocument = (System.Xml.XmlDocument)new System.Xml.XmlDocument().Clone();
            //    tempDocument.Load(str);
            //    innerDOMDocument = tempDocument;
            //    this.parseDocument(innerDOMDocument);
            //}
            ////UPGRADE_ISSUE: Class 'javax.xml.parsers.ParserConfigurationException' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersParserConfigurationException'"
            //catch (ParserConfigurationException err)
            //{
            //    System.Console.Out.WriteLine("ParserConfigurationException when parsing " + _abbr + ".xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            ////UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //catch (System.Xml.XmlException err)
            //{
            //    System.Console.Out.WriteLine("Error while parsing XML in " + _abbr + ".xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading " + _abbr + ".xml file");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
        #endregion

        #region Metodos no usados - auxiliares
        /// <summary> Static method used to convert ESMS txt roster format to JEsMS XML format
        /// It needs two files as parameters, the input (txt) and output (xml) roster files.
        /// TOD.O: Move this to DOM.
        /// </summary>
        /// <param name="source">The input txt roster file
        /// </param>
        /// <param name="destination">The output XML roster file
        /// </param>
        /// <throws>  java.io.IOException When source or destinationa are not accessible </throws>
        //private static void  convertFromESMS(System.IO.FileInfo source, System.IO.FileInfo destination)
        //{

        //    //UPGRADE_TODO: The differences in the expected value  of parameters for constructor 'java.io.BufferedReader.BufferedReader'  may cause compilation errors.  "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1092'"
        //    //UPGRADE_WARNING: At least one expression was used more than once in the target code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1181'"
        //    //UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
        //    System.IO.StreamReader read = new System.IO.StreamReader(new System.IO.StreamReader(source.FullName, System.Text.Encoding.Default).BaseStream, new System.IO.StreamReader(source.FullName, System.Text.Encoding.Default).CurrentEncoding);
        //    // TOD.O: Add new Regex to parse 2.7.2
        //    string regex = "([^ ]*) {1,}(\\d*) {1,}([a-z,A-Z]*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*) {1,}(\\d*)";
        //    Pattern p = Pattern.compile(regex);
        //    //UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
        //    //UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javaioFile'"
        //    System.IO.StreamWriter w = new System.IO.StreamWriter(new System.IO.FileStream(destination.FullName, System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));

        //    w.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
        //    w.Write("<Roster team=\"" + source.Name.Substring(0, (3) - (0)) + "\" budget=\"0\">");

        //    while (read.Peek() != -1)
        //    {
        //        string text = read.ReadLine();
        //        Matcher m = p.matcher(text);
        //        if (m.matches())
        //        {
        //            //String[] answer = p.split(text);
        //            w.Write("<Player name=\"" + m.group(1) + "\" ");
        //            w.Write("age=\"" + m.group(2) + "\" ");
        //            w.Write("nationality=\"" + m.group(3) + "\" ");
        //            w.Write("shootStopping=\"" + m.group(4) + "\" ");
        //            w.Write("tackling=\"" + m.group(5) + "\" ");
        //            w.Write("passing=\"" + m.group(6) + "\" ");
        //            w.Write("shooting=\"" + m.group(7) + "\" ");
        //            w.Write("aggression=\"" + m.group(8) + "\" ");
        //            w.Write("shootStoppingAbility=\"" + m.group(9) + "\" ");
        //            w.Write("tacklingAbility=\"" + m.group(10) + "\" ");
        //            w.Write("passingAbility=\"" + m.group(11) + "\" ");
        //            w.Write("shootingAbility=\"" + m.group(12) + "\" ");
        //            w.Write("games=\"" + m.group(13) + "\" ");
        //            w.Write("saves=\"" + m.group(14) + "\" ");
        //            w.Write("keyTackles=\"" + m.group(15) + "\" ");
        //            w.Write("keyPasses=\"" + m.group(16) + "\" ");
        //            w.Write("shots=\"" + m.group(17) + "\" ");
        //            w.Write("goals=\"" + m.group(18) + "\" ");
        //            w.Write("assists=\"" + m.group(19) + "\" ");
        //            w.Write("dps=\"" + m.group(20) + "\" ");
        //            w.Write("injury=\"" + m.group(21) + "\" ");
        //            w.Write("suspension=\"" + m.group(22) + "\"/>");
        //            w.Flush();
        //        }
        //    }
        //    w.Write("</Roster>");
        //    w.Flush();
        //    w.Close();
        //}

        /* Roster class can be used as main class, in that case it simply convert old ESMS format to new JEsMS one*/
        //[STAThread]
        //public static void  Main(string[] args)
        //{
        //    try
        //    {
        //        UPGRADE_ISSUE: Constructor 'java.text.SimpleDateFormat.SimpleDateFormat' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javatextSimpleDateFormat'"
        //        UPGRADE_TODO: The equivalent in .NET for method 'java.util.Calendar.getTime' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
        //        System.Console.Out.WriteLine(Version.Name + "Roster Importer Version " + Version.getVersion() + " - " + Version.Codename + " (" + SupportClass.FormatDateTime(new SimpleDateFormat("dd MMM yyyy"), SupportClass.CalendarManager.manager.GetDateTime(Version.LastBuild)) + ")\r\n" + Version.Features + "\r\n" + Version.Author);
        //        System.Console.Out.WriteLine("Converting ESMS Roster file named " + args[0] + " into JEsMS Roster file named " + args[1] + "...");
        //        convertFromESMS(new System.IO.FileInfo(args[0]), new System.IO.FileInfo(args[1]));
        //        System.Console.Out.WriteLine("Conversion succesfully ended.");
        //    }
        //    catch (System.IO.IOException err)
        //    {
        //    }
        //}
        #endregion
    }
}