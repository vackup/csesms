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
* Conditional.java
*
* Created on 25 dicembre 2003, 21.22
*/
using System;
using CSEsMS.Engine.Conditions;
using Action=CSEsMS.Engine.Actions.Action;

namespace CSEsMS.Engine
{
    /// <summary> </summary>
    /// <author>   Angelo Scotto
    /// </author>
    public class Conditional
    {
        virtual public Action Action
        {
            get
            {
                return this.action;
            }
			
        }
        virtual public Condition[] Conditions
        {
            get
            {
                return this.conditions;
            }
			
        }

        public static string convertSign(int sign)
        {
            // HZ: cambie Condition_Fields de STRUCT a ENUM. Volver a poner en SWITCH
            if (sign == (int)Condition_Fields.EQUALS)
                return "=";

            if (sign == (int)Condition_Fields.LESS)
                return "&lt;";

            if (sign == (int)Condition_Fields.GREATER)
                return "&gt;";

            if (sign == (int)Condition_Fields.LESSEQUALS)
                return "&lt;=";

            if (sign == (int)Condition_Fields.GREATEREQUALS)
                return "&gt;=";
            
            return "=";

            //switch (sign)
            //{

            //    case Engine.Conditions.Condition_Fields.EQUALS:
            //        return "=";

            //    case Engine.Conditions.Condition_Fields.LESS:
            //        return "&lt;";

            //    case Engine.Conditions.Condition_Fields.GREATER:
            //        return "&gt;";

            //    case Engine.Conditions.Condition_Fields.LESSEQUALS:
            //        return "&lt;=";

            //    case Engine.Conditions.Condition_Fields.GREATEREQUALS:
            //        return "&gt;=";
            //}
            //return "=";
        }

        /// <summary>Creates a new instance of Conditional </summary>
        public Conditional(Action action, Condition[] conditions)
        {
            this.action = action;
            this.conditions = conditions;
        }
		
        private Action action;
        private Condition[] conditions;
		
        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
            sb.Append(action.ToString());
            sb.Append(" IF ");
            for (int i = 0; i < conditions.Length; i++)
            {
                //UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
                sb.Append(conditions[i].ToString());
                sb.Append(", ");
            }
            sb.Length -= 2;
            return sb.ToString();
        }
        /*    public boolean isTrue(MatchStatus status) throws Exception
		{
		for(int i=0;i<conditions.length;i++)
		{ 
		if (!conditions[i].isTrue(status)) return false;
		}
		return true;
		}
		
		public void execute(TeamSheet team)
		{
		action.execute(team);
		}
		*/
    }
}