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
* MinCondition.java
*
* Created on 25 dicembre 2003, 22.46
*/
using System;

namespace CSEsMS.Engine.Conditions
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    public class MinCondition : Condition
    {
        virtual public int DeclaringTeam
        {
            /*    public boolean isTrue(MatchStatus status) throws Exception
			{
			switch(sign)
			{
			case Condition.EQUALS: {return status.currentMin==minute;}
			case Condition.GREATER: {return status.currentMin>minute;}
			case Condition.LESS: {return status.currentMin<minute;}
			case Condition.GREATEREQUALS: {return status.currentMin>=minute;}
			case Condition.LESSEQUALS: {return status.currentMin<=minute;}
			default: {throw new Exception("Sign is not of the available one");}
			}
			}*/
			
			
            set
            {
                /* This procedure must be empty, in fact MinCondition is the only condition which doesn't
				care about declaring team */
            }
			
        }
        virtual public int Type
        {
            get
            {
                // HZ: cambie Condition_Fields de STRUCT a ENUM.
                return (int)Condition_Fields.MINUTE;
            }
			
        }
		
        protected internal int sign;
        protected internal int minute;
		
        public virtual string toXMLString()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("<Condition type=\"MIN\" sign=\"");
            str.Append(Conditional.convertSign(sign));
            str.Append("\" value=\"");
            str.Append(minute);
            str.Append("\"/>");
            return str.ToString();
        }
		
        public MinCondition(MinCondition cond)
        {
            this.sign = cond.sign;
            this.minute = cond.minute;
        }
		
        /// <summary>Creates a new instance of MinCondition </summary>
        public MinCondition(string sign, int minute)
        {
            // HZ: cambie Condition_Fields de STRUCT a ENUM.
            if (sign.Equals("<"))
                this.sign = (int)Condition_Fields.LESS;
            else if (sign.Equals("<=") || sign.Equals("=<"))
                this.sign = (int)Condition_Fields.LESSEQUALS;
            else if (sign.Equals("="))
                this.sign = (int)Condition_Fields.EQUALS;
            else if (sign.Equals(">=") || sign.Equals("=>"))
                this.sign = (int)Condition_Fields.GREATEREQUALS;
            else if (sign.Equals(">"))
                this.sign = (int)Condition_Fields.GREATER;
			
            this.minute = minute;
        }
		
        private string signToString(int sign)
        {
            // HZ: cambie Condition_Fields de STRUCT a ENUM.
            switch ((Condition_Fields)sign)
            {
				
                case Condition_Fields.LESS:  return "<";
				
                case Condition_Fields.LESSEQUALS:  return "<=";
				
                case Condition_Fields.GREATER:  return ">";
				
                case Condition_Fields.GREATEREQUALS:  return ">=";
				
                case Condition_Fields.EQUALS:  return "=";
            }
            return null;
        }
        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("MIN ");
            sb.Append(signToString(sign));
            sb.Append(" ");
            sb.Append(minute);
            return sb.ToString();
        }
    }
}