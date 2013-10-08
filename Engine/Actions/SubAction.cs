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
* SubAction.java
*
* Created on 26 dicembre 2003, 16.00
*/
using System;

namespace CSEsMS.Engine.Actions
{
    /// <summary> </summary>
    /// <author>   Angelo Scotto
    /// </author>
    public class SubAction : Action
    {
        virtual public int Type
        {
            get
            {
                // HZ: converti Action_Fields de STRUCT a ENUM
                return (int)Action_Fields.SUB;
            }
			
        }
		
        private int declaringTeam = - 1;
		
        protected internal string playerIn;
        protected internal string playerOut;
        protected internal string newpos;
		
        public virtual string toXMLString()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("<Action value=\"SUB\"/>");
            str.Append("<Argument value=\"");
            str.Append(playerOut);
            str.Append("\"/>");
            str.Append("<Argument value=\"");
            str.Append(playerIn);
            str.Append("\"/>");
            str.Append("<Argument value=\"");
            str.Append(newpos);
            str.Append("\"/>");
            return str.ToString();
        }
		
        /// <summary>Creates a new instance of SubAction </summary>
        public SubAction(string playerOut, string playerIn, string newpos)
        {
            this.playerIn = playerIn;
            this.playerOut = playerOut;
            this.newpos = newpos;
        }
		
        public SubAction(SubAction action)
        {
            this.playerIn = action.playerIn;
            this.playerOut = action.playerOut;
            this.newpos = action.newpos;
            this.declaringTeam = action.declaringTeam;
        }
		
		
        public virtual int getDeclaringTeam()
        {
            return this.declaringTeam;
        }
		
        public virtual void  setDeclaringTeam(int declaringTeam)
        {
            this.declaringTeam = declaringTeam;
        }
		
        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("SUB ");
            sb.Append(playerOut);
            sb.Append(" ");
            sb.Append(playerIn);
            sb.Append(" ");
            sb.Append(newpos);
            return sb.ToString();
        }
    }
}