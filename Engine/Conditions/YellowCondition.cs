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
* YellowCondition.java
*
* Created on 25 dicembre 2003, 23.15
*/
using System;

namespace CSEsMS.Engine.Conditions
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    public class YellowCondition : Condition
    {
        virtual public int DeclaringTeam
        {
            /* Depends on the team declaring it (Away or Home)*/
            //    public boolean isTrue(Engine.MatchStatus status) {
            // THIS CONDITION CAN'T WORK BECAUSE PLAYER CAN BE A POSITION!!!
            //if (status.Away.yellow == player && declaringTeam == Condition.AWAY) return true;
            //else if (status.Home.yellow == player && declaringTeam == Condition.HOME) return true;
            //else return false;
            //        return false;
            //    }
			
			
            set
            {
                this.declaringTeam = value;
            }
			
        }
        virtual public int Type
        {
            get
            {
                // HZ: cambie Condition_Fields de STRUCT a ENUM
                return (int)Condition_Fields.YELLOW;
            }
			
        }
		
        protected internal string player;
        protected internal int declaringTeam;
		
        public virtual string toXMLString()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("<Condition type=\"YELLOW\" value=\"");
            str.Append(player);
            str.Append("\"/>");
            return str.ToString();
        }
		
        public YellowCondition(YellowCondition cond)
        {
            this.player = cond.player;
            this.declaringTeam = cond.declaringTeam;
        }
		
        /// <summary>Creates a new instance of YellowCondition </summary>
        public YellowCondition(string player)
        {
            this.player = player;
        }
		
        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("YELLOW ");
            sb.Append(this.player);
            return sb.ToString();
        }
    }
}