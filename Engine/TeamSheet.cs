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
* TeamSheet.java
* TODO: Update regular expressions to take care of preferred side.
* Created on 26 dicembre 2003, 14.48
*/
using System;
using CSEsMS.Domain.Entities;

//UPGRADE_TODO: The package 'java.util.regex' could not be found. If it was not included in the conversion, there may be compiler issues. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1262'"
//using java.util.regex;

namespace CSEsMS.Engine
{
    /// <summary>
    /// A teamsheet is a list of players and substitutes chosen for the match and contains 
    /// also orders for the engine explaining how to react to different possible situations
    /// 
    /// HZ: El TeamSheet es la plantilla (formacion) de jugadores que componen el equipo para el partido
    /// el equipo (formado por jugadores - players) que va a jugar, tanto titulares, suplentes, 
    /// pateadores de penales, etc.
    /// </summary>
    public class TeamSheet : XmlSaxContentHandler
    {
        #region Campos
        protected internal string _abbr;
        protected internal Tactic _tactic;

        protected internal Player[] _team;
        protected internal Player[] _subs;

        protected internal string[] _posTeam;
        protected internal PreferredSide[] _sideTeam;
        protected internal string[] _posSubs;
        protected internal PreferredSide[] _sideSubs;

        protected internal Player _penaltyKicker = null;
        //protected Conditional[] cond;

        //protected internal Roster _roster;

        protected internal int _iTeam = 0;
        protected internal int _iSubs = 0;

        /// <summary>Vector used to store conditional during the parsing of the XML file
        /// at the end of the parsing the whole content of vCond is transferred to
        /// cond array and the variable vCond is freed (NO MORE TRUE!!!).
        /// </summary>
        protected internal System.Collections.ArrayList _vCond;

        /*---------- Interface ContentHandler ----------*/
        protected internal System.Collections.ArrayList _tagStack;

        protected internal string _currentAction;
        protected internal System.Collections.ArrayList _currentArguments;
        protected internal System.Collections.ArrayList _currentConditions;
        #endregion
        
        #region Propiedades
        virtual public int NumPlayers
        {
            get
            {
                int number = 0;
                try
                {
                    number = Config.getConfig().NumSubs;
                }
                catch (System.Exception err)
                {
                    System.Console.Out.WriteLine("Error while reading NUM_SUBS from configuration object");
                    SupportClass.WriteStackTrace(err, Console.Error);
                }
                return number + 11;
            }
			
        }
        virtual public string Abbreviation
        {
            get
            {
                return _abbr;
            }
			
        }
        virtual public string Name
        {
            get
            {
                try
                {
                    throw new NotImplementedException("aca hay que reemplazar por la entidad timesheet");
                    //return ((string) Config.getConfig().getConfigValue(_abbr));
                }
                catch (System.Exception err)
                {
                    System.Console.Out.WriteLine("Unable to read name from abbreviation " + _abbr);
                    SupportClass.WriteStackTrace(err, Console.Error);
                    return null;
                }
            }
			
        }
        virtual public Conditional[] Conditionals
        {
            get
            {
                return (Conditional[]) SupportClass.ICollectionSupport.ToArray(_vCond, new Conditional[0]);
            }
			
        }
        virtual public Tactic Tactic
        {
            get
            {
                return _tactic;
            }
			
            set
            {
                this._tactic = value;
                /* Here i should recalculate tactic bonuses ?*/
            }

        }
        #endregion

        #region Constructores
        /// <summary>HZ: Este constructuctor arma una TeamSheet (formacion) con parametros x defecto con un Roster (plantel)</summary>
        //public TeamSheet(Roster roster)
        //{
        //    this._roster = roster;
        //    _tagStack = new System.Collections.ArrayList();
        //    _vCond = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
        //    _currentArguments = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
        //    _currentConditions = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));

        //    _team = new Player[11];
        //    _posTeam = new string[11];
        //    _sideTeam = new PreferredSide[11];

        //    _tactic = (Tactic)Tactic._Tactics["N"];
        //    _abbr = roster.Abbreviation;

