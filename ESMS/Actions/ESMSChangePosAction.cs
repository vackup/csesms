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
* ESMSChangePosAction.java
*
* Created on 30 dicembre 2003, 16.23
*/
using System;
using CSEsMS.Engine.Actions;
using Action=CSEsMS.Engine.Actions.Action;

namespace CSEsMS.ESMS.Actions
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    public class ESMSChangePosAction:ChangePosAction, ESMSAction
    {
		
        /// <summary>Creates a new instance of ESMSChangePosAction </summary>
        public ESMSChangePosAction(Action action):base((ChangePosAction) action)
        {
        }
		
        public virtual void  execute(ESMSTeam team)
        {
            //Ovvio che così non funzioni, devo stabilire se si tratta di un numero e se è una
            //posizione devo trovare il peggiore in quel ruolo
            bool isNumber = true;
            int p = - 1;
            if (lastMinuteActive == CSEsMS.ESMS.ESMS.currentMinute && lastActiveTeam.Equals(team.Abbreviation))
                return ;
            try
            {
                p = System.Int32.Parse(player);
            }
            catch (System.FormatException e)
            {
                isNumber = false;
            }
            if (!isNumber)
            {
                p = team.electWorsePlayer(player);
            }
            //if (p==-1) throw new Exception("Unable to detect player to substitute");
            if (p == - 1)
                return ;
            if (team.getPosition(p).Equals(newpos))
                return ;
            lastMinuteActive = CSEsMS.ESMS.ESMS.currentMinute;
            lastActiveTeam = team.Abbreviation;
            team.changePosition(p, newpos);
            string[] params_Renamed = new string[]{System.Convert.ToString(CSEsMS.ESMS.ESMS.currentMinute), team.Abbreviation, team.getPlayer(p).Name, newpos};
            CSEsMS.ESMS.ESMS.output.Write("<ChangePosition min=\"" + params_Renamed[0] + "\" team=\"" + params_Renamed[1] + "\" player=\"" + params_Renamed[2] + "\" newPosition=\"" + params_Renamed[3] + "\">");
            CSEsMS.ESMS.ESMS.output.Write(Comment.getComment().getCommentString("CHANGEPOSITION", params_Renamed));
            CSEsMS.ESMS.ESMS.output.Write("</ChangePosition>");
        }
        private static int lastMinuteActive;
        private static string lastActiveTeam;
    }
}