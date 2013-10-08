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
* Created on 31 dicembre 2003, 15.20
*/
using System;
using Engine;
using Team = League.Team;
namespace Fixtures
{
	
	/// <summary>  Fixture Creator
	/// 
	/// </summary>
	/// <author>   Angelo Scotto
	/// </author>
	public class Fixtures : XmlSaxContentHandler
	{
		private System.String[] Teams
		{
			get
			{
				return (System.String[]) SupportClass.ICollectionSupport.ToArray(vTeams, new System.String[0]);
			}
			
		}
		
		private const System.String CommandName = "fgen";
		private static System.String externalUrl = null;
		private static System.String filename = "fixtures.xml";
		private static System.String wname = "Week";
		private static System.String cname = "Competition";
		
		private static bool seed = false;
		
		/// <summary>Creates a new instance of Fixtures </summary>
		public Fixtures(System.String tableFile, System.String output)
		{
			vTeams = new System.Collections.ArrayList();
			try
			{
				//UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
				XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
				//UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
				//UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
				System.IO.StreamReader r = new System.IO.StreamReader(tableFile, System.Text.Encoding.Default);
				parser.setContentHandler(this);
				parser.parse(new XmlSourceSupport(r));
			}
			//UPGRADE_ISSUE: Class 'javax.xml.parsers.ParserConfigurationException' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersParserConfigurationException'"
			catch (javax.xml.parsers.ParserConfigurationException err)
			{
				System.Console.Out.WriteLine("Error while parsing XML in " + tableFile + " file");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			//UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
			catch (System.Xml.XmlException err)
			{
				System.Console.Out.WriteLine("Error while parsing XML in " + tableFile + " file");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			catch (System.IO.IOException err)
			{
				System.Console.Out.WriteLine("Error while reading " + tableFile + " file");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			
			IGenerator gen = new LeagueGenerator();
			gen.Generate(Teams, cname, wname);
			if (seed)
				PunkBuster.GenerateSeeds(gen);
			gen.WriteCompetition(output);
		}
		
		public static void  help()
		{
			System.Console.Out.WriteLine(Version.FullVersion);
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Usage: java " + CommandName + " [-h] [-s] [<fixture>] [-c:<cname>] [-w:<wname>]");
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Where:");
			System.Console.Out.WriteLine("<fixture>: filename of the output file");
			System.Console.Out.WriteLine("<cname>: name of the competition being generated");
			System.Console.Out.WriteLine("<wname>: term used to indicate \"weeks\" in this competition");
			System.Console.Out.WriteLine("-s: enable automatic seed generation (anticheat)");
			System.Console.Out.WriteLine("-h: shows this screen");
			System.Console.Out.WriteLine("NOTICE: if no <fixture> is inserted the program will use the default value of \"fixture.xml\"");
			System.Environment.Exit(0);
		}
		
		/// <summary> The Fixtures program is used to create a fixture based on a league table.</summary>
		/// <param name="args">the command line arguments
		/// </param>
		[STAThread]
		public static void  Main(System.String[] args)
		{
			try
			{
				System.String tableFile = "table.xml";
				System.String xls = null;
				int num = 0;
				//Loads Config data from config.xml file
				Config.loadConfig("league.xml");
				for (int i = 0; i < args.Length; i++)
				{
					/* Parse parameter */
					if (args[i].ToLower().Equals("-s"))
						seed = true;
					if (args[i].ToLower().Equals("-h"))
						help();
					else if (args[i].ToLower().StartsWith("-c:"))
						cname = args[i].Substring(3);
					else if (args[i].ToLower().StartsWith("-w:"))
						wname = args[i].Substring(3);
					else if (!args[i].StartsWith("-"))
					{
						filename = args[i];
					}
				}
				
				System.Console.Out.WriteLine(Version.FullVersion);
				System.Console.Out.WriteLine();
				
				Fixtures f = new Fixtures(tableFile, filename);
			}
			catch (System.Exception err)
			{
				SupportClass.WriteStackTrace(err, Console.Error);
				System.Environment.Exit(- 1);
			}
		}
		
		/// <summary>************* Interface ContentHandler *********************</summary>
		private System.Collections.ArrayList tagStack = new System.Collections.ArrayList();
		private System.Collections.ArrayList vTeams = null;
		private System.String name;
		
		public virtual void  characters(System.Char[] values, int param, int param2)
		{
		}
		
		public virtual void  endDocument()
		{
		}
		
		public virtual void  endElement(System.String str, System.String str1, System.String str2)
		{
			SupportClass.StackSupport.Pop(tagStack);
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
		}
		
		public virtual void  startElement(System.String str, System.String str2, System.String tag, SaxAttributesSupport attributes)
		{
			tagStack.Add(tag);
			if ((System.Object) tag == (System.Object) "League")
			{
				name = attributes.GetValue("name");
			}
			else if ((System.Object) tag == (System.Object) "Team")
			{
				vTeams.Add(attributes.GetValue("name"));
			}
		}
		
		public virtual void  startPrefixMapping(System.String str, System.String str1)
		{
		}
	}
}