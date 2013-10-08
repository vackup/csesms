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
* PlayerComparator.java
*
* Created on 2 gennaio 2004, 11.17
*/
using System;
using Engine;
namespace Leaders
{
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class PlayerComparator : System.Collections.IComparer
	{
		
		public const int GOALS = 0;
		public const int DPS = 1;
		public const int ASSISTS = 2;
		public const int PERFORMANCE = 3;
		
		private int type;
		/// <summary>Creates a new instance of PlayerComparator </summary>
		public PlayerComparator(int type)
		{
			/* Here i should check that type is an allowed one */
			this.type = type;
		}
		
		public virtual int Compare(System.Object player1, System.Object player2)
		{
			LeadersPlayer p1 = (LeadersPlayer) player1;
			LeadersPlayer p2 = (LeadersPlayer) player2;
			
			switch (type)
			{
				
				case GOALS: 
					{
						if (p1.getGoals() != p2.getGoals())
							return - (p1.getGoals() - p2.getGoals());
						else
							return (p1.Games - p2.Games);
					}
					goto case DPS;
				
				case DPS: 
					{
						if (p1.Dps != p2.Dps)
							return - (p1.Dps - p2.Dps);
						else
							return (p1.Games - p2.Games);
					}
					goto case ASSISTS;
				
				case ASSISTS: 
					{
						if (p1.getAssists() != p2.getAssists())
							return - (p1.getAssists() - p2.getAssists());
						else
							return (p1.Games - p2.Games);
					}
					goto case PERFORMANCE;
				
				case PERFORMANCE: 
					{
						if (p1.Performance != p2.Performance)
							return - (p1.Performance - p2.Performance);
						else
							return (p1.Games - p2.Games);
					}
					goto default;
				
				default: 
					{
						if (p1.getGoals() != p2.getGoals())
							return - (p1.getGoals() - p2.getGoals());
						else
							return (p1.Games - p2.Games);
					}
					break;
				
			}
		}
		
		public  override bool Equals(System.Object obj)
		{
			return false;
		}
		//UPGRADE_NOTE: The following method implementation was automatically added to preserve functionality. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1306'"
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}