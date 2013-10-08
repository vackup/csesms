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
* GoalKeeperComparator.java
*
* Created on 27 agosto 2004, 9.50
*/
using System;
using Engine;
namespace TeamSheetCreator.Comparators
{
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class GoalKeeperComparator : System.Collections.IComparer
	{
		
		/// <summary>Creates a new instance of GoalKeeperComparator </summary>
		public GoalKeeperComparator()
		{
		}
		
		public virtual int Compare(System.Object obj, System.Object obj1)
		{
			if (obj.GetType() != typeof(Player) || obj1.GetType() != typeof(Player))
				throw new System.InvalidCastException();
			
			Player P1 = (Player) obj;
			Player P2 = (Player) obj1;
			
			if (P2.Keeping != P1.Keeping)
				return P2.Keeping - P1.Keeping;
			else
				return P2.getKeepingAbility() - P1.getKeepingAbility();
		}
	}
}