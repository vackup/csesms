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
* Leaders.java
*
* Created on 1 gennaio 2004, 22.09
*/
using System;
using Engine;
namespace Leaders
{
	
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class Leaders
	{
		private LeadersPlayer[] totPlayers;
		private System.String competitionName;
		
		private static System.String externalUrls = null;
		private static System.String externalUrld = null;
		private static System.String externalUrla = null;
		private static System.String externalUrlp = null;
		
		/// <summary>Creates a new instance of Leaders </summary>
		public Leaders()
		{
			//Loads teams from a league table (uses default table.xml).
			League L = new League();
			competitionName = L.CompetitionName;
			System.String[] names = L.RosterNames;
			Roster[] Rosters = new Roster[names.Length];
			System.Collections.ArrayList totPlayers = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
			int total = 0;
			
			for (int i = 0; i < names.Length; i++)
			{
				Rosters[i] = new Roster(names[i]);
				
				Player[] pList = Rosters[i].getPlayers().toArray(new Player[0]);
				
				for (int j = 0; j < pList.Length; j++)
				{
					//Convert player into LeadersPlayer
					pList[j] = new LeadersPlayer(pList[j], Rosters[i].Abbreviation);
				}
				//UPGRADE_TODO: Method 'java.util.Arrays.asList' was converted to 'System.Collections.ArrayList' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilArraysasList_javalangObject[]'"
				totPlayers.AddRange(new System.Collections.ArrayList(pList));
			}
			/* Now teams are loaded */
			/* Loads all players in a single array */
			this.totPlayers = (LeadersPlayer[]) SupportClass.ICollectionSupport.ToArray(totPlayers, new LeadersPlayer[0]);
		}
		
		public virtual void  createScorers(int maxnumber)
		{
			// Delete previous existing File scorers.xml
			System.IO.FileInfo temp = new System.IO.FileInfo("scorers.xml");
			bool tmpBool;
			if (System.IO.File.Exists(temp.FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists(temp.FullName);
			if (tmpBool)
			{
				bool tmpBool2;
				if (System.IO.File.Exists(temp.FullName))
				{
					System.IO.File.Delete(temp.FullName);
					tmpBool2 = true;
				}
				else if (System.IO.Directory.Exists(temp.FullName))
				{
					System.IO.Directory.Delete(temp.FullName);
					tmpBool2 = true;
				}
				else
					tmpBool2 = false;
				bool generatedAux = tmpBool2;
			}
			System.Array.Sort(totPlayers, new PlayerComparator(PlayerComparator.GOALS));
			//UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
			//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
			System.IO.StreamWriter output = new System.IO.StreamWriter(new System.IO.FileStream("scorers.xml", System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
			output.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
			if (externalUrls != null)
				output.Write("<?xml-stylesheet type=\"text/xsl\" href=\"" + externalUrls + "\"?>");
			output.Write("<Scorers competitionName=\"" + competitionName + "\">");
			for (int i = 0; i < maxnumber; i++)
			{
				output.Write("<Player name=\"" + totPlayers[i].Name + "\" team=\"" + totPlayers[i].Team + "\" value=\"" + totPlayers[i].getGoals() + "\" games=\"" + totPlayers[i].Games + "\"/>");
			}
			output.Write("</Scorers>");
			output.Flush();
			output.Close();
		}
		
		public virtual void  createDps(int maxnumber)
		{
			System.IO.FileInfo temp = new System.IO.FileInfo("dps.xml");
			bool tmpBool;
			if (System.IO.File.Exists(temp.FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists(temp.FullName);
			if (tmpBool)
			{
				bool tmpBool2;
				if (System.IO.File.Exists(temp.FullName))
				{
					System.IO.File.Delete(temp.FullName);
					tmpBool2 = true;
				}
				else if (System.IO.Directory.Exists(temp.FullName))
				{
					System.IO.Directory.Delete(temp.FullName);
					tmpBool2 = true;
				}
				else
					tmpBool2 = false;
				bool generatedAux = tmpBool2;
			}
			System.Array.Sort(totPlayers, new PlayerComparator(PlayerComparator.DPS));
			//UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
			//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
			System.IO.StreamWriter output = new System.IO.StreamWriter(new System.IO.FileStream("dps.xml", System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
			output.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
			if (externalUrld != null)
				output.Write("<?xml-stylesheet type=\"text/xsl\" href=\"" + externalUrld + "\"?>");
			output.Write("<Dps competitionName=\"" + competitionName + "\">");
			for (int i = 0; i < maxnumber; i++)
			{
				output.Write("<Player name=\"" + totPlayers[i].Name + "\" team=\"" + totPlayers[i].Team + "\" value=\"" + totPlayers[i].Dps + "\" games=\"" + totPlayers[i].Games + "\"/>");
			}
			output.Write("</Dps>");
			output.Flush();
			output.Close();
		}
		
		public virtual void  createAssists(int maxnumber)
		{
			System.IO.FileInfo temp = new System.IO.FileInfo("assisters.xml");
			bool tmpBool;
			if (System.IO.File.Exists(temp.FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists(temp.FullName);
			if (tmpBool)
			{
				bool tmpBool2;
				if (System.IO.File.Exists(temp.FullName))
				{
					System.IO.File.Delete(temp.FullName);
					tmpBool2 = true;
				}
				else if (System.IO.Directory.Exists(temp.FullName))
				{
					System.IO.Directory.Delete(temp.FullName);
					tmpBool2 = true;
				}
				else
					tmpBool2 = false;
				bool generatedAux = tmpBool2;
			}
			System.Array.Sort(totPlayers, new PlayerComparator(PlayerComparator.ASSISTS));
			//UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
			//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
			System.IO.StreamWriter output = new System.IO.StreamWriter(new System.IO.FileStream("assisters.xml", System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
			output.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
			if (externalUrla != null)
				output.Write("<?xml-stylesheet type=\"text/xsl\" href=\"" + externalUrla + "\"?>");
			output.Write("<Assisters competitionName=\"" + competitionName + "\">");
			for (int i = 0; i < maxnumber; i++)
			{
				output.Write("<Player name=\"" + totPlayers[i].Name + "\" team=\"" + totPlayers[i].Team + "\" value=\"" + totPlayers[i].getAssists() + "\" games=\"" + totPlayers[i].Games + "\"/>");
			}
			output.Write("</Assisters>");
			output.Flush();
			output.Close();
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
		
		public virtual void  createPerforms(int maxnumber)
		{
			System.IO.FileInfo temp = new System.IO.FileInfo("performs.xml");
			bool tmpBool;
			if (System.IO.File.Exists(temp.FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists(temp.FullName);
			if (tmpBool)
			{
				bool tmpBool2;
				if (System.IO.File.Exists(temp.FullName))
				{
					System.IO.File.Delete(temp.FullName);
					tmpBool2 = true;
				}
				else if (System.IO.Directory.Exists(temp.FullName))
				{
					System.IO.Directory.Delete(temp.FullName);
					tmpBool2 = true;
				}
				else
					tmpBool2 = false;
				bool generatedAux = tmpBool2;
			}
			System.Array.Sort(totPlayers, new PlayerComparator(PlayerComparator.PERFORMANCE));
			//UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
			//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
			System.IO.StreamWriter output = new System.IO.StreamWriter(new System.IO.FileStream("performs.xml", System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
			output.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
			if (externalUrlp != null)
				output.Write("<?xml-stylesheet type=\"text/xsl\" href=\"" + externalUrlp + "\"?>");
			output.Write("<Performs competitionName=\"" + competitionName + "\">");
			for (int i = 0; i < maxnumber; i++)
			{
				output.Write("<Player name=\"" + totPlayers[i].Name + "\" team=\"" + totPlayers[i].Team + "\" value=\"" + totPlayers[i].Performance + "\" games=\"" + totPlayers[i].Games + "\"/>");
			}
			output.Write("</Performs>");
			output.Flush();
			output.Close();
		}
		
		public static System.String CommandName = "leader";
		
		public static void  help()
		{
			System.Console.Out.WriteLine("Usage: java " + CommandName + " [-h] [<NumPlayers>] [-xs:<url1>] [-xd:<url2>] [-xa:<url3>] [-xp:<url4>]");
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Where:");
			System.Console.Out.WriteLine("<NumPlayers>: the number of players to show in the tables");
			System.Console.Out.WriteLine("<url1>: the URL of the xsl sheet used to parse scorers.xml");
			System.Console.Out.WriteLine("<url2>: the URL of the xsl sheet used to parse dps.xml");
			System.Console.Out.WriteLine("<url3>: the URL of the xsl sheet used to parse assisters.xml");
			System.Console.Out.WriteLine("<url4>: the URL of the xsl sheet used to parse performs.xml");
			System.Console.Out.WriteLine("-h: shows this screen");
			System.Console.Out.WriteLine("NOTICE: if no <NumPlayers> is inserted the program will use the default value of 20");
			System.Environment.Exit(0);
		}
		/// <summary> The Leaders program uses roster files to calculate
		/// leaders of the league.
		/// </summary>
		/// <param name="args">the command line arguments
		/// </param>
		[STAThread]
		public static void  Main(System.String[] args)
		{
			try
			{
				System.Console.Out.WriteLine(Version.FullVersion);
				System.Console.Out.WriteLine();
				
				System.String xls = null;
				int num = 0;
				//Loads Config data from config.xml file
				Config.loadConfig("league.xml");
				for (int i = 0; i < args.Length; i++)
				{
					/* Parse parameter */
					if (args[i].ToLower().Equals("-h"))
						help();
					else if (args[i].ToLower().StartsWith("-x:"))
						xls = args[i].Substring(3);
					else if (args[i].ToLower().StartsWith("-xs:"))
						externalUrls = args[i].Substring(4);
					else if (args[i].ToLower().StartsWith("-xd:"))
						externalUrld = args[i].Substring(4);
					else if (args[i].ToLower().StartsWith("-xa:"))
						externalUrla = args[i].Substring(4);
					else if (args[i].ToLower().StartsWith("-xp:"))
						externalUrlp = args[i].Substring(4);
					else if (!args[i].StartsWith("-"))
					{
						try
						{
							num = System.Int32.Parse(args[i]);
						}
						catch (System.FormatException err)
						{
							System.Console.Out.WriteLine("Illegal usage of Leaders: expecting number as parameter, usage 'java " + CommandName + " -h' for help"); System.Environment.Exit(- 1);
						}
					}
				}
				
				if (num == 0)
					num = 20;
				
				Leaders leaders = new Leaders();
				leaders.createScorers(num);
				System.Console.Out.WriteLine("Scorers.xml created.");
				leaders.createPerforms(num);
				System.Console.Out.WriteLine("Performs.xml created.");
				leaders.createAssists(num);
				System.Console.Out.WriteLine("Assisters.xml created.");
				leaders.createDps(num);
				System.Console.Out.WriteLine("Dps.xml created.");
			}
			catch (System.IO.FileNotFoundException err)
			{
				System.Console.Out.WriteLine("Error: Impossible to find league.xml file!");
				System.Environment.Exit(- 1);
			}
			catch (System.Exception err)
			{
				SupportClass.WriteStackTrace(err, Console.Error);
				System.Environment.Exit(- 1);
			}
		}
	}
}