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
* GeneratorConfig.java
*
* Created on 9 ottobre 2004, 9.47
*/
using System;
namespace RosterGenerator
{
	
	/// <summary>  This class simply parse content of an XML config file for RosterGenerator.
	/// 
	/// 
	/// </summary>
	/// <author>   Angelo
	/// </author>
	public class GeneratorConfig : XmlSaxContentHandler
	{
		
		public const int KEEPING = 0;
		public const int TACKLING = 1;
		public const int PASSING = 2;
		public const int SHOOTING = 3;
		public const int AGGRESSION = 4;
		public const int AGE = 5;
		public const int TOTALALLOWED = 6;
		
		private int[] max = new int[7];
		private int[] min = new int[7];
		
		private System.Random rnd = new System.Random();
		
		public virtual int generate(int value_Renamed)
		{
			if (max[value_Renamed] == - 1 || min[value_Renamed] == - 1)
				throw new System.Exception("Config data has not been loaded");
			if (value_Renamed < 7)
				return rnd.Next(max[value_Renamed] - min[value_Renamed]) + min[value_Renamed];
			else
				return - 1;
		}
		
		public virtual bool isValid(int total)
		{
			return (total < max[TOTALALLOWED] && total > min[TOTALALLOWED]);
		}
		
		/// <summary>Creates a new instance of GeneratorConfig </summary>
		public GeneratorConfig(System.String fileName)
		{
			initTable();
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
			catch (javax.xml.parsers.ParserConfigurationException err)
			{
				System.Console.Out.WriteLine("Error while parsing XML in " + fileName + " file");
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			//UPGRADE_TODO: Class 'org.xml.sax.SAXException' was converted to 'System.Xml.XmlException' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
			catch (System.Xml.XmlException err)
			{
				System.Console.Out.WriteLine("Error while parsing XML in " + fileName);
				SupportClass.WriteStackTrace(err, Console.Error);
			}
			catch (System.IO.IOException err)
			{
				System.Console.Out.WriteLine("Error while reading file " + fileName);
				SupportClass.WriteStackTrace(err, Console.Error);
			}
		}
		
		private void  initTable()
		{
			for (int i = 0; i < 6; i++)
			{
				min[i] = - 1;
				max[i] = - 1;
			}
		}
		/// <summary>****** Interface ContentHandler ****************</summary>
		protected internal System.Collections.ArrayList tagStack;
		
		public virtual void  characters(System.Char[] text, int start, int length)
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
			tagStack = new System.Collections.ArrayList();
		}
		
		public virtual void  startElement(System.String str, System.String str2, System.String tag, SaxAttributesSupport attributes)
		{
			tagStack.Add(tag);
			if ((System.Object) tag == (System.Object) "Keeping")
			{
				max[KEEPING] = System.Int32.Parse(attributes.GetValue("max"));
				min[KEEPING] = System.Int32.Parse(attributes.GetValue("min"));
			}
			else if ((System.Object) tag == (System.Object) "Tackling")
			{
				max[TACKLING] = System.Int32.Parse(attributes.GetValue("max"));
				min[TACKLING] = System.Int32.Parse(attributes.GetValue("min"));
			}
			else if ((System.Object) tag == (System.Object) "Passing")
			{
				max[PASSING] = System.Int32.Parse(attributes.GetValue("max"));
				min[PASSING] = System.Int32.Parse(attributes.GetValue("min"));
			}
			else if ((System.Object) tag == (System.Object) "Shooting")
			{
				max[SHOOTING] = System.Int32.Parse(attributes.GetValue("max"));
				min[SHOOTING] = System.Int32.Parse(attributes.GetValue("min"));
			}
			else if ((System.Object) tag == (System.Object) "Aggression")
			{
				max[AGGRESSION] = System.Int32.Parse(attributes.GetValue("max"));
				min[AGGRESSION] = System.Int32.Parse(attributes.GetValue("min"));
			}
			else if ((System.Object) tag == (System.Object) "Age")
			{
				max[AGE] = System.Int32.Parse(attributes.GetValue("max"));
				min[AGE] = System.Int32.Parse(attributes.GetValue("min"));
			}
			else if ((System.Object) tag == (System.Object) "TotalAllowed")
			{
				max[TOTALALLOWED] = System.Int32.Parse(attributes.GetValue("max"));
				min[TOTALALLOWED] = System.Int32.Parse(attributes.GetValue("min"));
			}
		}
		
		public virtual void  startPrefixMapping(System.String str, System.String str1)
		{
		}
	}
}