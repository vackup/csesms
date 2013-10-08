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
* Action.java
*
* Created on 25 dicembre 2003, 21.30
*/
using System;

namespace CSEsMS.Engine.Actions
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    //public struct Action_Fields{
    //    public readonly static int CHANGE = 0;
    //    public readonly static int SUB = 1;
    //    public readonly static int TACTIC = 2;
    //    public readonly static int AWAY = 1;
    //    public readonly static int HOME = 0;
    //}

    public enum Action_Fields
    {
        CHANGE = 0,
        SUB = 1,
        TACTIC = 2,
        AWAY = 1,
        HOME = 0
    }

    public interface Action
    {
        //UPGRADE_NOTE: Members of interface 'Action' were extracted into structure 'Action_Fields'. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1045'"
        int Type
        {
            get;
			
        }
		
        void  setDeclaringTeam(int declaringTeam);
        string toXMLString();
    }
}