        //    try
        //    {
        //        /* TODO:Check that Config has been already initialized */
        //        int number = Config.getConfig().NumSubs;
        //        _subs = new Player[number];
        //        _posSubs = new string[number];
        //        _sideSubs = new PreferredSide[number];
        //    }
        //    catch (System.Exception err)
        //    {
        //        System.Console.Out.WriteLine("Error while trying to extract \"NUM_SUBS\" from configuration table");
        //        SupportClass.WriteStackTrace(err, Console.Error);
        //    }
        //}

        /// <summary>
        /// HZ: este metodo se usa para cargar un archivo a partir de un stream XML creado en algun lado por lo que no se estaria usando mas. Habria que ver la logica y reemplazarlo con en DAL
        /// </summary>
        public TeamSheet(System.IO.Stream str)
        {
            throw new NotImplementedException("Error en Engine.TeamSheet.TeamSheet(System.IO.Stream str). HZ: este metodo se usa para cargar un archivo a partir de un stream XML creado en algun lado por lo que no se estaria usando mas. Habria que ver la logica y reemplazarlo con en DAL");
            
            //tagStack = new System.Collections.ArrayList();
            //_vCond = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
            //currentArguments = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
            //currentConditions = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));

            //_team = new Player[11];
            //_posTeam = new string[11];
            //_sideTeam = new PreferredSide[11];

            //parseXML(str);
        }

