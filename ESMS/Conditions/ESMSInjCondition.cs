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
* ESMSInjCondition.java
*
* Created on 30 dicembre 2003, 16.44
*/
using System;
using CSEsMS.Engine.Conditions;

namespace CSEsMS.ESMS.Conditions
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    public class ESMSInjCondition:Engine.Conditions.InjCondition, ESMSCondition
    {
		
        /// <summary>Creates a new instance of ESMSInjCondition </summary>
        public ESMSInjCondition(Condition cond):base((InjCondition) cond)
        {
        }
		
        public virtual bool isTrue(ESMSTeam team, ESMSTeam away, int min)
        {
            /* I need to know if player is a number or a position */
            int number = - 1;
            bool isNumber = true;
			
            if (team.Injured == null)
                return false;
			
            try
            {
                number = System.Int32.Parse(this.player);
            }
            catch (System.FormatException err)
            {
                isNumber = false;
            }
			
            if (!isNumber)
            {
                if (team.getPosition(team.Injured).Equals(player))
                    return true;
                else
                    return false;
            }
            else
            {
                if (team.Injured.Name.Equals(team.getPlayer(number).Name))
                    return true;
                else
                    return false;
            }
        }
    }
}