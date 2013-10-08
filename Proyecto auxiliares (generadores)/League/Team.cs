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
* Team.java
*
* Created on 31 dicembre 2003, 13.09
*/
using System;
using Engine;
namespace League
{
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class Team
	{
		virtual public System.String Name
		{
			get
			{
				return name;
			}
			
		}
		
		internal System.String name;
		internal int won, lost, draw;
		internal int goalFor, goalAgainst;
		internal int points;
		
		/// <summary>Creates a new instance of Team </summary>
		public Team(System.String name, int won, int lost, int draw, int goalFor, int goalAgainst, int points)
		{
			this.name = name;
			this.won = won;
			this.lost = lost;
			this.draw = draw;
			this.goalFor = goalFor;
			this.goalAgainst = goalAgainst;
			this.points = points;
		}
		
		public Team(System.String name, System.String won, System.String lost, System.String draw, System.String goalFor, System.String goalAgainst, System.String points)
		{
			this.name = name;
			this.won = System.Int32.Parse(won);
			this.lost = System.Int32.Parse(lost);
			this.draw = System.Int32.Parse(draw);
			this.goalFor = System.Int32.Parse(goalFor);
			this.goalAgainst = System.Int32.Parse(goalAgainst);
			this.points = System.Int32.Parse(points);
		}
		
		public virtual void  addMatch(int ourScore, int oppScore)
		{
			try
			{
				if (ourScore > oppScore)
				{
					this.won++;
					this.points += ((System.Int32) Config.getConfig().getConfigValue("WINPTS"));
				}
				else if (ourScore < oppScore)
					this.lost++;
				else
				{
					this.draw++;
					this.points += ((System.Int32) Config.getConfig().getConfigValue("DRAWPTS"));
				}
				this.goalFor += ourScore;
				this.goalAgainst += oppScore;
			}
			catch (System.Exception err)
			{
				SupportClass.WriteStackTrace(err, Console.Error);
			}
		}
		
		public virtual void  Clean()
		{
			won = 0;
			draw = 0;
			lost = 0;
			goalFor = 0;
			goalAgainst = 0;
			points = 0;
		}
		
		//UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Writer' and 'System.IO.StreamWriter' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
		public virtual void  writeTeam(System.IO.StreamWriter output)
		{
			output.Write("<Team name=\"" + name + "\" won=\"" + won + "\" draw=\"" + draw + "\" lost=\"" + lost + "\" goalsFor=\"" + goalFor + "\" goalsAgainst=\"" + goalAgainst + "\" points=\"" + points + "\"/>");
			output.Flush();
		}
	}
}