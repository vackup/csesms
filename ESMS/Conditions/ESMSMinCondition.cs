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
    public class ESMSMinCondition:Engine.Conditions.MinCondition, ESMSCondition
    {
		
        /// <summary>Creates a new instance of ESMSInjCondition </summary>
        public ESMSMinCondition(Condition cond):base((MinCondition) cond)
        {
        }
		
        public virtual bool isTrue(ESMSTeam team, ESMSTeam away, int Minute)
        {
            // HZ: converti Condition_Fields de STRUC a ENUM y agregue (Condition_Fields) en el SWITCH
            switch ((Condition_Fields)sign)
            {
				
                case Engine.Conditions.Condition_Fields.EQUALS:  {
                    return Minute == minute;
                }
				
                case Engine.Conditions.Condition_Fields.GREATER:  {
                    return Minute > minute;
                }
				
                case Engine.Conditions.Condition_Fields.LESS:  {
                    return Minute < minute;
                }
				
                case Engine.Conditions.Condition_Fields.GREATEREQUALS:  {
                    return Minute >= minute;
                }
				
                case Engine.Conditions.Condition_Fields.LESSEQUALS:  {
                    return Minute <= minute;
                }
				
                default:  {
                    throw new System.Exception("Sign is not of the available one");
                }
				
            }
        }
    }
}