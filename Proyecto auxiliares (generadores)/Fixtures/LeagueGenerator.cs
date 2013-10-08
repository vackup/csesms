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
* LeagueGenerator.java
*
* Created on 24 agosto 2004, 11.09
*/
using System;
using Engine;
namespace Fixtures
{
	/// <summary> </summary>
	/// <author>   Angelo Scotto
	/// </author>
	public class LeagueGenerator : IGenerator
	{
		virtual public Match[] Matches
		{
			get
			{
				
				System.Collections.ArrayList answer = new System.Collections.ArrayList();
				// I need to flat competition hierarchy
				for (int i = 0; i < weeks.Count; i++)
				{
					Match[] m = ((Week) weeks[i]).Matches;
					for (int j = 0; j < m.Length; j++)
					{
						answer.Add(m[j]);
					}
				}
				return (Match[]) answer.ToArray();
			}
			
		}
		
		private int numberWeek = 1;
		private int numberMatch = 1;
		private int offset = 0;
		private System.String[] teams;
		private System.String competition;
		private System.String weekName;
		
		private System.Collections.ArrayList weeks;
		
		/// <summary>Creates a new instance of LeagueGenerator </summary>
		public LeagueGenerator()
		{
			weeks = new System.Collections.ArrayList();
		}
		
		
		private void  GenerateRoundTwo()
		{
			System.Collections.ArrayList temp = new System.Collections.ArrayList();
			// I've simply to copy round one and switch sides
			for (int week = 0; week < this.weeks.Count; week++)
			{
				Week w = ((Week) this.weeks[week]).copyAndSwitch(System.Convert.ToString(this.weeks.Count + week + 1));
				temp.Add(w);
			}
			
			weeks.AddRange(temp);
		}
		
		private void  GenerateRoundOne()
		{
			int max = (teams.Length - 1);
			
			for (int week = 1; week <= max; week++)
			{
				GenerateWeek(week, week);
			}
			
			// Now i've to balance home/away
			balanceTeams();
		}
		
		public virtual void  Generate(System.String[] teams, System.String competition, System.String name)
		{
			this.competition = competition;
			this.weekName = name;
			this.teams = teams;
			scrambleTeams();
			GenerateRoundOne();
			GenerateRoundTwo();
		}
		
		private void  GenerateWeek(int numberWeek, int round)
		{
			Week w = new Week(System.Convert.ToString(numberWeek));
			int mid = 1;
			for (int team = 0; team < teams.Length; team = team + 2)
			{
				int home = calculateOffset(team, round - 1);
				int away = calculateOffset(team + 1, round - 1);
				
				w.addMatch(new Match("W" + System.Convert.ToString(numberWeek) + mid, teams[home], teams[away]));
				mid++;
			}
			weeks.Add(w);
		}
		public virtual void  WriteCompetition(System.String filename)
		{
			
			try
			{
				// Old way, actually it's better to use XmlFileMerge
				System.IO.FileInfo f = new System.IO.FileInfo(filename);
				//UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
				//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javaioFile'"
				System.IO.StreamWriter str = new System.IO.StreamWriter(new System.IO.FileStream(f.FullName, System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
				
				str.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
				str.Write("<Fixtures competition=\"" + competition + "\" weekName=\"" + weekName + "\" type=\"League\">");
				for (int week = 0; week < this.weeks.Count; week++)
				{
					Week w = (Week) this.weeks[week];
					str.Write("<Week id=\"" + w.Id + "\" played=\"false\">");
					Match[] m = w.Matches;
					for (int match = 0; match < m.Length; match++)
					{
						str.Write("<Match id=\"" + m[match].Id + "\" homeTeam=\"" + m[match].HomeTeam + "\" awayTeam=\"" + m[match].AwayTeam);
						if (m[match].Seed != - 1)
							str.Write("seed=\"" + m[match].Seed + "\"");
						str.Write("\"/>");
					}
					str.Write("</Week>");
				}
				str.Write("</Fixtures>");
				str.Flush();
				str.Close();
			}
			catch (System.Exception err)
			{
				//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Throwable.getMessage' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
				System.Console.Out.WriteLine("Error" + err.Message);
			}
		}
		
		[STAThread]
		public static void  Main(System.String[] args)
		{
			/*        
			int lungh = 8;
			for(int round = 0; round<lungh; round++) {
			System.out.println(round);
			for(int team = 0; team<lungh; team=team+2) {
			
			int home = calculateOffset(team, round);
			int away = calculateOffset(team+1, round);
			
			System.out.print(home);
			System.out.print("-");
			System.out.print(away);
			System.out.println();
			}
			}
			**/
		}
		
		private void  scrambleTeams()
		{
			//UPGRADE_TODO: Method 'java.util.Arrays.asList' was converted to 'System.Collections.ArrayList' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilArraysasList_javalangObject[]'"
			System.Collections.ArrayList numbers = new System.Collections.ArrayList(new System.Collections.ArrayList(teams));
			System.String[] p = new System.String[numbers.Count];
			System.Random r = new System.Random();
			for (int i = 0; i < teams.Length; i++)
			{
				int rand = r.Next(numbers.Count);
				p[i] = ((System.String) numbers[rand]);
				numbers.RemoveAt(rand);
			}
			this.teams = p;
		}
		
		private void  balanceTeams()
		{
			for (int week = 1; week < weeks.Count; week += 2)
			{
				((Week) weeks[week]).switchSides();
			}
		}
		
		private int calculateOffset(int team, int round)
		{
			int size = teams.Length;
			int currentRound = round;
			int answer = team;
			while (currentRound > 0)
			{
				if (answer != 0)
				{
					if (answer % 2 == 0)
						answer = answer + 2;
					else
						answer = answer - 2;
					if (answer == - 1)
						answer = 2;
					//if(answer == 1) answer = 2;
					if (answer == size - 1)
						answer = size - 2;
					if (answer == size)
						answer = size - 1;
				}
				currentRound--;
			}
			return answer;
		}
	}
}