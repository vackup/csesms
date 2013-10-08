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
* TacticAction.java
*
* Created on 26 dicembre 2003, 9.41
*/
using System;

namespace CSEsMS.Engine.Actions
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    public class TacticAction : Action
    {
        virtual public int Type
        {
            get
            {
                // HZ: cambie Action_Fields de STRUCT a ENUM.
                return (int)Action_Fields.TACTIC;
            }
			
        }
		
        public virtual string toXMLString()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("<Action value=\"TACTIC\"/>");
            str.Append("<Argument value=\"");
            str.Append(this.tacticName);
            str.Append("\"/>");
            return str.ToString();
        }
		
        /// <summary>Creates a new instance of TacticAction </summary>
        public TacticAction(string tacticName)
        {
            this.tacticName = tacticName;
        }
		
        public TacticAction(TacticAction action)
        {
            this.declaringTeam = action.declaringTeam;
            this.tacticName = action.tacticName;
        }
        protected internal int declaringTeam = - 1;
        protected internal string tacticName;
		
		
        public virtual int getDeclaringTeam()
        {
            return declaringTeam;
        }
		
        public virtual void  setDeclaringTeam(int declaringTeam)
        {
            this.declaringTeam = declaringTeam;
        }
		
        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("TACTIC ");
            sb.Append(tacticName);
            return sb.ToString();
        }
    }
}