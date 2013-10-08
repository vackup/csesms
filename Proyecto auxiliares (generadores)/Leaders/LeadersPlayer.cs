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
* LeadersPlayer.java
*
* Created on 3 gennaio 2004, 15.46
*/
using System;
namespace Leaders
{
	
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class LeadersPlayer:Engine.Player
	{
		virtual public System.String Team
		{
			get
			{
				return team;
			}
			
		}
		virtual public int Performance
		{
			get
			{
				return this.getGoals() * 9 + this.getShots() + this.getTackles() * 6 + this.getSaves() * 3 + this.getAssists() * 7 + this.getKeyPasses() * 4 - this.Dps;
			}
			
		}
		
		private System.String team;
		
		/// <summary>Creates a new instance of LeadersPlayer </summary>
		public LeadersPlayer(Engine.Player p, System.String team):base(p.Name, p.Nationality, p.Age, p.Keeping, p.Tackling, p.Passing, p.Shooting, p.getAggression(), p.getKeepingAbility(), p.getTacklingAbility(), p.getPassingAbility(), p.getShootingAbility(), p.Games, p.getSaves(), p.getTackles(), p.getKeyPasses(), p.getShots(), p.getGoals(), p.getAssists(), p.Dps, p.Injury, p.Suspension)
		{
			this.team = team;
		}
	}
}