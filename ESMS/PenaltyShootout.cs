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
* PenaltyShootout.java
*
* Created on 25 aprile 2004, 13.34
*/
using System;
using CSEsMS.Engine;

namespace CSEsMS.ESMS
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    public class PenaltyShootout
    {
        private void  InitBlock()
        {
            for (int i = 0; i < 2; i++)
            {
                tmpArray[i] = new PenaltyPlayer[11];
            }

            // HZ: arregue esta inicializacion aca ya que el campo estaba inicializado mas abajo y daba error de .NET - internal PenaltyPlayer[][] PenaltyTakers = tmpArray;
            PenaltyTakers = tmpArray;
        }
		
        private ESMSTeam[] teams = new ESMSTeam[2];
        private System.IO.StreamWriter output;
        private int homePenScore = 0;
        private int awayPenScore = 0;
		
        //Temp
        internal int[] kickTakers = new int[2];
        private PenaltyPlayer[][] tmpArray = new PenaltyPlayer[2][];
        internal PenaltyPlayer[][] PenaltyTakers;
        // HZ: ver comentario de InitBlock()
        //internal PenaltyPlayer[][] PenaltyTakers = tmpArray;
		
        /// <summary>Creates a new instance of PenaltyShootout </summary>
        public PenaltyShootout(ESMSTeam homeTS, ESMSTeam awayTS, System.IO.StreamWriter output)
        {
            InitBlock();
            this.teams[0] = homeTS;
            this.teams[1] = awayTS;
            this.output = output;
        }
		
        private int goalDiff()
        {
            return homePenScore - awayPenScore;
        }
		
        private void  takePenalty(int nTeam, int nPenalty)
        {
            Player player = teams[nTeam].getPlayer(PenaltyTakers[nTeam][nPenalty].Number);
            output.Write("<Penalty team=\"" + teams[nTeam].Abbreviation + "\" player=\"" + player.Name + "\">");
            output.Write(Comment.getComment().getCommentString("PENALTY", new string[]{player.Name}));
            output.Write("</Penalty>");
            output.Flush();
			
            if (CSEsMS.ESMS.ESMS.getThresold(8000 + player.Shooting * 100 - teams[1 - nTeam].Keeper.Keeping * 100))
            {
                output.Write("<Goal team=\"" + teams[nTeam].Abbreviation + "\" player=\"" + player.Name + "\">");
                output.Write(Comment.getComment().getCommentString("GOAL"));
                output.Write("</Goal>");
                output.Flush();
                if (nTeam == 0)
                    homePenScore++;
                else
                    awayPenScore++;
            }
            else
            {
                if (CSEsMS.ESMS.ESMS.getThresold(5000))
                {
                    string[] parames = new string[]{teams[1 - nTeam].Keeper.Name};
                    output.Write("<Save player=\"" + parames[0] + "\">");
                    output.Write(Comment.getComment().getCommentString("SAVE", parames));
                    output.Write("</Save>");
                    output.Flush();
                }
                else
                {
                    output.Write("<OffTarget>");
                    output.Write(Comment.getComment().getCommentString("OFFTARGET"));
                    output.Write("</OffTarget>");
                    output.Flush();
                }
            }
        }
		
        internal virtual void  RunPenaltyShootout()
        {
            int nPenalty, nTeam;
            bool gameDecided = false;
			
            output.Write("<PenaltyShootout>");
            output.Write(Comment.getComment().getCommentString("PENALTYSHOOTOUT"));
            output.Write("</PenaltyShootout>");
			
            AssignPenaltyTakers();
			
            /* Main penalties loop
			Each team takes 5 penalties (the shootout will stop if
			it will be obvious that one team won at some stage before
			the end, ie. one team leading 4-1 etc.)
			*/
			
            for (nPenalty = 0; nPenalty < 5 && !gameDecided; nPenalty++)
            {
                for (nTeam = 0; nTeam <= 1 && !gameDecided; nTeam++)
                {
                    takePenalty(nTeam, nPenalty);
					
                    if (((nTeam == 0) && (goalDiff() > 4 - nPenalty || - goalDiff() > 4 - nPenalty)) || ((nTeam == 1) && (goalDiff() > 4 - nPenalty || - goalDiff() > 4 - nPenalty)))
                        gameDecided = true;
                }
            }
			
            while (!gameDecided)
            {
                //Continue until a winner came out.
                for (nTeam = 0; nTeam <= 1; nTeam++)
                {
                    takePenalty(nTeam, nPenalty);
                }
				
                if (goalDiff() != 0)
                    gameDecided = true;
				
                /* Prepare next player */
                if (nPenalty == kickTakers[0] - 1)
                    nPenalty = 0;
                else
                    nPenalty++;
            }
			
            ESMSTeam team;
            if (goalDiff() > 0)
                team = teams[0];
            else
                team = teams[1];
			
            string[] params_Renamed = new string[]{team.Name, System.Convert.ToString(homePenScore), System.Convert.ToString(awayPenScore)};
			
            output.Write("<WonPenaltyShootout team=\"" + team.Abbreviation + "\" homeRealizedPenalties=\"" + params_Renamed[1] + "\" awayRealizedPenalties=\"" + params_Renamed[2] + "\">");
            output.Write(Comment.getComment().getCommentString("WONPENALTYSHOOTOUT", params_Renamed));
            output.Write("</WonPenaltyShootout>");
        }
		
		
        private void  AssignPenaltyTakers()
        {
            //First i need to find all active players for each team
            int nTeam, nPlayer, nTaker;
            int max = - 1, index = - 1;
			
            kickTakers[0] = kickTakers[1] = 0;
			
            for (nTeam = 0; nTeam <= 1; nTeam++)
            {
                for (nPlayer = 1; nPlayer < teams[nTeam].NumPlayers; nPlayer++)
                {
                    if (((ESMSPlayer) teams[nTeam].getPlayer(nPlayer)).Status == ESMSPlayer.PLAYING)
                        kickTakers[nTeam]++;
                }
            }
			
            /* each team will have an even number of PK takers */
            kickTakers[0] = kickTakers[1] = (kickTakers[0] > kickTakers[1]?kickTakers[1]:kickTakers[0]);
			
            for (nTeam = 0; nTeam <= 1; nTeam++)
            {
                for (nTaker = 0; nTaker < kickTakers[nTeam]; nTaker++)
                    /* for each penalty taker */
                {
                    for (nPlayer = 1; nPlayer < teams[nTeam].NumPlayers; nPlayer++)
                    {
                        if ((teams[nTeam].getPlayer(nPlayer).Shooting > max) && (((ESMSPlayer) teams[nTeam].getPlayer(nPlayer)).Status == ESMSPlayer.PLAYING))
                        {
                            max = teams[nTeam].getPlayer(nPlayer).Shooting;
                            index = nPlayer;
                        }
                    }
					
                    /* copy the stats of the suitable player to PenaltyTaker */
                    //strcpy(PenaltyTaker[nTeam][nTaker].name, team[nTeam].player[index].name);
                    PenaltyTakers[nTeam][nTaker] = new PenaltyPlayer(teams[nTeam].getPlayer(index).Name, index, teams[nTeam].getPlayer(index).Shooting);
                    /* set active = 0, making sure that this player won't be chosen again */
                    ((ESMSPlayer) (teams[nTeam].getPlayer(index))).Status = - 1;
					
                    max = index = - 1;
                }
            }
			
            for (nTeam = 0; nTeam <= 1; nTeam++)
            {
                for (nTaker = 0; nTaker < kickTakers[nTeam]; nTaker++)
                    /* for each penalty taker */
                {
                    /* copy the stats of the suitable player to PenaltyTaker */
                    //strcpy(PenaltyTaker[nTeam][nTaker].name, team[nTeam].player[index].name);
					
                    /* set active = 0, making sure that this player won't be chosen again */
                    ((ESMSPlayer) (teams[nTeam].getPlayer(PenaltyTakers[nTeam][nTaker].Number))).Status = ESMSPlayer.PLAYING;
                }
            }
        }
    }
}