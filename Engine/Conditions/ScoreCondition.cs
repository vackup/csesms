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
* ScoreCondition.java
*
* Created on 25 dicembre 2003, 23.03
*/
using System;

namespace CSEsMS.Engine.Conditions
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    public class ScoreCondition : Condition
    {
        virtual public int DeclaringTeam
        {
            /* I must keep in mind that the condition depends on the team (away or home) */
            //    public boolean isTrue(Engine.MatchStatus status) throws Exception {
            //        int diff;
            //        if (declaringTeam == Condition.AWAY) diff = status.Away.score-status.Home.score;
            //        else diff = status.Home.score-status.Away.score;
            //        switch(sign)
            //        {
            //            case Condition.EQUALS: {return diff == scoreDiff;}
            //            case Condition.GREATER: {return diff > scoreDiff;}
            //            case Condition.LESS: {return diff < scoreDiff;}
            //            case Condition.GREATEREQUALS: {return diff >= scoreDiff;}
            //            case Condition.LESSEQUALS: {return diff <= scoreDiff;}
            //            default: {throw new Exception("Sign is not of the available one");}
            //        }
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
                // HZ: cambie Condition_Fields de STRUCT a ENUM.
                return (int)Condition_Fields.SCORE;
            }
			
        }
		
        protected internal int sign;
        protected internal int scoreDiff;
        protected internal int declaringTeam;
		
        public virtual string toXMLString()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("<Condition type=\"SCORE\" sign=\"");
            str.Append(Conditional.convertSign(sign));
            str.Append("\" value=\"");
            str.Append(scoreDiff);
            str.Append("\"/>");
            return str.ToString();
        }
		
        public ScoreCondition(ScoreCondition cond)
        {
            this.sign = cond.sign;
            this.scoreDiff = cond.scoreDiff;
            this.declaringTeam = cond.declaringTeam;
        }
        /// <summary>Creates a new instance of ScoreCondition </summary>
        public ScoreCondition(string sign, int scoreDiff)
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
			
            this.scoreDiff = scoreDiff;
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
            sb.Append("SCORE ");
            sb.Append(signToString(sign));
            sb.Append(" ");
            sb.Append(scoreDiff);
            return sb.ToString();
        }
    }
}