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
* ESMSTacticAction.java
*
* Created on 30 dicembre 2003, 16.27
*/
using System;
using CSEsMS.Engine;
using CSEsMS.Engine.Actions;
using Action=CSEsMS.Engine.Actions.Action;

namespace CSEsMS.ESMS.Actions
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    public class ESMSTacticAction:TacticAction, ESMSAction
    {
		
        /// <summary>Creates a new instance of ESMSTacticAction </summary>
        public ESMSTacticAction(Action action):base((TacticAction) action)
        {
        }
		
        public virtual void  execute(ESMSTeam team)
        {
            if (team.Tactic.Name.Equals(tacticName) || (lastMinuteActive == CSEsMS.ESMS.ESMS.currentMinute && lastActiveTeam.Equals(team.Abbreviation)))
                return ;
            lastMinuteActive = CSEsMS.ESMS.ESMS.currentMinute;
            lastActiveTeam = team.Abbreviation;
            team.Tactic = (Tactic) Tactic._Tactics[tacticName];
            CSEsMS.ESMS.ESMS.output.Write("<ChangeTactic min=\"" + CSEsMS.ESMS.ESMS.currentMinute + "\" team=\"");
            CSEsMS.ESMS.ESMS.output.Write(team.Abbreviation + "\" tactic=\"" + tacticName + "\">");
            string[] params_Renamed = new string[]{System.Convert.ToString(CSEsMS.ESMS.ESMS.currentMinute), team.Abbreviation, team.Name, tacticName};
            CSEsMS.ESMS.ESMS.output.Write(Comment.getComment().getCommentString("CHANGETACTIC", params_Renamed));
            CSEsMS.ESMS.ESMS.output.Write("</ChangeTactic>");
            CSEsMS.ESMS.ESMS.output.Flush();
        }
		
        private static int lastMinuteActive;
        private static string lastActiveTeam;
    }
}