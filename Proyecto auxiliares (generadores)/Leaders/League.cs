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
* League.java
*
* Created on 2 gennaio 2004, 9.25
*/
using System;
using Engine;
namespace Leaders
{
	
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class League : XmlSaxContentHandler
	{
		virtual public System.String CompetitionName
		{
			get
			{
				return competitionName;
			}
			
		}
		virtual public System.String[] RosterNames
		{
			get
			{
				return (System.String[]) SupportClass.ICollectionSupport.ToArray(abbreviations, new System.String[0]);
			}
			
		}
		
		private System.String tablename;
		
		private System.String competitionName;
		
		/// <summary>Creates a new instance of League </summary>
		public League()
		{
			//Set tablename to default
			tablename = "table.xml";
			//Remember to initialize Config table.
			parseTableFile(tablename);
			transformFullNamesToAbbreviations();
		}
		
		private void  parseTableFile(System.String filename)
		{
			try
			{
				//UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
				XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
				//UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
				//UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
				System.IO.StreamReader r = new System.IO.StreamReader(filename, System.Text.Encoding.Default);
				parser.setContentHandler(this);
				parser.parse(new XmlSourceSupport(r));
			}
			//UPGRADE_ISSUE: Class 'javax.xml.parsers.ParserConfigurationException' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersParserConfigurationException'"
			catch (javax.xml.parsers.ParserConfigurationException err)
			{
				System.Console.Out.WriteLine("Error while parsing XML in table.xml");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			//UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
			catch (System.Xml.XmlException err)
			{
				System.Console.Out.WriteLine("Error while parsing XML in table.xml");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			catch (System.IO.IOException err)
			{
				System.Console.Out.WriteLine("Error while reading file table.xml");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
		}
		
		private void  transformFullNamesToAbbreviations()
		{
			abbreviations = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
			for (int i = 0; i < vTeams.Count; i++)
			{
				System.String name = (System.String) vTeams[i];
				abbreviations.Add(Config.getConfig().getAbbreviationFromName(name) + ".xml");
			}
		}
		/*----------- Interface ContentHandler ----------*/
		private System.Collections.ArrayList vTeams;
		private System.Collections.ArrayList abbreviations;
		
		public virtual void  characters(System.Char[] values, int param, int param2)
		{
		}
		
		public virtual void  endDocument()
		{
		}
		
		public virtual void  endElement(System.String str, System.String str1, System.String str2)
		{
		}
		
		public virtual void  endPrefixMapping(System.String str)
		{
		}
		
		//UPGRADE_TODO: Method 'org.xml.sax.ContentHandler.ignorableWhitespace' was converted to 'XmlSaxContentHandler.ignorableWhitespace' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
		public virtual void ignorableWhitespace(System.Char[] values, int param, int param2)
		{
		}
		
		public virtual void  processingInstruction(System.String str, System.String str1)
		{
		}
		
		//UPGRADE_TODO: The equivalent in .NET for method 'org.xml.sax.Locator' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
		public virtual void  setDocumentLocator(XmlSaxLocator locator)
		{
		}
		
		public virtual void  skippedEntity(System.String str)
		{
		}
		
		public virtual void  startDocument()
		{
			vTeams = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
		}
		
		public virtual void  startElement(System.String str, System.String str2, System.String tag, SaxAttributesSupport attributes)
		{
			if (tag.Equals("League"))
			{
				competitionName = attributes.GetValue("name");
			}
			if (tag.Equals("Team"))
			{
				vTeams.Add(attributes.GetValue("name"));
			}
		}
		
		public virtual void  startPrefixMapping(System.String str, System.String str1)
		{
		}
	}
}