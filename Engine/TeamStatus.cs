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
* TeamStatus.java
*
* Created on 26 dicembre 2003, 9.31
*/
using System;
using CSEsMS.Domain.Entities;

namespace CSEsMS.Engine
{
    /// <summary> I believe that in this version of code this class is useless</summary>
    /// <author>   Angelo
    /// </author>
    public class TeamStatus
    {
		
        /// <summary>Creates a new instance of TeamStatus </summary>
        public TeamStatus()
        {
        }
		
        public int score;
		
        /* 0 means that no player of the team has been injured/sent off/booked
		during the current minute */
        public int injured;
        public int suspended;
        public int yellow;
		
        public Tactic currentTactic;
		
        //public Player[] teamsheet;
    }
}