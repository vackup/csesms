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
* Created on 31 dicembre 2003, 12.58
*/
using System;
using Engine;
namespace League
{
	
	/// <summary> TODO: Merge Match and Team objects with Engine Match objects.</summary>
	/// <author>   Angelo Scotto
	/// </author>
	public class League : XmlSaxContentHandler
	{
		
		private static System.String externalUrl = null;
		
		public League(int teams)
		{
			vTeams = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
			this.name = "Template League";
			for (int i = 0; i < teams; i++)
			{
				Team t = new Team("Team n." + i, 0, 0, 0, 0, 0, 0);
				vTeams[t.Name] = t;
			}
		}
		/// <summary>Creates a new instance of League </summary>
		public League(System.String fileName, System.String fixtures)
		{
			
			vTeams = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
			tagStack = new System.Collections.ArrayList();
			
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
			//UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
			catch (System.Xml.XmlException err)
			{
				System.Console.Out.WriteLine("Error while parsing XML in " + fileName + ".xml file");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			catch (System.IO.IOException err)
			{
				System.Console.Out.WriteLine("Error while reading " + fileName + ".xml file");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			
			//UPGRADE_TODO: Method 'java.util.Enumeration.hasMoreElements' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationhasMoreElements'"
			for (System.Collections.IEnumerator e = vTeams.Values.GetEnumerator(); e.MoveNext(); )
			{
				//UPGRADE_TODO: Method 'java.util.Enumeration.nextElement' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilEnumerationnextElement'"
				((Team) e.Current).Clean();
			}
			
			FixturesParser parser2 = new FixturesParser(fixtures);
			Engine.Match[] m = parser2.Matches;
			for (int i = 0; i < m.Length; i++)
			{
				Team home = (Team) vTeams[m[i].HomeTeam];
				Team away = (Team) vTeams[m[i].AwayTeam];
				
				if (m[i].hasBeenPlayed())
				{
					home.addMatch(m[i].HomeScore, m[i].AwayScore);
					away.addMatch(m[i].AwayScore, m[i].HomeScore);
				}
			}
		}
		
		/// <summary>Creates a new instance of League </summary>
		public League(System.String fileName)
		{
			vTeams = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
			tagStack = new System.Collections.ArrayList();
			
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
			//UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
			catch (System.Xml.XmlException err)
			{
				System.Console.Out.WriteLine("Error while parsing XML in " + fileName + ".xml file");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			catch (System.IO.IOException err)
			{
				System.Console.Out.WriteLine("Error while reading " + fileName + ".xml file");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			
			MatchesParser parser2 = new MatchesParser();
			Match[] m = parser2.Matches;
			for (int i = 0; i < m.Length; i++)
			{
				Team home = (Team) vTeams[Config.getConfig().getConfigValue(m[i].HomeTeam)];
				Team away = (Team) vTeams[Config.getConfig().getConfigValue(m[i].AwayTeam)];
				
				home.addMatch(m[i].HomeScore, m[i].AwayScore);
				away.addMatch(m[i].AwayScore, m[i].HomeScore);
			}
		}
		
		public virtual void  writeXSLTransform(System.String filename, GenericSourceSupport XSL)
		{
			TransformerSupport tFactory = TransformerSupport.NewInstance();
			TransformerSupport temp_Transformer;
			temp_Transformer = TransformerSupport.NewTransform(tFactory);
			temp_Transformer.Load(XSL);
			TransformerSupport transformer = temp_Transformer;
			//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
			transformer.DoTransform(new GenericSourceSupport(filename + ".xml"), new GenericResultSupport(new System.IO.FileStream(filename + ".out", System.IO.FileMode.Create)));
		}
		
		//UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Writer' and 'System.IO.StreamWriter' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
		public virtual void  writeXML(System.IO.StreamWriter output)
		{
			output.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
			if (externalUrl != null)
				output.Write("<?xml-stylesheet type=\"text/xsl\" href=\"" + externalUrl + "\"?>");
			output.Write("<League name=\"" + this.name + "\">");
			System.Collections.IEnumerator E = vTeams.Values.GetEnumerator();
			//UPGRADE_TODO: Method 'java.util.Iterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratorhasNext'"
			while (E.MoveNext())
			{
				//UPGRADE_TODO: Method 'java.util.Iterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratornext'"
				Team t = (Team) E.Current;
				t.writeTeam(output);
			}
			output.Write("</League>");
			output.Flush();
		}
		
		/*---------- Static Section of League file ----------*/
		
		private static System.String commandname = "lgtable";
		/// <param name="args">the command line arguments
		/// </param>
		[STAThread]
		public static void  Main(System.String[] args)
		{
			/* Parsing parameters */
			//UPGRADE_TODO: The 'System.Int32' structure does not have an equivalent to NULL. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1291'"
			System.Int32 num = null;
			System.String filename = null;
			System.String xls = null;
			System.String fixtures = null;
			
			/* Here the League object has been correctly initialized */
			System.Console.Out.WriteLine(Version.FullVersion);
			System.Console.Out.WriteLine();
			
			for (int i = 0; i < args.Length; i++)
			{
				/* Parse parameter */
				if (args[i].ToLower().StartsWith("-t:"))
					num = System.Int32.Parse(args[i].Substring(3));
				else if (args[i].ToLower().StartsWith("-f:"))
					fixtures = args[i].Substring(3);
				else if (args[i].ToLower().Equals("-h"))
					help();
				else if (args[i].ToLower().StartsWith("-x:"))
					xls = args[i].Substring(3);
				else if (args[i].ToLower().StartsWith("-xe:"))
					externalUrl = args[i].Substring(4);
				else if (!args[i].StartsWith("-"))
				{
					filename = args[i];
				}
				else
				{
					System.Console.Out.WriteLine("Illegal parameter passed to League Updater : use 'java " + commandname + " -h' for help");
					System.Environment.Exit(- 1);
				}
			}
			if (filename == null)
				filename = "table.xml";
			try
			{
				League L;
				//UPGRADE_TODO: The 'System.Int32' structure does not have an equivalent to NULL. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1291'"
				if (num == null)
				{
					if (fixtures == null)
						L = new League(filename);
					else
						L = new League(filename, fixtures);
				}
				else
					L = new League(num);
				//FileWriter FW = new FileWriter(filename);
				//UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
				//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
				System.IO.StreamWriter FW = new System.IO.StreamWriter(new System.IO.FileStream(filename, System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
				L.writeXML(FW);
				FW.Close();
			}
			catch (System.Exception err)
			{
				//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Throwable.getMessage' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
				System.Console.Out.WriteLine(err.Message);
				SupportClass.WriteStackTrace(err, Console.Error);
			}
		}
		
		public static void  help()
		{
			System.Console.Out.WriteLine(Version.FullVersion);
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Usage: java " + commandname + " [<tablename>] [-t:<numTeams>] [-f:<fixturefile>] [-x:<xslfile>] [-xe:<url>]");
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Where:");
			System.Console.Out.WriteLine("<tablename>: the name of the xml file containing the table to update");
			System.Console.Out.WriteLine("-t:<numTeams>: Creates a template of a table with <numTeams> teams");
			System.Console.Out.WriteLine("-xe:<url>: Add url as external xsl source to table.xml");
			System.Console.Out.WriteLine("-f:<fixturefile>: Creates a template of a table with <numTeams> teams");
			System.Console.Out.WriteLine("In this case <tablename> is the name of the file created");
			System.Console.Out.WriteLine("NOTICE: If <tablename> is not passed as parameter the default name of 'table.xml' is used");
			System.Environment.Exit(0);
		}
		/*---------- End of Static Section ----------*/
		
		private System.String name;
		private Team[] teams;
		
		public virtual void  printTable()
		{
			for (int i = 0; i < teams.Length; i++)
			{
				System.Console.Out.WriteLine(teams[i].Name);
			}
		}
		
		/*---------- Interface ContentHandler ----------*/
		private System.Collections.ArrayList tagStack;
		private System.Collections.Hashtable vTeams = null;
		
		public virtual void  characters(System.Char[] values, int param, int param2)
		{
		}
		
		public virtual void  endDocument()
		{
		}
		
		public virtual void  endElement(System.String str, System.String tag, System.String str2)
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
				Team t = new Team(attributes.GetValue("name"), attributes.GetValue("won"), attributes.GetValue("lost"), attributes.GetValue("draw"), attributes.GetValue("goalsFor"), attributes.GetValue("goalsAgainst"), attributes.GetValue("points"));
				vTeams[t.Name] = t;
			}
		}
		
		public virtual void  startPrefixMapping(System.String str, System.String str1)
		{
		}
	}
}