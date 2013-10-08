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
* TeamSheetCreator.java
*
* Created on 27 agosto 2004, 9.48
*/
using System;
using Engine;
using TeamSheetCreator.Comparators;
//UPGRADE_TODO: The package 'java.util.regex' could not be found. If it was not included in the conversion, there may be compiler issues. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1262'"
using java.util.regex;
namespace TeamSheetCreator
{
	/// <summary> </summary>
	/// <author>   Angelo Scotto
	/// </author>
	public class TeamSheetCreator
	{
		
		private static System.String commandname = "tsc";
		
		internal TeamSheet teamsheet;
		
		internal Roster roster;
		
		internal int df, mf, fw;
		
		internal int sdf, smf, sfw;
		
		internal System.String tactic;
		
		private System.String[] sequence = new System.String[]{"DF", "MF", "DF", "FW", "MF"};
		
		/// <summary>Creates a new instance of TeamSheetCreator </summary>
		public TeamSheetCreator(System.String filename)
		{
			Config.loadConfig("league.xml");
			Tactic.parseTactics("tactics.xml");
			roster = new Roster(filename);
			//Parse command line and read roster;
			teamsheet = new TeamSheet(roster);
		}
		
		public virtual void  generateTeamSheet(System.String formation)
		{
			try
			{
				sdf = calculateHowMuchSubs("DF");
				smf = calculateHowMuchSubs("MF");
				sfw = calculateHowMuchSubs("FW");
				parseFormation(formation);
				writeTeamSheet();
			}
			catch (System.Exception err)
			{
				SupportClass.WriteStackTrace(err, Console.Error);
			}
		}
		internal virtual void  writeTeamSheet()
		{
			teamsheet.save();
		}
		
		public static void  help()
		{
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Usage: java " + commandname + " [-h] [-x:<xslfile>] [-xe:<url>] <roster> <formation> ");
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Where:");
			System.Console.Out.WriteLine("<roster>: the name of the xml file containing the roster of the team.");
			System.Console.Out.WriteLine("<formation>: a '-' separated string indicating formation (such as\"4-4-2-N\")");
			System.Console.Out.WriteLine("-h: Shows this help screen");
			System.Environment.Exit(0);
		}
		
		[STAThread]
		public static void  Main(System.String[] args)
		{
			System.Console.Out.WriteLine(Version.FullVersion);
			
			System.String formation = null;
			System.String rostername = null;
			
			if (args.Length == 0)
				help();
			
			for (int i = 0; i < args.Length; i++)
			{
				/* Parse parameter */
				if (args[i].ToLower().Equals("-h"))
					help();
				else if (!args[i].StartsWith("-"))
				{
					if (rostername != null)
						formation = args[i];
					else
						rostername = args[i];
				}
				else
				{
					System.Console.Out.WriteLine("Illegal parameter passed to TeamSheet creator : use 'java " + commandname + " -h' for help");
					System.Environment.Exit(- 1);
				}
			}
			
			if (formation == null || rostername == null)
			{
				System.Console.Out.WriteLine();
				System.Console.Out.WriteLine("Error: Wrong number of parameters!");
				help();
			}
			
			TeamSheetCreator tsc = new TeamSheetCreator(rostername);
			tsc.generateTeamSheet(formation);
			tsc.writeTeamSheet();
		}
		
		internal virtual void  setGoalKeepers()
		{
			//Player[] goalkeepers = roster.getPlayers();
			Player[] goalkeepers = removeUnavailable();
			System.Array.Sort(goalkeepers, new GoalKeeperComparator());
			
			teamsheet.setPlayer(0, goalkeepers[0], "GK");
			
			teamsheet.setSub(0, goalkeepers[1], "GK");
		}
		
		internal virtual int calculateHowMuchSubs(System.String role)
		{
			int answer = 0;
			for (int i = 0; i < ((System.Int32) Config.getConfig().getConfigValue("NUM_SUBS")) - 1; i++)
				if (sequence[i % 5].Equals(role))
					answer++;
			return answer;
		}
		
		internal virtual void  setDefenders()
		{
			//Player[] defenders = roster.getPlayers();
			Player[] defenders = removeUnavailable();
			System.Array.Sort(defenders, new DefenderComparator());
			
			for (int i = 0; i < df; i++)
				teamsheet.setPlayer(i + 1, defenders[i], "DF");
			
			for (int i = 0; i < sdf; i++)
				teamsheet.setSub(i + 1, defenders[df + i], "DF");
		}
		
		internal virtual void  setMidfielders()
		{
			//Player[] midfielders = roster.getPlayers();
			Player[] midfielders = removeUnavailable();
			System.Array.Sort(midfielders, new MidfielderComparator());
			
			for (int i = 0; i < mf; i++)
				teamsheet.setPlayer(i + 1 + df, midfielders[i], "MF");
			
			for (int i = 0; i < smf; i++)
				teamsheet.setSub(i + sdf + 1, midfielders[mf + i], "MF");
		}
		
		internal virtual void  setForwarders()
		{
			//Player[] forwarders = roster.getPlayers();
			Player[] forwarders = removeUnavailable();
			System.Array.Sort(forwarders, new ForwarderComparator());
			
			for (int i = 0; i < fw; i++)
				teamsheet.setPlayer(i + 1 + df + mf, forwarders[i], "FW");
			
			for (int i = 0; i < sfw; i++)
				teamsheet.setSub(i + sdf + smf + 1, forwarders[fw + i], "FW");
			
			teamsheet.setPenaltyKicker(df + mf + 1);
		}
		
		
		internal virtual Player[] removeUnavailable()
		{
			System.Collections.ArrayList available = new System.Collections.ArrayList();
			//UPGRADE_NOTE: There is an untranslated Statement.  Please refer to original code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1153'"
			//UPGRADE_NOTE: There is an untranslated Statement.  Please refer to original code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1153'"
			try
			{
				for (int i = 1; i < teamsheet.NumPlayers; i++)
				{
					if (available.Contains(teamsheet.getPlayer(i)))
					{
						SupportClass.ICollectionSupport.Remove(available, teamsheet.getPlayer(i));
					}
				}
			}
			catch (System.Exception error)
			{
				SupportClass.WriteStackTrace(error, Console.Error);
				System.Environment.Exit(- 1);
			}
			return (Player[]) SupportClass.ICollectionSupport.ToArray(available, new Player[0]);
		}
		
		internal virtual void  parseFormation(System.String formation)
		{
			//Parse formation using split        
			System.String[] strings = formation.split("-");
			
			df = System.Int32.Parse(strings[0]);
			mf = System.Int32.Parse(strings[1]);
			fw = System.Int32.Parse(strings[2]);
			tactic = strings[3];
			
			teamsheet.Tactic = ((Tactic) Tactic.Tactics[tactic]);
			setGoalKeepers();
			setDefenders();
			setMidfielders();
			setForwarders();
		}
	}
}