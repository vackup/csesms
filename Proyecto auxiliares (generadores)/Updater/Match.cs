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
* Match.java
*
* Created on 3 gennaio 2004, 16.53
*/
using System;
using Engine;
namespace Updater
{
	
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class Match
	{
		virtual public int HomeScore
		{
			get
			{
				return homeScore;
			}
			
		}
		virtual public int AwayScore
		{
			get
			{
				return awayScore;
			}
			
		}
		virtual public System.String HomeTeam
		{
			get
			{
				return homeTeam;
			}
			
		}
		virtual public System.String AwayTeam
		{
			get
			{
				return awayTeam;
			}
			
		}
		
		private System.String homeTeam;
		private System.String awayTeam;
		private int homeScore;
		private int awayScore;
		
		public virtual void  setScore(int homeScore, int awayScore)
		{
			this.homeScore = homeScore;
			this.awayScore = awayScore;
		}
		
		private System.Collections.ArrayList homePlayers;
		private System.Collections.ArrayList awayPlayers;
		
		/// <summary>Creates a new instance of Match </summary>
		public Match(System.String home, System.String away)
		{
			this.homeTeam = home;
			this.awayTeam = away;
			
			homePlayers = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
			awayPlayers = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
		}
		
		public virtual void  addPlayer(System.String team, UpdaterPlayer p)
		{
			if (team.Equals(homeTeam))
				homePlayers.Add(p);
			else if (team.Equals(awayTeam))
				awayPlayers.Add(p);
			else
				throw new System.Exception("team " + team + " is not in the match");
		}
		
		public virtual void  updateRosters()
		{
			//First of all i must load the two rosters.
			Roster homeR = new Roster(homeTeam + ".xml");
			Roster awayR = new Roster(awayTeam + ".xml");
			
			for (int i = 0; i < homePlayers.Count; i++)
			{
				UpdaterPlayer up = (UpdaterPlayer) homePlayers[i];
				if (up.played())
				{
					Player player = homeR.getPlayer(up.Name);
					int oldDps = player.Dps;
					player.increaseAbilities(up.StIncrease, up.TkIncrease, up.PsIncrease, up.ShIncrease);
					player.increaseStats(up.Saves, up.Tackles, up.Passes, up.Shots, up.Goals, up.Assists, up.Dps);
					player.Injury = up.Injury;
					//Ora bisogna settare le suspensions
					int newDps = player.Dps;
					int margin = ((System.Int32) Config.getConfig().getConfigValue("SUSPENSION_MARGIN"));
					int suspension;
					if (oldDps % margin < newDps % margin)
						suspension = newDps % margin;
				}
			}
			
			for (int i = 0; i < awayPlayers.Count; i++)
			{
				UpdaterPlayer up = (UpdaterPlayer) awayPlayers[i];
				if (up.played())
				{
					Player player = awayR.getPlayer(up.Name);
					int oldDps = player.Dps;
					player.increaseAbilities(up.StIncrease, up.TkIncrease, up.PsIncrease, up.ShIncrease);
					player.increaseStats(up.Saves, up.Tackles, up.Passes, up.Shots, up.Goals, up.Assists, up.Dps);
					player.Injury = up.Injury;
					//Ora bisogna settare le suspensions
					int newDps = player.Dps;
					int margin = ((System.Int32) Config.getConfig().getConfigValue("SUSPENSION_MARGIN"));
					int suspension;
					if (oldDps % margin < newDps % margin)
						suspension = newDps % margin;
				}
			}
			
			homeR.WriteRoster(Updater.externalUrl);
			awayR.WriteRoster(Updater.externalUrl);
		}
		
		public virtual System.Collections.ICollection Suspended()
		{
			System.Collections.ArrayList answer = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
			
			Roster homeR = new Roster(homeTeam + ".xml");
			Roster awayR = new Roster(awayTeam + ".xml");
			
			
			//UPGRADE_NOTE: There is an untranslated Statement.  Please refer to original code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1153'"
			//UPGRADE_NOTE: There is an untranslated Statement.  Please refer to original code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1153'"
			return answer;
		}
		
		public virtual System.Collections.ICollection Injured()
		{
			System.Collections.ArrayList answer = System.Collections.ArrayList.Synchronized(new System.Collections.ArrayList(10));
			
			Roster homeR = new Roster(homeTeam + ".xml");
			Roster awayR = new Roster(awayTeam + ".xml");
			
			//UPGRADE_NOTE: There is an untranslated Statement.  Please refer to original code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1153'"
			//UPGRADE_NOTE: There is an untranslated Statement.  Please refer to original code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1153'"
			
			return answer;
		}
		
		public virtual void  decreaseInjuries()
		{
			//First of all i must load the two rosters.
			Roster homeR = new Roster(homeTeam + ".xml");
			Roster awayR = new Roster(awayTeam + ".xml");
			
			homeR.decreaseInjuries();
			awayR.decreaseInjuries();
			
			homeR.WriteRoster(Updater.externalUrl);
			awayR.WriteRoster(Updater.externalUrl);
		}
		
		public virtual void  decreaseSuspensions()
		{
			//First of all i must load the two rosters.
			Roster homeR = new Roster(homeTeam + ".xml");
			Roster awayR = new Roster(awayTeam + ".xml");
			
			homeR.decreaseSuspensions();
			awayR.decreaseSuspensions();
			
			homeR.WriteRoster(Updater.externalUrl);
			awayR.WriteRoster(Updater.externalUrl);
		}
		
		public override System.String ToString()
		{
			return this.homeTeam + " " + this.homeScore + " - " + awayScore + " " + awayTeam;
		}
	}
}