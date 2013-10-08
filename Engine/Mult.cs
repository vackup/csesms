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
* Mult.java
*
* Created on 26 dicembre 2003, 19.33
*/
using System;

namespace CSEsMS.Engine
{
    /// <summary> </summary>
    /// <author>   Angelo Scotto
    /// </author>
    public class Mult
    {
		
        private string position;
        private string skill;
        private double multiplier;
		
        public virtual double getValue(string position, string skill)
        {
            /* I've to check if Mult has been properly initialized */
            if (this.position.Equals(position) && this.skill.Equals(skill))
                return multiplier;
            else
                return 0.0;
        }
        /// <summary>Creates a new instance of Mult </summary>
        public Mult(string position, string skill, string multiplier)
        {
            this.position = position;
            this.skill = skill;
            this.multiplier = System.Double.Parse(multiplier);
        }
		
        /// <summary>This method should apply changes represented by this Mult to the status </summary>
        public virtual void  apply(MatchStatus status)
        {
        }
		
		
        /// <summary>Method used to remove Mult effects from the current MatchStatus. </summary>
        public virtual void  remove(MatchStatus status)
        {
        }
    }
}