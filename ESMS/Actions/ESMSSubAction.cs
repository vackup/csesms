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
* ESMSSubAction.java
*
* Created on 30 dicembre 2003, 16.09
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
    public class ESMSSubAction:SubAction, ESMSAction
    {
		
        /// <summary>Creates a new instance of ESMSSubAction </summary>
        public ESMSSubAction(string playerIn, string playerOut, string newpos):base(playerIn, playerOut, newpos)
        {
        }
		
        public ESMSSubAction(Action action):base((SubAction) action)
        {
        }
		
        public virtual void  execute(ESMSTeam team)
        {
            //Ovvio che così non funzioni, devo stabilire se si tratta di un numero e se è una
            //posizione devo trovare il peggiore in quel ruolo
            bool isInNumber = true;
            bool isOutNumber = true;
            int pIn = - 1, pOut = - 1;
            if (lastMinuteActive == CSEsMS.ESMS.ESMS.currentMinute && lastActiveTeam.Equals(team.Abbreviation))
                return ;
			
            if (team.Substitutions >=  Config.getConfig().Substitutions)
                return ;
			
            try
            {
                pIn = System.Int32.Parse(playerIn);
            }
            catch (System.FormatException e)
            {
                isInNumber = false;
            }
            try
            {
                //System.out.println("A"+playerOut);
                pOut = System.Int32.Parse(playerOut);
            }
            catch (System.FormatException e)
            {
                isOutNumber = false;
            }
            if (!isOutNumber)
                pOut = team.electWorsePlayer(playerOut);
            if (isInNumber)
            {
                if (pOut == - 1)
                    throw new System.Exception("Unable to detect worse player on position");
                if (((ESMSPlayer) team.getPlayer(pIn)).Status != ESMSPlayer.SUBSTITUTION || ((ESMSPlayer) team.getPlayer(pOut)).Status != ESMSPlayer.PLAYING)
                    return ;
                lastMinuteActive = CSEsMS.ESMS.ESMS.currentMinute;
                lastActiveTeam = team.Abbreviation;
                team.substitutePlayer(pOut, pIn, newpos);
                string[] params_Renamed = new string[]{System.Convert.ToString(CSEsMS.ESMS.ESMS.currentMinute), team.Abbreviation, team.getPlayer(pIn).Name, team.getPlayer(pOut).Name, newpos};
                CSEsMS.ESMS.ESMS.output.Write("<Substitution min=\"" + params_Renamed[0] + "\" team=\"" + params_Renamed[1] + "\" playerIn=\"" + params_Renamed[2] + "\" playerOut=\"" + params_Renamed[3] + "\" position=\"" + params_Renamed[4] + "\">");
                CSEsMS.ESMS.ESMS.output.Write(Comment.getComment().getCommentString("SUB", params_Renamed));
                CSEsMS.ESMS.ESMS.output.Write("</Substitution>");
                CSEsMS.ESMS.ESMS.output.Flush();
            }
            else
            {
                pIn = team.electBestSub(this.playerIn);
                if (pOut == - 1)
                    throw new System.Exception("Unable to detect worse player on position2");
                if (pIn == - 1)
                    throw new System.Exception("Unable to detect best substitute on position");
                if (((ESMSPlayer) team.getPlayer(pIn)).Status != ESMSPlayer.SUBSTITUTION || ((ESMSPlayer) team.getPlayer(pOut)).Status != ESMSPlayer.PLAYING)
                    return ;
                lastMinuteActive = CSEsMS.ESMS.ESMS.currentMinute;
                lastActiveTeam = team.Abbreviation;
                team.substitutePlayer(pOut, pIn, newpos);
                string[] params_Renamed = new string[]{System.Convert.ToString(CSEsMS.ESMS.ESMS.currentMinute), team.Abbreviation, team.getPlayer(pIn).Name, team.getPlayer(pOut).Name, newpos};
                CSEsMS.ESMS.ESMS.output.Write("<Substitution min=\"" + params_Renamed[0] + "\" team=\"" + params_Renamed[1] + "\" playerIn=\"" + params_Renamed[2] + "\" playerOut=\"" + params_Renamed[3] + "\" position=\"" + params_Renamed[4] + "\">");
                CSEsMS.ESMS.ESMS.output.Write(Comment.getComment().getCommentString("SUB", params_Renamed));
                CSEsMS.ESMS.ESMS.output.Write("</Substitution>");
                CSEsMS.ESMS.ESMS.output.Flush();
            }
        }
		
        private static int lastMinuteActive;
        private static string lastActiveTeam;
    }
}