        /// <summary>Creates a new instance of TeamSheet. HZ: este metodo se usa para cargar un archivo a partir de un archivo XML por lo que no se estaria usando mas. Habria que ver la logica y reemplazarlo con en DAL</summary>
        public TeamSheet(string fileName)
        {
            throw new NotImplementedException("Error en Engine.TeamSheet.TeamSheet(string fileName). HZ: este metodo se usa para cargar un archivo a partir de un archivo XML por lo que no se estaria usando mas. Habria que ver la logica y reemplazarlo con en DAL");

            //tagStack = new System.Collections.ArrayList();
            //_vCond = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
            //currentArguments = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
            //currentConditions = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));

            //_team = new Player[11];
            //_posTeam = new string[11];
            //_sideTeam = new PreferredSide[11];

            //try
            //{
            //    /* TOD.O:Check that Config has been already initialized */
            //    int number = Config.getConfig().NumSubs;
            //    _subs = new Player[number];
            //    _posSubs = new string[number];
            //    _sideSubs = new PreferredSide[number];
            //}
            //catch (System.Exception err)
            //{
            //    System.Console.Out.WriteLine("Error while trying to extract \"NUM_SUBS\" from configuration table");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}

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
            //    System.Console.Out.WriteLine("Error while parsing XML in " + fileName);
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading file " + fileName);
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
        #endregion

        public virtual void  clearTeamSheet()
        {
            _tagStack = new System.Collections.ArrayList();
            _vCond = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
            _currentArguments = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
            _currentConditions = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
			
            _team = new Player[11];
            _posTeam = new string[11];
            _sideTeam = new PreferredSide[11];
        }

        public virtual void  setPosition(int number, string newrole)
        {
            if (number <= 11)
                _posTeam[number - 1] = newrole;
            else
                _posSubs[number - 12] = newrole;
        }
		
        public virtual void  setPenaltyKicker(int nr)
        {
            try
            {
                this._penaltyKicker = getPlayer(nr);
            }
            catch (System.Exception err)
            {
                SupportClass.WriteStackTrace(err, Console.Error);
            }
        }
		
        public virtual Player getPenaltyKicker()
        {
            return this._penaltyKicker;
        }
		
        public virtual void  addConditional(Conditional c)
        {
            _vCond.Add(c);
        }
		
        public virtual void  removeConditional(Conditional c)
        {
            _vCond.Remove(c);
        }
		
        public virtual Player getPlayer(int number)
        {
            int n = 11 + Config.getConfig().NumSubs;
			
            if (number < 1 || number > n)
                throw new System.Exception("Player number must be between 1 and " + n);
            else
            {
                if (number <= 11)
                    return _team[number - 1];
                else
                    return _subs[number - 12];
            }
        }
		
        // TODO: Check possible exceptions
        public virtual void  setPlayer(int number, Player player, string pos, PreferredSide side)
        {
            _team[number] = player;
            _posTeam[number] = pos;
            _sideTeam[number] = side;
        }
		
        public virtual void  setPlayer(int number, Player player, string pos)
        {
            this.setPlayer(number, player, pos, new PreferredSide("C"));
        }
		
        public virtual void  setSub(int number, Player player, string pos, PreferredSide side)
        {
            _subs[number] = player;
            _posSubs[number] = pos;
            _sideSubs[number] = side;
        }
		
        public virtual void  setSub(int number, Player player, string pos)
        {
            this.setSub(number, player, pos, new PreferredSide("C"));
        }
	
        public virtual PreferredSide getActualSide(Player player)
        {
            string name = player.Name;
            for (int i = 0; i < _team.Length; i++)
            {
                if (_team[i] != null && _team[i].Name.Equals(name))
                    return _sideTeam[i];
            }
            for (int i = 0; i < _subs.Length; i++)
            {
                if (_subs[i] != null && _subs[i].Name.Equals(name))
                    return _sideSubs[i];
            }
            throw new System.Exception("Player is not present in the teamsheet!");
        }
		
        public virtual PreferredSide getActualSide(int number)
        {
            int n = 11 + Config.getConfig().NumSubs;
			
            if (number < 1 || number > n)
                throw new System.Exception("Player number must be between 1 and " + n);
            else
            {
                if (number <= 11)
                    return _sideTeam[number - 1];
                else
                    return _sideSubs[number - 12];
            }
        }
		
        public virtual string getPosition(Player player)
        {
            string name = player.Name;
            for (int i = 0; i < _team.Length; i++)
            {
                if (_team[i] != null && _team[i].Name.Equals(name))
                    return _posTeam[i];
            }
            for (int i = 0; i < _subs.Length; i++)
            {
                if (_subs[i] != null && _subs[i].Name.Equals(name))
                    return _posSubs[i];
            }
            throw new System.Exception("Player is not present in the teamsheet!");
        }
		
        public virtual string getPosition(int number)
        {
            int n = 11 + Config.getConfig().NumSubs;
			
            if (number < 1 || number > n)
                throw new System.Exception("Player number must be between 1 and " + n);
            else
            {
                if (number <= 11)
                    return _posTeam[number - 1];
                else
                    return _posSubs[number - 12];
            }
        }

        #region Metodos vacios (seran para cumplir con la INTERFASE de la cual hereda la clase?)
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

        public virtual void startPrefixMapping(string str, string str1)
        {
        }
        #endregion

        #region Manipulacion XML (DAL XML)
        protected internal virtual void parseXML(System.IO.Stream str)
        {
            throw new NotImplementedException("Error en Engine.TeamSheet.parseXML(System.IO.Stream str). HZ: Creo que este metodo se usa solo para validar el archivo XML por lo que no se estaria usando mas.");

            //try
            //{
            //    /* TOD.O:Check that Config has been already initialized */
            //    int number = Config.getConfig().NumSubs;
            //    _subs = new Player[number];
            //    _posSubs = new string[number];
            //    _sideSubs = new PreferredSide[number];
            //}
            //catch (System.Exception err)
            //{
            //    System.Console.Out.WriteLine("Error while trying to extract \"NUM_SUBS\" from configuration table");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}

            //try
            //{
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //    XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
            //    //UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
            //    //UPGRADE_TODO: Constructor 'java.io.InputStreamReader.InputStreamReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioInputStreamReaderInputStreamReader_javaioInputStream_javalangString'"
            //    System.IO.StreamReader r = new System.IO.StreamReader(str, System.Text.Encoding.GetEncoding("iso-8859-1"));
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
            //    System.Console.Out.WriteLine("Error while parsing XML from team roster");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
            //catch (System.IO.IOException err)
            //{
            //    System.Console.Out.WriteLine("Error while reading team roster");
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }

        public virtual void  startElement(string str, string str2, string tag, SaxAttributesSupport attributes)
        {
            throw new NotImplementedException("Error en Engine.Roster.startElement(string str, string str2, string tag, SaxAttributesSupport attributes). HZ: Creo que este metodo se usa para abrir los archivos XML generado por lo que no se estaria usando mas.");

            //_tagStack.Add(tag);
            //if ((System.Object) tag == (System.Object) "TeamSheet")
            //{
            //    _abbr = attributes.GetValue("name");
            //    // TODO: I need to ensure that Tactics has been loaded.
            //    this._tactic = (Tactic) Tactic.Tactics[attributes.GetValue("tactic")];
            //    /* Try to load the roster */
            //    _roster = new Roster(_abbr + ".xml");
            //}
            //else if ((System.Object) tag == (System.Object) "Player" || (System.Object) tag == (System.Object) "Substitute" || (System.Object) tag == (System.Object) "PenaltyKicker")
            //{
            //    string name = attributes.GetValue("name");
            //    string position = null;
            //    PreferredSide side = null;
				
            //    if ((System.Object) tag != (System.Object) "PenaltyKicker")
            //    {
            //        position = attributes.GetValue("role");
            //        if (attributes.GetValue("side") != null)
            //            side = new PreferredSide(attributes.GetValue("side"));
            //        else
            //            side = new PreferredSide("C");
            //    }
				
            //    Player player = null;
				
            //    try
            //    {
            //        player = _roster.getPlayer(name);
            //    }
            //    catch (System.Exception err)
            //    {
            //        //UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Throwable.getMessage' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
            //        System.Console.Out.WriteLine(err.Message);
            //        SupportClass.WriteStackTrace(err, Console.Error);
            //        System.Environment.Exit(- 1);
            //    }
            //    if ((System.Object) tag == (System.Object) "Player")
            //    {
            //        /* Before adding the player i must check that he's not already
            //        in the team */
            //        if (player.Injury > 0 || player.Suspension > 0)
            //        {
            //            //UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //            throw new System.Xml.XmlException("Error: player " + player.name + " in team " + this.Name + " is unavailable for the match");
            //        }
            //        for (int j = 0; j < _iTeam; j++)
            //        {
            //            if (_team[j].name.Equals(player.name))
            //            {
            //                //UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //                throw new System.Xml.XmlException("Error: player " + player.name + " is already present in teamsheet of team " + this.Name);
            //            }
            //        }
            //        _team[_iTeam] = player;
            //        _posTeam[_iTeam] = position;
            //        _sideTeam[_iTeam++] = side;
            //    }
            //    else if ((System.Object) tag == (System.Object) "Substitute")
            //    {
            //        if (player.Injury > 0 || player.Suspension > 0)
            //        {
            //            //UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //            throw new System.Xml.XmlException("Error: player " + player.name + " in team " + this.Name + " is unavailable for the match");
            //        }
            //        for (int j = 0; j < _iTeam; j++)
            //        {
            //            if (_team[j].name.Equals(player.name))
            //            {
            //                //UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //                throw new System.Xml.XmlException("Error: player " + player.name + " is already present in teamsheet of team " + this.Name);
            //            }
            //        }
            //        for (int j = 0; j < _iSubs; j++)
            //        {
            //            if (_subs[j].name.Equals(player.name))
            //            {
            //                //UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //                throw new System.Xml.XmlException("Error: player " + player.name + " is already present in teamsheet of team " + this.Name);
            //            }
            //        }
            //        _subs[_iSubs] = player;
            //        _posSubs[_iSubs] = position;
            //        _sideSubs[_iSubs++] = side;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < _team.Length; i++)
            //            if (_team[i].Name.Equals(player.name))
            //                _penaltyKicker = _team[i];
            //        if (_penaltyKicker == null)
            //        {
            //            //UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //            throw new System.Xml.XmlException("Error in PenaltyKicker, player can't be found in the teamsheet");
            //        }
            //    }
            //}
            //else if ((System.Object) tag == (System.Object) "Action")
            //    this._currentAction = attributes.GetValue("value");
            //else if ((System.Object) tag == (System.Object) "Argument")
            //    this._currentArguments.Add(attributes.GetValue("value"));
            //else if ((System.Object) tag == (System.Object) "Condition")
            //{
            //    string type = attributes.GetValue("type");
            //    /* What happens if the XML doesn't declare the attribute sign ? */
            //    string sign = attributes.GetValue("sign");
            //    string value_Renamed = attributes.GetValue("value");
            //    Condition C;
            //    if (type.Equals("MIN"))
            //        C = new MinCondition(sign, System.Int32.Parse(value_Renamed));
            //    else if (type.Equals("SCORE"))
            //        C = new ScoreCondition(sign, System.Int32.Parse(value_Renamed));
            //    else if (type.Equals("INJ"))
            //        C = new InjCondition(value_Renamed);
            //    else if (type.Equals("YELLOW"))
            //        C = new YellowCondition(value_Renamed);
            //    else if (type.Equals("RED"))
            //        C = new RedCondition(value_Renamed);
            //    else
            //    {
            //        //UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //        throw new System.Xml.XmlException("", new System.Exception("Condition type not allowed"));
            //    }
				
            //    this._currentConditions.Add(C);
            //}
        }
        public virtual void endElement(string str, string str2, string tag)
        {
            throw new NotImplementedException("Error en Engine.Roster. endElement(string str, string str2, string tag). HZ: Creo que este metodo se usa cerrar los archivos XML generado por lo que no se estaria usando mas.");

            //if ((System.Object) tag == (System.Object) "Conditional")
            //{
            //    Action A;
            //    if (_currentAction.Equals("TACTIC"))
            //        A = new TacticAction((string) (_currentArguments[0]));
            //    else if (_currentAction.Equals("SUB"))
            //        A = new SubAction((string) (_currentArguments[0]), (string) (_currentArguments[1]), (string) (_currentArguments[2]));
            //    else if (_currentAction.Equals("CHANGEPOS"))
            //        A = new ChangePosAction((string) (_currentArguments[0]), (string) (_currentArguments[1]));
            //    else
            //    {
            //        //UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            //        throw new System.Xml.XmlException("", new System.Exception("Error: unable to understand action type"));
            //    }
            //    _vCond.Add(new Conditional(A, (Condition[]) SupportClass.ICollectionSupport.ToArray(_currentConditions, new Condition[0])));

            //    /* Empty Vectors and currentXYZ data */
            //    _currentAction = null;
            //    _currentArguments.Clear();
            //    _currentConditions.Clear();
            //}
            //if ((System.Object) tag == (System.Object) "TeamSheet")
            //{
            //    // This should be avoided.
            //    //cond = (Conditional[])vCond.toArray(new Conditional[0]);
            //    //vCond.clear();
            //}
            //SupportClass.StackSupport.Pop(_tagStack);
        }
        public virtual void save()
        {
            save(this.Abbreviation + "sht.xml");
        }

        public virtual void save(string filename)
        {
            throw new NotImplementedException("Error en Engine.Roster.save(string filename). HZ: Creo que este metodo se usa para grabar los archivos XML generado por lo que no se estaria usando mas.");
            //try
            //{
            //    //FileWriter writer = new FileWriter(filename);
            //    //UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
            //    //UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
            //    System.IO.StreamWriter writer = new System.IO.StreamWriter(new System.IO.FileStream(filename, System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
            //    writer.Write(writeToString());
            //    writer.Flush();
            //    writer.Close();
            //}
            //catch (System.Exception err)
            //{
            //    System.Console.Out.WriteLine("Error while saving teamsheet as " + filename);
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
        private void writeConditional(System.Text.StringBuilder str, Conditional c)
        {
            throw new NotImplementedException("Error en Engine.Roster.writeConditional(System.Text.StringBuilder str, Conditional c). HZ: Creo que este metodo se usa para grabar cosas en los archivos XML generado por lo que no se estaria usando mas.");
            //str.Append("<Conditional>");
            //str.Append(c.Action.toXMLString());
            //Condition[] cond = c.Conditions;
            //for (int i = 0; i < cond.Length; i++)
            //    str.Append(cond[i].toXMLString());
            //str.Append("</Conditional>");
        }

        public virtual string writeToString()
        {
            throw new NotImplementedException("Error en Engine.Roster.writeToString(). HZ: Creo que este metodo se usa para grabar los archivos XML generado a disco por lo que no se estaria usando mas.");

            //string newLine = "\r\n";
            //System.Text.StringBuilder str = new System.Text.StringBuilder();
            //str.Append("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
            //str.Append(newLine);
            //str.Append("<TeamSheet name=\"" + this._abbr + "\" tactic=\"" + this._tactic.Name + "\">");
            //str.Append(newLine);
            //for (int i = 0; i < _team.Length; i++)
            //{
            //    if (_team[i] != null)
            //    {
            //        str.Append("<Player role=\"" + this._posTeam[i] + "\" name=\"" + this._team[i].Name + "\" side=\"" + this._sideTeam[i] + "\"/>");
            //        str.Append(newLine);
            //    }
            //}
            //for (int i = 0; i < _subs.Length; i++)
            //{
            //    if (_subs[i] != null)
            //    {
            //        str.Append("<Substitute role=\"" + this._posSubs[i] + "\" name=\"" + this._subs[i].Name + "\" side=\"" + this._sideSubs[i] + "\"/>");
            //        str.Append(newLine);
            //    }
            //}
            //if (_penaltyKicker != null)
            //{
            //    try
            //    {
            //        str.Append("<PenaltyKicker role=\"" + this.getPosition(this._penaltyKicker) + "\" name=\"" + this._penaltyKicker.Name + "\"/>");
            //        str.Append(newLine);
            //    }
            //    catch (System.Exception err)
            //    {
            //        System.Console.Out.WriteLine("Error while reading penalty kicker.");
            //    }
            //}
            //Conditional[] cond = this.Conditionals;
            //for (int i = 0; i < cond.Length; i++)
            //{
            //    writeConditional(str, cond[i]);
            //}
            //str.Append(newLine);
            //str.Append("</TeamSheet>");
            //return str.ToString();
        }
        #endregion

        #region Metodos auxiliares (por ej: test)
        /* Use for test purpose only!!!*/
        public virtual void printTeamSheet()
        {
            for (int i = 0; i < _team.Length; i++)
            {
                System.Console.Out.WriteLine(_team[i].name);
            }
        }
        #endregion

        #region Metodos comentados que no se usan
        //[STAThread]
        //public static void  Main(string[] args)
        //{
        //    try
        //    {
        //        //UPGRADE_ISSUE: Constructor 'java.text.SimpleDateFormat.SimpleDateFormat' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javatextSimpleDateFormat'"
        //        //UPGRADE_TODO: The equivalent in .NET for method 'java.util.Calendar.getTime' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
        //        System.Console.Out.WriteLine(Version.Name + " TeamSheet Importer Version " + Version.getVersion() + " - " + Version.Codename + " (" + SupportClass.FormatDateTime(new SimpleDateFormat("dd MMM yyyy"), SupportClass.CalendarManager.manager.GetDateTime(Version.LastBuild)) + ")\r\n" + Version.Features + "\r\n" + Version.Author);
        //        System.Console.Out.WriteLine("Converting ESMS Teamsheet named " + args[0] + " into JEsMS Teamsheet named " + args[1] + "...");
        //        convertFromESMS(new System.IO.FileInfo(args[0]), new System.IO.FileInfo(args[1]));
        //        System.Console.Out.WriteLine("Conversion succesfully ended.");
        //    }
        //    catch (System.IO.IOException err)
        //    {
        //        //UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Throwable.toString' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
        //        System.Console.Out.WriteLine(err.ToString());
        //    }
        //}

        //public static void  convertFromESMS(System.IO.FileInfo source, System.IO.FileInfo destination)
        //{
        //    //UPGRADE_TODO: The differences in the expected value  of parameters for constructor 'java.io.BufferedReader.BufferedReader'  may cause compilation errors.  "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1092'"
        //    //UPGRADE_WARNING: At least one expression was used more than once in the target code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1181'"
        //    //UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
        //    System.IO.StreamReader read = new System.IO.StreamReader(new System.IO.StreamReader(source.FullName, System.Text.Encoding.Default).BaseStream, new System.IO.StreamReader(source.FullName, System.Text.Encoding.Default).CurrentEncoding);
        //    //UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
        //    //UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javaioFile'"
        //    System.IO.StreamWriter w = new System.IO.StreamWriter(new System.IO.FileStream(destination.FullName, System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
        //    w.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
        //    w.Write("<TeamSheet");

        //    Pattern p = Pattern.compile("^(.{3})$");
        //    string text = read.ReadLine();
        //    Matcher m = p.matcher(text);
        //    while (!m.matches())
        //    {
        //        text = read.ReadLine();
        //        m = p.matcher(text);
        //    }
        //    w.Write(" name=\"" + m.group(1) + "\"");

        //    p = Pattern.compile("^([A-Z]{1})$");
        //    text = read.ReadLine();
        //    m = p.matcher(text);
        //    while (!m.matches())
        //    {
        //        text = read.ReadLine();
        //        m = p.matcher(text);
        //    }
        //    w.Write(" tactic=\"" + m.group(1) + "\">");

        //    for (int i = 0; i < 11; i++)
        //    {
        //        p = Pattern.compile("([GK|MF|FW|DF]{2}) {1,}(.*)");
        //        text = read.ReadLine();
        //        m = p.matcher(text);
        //        while (!m.matches())
        //        {
        //            text = read.ReadLine();
        //            m = p.matcher(text);
        //        }
        //        w.Write("<Player role=\"" + m.group(1) + "\" name=\"" + m.group(2).trim() + "\"/>");
        //    }

        //    Pattern p2 = Pattern.compile(".*PK: {1,}(.*)");
        //    text = read.ReadLine();
        //    m = p.matcher(text);
        //    Matcher m2 = p2.matcher(text);
        //    while (!m2.matches())
        //    {
        //        p = Pattern.compile("([GK|MF|FW|DF]{2}) {1,}(.*)");
        //        text = read.ReadLine();
        //        m = p.matcher(text);
        //        m2 = p2.matcher(text);
        //        while (!m.matches() && !m2.matches())
        //        {
        //            text = read.ReadLine();
        //            m = p.matcher(text);
        //            m2 = p2.matcher(text);
        //        }
        //        if (m.matches())
        //            w.Write("<Substitute role=\"" + m.group(1) + "\" name=\"" + m.group(2).trim() + "\"/>");
        //    }
        //    w.Write("<PenaltyKicker name=\"" + m2.group(1).trim() + "\"/>");

        //    Pattern pTactic = Pattern.compile(".*TACTIC {1,}([A-Z]{1}).*");
        //    Pattern pChangePos = Pattern.compile(".*CHANGEPOS {1,}([A-Z]{2}|\\d{1,2}) {1,}([A-Z]{2}).*");
        //    Pattern pSub = Pattern.compile(".*SUB {1,}([A-Z]{2}|\\d{1,2}) {1,}([A-Z]{2}|\\d{1,2}) {1,}([A-Z]{2}).*");

        //    Pattern pYellow = Pattern.compile(".*YELLOW {1,}([GK|DF|MF|FW]{2}|\\d{1,2})\\ *,*.*");
        //    Pattern pRed = Pattern.compile(".*RED {1,}([GK|DF|MF|FW]{2}|\\d{1,2})\\ *,*.*");
        //    Pattern pScore = Pattern.compile(".*SCORE {1,}(<|>|>=|=|<=|=<|=>) {1,}([-,\\d]*)\\ *,*.*");
        //    Pattern pMin = Pattern.compile(".*MIN {1,}(<|>|>=|=|<=|=<|=>) {1,}(\\d*)\\ *,*.*");
        //    Pattern pInj = Pattern.compile(".*INJ {1,}([GK|DF|MF|FW]{2}|\\d{1,2})\\ *,*.*");
        //    //Pattern pInj = Pattern.compile(".*INJ {1,}(<|>|>=|=|<=|=<|=>) {1,}([-,\\d]*)\\ *,*.*");

        //    while (read.Peek() != -1)
        //    {
        //        /* Is this line a conditional? */
        //        p = Pattern.compile("(.* IF .*)");
        //        text = read.ReadLine();
        //        m = p.matcher(text);
        //        //m2 = p2.matcher(text);
        //        while (!m.matches() && read.Peek() != -1)
        //        {
        //            text = read.ReadLine();
        //            m = p.matcher(text);
        //        }
        //        if (m.matches())
        //        {
        //            /* It's a conditional, i must parse it */
        //            w.Write("<Conditional>");
        //            if (pTactic.matcher(text).matches())
        //            {
        //                //is a tactic
        //                Matcher temp = pTactic.matcher(text);
        //                temp.matches();
        //                w.Write("<Action value=\"TACTIC\">");
        //                w.Write("<Argument value=\"" + temp.group(1) + "\"/>");
        //                w.Write("</Action>");
        //            }
        //            else if (pChangePos.matcher(text).matches())
        //            {
        //                //is a changepos
        //                Matcher temp = pChangePos.matcher(text);
        //                temp.matches();
        //                w.Write("<Action value=\"CHANGEPOS\">");
        //                w.Write("<Argument value=\"" + temp.group(1) + "\"/>");
        //                w.Write("<Argument value=\"" + temp.group(2) + "\"/>");
        //                w.Write("</Action>");
        //            }
        //            else if (pSub.matcher(text).matches())
        //            {
        //                //is a sub
        //                Matcher temp = pSub.matcher(text);
        //                temp.matches();
        //                w.Write("<Action value=\"SUB\">");
        //                w.Write("<Argument value=\"" + temp.group(1) + "\"/>");
        //                w.Write("<Argument value=\"" + temp.group(2) + "\"/>");
        //                w.Write("<Argument value=\"" + temp.group(3) + "\"/>");
        //                w.Write("</Action>");
        //            }
        //            /*I've parsed the Action, now it's the turn of conditions*/
        //            Pattern pSplit = Pattern.compile(",|IF");
        //            string[] conds = pSplit.split(text);
        //            for (int i = 1; i < conds.Length; i++)
        //            {
        //                if (pYellow.matcher(conds[i]).matches())
        //                {
        //                    //is a yellow card
        //                    Matcher temp = pYellow.matcher(conds[i]);
        //                    temp.matches();
        //                    w.Write("<Condition type=\"YELLOW\" ");
        //                    w.Write(" value=\"" + temp.group(1).replaceAll(",", " ").trim() + "\"/>");
        //                }
        //                else if (pRed.matcher(conds[i]).matches())
        //                {
        //                    ////is a red card
        //                    Matcher temp = pRed.matcher(conds[i]);
        //                    temp.matches();
        //                    w.Write("<Condition type=\"RED\" ");
        //                    w.Write(" value=\"" + temp.group(1).replaceAll(",", " ").trim() + "\"/>");
        //                }
        //                else if (pInj.matcher(conds[i]).matches())
        //                {
        //                    //is an injury
        //                    Matcher temp = pInj.matcher(conds[i]);
        //                    temp.matches();
        //                    w.Write("<Condition type=\"INJ\" ");
        //                    w.Write(" value=\"" + temp.group(1).replaceAll(",", " ").trim() + "\"/>");
        //                }
        //                else if (pScore.matcher(conds[i]).matches())
        //                {
        //                    //is a score
        //                    Matcher temp = pScore.matcher(conds[i]);
        //                    temp.matches();
        //                    w.Write("<Condition type=\"SCORE\" ");
        //                    //Quick substitution since XML doesn't want characters '>' and '<' directly
        //                    string sign = temp.group(1).replaceAll(">", "&gt;").replaceAll("<", "&lt;");
        //                    w.Write(" sign=\"" + sign + "\" value=\"" + temp.group(2).replaceAll(",", " ").trim() + "\"/>");
        //                }
        //                else if (pMin.matcher(conds[i]).matches())
        //                {
        //                    //is a tactic
        //                    Matcher temp = pMin.matcher(conds[i]);
        //                    temp.matches();
        //                    w.Write("<Condition type=\"MIN\" ");
        //                    //Quick substitution since XML doesn't want characters '>' and '<' directly
        //                    string sign = temp.group(1).replaceAll(">", "&gt;").replaceAll("<", "&lt;");
        //                    w.Write(" sign=\"" + sign + "\" value=\"" + temp.group(2).replaceAll(",", " ").trim() + "\"/>");
        //                }
        //            }
        //            w.Write("</Conditional>");
        //        }
        //        //w.write(" tactic=\""+m.group(1)+"\">");
        //    }
        //    w.Write("</TeamSheet>");
        //    w.Flush();
        //    w.Close();
        //}
        #endregion
    }
}