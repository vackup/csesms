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
* UpdaterPlayer.java
*
* Created on 3 gennaio 2004, 17.10
*/
using System;
using Engine;
namespace Updater
{
	/// <summary> It's not a true player (it doesn't inherit from Engine.Player) but it contains just fields needed to update
	/// Roster
	/// </summary>
	/// <author>   Angelo
	/// </author>
	public class UpdaterPlayer
	{
		virtual public System.String Team
		{
			get
			{
				return teamAbbr;
			}
			
			set
			{
				teamAbbr = value;
			}
			
		}
		virtual public System.String Name
		{
			get
			{
				return name;
			}
			
		}
		virtual public int StIncrease
		{
			get
			{
				return this.stIncrease;
			}
			
		}
		virtual public int TkIncrease
		{
			get
			{
				return this.tkIncrease;
			}
			
		}
		virtual public int PsIncrease
		{
			get
			{
				return this.psIncrease;
			}
			
		}
		virtual public int ShIncrease
		{
			get
			{
				return this.shIncrease;
			}
			
		}
		virtual public int Saves
		{
			get
			{
				return this.saves;
			}
			
		}
		virtual public int Tackles
		{
			get
			{
				return this.ktk;
			}
			
		}
		virtual public int Passes
		{
			get
			{
				return this.kps;
			}
			
		}
		virtual public int Goals
		{
			get
			{
				return this.goals;
			}
			
		}
		virtual public int Shots
		{
			get
			{
				return this.shots;
			}
			
		}
		virtual public int Assists
		{
			get
			{
				return this.assists;
			}
			
		}
		virtual public int Dps
		{
			/*An interesting thing to understand is if the second yellow is counted as a red or not*/
			
			get
			{
				return this.red * (((System.Int32) Config.getConfig().getConfigValue("DP_FOR_RED"))) + this.yellow * ((System.Int32) Config.getConfig().getConfigValue("DP_FOR_YELLOW"));
			}
			
		}
		virtual public int Injury
		{
			get
			{
				return this.injured;
			}
			/*    public int getSuspension()
			{
			return this.suspended;
			}*/
			
		}
		
		private System.String name;
		private System.String teamAbbr;
		private bool matchPlayed = false;
		private int stIncrease, tkIncrease, psIncrease, shIncrease;
		private int saves, ktk, kps, assists, shots, goals, yellow, red;
		private int injured, suspended;
		
		/// <summary>Creates a new instance of UpdaterPlayer, the player has not played </summary>
		public UpdaterPlayer(System.String name)
		{
			this.name = name;
			matchPlayed = false;
			stIncrease = tkIncrease = psIncrease = shIncrease = 0;
			saves = ktk = kps = assists = shots = goals = yellow = red;
			injured = suspended = 0;
		}
		
		public UpdaterPlayer(System.String name, int stIncrease, int tkIncrease, int psIncrease, int shIncrease, int saves, int ktk, int kps, int assists, int shots, int goals, int yellow, int red, bool injured)
		{
			this.matchPlayed = true;
			this.name = name;
			this.stIncrease = stIncrease;
			this.tkIncrease = tkIncrease;
			this.psIncrease = psIncrease;
			this.shIncrease = shIncrease;
			this.saves = saves;
			this.ktk = ktk;
			this.kps = kps;
			this.assists = assists;
			this.shots = shots;
			this.goals = goals;
			this.yellow = yellow;
			this.red = red;
			if (injured)
				this.injured = Updater.Random.Next(((System.Int32) Config.getConfig().getConfigValue("MAX_INJURY")));
			else
				this.injured = 0;
		}
		
		public virtual bool played()
		{
			return this.matchPlayed;
		}
	}
}