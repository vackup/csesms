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
* Updater.java
*
* Created on 1 gennaio 2004, 22.04
*/
using System;
using Engine;
namespace Updater
{
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class Updater
	{
		public static long Seed
		{
			get
			{
				if (rnd != null)
					return Updater.seed;
				else
					throw new System.NullReferenceException("Random generator still not initialized!");
			}
			
		}
		public static System.Random Random
		{
			get
			{
				if (rnd != null)
					return rnd;
				//else throw new NullPointerException("Random generator still not initialized!");
				else
				{
					setRandomEngine();
					return rnd;
				}
			}
			
		}
		
		public virtual void  writeXSLTransform(System.String[] filenames, GenericSourceSupport XSL)
		{
			TransformerSupport tFactory = TransformerSupport.NewInstance();
			TransformerSupport temp_Transformer;
			temp_Transformer = TransformerSupport.NewTransform(tFactory);
			temp_Transformer.Load(XSL);
			TransformerSupport transformer = temp_Transformer;
			for (int i = 0; i < filenames.Length; i++)
			{
				//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
				transformer.DoTransform(new GenericSourceSupport(filenames[i] + ".xml"), new GenericResultSupport(new System.IO.FileStream(filenames[i] + ".out", System.IO.FileMode.Create)));
			}
		}
		
		private static System.String fixtureFile = null;
		
		/*A good solution could be move the random engine from ESMS to Engine and make all programs calls it*/
		/*---------- Section declaring the RandomGenerator ----------*/
		private static System.Random rnd;
		
		public static bool getThresold(int thresold)
		{
			int value_Renamed = Random.Next(10000);
			
			if (value_Renamed < thresold)
				return true;
			else
				return false;
		}
		private static long seed;
		
		public static void  setRandomEngine(long seed)
		{
			Updater.seed = seed;
			//UPGRADE_TODO: The differences in the expected value  of parameters for constructor 'java.util.Random.Random'  may cause compilation errors.  "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1092'"
			rnd = new System.Random((System.Int32) seed);
			/* else it should raise an exception or warn the user in some ways*/
		}
		
		public static void  setRandomEngine()
		{
			if (rnd == null)
			{
				System.Random temp = new System.Random();
				//UPGRADE_TODO: Method 'java.util.Random.nextLong' was converted to 'SupportClass.NextLong' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilRandomnextLong'"
				Updater.seed = SupportClass.NextLong(temp);
				//UPGRADE_TODO: The differences in the expected value  of parameters for constructor 'java.util.Random.Random'  may cause compilation errors.  "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1092'"
				rnd = new System.Random((System.Int32) Updater.seed);
			}
			/* else it should raise an exception or warn the user in some ways*/
		}
		/*---------- End of RandomGenerator declaration ----------*/
		
		/// <summary>Creates a new instance of Updater </summary>
		public Updater()
		{
		}
		
		private static System.String commandname = "updtr";
		
		private static System.String competitionName;
		
		// I need to add several externalUrls!
		protected internal static System.String externalUrl = null;
		protected internal static System.String externalUrls = null;
		protected internal static System.String externalUrli = null;
		protected internal static System.String externalUrlf = null;
		
		
		public static void  help()
		{
			System.Console.Out.WriteLine(Version.FullVersion);
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Usage: java " + commandname + " [-dS][-dI][-uR][-f:<fixtures>] ");
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Where:");
			System.Console.Out.WriteLine("-f:<fixture>: Updater will get matches to update using fixture contained in <fixture> xml file");
			System.Console.Out.WriteLine("-dS: Updater will decrease suspension days of teams which played a match");
			System.Console.Out.WriteLine("-dI: Updater will decrease injuries of teams which played a match");
			System.Console.Out.WriteLine("-uR: Updater will update rosters of teams which played a match");
			System.Console.Out.WriteLine("NOTICE: If no action is selected (dS/dI/uR) all of them will be applied");
			System.Console.Out.WriteLine("If only one or two actions are selected, just them are applied");
			System.Environment.Exit(0);
		}
		
		/// <summary> The Updater program must do the following tasks:
		/// decrese Injuries
		/// decrease Suspensions
		/// increase abilities and skills
		/// </summary>
		/// <param name="args">the command line arguments
		/// </param>
		[STAThread]
		public static void  Main(System.String[] args)
		{
			/*TODO: Change dS and dI to decrease injuries and suspensions of all teams, even those who 
			haven't played a match*/
			bool injuries = false, suspensions = false, rosters = false, injList = true, susList = true;
			System.String xls = null;
			
			for (int i = 0; i < args.Length; i++)
			{
				/* Parse parameter */
				if (args[i].ToLower().StartsWith("-di"))
					injuries = true;
				else if (args[i].ToLower().StartsWith("-ds"))
					suspensions = true;
				else if (args[i].ToLower().StartsWith("-ur"))
					rosters = true;
				else if (args[i].ToLower().StartsWith("-x:"))
					xls = args[i].Substring(3);
				else if (args[i].ToLower().StartsWith("-xe:"))
					externalUrl = args[i].Substring(4);
				else if (args[i].ToLower().StartsWith("-xi:"))
					externalUrli = args[i].Substring(4);
				else if (args[i].ToLower().StartsWith("-xs:"))
					externalUrls = args[i].Substring(4);
				else if (args[i].ToLower().StartsWith("-xf:"))
					externalUrlf = args[i].Substring(4);
				else if (args[i].ToLower().StartsWith("-f:"))
					fixtureFile = args[i].Substring(3);
				else if (args[i].ToLower().Equals("-h"))
					help();
				else
				{
					System.Console.Out.WriteLine("Illegal parameter passed to League Updater : use 'java " + commandname + " -h' for help");
					System.Environment.Exit(- 1);
				}
			}
			
			System.Console.Out.WriteLine(Version.FullVersion);
			System.Console.Out.WriteLine();
			
			Config.loadConfig("league.xml");
			
			if (!injuries && !suspensions && !rosters)
			{
				injuries = true;
				suspensions = true;
				rosters = true;
			}
			
			Match[] matches;
			
			if (fixtureFile == null)
			{
				MatchesParser MP = new MatchesParser();
				matches = MP.Matches;
			}
			else
			{
				FixtureParser FP = new FixtureParser(fixtureFile, externalUrlf);
				MatchesParser MP = new MatchesParser(FP.Commentaries);
				matches = MP.Matches;
				competitionName = FP.CompetitionName;
				FP.updateFixtures(matches);
			}
			try
			{
				
				if (injuries)
				{
					for (int i = 0; i < matches.Length; i++)
					{
						matches[i].decreaseInjuries();
						System.Console.Out.WriteLine("Decreased injuries in team " + matches[i].HomeTeam);
						System.Console.Out.WriteLine("Decreased injuries in team " + matches[i].AwayTeam);
					}
				}
				if (suspensions)
				{
					for (int i = 0; i < matches.Length; i++)
					{
						matches[i].decreaseSuspensions();
						System.Console.Out.WriteLine("Decreased suspensions in team " + matches[i].HomeTeam);
						System.Console.Out.WriteLine("Decreased suspensions in team " + matches[i].AwayTeam);
					}
				}
				if (rosters)
				{
					for (int i = 0; i < matches.Length; i++)
					{
						matches[i].updateRosters();
						System.Console.Out.WriteLine("Updated roster for team " + matches[i].HomeTeam);
						System.Console.Out.WriteLine("Updated roster for team " + matches[i].AwayTeam);
					}
				}
				
				if (injList)
				{
					System.Collections.ArrayList injured = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
					for (int i = 0; i < matches.Length; i++)
					{
						injured.AddRange(matches[i].Injured());
					}
					//Write the file
					//UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
					//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
					System.IO.StreamWriter FW = new System.IO.StreamWriter(new System.IO.FileStream("injured.xml", System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
					writeInjured(FW, injured);
					System.Console.Out.WriteLine("Injured List written in the Injured.xml file");
				}
				if (susList)
				{
					System.Collections.ArrayList suspended = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
					for (int i = 0; i < matches.Length; i++)
					{
						suspended.AddRange(matches[i].Suspended());
					}
					//Write the file
					//UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
					//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
					System.IO.StreamWriter FW = new System.IO.StreamWriter(new System.IO.FileStream("suspended.xml", System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
					writeSuspended(FW, suspended);
					System.Console.Out.WriteLine("Suspension List written in the Suspended.xml file");
				}
			}
			catch (System.Exception err)
			{
				System.Console.Out.WriteLine("Error found while applying actions.");
				SupportClass.WriteStackTrace(err, Console.Error);
				System.Environment.Exit(- 1);
			}
		}
		
		//UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Writer' and 'System.IO.StreamWriter' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
		public static void  writeInjured(System.IO.StreamWriter output, System.Collections.ICollection c)
		{
			output.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
			if (externalUrli != null)
				output.Write("<?xml-stylesheet type=\"text/xsl\" href=\"" + externalUrli + "\"?>");
			if (fixtureFile == null)
				output.Write("<Injured>");
			else
				output.Write("<Injured competitionName=\"" + competitionName + "\">");
			System.Collections.IEnumerator E = c.GetEnumerator();
			//UPGRADE_TODO: Method 'java.util.Iterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratorhasNext'"
			while (E.MoveNext())
			{
				//UPGRADE_TODO: Method 'java.util.Iterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratornext'"
				PlayerWrapper t = (PlayerWrapper) E.Current;
				output.Write("<Player name=\"" + t.Player.Name + "\" team=\"" + t.Team + "\" weeks=\"" + t.Player.Injury + "\"/>");
			}
			output.Write("</Injured>");
			output.Flush();
		}
		//UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Writer' and 'System.IO.StreamWriter' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
		public static void  writeSuspended(System.IO.StreamWriter output, System.Collections.ICollection c)
		{
			output.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
			if (externalUrls != null)
				output.Write("<?xml-stylesheet type=\"text/xsl\" href=\"" + externalUrls + "\"?>");
			if (fixtureFile == null)
				output.Write("<Suspended>");
			else
				output.Write("<Suspended competitionName=\"" + competitionName + "\">");
			System.Collections.IEnumerator E = c.GetEnumerator();
			//UPGRADE_TODO: Method 'java.util.Iterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratorhasNext'"
			while (E.MoveNext())
			{
				//UPGRADE_TODO: Method 'java.util.Iterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratornext'"
				PlayerWrapper t = (PlayerWrapper) E.Current;
				output.Write("<Player name=\"" + t.Player.Name + "\" team=\"" + t.Team + "\" weeks=\"" + t.Player.Suspension + "\"/>");
			}
			output.Write("</Suspended>");
			output.Flush();
		}
	}
}