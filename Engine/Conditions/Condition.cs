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
* Condition.java
*
* Created on 25 dicembre 2003, 21.30
*/
using System;

namespace CSEsMS.Engine.Conditions
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
	
    //public struct Condition_Fields{
    //    public readonly static int LESS = - 2;
    //    public readonly static int LESSEQUALS = - 1;
    //    public readonly static int EQUALS = 0;
    //    public readonly static int GREATEREQUALS = 1;
    //    public readonly static int GREATER = 2;
    //    public readonly static int AWAY = 1;
    //    public readonly static int HOME = 0;
    //    public readonly static int INJURY = 0;
    //    public readonly static int MINUTE = 1;
    //    public readonly static int RED = 2;
    //    public readonly static int SCORE = 3;
    //    public readonly static int YELLOW = 4;
    //}

    public enum Condition_Fields
    {
        LESS = -2,
        LESSEQUALS = -1,
        EQUALS = 0,
        GREATEREQUALS = 1,
        GREATER = 2,
        AWAY = 1,
        HOME = 0,
        INJURY = 0,
        MINUTE = 1,
        RED = 2,
        SCORE = 3,
        YELLOW = 4
    }

    public interface Condition
    {
        //UPGRADE_NOTE: Members of interface 'Condition' were extracted into structure 'Condition_Fields'. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1045'"
        int Type
        {
            get;
			
        }
        int DeclaringTeam
        {
            //    public boolean isTrue(MatchStatus status) throws Exception;
			
            set;
			
        }
        string toXMLString();
    }
}