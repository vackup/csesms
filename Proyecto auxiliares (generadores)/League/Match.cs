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
* Created on 1 gennaio 2004, 18.50
*/
using System;
namespace League
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
				return this.awayScore;
			}
			
		}
		virtual public System.String HomeTeam
		{
			get
			{
				return this.homeName;
			}
			
		}
		virtual public System.String AwayTeam
		{
			get
			{
				return this.awayName;
			}
			
		}
		
		private int homeScore, awayScore;
		private System.String homeName, awayName;
		
		/// <summary>Creates a new instance of Match </summary>
		public Match(System.String homeName, int homeScore, System.String awayName, int awayScore)
		{
			this.homeName = homeName;
			this.homeScore = homeScore;
			this.awayScore = awayScore;
			this.awayName = awayName;
		}
	}
}