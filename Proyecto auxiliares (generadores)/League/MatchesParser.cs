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
* MatchesParses.java
*
* Created on 1 gennaio 2004, 18.20
*/
using System;
namespace League
{
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class MatchesParser : XmlSaxContentHandler
	{
		virtual public Match[] Matches
		{
			get
			{
				return (Match[]) SupportClass.ICollectionSupport.ToArray(vMatches, new Match[0]);
			}
			
		}
		private System.Collections.ArrayList vMatches;
		
		private System.String todayString;
		private void  initDate()
		{
			//UPGRADE_ISSUE: Constructor 'java.text.SimpleDateFormat.SimpleDateFormat' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javatextSimpleDateFormat'"
			//UPGRADE_TODO: The equivalent in .NET for method 'java.util.Calendar.getTime' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
			todayString = SupportClass.FormatDateTime(new SimpleDateFormat("ddMMyy"), SupportClass.CalendarManager.manager.GetDateTime(new System.Globalization.GregorianCalendar()));
		}
		
		public MatchesParser(System.String dirbase)
		{
			vMatches = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
			initDate();
			System.IO.FileInfo f = new System.IO.FileInfo(dirbase);
			//UPGRADE_TODO: The equivalent in .NET for method 'java.io.File.list' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
			System.String[] xmlfiles = System.IO.Directory.GetFileSystemEntries(f.FullName);
			for (int i = 0; i < xmlfiles.Length; i++)
			{
				if (xmlfiles[i].ToLower().EndsWith(".xml"))
				{
					try
					{
						//UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
						XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
						//UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
						//UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
						System.IO.StreamReader r = new System.IO.StreamReader(xmlfiles[i], System.Text.Encoding.Default);
						parser.setContentHandler(this);
						parser.parse(new XmlSourceSupport(r));
					}
					//UPGRADE_ISSUE: Class 'javax.xml.parsers.ParserConfigurationException' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersParserConfigurationException'"
					catch (javax.xml.parsers.ParserConfigurationException err)
					{
						System.Console.Out.WriteLine("Error while parsing XML in " + xmlfiles[i] + " file");
						SupportClass.WriteStackTrace(err, Console.Error);
					}
					//UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
					catch (System.Xml.XmlException err)
					{
						System.Console.Out.WriteLine("Error while parsing XML in " + xmlfiles[i] + " file");
						SupportClass.WriteStackTrace(err, Console.Error);
					}
					catch (System.IO.IOException err)
					{
						System.Console.Out.WriteLine("Error while reading " + xmlfiles[i] + ".xml file");
						SupportClass.WriteStackTrace(err, Console.Error);
					}
				}
			}
		}
		
		/// <summary>Creates a new instance of MatchesParses </summary>
		public MatchesParser()
		{
			vMatches = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
			initDate();
			System.IO.FileInfo f = new System.IO.FileInfo(".");
			//UPGRADE_TODO: The equivalent in .NET for method 'java.io.File.list' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
			System.String[] xmlfiles = System.IO.Directory.GetFileSystemEntries(f.FullName);
			for (int i = 0; i < xmlfiles.Length; i++)
			{
				if (xmlfiles[i].ToLower().EndsWith(".xml"))
				{
					try
					{
						//UPGRADE_TODO: Method 'javax.xml.parsers.SAXParser.getXMLReader' was converted to 'SupportClass.XmlSAXDocumentManager' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
						XmlSAXDocumentManager parser = XmlSAXDocumentManager.CloneInstance(XmlSAXDocumentManager.NewInstance());
						//UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Reader' and 'System.IO.StreamReader' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
						//UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
						System.IO.StreamReader r = new System.IO.StreamReader(xmlfiles[i], System.Text.Encoding.Default);
						parser.setContentHandler(this);
						parser.parse(new XmlSourceSupport(r));
					}
					//UPGRADE_ISSUE: Class 'javax.xml.parsers.ParserConfigurationException' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersParserConfigurationException'"
					catch (javax.xml.parsers.ParserConfigurationException err)
					{
						System.Console.Out.WriteLine("Error while parsing XML in " + xmlfiles[i] + " file");
						SupportClass.WriteStackTrace(err, Console.Error);
					}
					//UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
					catch (System.Xml.XmlException err)
					{
						System.Console.Out.WriteLine("Error while parsing XML in " + xmlfiles[i] + " file");
						SupportClass.WriteStackTrace(err, Console.Error);
					}
					catch (System.IO.IOException err)
					{
						System.Console.Out.WriteLine("Error while reading " + xmlfiles[i] + ".xml file");
						SupportClass.WriteStackTrace(err, Console.Error);
					}
				}
			}
		}
		/*---------- Interface ContentHandler ----------*/
		//UPGRADE_TODO: The 'System.Boolean' structure does not have an equivalent to NULL. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1291'"
		internal System.Boolean matchAlreadyFound = null;
		internal System.String currentHomeTeam, currentAwayTeam;
		internal int currentHomeScore, currentAwayScore;
		public virtual void  characters(System.Char[] values, int param, int param2)
		{
		}
		
		public virtual void  endDocument()
		{
			//UPGRADE_TODO: The 'System.Boolean' structure does not have an equivalent to NULL. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1291'"
			matchAlreadyFound = null;
		}
		
		public virtual void  endElement(System.String str, System.String str2, System.String tag)
		{
			if (tag.Equals("Match") && matchAlreadyFound)
			{
				vMatches.Add(new Match(currentHomeTeam, currentHomeScore, currentAwayTeam, currentAwayScore));
				currentHomeTeam = null;
				currentAwayTeam = null;
				currentHomeScore = - 1;
				currentAwayScore = - 1;
			}
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
			//UPGRADE_TODO: The 'System.Boolean' structure does not have an equivalent to NULL. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1291'"
			if (!tag.Equals("Match") && matchAlreadyFound == null)
				matchAlreadyFound = false;
			//UPGRADE_TODO: The 'System.Boolean' structure does not have an equivalent to NULL. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1291'"
			if (tag.Equals("Match") && matchAlreadyFound == null && attributes.GetValue("date").Equals(todayString))
			{
				/* The match file needs to be parsed */
				matchAlreadyFound = true;
				currentHomeTeam = attributes.GetValue("home");
				currentAwayTeam = attributes.GetValue("away");
			}
			//UPGRADE_TODO: The 'System.Boolean' structure does not have an equivalent to NULL. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1291'"
			if (matchAlreadyFound != null && matchAlreadyFound.Equals(true))
			{
				if (tag.Equals("Score"))
				{
					currentHomeScore = System.Int32.Parse(attributes.GetValue("home"));
					currentAwayScore = System.Int32.Parse(attributes.GetValue("away"));
				}
			}
		}
		
		public virtual void  startPrefixMapping(System.String str, System.String str1)
		{
		}
	}
}