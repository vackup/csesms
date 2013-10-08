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
* ChangePosAction.java
*
* Created on 26 dicembre 2003, 15.58
*/
using System;

namespace CSEsMS.Engine.Actions
{
    /// <summary> </summary>
    /// <author>   Angelo Scotto
    /// </author>
    public class ChangePosAction : Action
    {
        virtual public int Type
        {
            get
            {

                // HZ: cambie Action_Fields de STRUCT a ENUM
                return (int)Action_Fields.CHANGE;
            }
			
        }
		
        private int declaringTeam;
		
        protected internal string player;
        protected internal string newpos;
		
        public virtual string toXMLString()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("<Action value=\"CHANGEPOS\"/>");
            str.Append("<Argument value=\"");
            str.Append(player);
            str.Append("\"/>");
            str.Append("<Argument value=\"");
            str.Append(newpos);
            str.Append("\"/>");
            return str.ToString();
        }
		
        /// <summary>Creates a new instance of ChangePosAction </summary>
        public ChangePosAction(string player, string newpos)
        {
            this.player = player;
            this.newpos = newpos;
        }
		
        public ChangePosAction(ChangePosAction action)
        {
            this.declaringTeam = action.declaringTeam;
            this.player = action.player;
            this.newpos = action.newpos;
        }
		
        public virtual void  execute(TeamSheet team)
        {
        }
		
        public virtual void  setDeclaringTeam(int declaringTeam)
        {
            this.declaringTeam = declaringTeam;
        }
		
        public virtual int getDeclaringTeam()
        {
            return declaringTeam;
        }
		
        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("CHANGEPOS ");
            sb.Append(player);
            sb.Append(" ");
            sb.Append(newpos);
            return sb.ToString();
        }
    }
}