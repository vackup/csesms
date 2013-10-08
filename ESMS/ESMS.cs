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
* ESMS.java
*
* Created on 25 dicembre 2003, 17.34
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using CSEsMS.Domain;
using CSEsMS.Domain.Entities;
using CSEsMS.Engine;
using Version=CSEsMS.Engine.Version;

namespace CSEsMS.ESMS
{
    /// <summary> Main ESMS class
    /// It contains the RandomGenerator used by all classes inside ESMS program
    /// </summary>
    /// <author>   Angelo Scotto
    /// </author>
    public class ESMS
    {
        #region Propiedades
        public static long Seed
        {
            get
            {
                if (rnd != null)
                    return ESMS.seed;
                else
                    throw new System.NullReferenceException("Random generator still not initialized!");
            }
			
        }
        public static System.Random Random
        {
            get
            {
                if (rnd != null)
                    return rnd;
                else
                    throw new System.NullReferenceException("Random generator still not initialized!");
            }
			
        }
        virtual public string CommentaryName
        {
            get
            {
                return homeTS.Abbreviation + "_" + awayTS.Abbreviation;
            }
			
        }
        private bool GoalCancelled
        {
            get
            {
                if (getThresold(500))
                {
                    output.Write("<GoalCancelled>");
                    output.Write(Comment.getComment().getCommentString("GOALCANCELLED"));
                    output.Write("</GoalCancelled>");
                    return true;
                }
                else
                    return false;
            }

        }
        #endregion

        private static string CommandName = "ESMS";
        private static string compatibleXLS = "xls/esms.xls";
		
        private const int DID_SHOT = 0;
        private const int DID_FOUL = 1;
        private const int DID_TACKLE = 2;
        private const int DID_ASSIST = 3;
		
        private const int YELLOW = 0;
        private const int RED = 1;
		
        private static bool compatibleOutput;
        private static string externalUrl = null;

        /*---------- Section declaring the RandomGenerator ----------*/
        private static System.Random rnd;
		
        public static bool getThresold(int thresold)
        {
            int value_Renamed = Random.Next(10000);
			
            if (value_Renamed < thresold)
                return true;
            else
                return false;
        }
        private static long seed;
		
		
        public static void  setRandomEngine(long seed)
        {
            ESMS.seed = seed;
            //UPGRADE_TODO: The differences in the expected value  of parameters for constructor 'java.util.Random.Random'  may cause compilation errors.  "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1092'"
            rnd = new System.Random((System.Int32) seed);
            /* else it should raise an exception or warn the user in some ways*/
        }
		
        public static void  setRandomEngine()
        {
            if (rnd == null)
            {
                System.Random temp = new System.Random();
                //UPGRADE_TODO: Method 'java.util.Random.nextLong' was converted to 'SupportClass.NextLong' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilRandomnextLong'"
                ESMS.seed = SupportClass.NextLong(temp);
                //UPGRADE_TODO: The differences in the expected value  of parameters for constructor 'java.util.Random.Random'  may cause compilation errors.  "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1092'"
                rnd = new System.Random((System.Int32) ESMS.seed);
            }
            /* else it should raise an exception or warn the user in some ways*/
        }
        /*---------- End of RandomGenerator declaration ----------*/
        /*---------- Declaration of main static method ----------*/
		
        public static void  help()
        {
            Console.WriteLine(global::CSEsMS.ESMS.Version.FullVersion);
            Console.WriteLine();
            Console.WriteLine("Usage: java " + CommandName + " [-h][<HomeTeamSheet>][<AwayTeamSheet>][-x:<xslfile>][-xe:<url>][-r:<seed>][-cI][-cO]");
            Console.WriteLine();
            Console.WriteLine("Where:");
            Console.WriteLine("<HomeTeamSheet>: the name of the file containing the home teamsheet");
            Console.WriteLine("<AwayTeamSheet>: the name of the file containing the away teamsheet");
            Console.WriteLine("<seed>: A number representing the seed to initialize the random generator");
            Console.WriteLine("<xmlfile>: the name of a XSL file to use to format the output");
            Console.WriteLine("<url>: the online url of a XSL file that should be embedded directly in XML output");
            Console.WriteLine("NOTICE: If you insert HomeTeamSheet then you MUST insert also AwayTeamSheet!");
            Console.WriteLine("-cI/-cO: Flags to enable Compatibility mode with ESMS Input/Output (Not yet implemented)");
            System.Environment.Exit(0);
        }
		
		
        /// <summary>
        /// Clase principal del juego que ejecuta toda la logica. Este metodo hay que sacarlo de aca y 
        /// toda esta logica es de UI. Que la clase ESMS deje de ser static
        /// 
        /// Now the code loads data from league.xml, tactics.xml and language.xml.
        /// Actually the name of the files is hardwired in the code but it could be changed in future
        /// </summary>
        //[STAThread]
        public static void  main(string[] args)
        {
            Console.WriteLine(string.Format("Cargando la configuracion de la Liga: {0}", Config.getConfig().Name));
			
            string xls = null;
            //UPGRADE_TODO: The 'System.Int64' structure does not have an equivalent to NULL. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1291'"
            //System.Int64 seed = null;
            long seed;
            string homeTeamSheet = null;
            string awayTeamSheet = null;
			
			
            for (int i = 0; i < args.Length; i++)
            {
                /* Parse parameter */
                if (args[i].ToLower().StartsWith("-r:"))
                    seed = System.Int64.Parse(args[i].Substring(3));
                if (args[i].ToLower().StartsWith("-x:"))
                    xls = args[i].Substring(3);
                else if (args[i].ToLower().Equals("-ci"))
                    Console.WriteLine("Compatibility Mode still not implemented");
                else if (args[i].ToLower().Equals("-co"))
                    compatibleOutput = true;
                else if (args[i].ToLower().Equals("-h"))
                    help();
                else if (args[i].ToLower().Equals("-xe:"))
                    externalUrl = args[i].Substring(4);
                else if (!args[i].StartsWith("-"))
                {
                    if (homeTeamSheet == null)
                        homeTeamSheet = args[i];
                    else if (awayTeamSheet == null)
                        awayTeamSheet = args[i];
                    else
                    {
                        Console.WriteLine("Illegal usage of JEsMS: usage 'java " + CommandName + " -h' for help");
                        System.Environment.Exit(- 1);
                    }
                }
            }
            if (awayTeamSheet == null && homeTeamSheet != null)
            {
                Console.WriteLine("Illegal usage of JEsMS: usage 'java " + CommandName + " -h' for help"); 
                System.Environment.Exit(- 1);
            }
            /* Here the ESMS object has been correctly initialized */
            Console.WriteLine(Version.FullVersion);
            Console.WriteLine();
			
            // TODO: Now the code loads data from league.xml, tactics.xml and language.xml. Actually the name of the files is hardwired in the code but it could be changed in future
            //Config.loadConfig("league.xml");
			
            if (homeTeamSheet == null)
            {
                try
                {
                    //TeamSheet names were not passed as parameters.
                    Console.WriteLine("Enter the home teamsheet name:");
                    homeTeamSheet = Console.ReadLine();
                    
                    Console.WriteLine("Enter the away teamsheet name:");
                    awayTeamSheet = Console.ReadLine();
                }
                catch (System.IO.IOException err)
                {
                    Console.WriteLine("Error while reading teamsheets name from standard input");
                    if (Debug())
                        SupportClass.WriteStackTrace(err, Console.Error);
                    System.Environment.Exit(ExitCodes.FILE_NOT_FOUND);
                }
            }
            //Tactic.parseTactics("tactics.xml");
			
            //UPGRADE_TODO: The 'System.Int64' structure does not have an equivalent to NULL. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1291'"
            // Mas alla que el long de .net no acepte nulos, Seed tendrá valor si se le pasa por linea de comando.
            // Esto lo tengo que cambiar y que sea un parametro que se inicialice automaticamente cuando se levante la aplicacion, no?
            // Acá me parece que me convendrías redefinir esta clase y sacar esto de los constructores.

            //At this time, the static configuration of the program has been loaded.
            //Now it's time to create the ESMS object and let it play the match.
            ESMS game = new ESMS(homeTeamSheet, awayTeamSheet);
			
            Comment.loadComment("language.xml");
			
            //Let the ESMS play the match
            game.play();
			
            try
            {
                if (xls != null)
                    game.writeXSLTransform(new GenericSourceSupport(xls));
                if (compatibleOutput)
                    game.writeXSLTransform(new GenericSourceSupport(compatibleXLS));
            }
            catch (System.Exception err)
            {
                Console.WriteLine("Error while transforming output with XSL file " + xls);
                if (Debug())
                    SupportClass.WriteStackTrace(err, Console.Error);
                System.Environment.Exit(ExitCodes.XSL_TRANSFORMATION_ERROR);
            }
        }
        /*---------- End of ESMS main static method ----------*/

        private static bool Debug()
        {
            bool answer;
            try
            {
                answer = Config.getConfig().Debug;
            }
            catch (System.Exception err)
            {
                Console.WriteLine("DEBUG value not defined in league.xml, defaulting to false.");
                return false;
            }
            return answer;
        }
		
        public static int currentMinute;
		
        /// <summary>Creates a new instance of ESMS </summary>
        public ESMS(long seed, string homeSheet, string awaySheet)
        {
            ESMS.setRandomEngine(seed);
            homeTS = new ESMSTeam(homeSheet);
            awayTS = new ESMSTeam(awaySheet);
        }
		
        public ESMS(string homeSheet, string awaySheet)
        {
            ESMS.setRandomEngine();
            homeTS = new ESMSTeam(homeSheet);
            awayTS = new ESMSTeam(awaySheet);
        }
		
		
        /// <summary>Handle fouls (called on each minute with for each team) </summary>
        internal virtual void  if_foul(ESMSTeam team, ESMSTeam opponent)
        {
            int fouler;
			
            if (getThresold((int) ((float) team.Aggression * (3.0 / 4.0))))
            {
                fouler = who_did_it(team, DID_FOUL);
                string[] param = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(fouler).Name};
                output.Write("<Foul min=\"" + param[0] + "\" team=\"" + param[1] + "\" player=\"" + param[2] + "\">");
                output.Write(Comment.getComment().getCommentString("FOUL", param));
                output.Write("</Foul>");
                output.Flush();
				
                team.increaseFinalFouls();
                ((ESMSPlayer) team.getPlayer(fouler)).increaseFouls();
				
                if (getThresold(6000))
                    bookings(team, fouler, YELLOW);
                else if (getThresold(400))
                    bookings(team, fouler, RED);
                else
                {
                    output.Write("<Warned>");
                    output.Write(Comment.getComment().getCommentString("WARNED", param));
                    output.Write("</Warned>");
                    output.Flush();
                }
				
                /* Condition for a penalty to occur, if GK fouled or random */
                if ((team.getPosition(fouler).Equals("GK")) || (getThresold(300)))
                {
                    if (((ESMSPlayer) opponent.PKicker).Status != ESMSPlayer.PLAYING)
                    {
                        opponent.electNewPKicker();
                    }
					
                    string[] params_Renamed = new string[]{opponent.PKicker.Name};
                    output.Write("<Penalty team=\"" + opponent.Abbreviation + "\" player=\"" + params_Renamed[0] + "\">");
                    output.Write(Comment.getComment().getCommentString("PENALTY", params_Renamed));
                    output.Write("</Penalty>");
                    output.Flush();
					
                    if (getThresold(8000 + opponent.PKicker.Shooting * 100 - team.Keeper.Keeping * 100))
                    {
                        output.Write("<Goal team=\"" + opponent.Abbreviation + "\" player=\"" + opponent.PKicker.Name + "\">");
                        output.Write(Comment.getComment().getCommentString("GOAL"));
                        output.Write("</Goal>");
                        output.Flush();
						
                        opponent.increaseScore();
                        ((ESMSPlayer) opponent.PKicker).increaseGoals();
                        ((ESMSPlayer) team.Keeper).increaseConceded();
                    }
                    else
                    {
                        if (getThresold(5000))
                        {
                            string[] parames = new string[]{team.Keeper.Name};
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
            }
        }
		
		
        public virtual void  checkConditionals(int team)
        {
            /**/
            if (team == 0)
                homeTS.checkConditionals(awayTS, ESMS.currentMinute);
            else
                awayTS.checkConditionals(homeTS, ESMS.currentMinute);
        }
		
        public virtual void  printFinalStats()
        {
            string[] params_Renamed = new string[]{homeTS.Name, System.Convert.ToString(homeTS.ShotsOn), System.Convert.ToString(awayTS.ShotsOn), awayTS.Name};
            output.Write("<ShotsOnTarget home=\"" + params_Renamed[1] + "\" away=\"" + params_Renamed[2] + "\">");
            output.Write(Comment.getComment().getCommentString("COMM_SHOTSONTARGET", params_Renamed));
            output.Write("</ShotsOnTarget>");
            params_Renamed = null;
			
            string[] params2 = new string[]{homeTS.Name, System.Convert.ToString(homeTS.ShotsOff), System.Convert.ToString(awayTS.ShotsOff), awayTS.Name};
            output.Write("<ShotsOffTarget home=\"" + params2[1] + "\" away=\"" + params2[2] + "\">");
            output.Write(Comment.getComment().getCommentString("COMM_SHOTSOFFTARGET", params2));
            output.Write("</ShotsOffTarget>");
            params2 = null;
			
            string[] params3 = new string[]{homeTS.Name, System.Convert.ToString(homeTS.Score), System.Convert.ToString(awayTS.Score), awayTS.Name};
            output.Write("<Score home=\"" + params3[1] + "\" away=\"" + params3[2] + "\">");
            output.Write(Comment.getComment().getCommentString("COMM_SCORE", params3));
            output.Write("</Score>");
            params3 = null;
			
            int t_saves = 0, t_tackles = 0, t_keypasses = 0, t_assists = 0, t_shots = 0, t_goals = 0, t_yellowcards = 0, t_redcards = 0;
			
            output.Write("<TeamStats team=\"" + homeTS.Abbreviation + "\">");
			
            for (int i = 1; i <= homeTS.NumPlayers; i++)
            {
                ESMSPlayer p = ((ESMSPlayer) homeTS.getPlayer(i));
                output.Write("<PlayerStats name=\"" + p.Name + "\"");
                output.Write(" position=\"" + homeTS.getPosition(i) + "\"");
                output.Write(" shotStopping=\"" + p.Keeping + "\"");
                output.Write(" tackling=\"" + p.Tackling + "\"");
                output.Write(" passing=\"" + p.Passing + "\"");
                output.Write(" shooting=\"" + p.Shooting + "\"");
                output.Write(" aggression=\"" + p.getAggression() + "\"");
                output.Write(" minutes=\"" + p.Minutes + "\"");
                output.Write(" saves=\"" + p.getSaves() + "\"");
                output.Write(" keyTackling=\"" + p.getTackles() + "\"");
                output.Write(" keyPassing=\"" + p.getKeyPasses() + "\"");
                output.Write(" assists=\"" + p.getAssists() + "\"");
                output.Write(" shots=\"" + p.getShots() + "\"");
                output.Write(" goals=\"" + p.getGoals() + "\"");
                output.Write(" yellowCards=\"" + p.YellowCards + "\"");
                output.Write(" redCards=\"" + p.RedCard + "\"");
                output.Write(" keepingAbility=\"" + p.getKeepingAbility() + "\"");
                output.Write(" tacklingAbility=\"" + p.getTacklingAbility() + "\"");
                output.Write(" passingAbility=\"" + p.getPassingAbility() + "\"");
                output.Write(" shootingAbility=\"" + p.getShootingAbility() + "\"");
                output.Write(" injured=\"" + p.Injured + "\"");
                output.Write("/>");
				
                t_saves += p.getSaves();
                t_tackles += p.getTackles();
                t_keypasses += p.getKeyPasses();
                t_assists += p.getAssists();
                t_shots += p.getShots();
                t_goals += p.getGoals();
                t_yellowcards += p.YellowCards;
                t_redcards += p.RedCard;
            }
            /* Here i must add total statistics */
            output.Write("<TotalStats");
            output.Write(" saves=\"" + t_saves + "\"");
            output.Write(" keyTackling=\"" + t_tackles + "\"");
            output.Write(" keyPassing=\"" + t_keypasses + "\"");
            output.Write(" assists=\"" + t_assists + "\"");
            output.Write(" shots=\"" + t_shots + "\"");
            output.Write(" goals=\"" + t_goals + "\"");
            output.Write(" yellowCards=\"" + t_yellowcards + "\"");
            output.Write(" redCards=\"" + t_redcards + "\"");
            output.Write("/>");
			
            output.Write("</TeamStats>");
			
            t_saves = 0; t_tackles = 0; t_keypasses = 0; t_assists = 0;
            t_shots = 0; t_goals = 0; t_yellowcards = 0; t_redcards = 0;
			
            output.Write("<TeamStats team=\"" + awayTS.Abbreviation + "\">");
			
            for (int i = 1; i <= awayTS.NumPlayers; i++)
            {
                ESMSPlayer p = ((ESMSPlayer) awayTS.getPlayer(i));
                output.Write("<PlayerStats name=\"" + p.Name + "\"");
                output.Write(" position=\"" + awayTS.getPosition(i) + "\"");
                output.Write(" shotStopping=\"" + p.Keeping + "\"");
                output.Write(" tackling=\"" + p.Tackling + "\"");
                output.Write(" passing=\"" + p.Passing + "\"");
                output.Write(" shooting=\"" + p.Shooting + "\"");
                output.Write(" aggression=\"" + p.getAggression() + "\"");
                output.Write(" minutes=\"" + p.Minutes + "\"");
                output.Write(" saves=\"" + p.getSaves() + "\"");
                output.Write(" keyTackling=\"" + p.getTackles() + "\"");
                output.Write(" keyPassing=\"" + p.getKeyPasses() + "\"");
                output.Write(" assists=\"" + p.getAssists() + "\"");
                output.Write(" shots=\"" + p.getShots() + "\"");
                output.Write(" goals=\"" + p.getGoals() + "\"");
                output.Write(" yellowCards=\"" + p.YellowCards + "\"");
                output.Write(" redCards=\"" + p.RedCard + "\"");
                output.Write(" keepingAbility=\"" + p.getKeepingAbility() + "\"");
                output.Write(" tacklingAbility=\"" + p.getTacklingAbility() + "\"");
                output.Write(" passingAbility=\"" + p.getPassingAbility() + "\"");
                output.Write(" shootingAbility=\"" + p.getShootingAbility() + "\"");
                output.Write(" injured=\"" + p.Injured + "\"");
                output.Write("/>");
				
                t_saves += p.getSaves();
                t_tackles += p.getTackles();
                t_keypasses += p.getKeyPasses();
                t_assists += p.getAssists();
                t_shots += p.getShots();
                t_goals += p.getGoals();
                t_yellowcards += p.YellowCards;
                t_redcards += p.RedCard;
            }
            /* Here i must add total statistics */
            output.Write("<TotalStats");
            output.Write(" saves=\"" + t_saves + "\"");
            output.Write(" keyTackling=\"" + t_tackles + "\"");
            output.Write(" keyPassing=\"" + t_keypasses + "\"");
            output.Write(" assists=\"" + t_assists + "\"");
            output.Write(" shots=\"" + t_shots + "\"");
            output.Write(" goals=\"" + t_goals + "\"");
            output.Write(" yellowCards=\"" + t_yellowcards + "\"");
            output.Write(" redCards=\"" + t_redcards + "\"");
            output.Write("/>");
			
            output.Write("</TeamStats>");
			
            output.Flush();
        }
		
        public virtual void  calcAbility()
        {
            homeTS.calcAbility(homeTS.Score, awayTS.Score);
            awayTS.calcAbility(awayTS.Score, homeTS.Score);
        }
		
        public virtual void  bookings(ESMSTeam team, int player, int card_color)
        {
            if (card_color == YELLOW)
            {
                output.Write("<YellowCard>");
                output.Write(Comment.getComment().getCommentString("YELLOWCARD"));
                output.Write("</YellowCard>");
                output.Flush();
                ((ESMSPlayer) team.getPlayer(player)).increaseYellowCards();
				
                if (((ESMSPlayer) team.getPlayer(player)).YellowCards == 2)
                {
                    output.Write("<SecondYellowCard>");
                    output.Write(Comment.getComment().getCommentString("SECONDYELLOWCARD"));
                    output.Write("</SecondYellowCard>");
                    output.Flush();
                    send_off(team, player);
                    team.RedCarded = ((ESMSPlayer) team.getPlayer(player));
                }
                else
                    team.YellowCarded = ((ESMSPlayer) team.getPlayer(player));
            }
            else if (card_color == RED)
            {
                output.Write("<RedCard>");
                output.Write(Comment.getComment().getCommentString("REDCARD"));
                output.Write("</RedCard>");
                output.Flush();
                send_off(team, player);
                team.RedCarded = ((ESMSPlayer) team.getPlayer(player));
            }
        }
		
        public virtual void  CleanInjCards()
        {
            homeTS.clean();
            awayTS.clean();
        }
		
        public virtual void  updateStats()
        {
            homeTS.updateStats(awayTS);
            awayTS.updateStats(homeTS);
			
            homeTS.calcShotProb(awayTS.Tackling, true);
            awayTS.calcShotProb(homeTS.Tackling, false);
        }
		
        public virtual void  send_off(ESMSTeam team, int player)
        {
            ESMSPlayer p = ((ESMSPlayer) team.getPlayer(player));
            p.clearYellowCards();
            p.increaseRedCards();
            p.Status = ESMSPlayer.UNAVAILABLE;
			
            if (team.getPosition(player).Equals("GK"))
            {
                /* Innanzitutto devo controllare se GK è in panchina
				* Poi devo controllare se ho sostituzioni
				* Se è in panchina ed ho sostituzioni allora lo sostituisco
				* Altrimenti devo sostituirlo con uno dei giocatori in campo
				*/
				
                int newkeeper = team.electNewKeeper();
                if (((ESMSPlayer) team.getPlayer(newkeeper)).Status == ESMSPlayer.PLAYING)
                {
                    team.changePosition(newkeeper, "GK");
                    string[] params_Renamed = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(newkeeper).Name, "GK"};
                    output.Write("<ChangePosition min=\"" + params_Renamed[0] + "\" team=\"" + params_Renamed[1] + "\" player=\"" + params_Renamed[2] + "\" newPosition=\"" + params_Renamed[3] + "\">");
                    output.Write(Comment.getComment().getCommentString("CHANGEPOSITION", params_Renamed));
                    output.Write("</ChangePosition>");
                    output.Flush();
                }
                else
                {
                    team.substitutePlayer(player, newkeeper, "GK");
                    string[] params_Renamed = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(newkeeper).Name, team.getPlayer(player).Name, "GK"};
                    output.Write("<Substitution min=\"" + params_Renamed[0] + "\" team=\"" + params_Renamed[1] + "\" playerIn=\"" + params_Renamed[2] + "\" playerOut=\"" + params_Renamed[3] + "\" position=\"" + params_Renamed[4] + "\">");
                    output.Write(Comment.getComment().getCommentString("SUBSTITUTION", params_Renamed));
                    output.Write("</Substitution>");
                    output.Flush();
                }
            }
        }
		
        private void  adjust_contrib_with_side_balance(ESMSTeam team)
        {
			
            // Inzializza Vettore
            /* * Dopodichè per ogni giocatore ci si segna il ruolo (FW, DF, MF, etc)
			* Si incrementa il contatore in base del ruolo e posizione in cui gioca
			*/
            /*        for (int i = 0; i < team.getNumPlayers(); i++) {
			if (((ESMSPlayer)team.getPlayer(i)).getStatus() == ESMSPlayer.PLAYING)
			{
			if (team.getActualSide(i) == 'R')
			Vett[team.getPosition(i)]['R']++;
			else if (team.getActualSide(i) == 'L')
			Vett[team.getPosition(i)]['L']++;
			else if (team.getActualSide(i) == 'C')
			Vett[team.getPosition(i)]['C']++;
			}
			}
			**/
            /*        for(ogni ruolo)
			{
			Controlla NroR == NroL e !(NroC > 3 && NroR==0 && NroL == 0)
			altrimenti penale nel ruolo;
			}
			*/
            /* 
			* L'idea è che il sistema inizia a tenere una hashtable con 3 int
			* uno per R, L, C.
			*
			*
			* A quel punto si controlla:
			* Se la squadra è sbilanciata (Nro R != Nro L) si penalizza
			* Se la squadra ha troppi centrali >3 e 0 ali si penalizza.
			*
			* La penalizzazione abbassa tutto il reparto che stava venendo testato.
			*
			* a è la squadra da controllare (0 o 1)
			* Questa routine viene invocata (ricalcolata) AD OGNI MINUTO!!!
			*/
        }
		
		
        /// <summary>Calculate whether was a shot on a certain minute. If was, is it on/off
        /// target, if on target if it goal, if goal, if it was assisted 
        /// </summary>
        private void  if_shot(ESMSTeam team, ESMSTeam opponent)
        {
            int shooter, assister, tackler;
            int chance_tackled;
            bool chance_assisted = false;
			
            if (getThresold((int) team.ShotProb))
            {
                shooter = who_did_it(team, DID_SHOT);
                if (getThresold(7000))
                {
                    assister = who_did_it(team, DID_ASSIST);
                    chance_assisted = true;
					
                    if (assister != shooter)
                    {
						
                        if (team.getActualSide(assister) != team.getActualSide(shooter))
                        {
                            do 
                            {
                                assister = who_did_it(team, DID_ASSIST);
                            }
                            while (assister != shooter);
                        }
						
                        string[] params_Renamed = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(assister).Name, team.getPlayer(shooter).Name};
                        output.Write("<AssistedChance min=\"" + currentMinute + "\" team=\"" + team.Abbreviation + "\" assister=\"" + team.getPlayer(assister).Name + "\" assisted=\"" + team.getPlayer(shooter).Name + "\">");
						
                        output.Write(Comment.getComment().getCommentString("ASSISTEDCHANCE", params_Renamed));
                        output.Write("</AssistedChance>");
                        ((ESMSPlayer) team.getPlayer(assister)).increasePasses();
                        output.Flush();
                    }
                    else
                    {
                        string[] params_Renamed = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(shooter).Name};
                        output.Write("<Chance min=\"" + currentMinute + "\" team=\"" + team.Abbreviation + "\" player=\"" + team.getPlayer(shooter).Name + "\">");
						
                        output.Write(Comment.getComment().getCommentString("CHANCE", params_Renamed));
                        output.Write("</Chance>");
                        output.Flush();
                    }
                }
                else
                {
                    chance_assisted = false;
                    assister = 0;
					
                    string[] params_Renamed = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(shooter).Name};
                    output.Write("<Chance min=\"" + currentMinute + "\" team=\"" + team.Abbreviation + "\" player=\"" + team.getPlayer(shooter).Name + "\">");
					
                    output.Write(Comment.getComment().getCommentString("CHANCE", params_Renamed));
                    output.Write("</Chance>");
                    output.Flush();
                }
				
                chance_tackled = (int) (4000.0 * ((opponent.Tackling * 3.0) / (team.Passing * 2.0 + team.Shooting)));
				
                if (getThresold(chance_tackled))
                {
                    tackler = who_did_it(opponent, DID_TACKLE);
                    ((ESMSPlayer) opponent.getPlayer(tackler)).increaseTackles();
					
                    string[] params_Renamed = new string[]{opponent.getPlayer(tackler).Name};
                    output.Write("<Tackle player=\"" + opponent.getPlayer(tackler).Name + "\">");
					
                    output.Write(Comment.getComment().getCommentString("TACKLE", params_Renamed));
                    output.Write("</Tackle>");
                    output.Flush();
                }
                else
                {
                    string[] params_Renamed = new string[]{team.getPlayer(shooter).Name};
                    output.Write("<Shot player=\"" + team.getPlayer(shooter).Name + "\">");
                    output.Write(Comment.getComment().getCommentString("SHOT", params_Renamed));
                    output.Write("</Shot>");
                    output.Flush();
					
                    ((ESMSPlayer) team.getPlayer(shooter)).increaseShots();
					
                    if (ifOnTarget(team, shooter))
                    {
                        team.increaseFinalShotsOn();
                        ((ESMSPlayer) team.getPlayer(shooter)).increaseShotsOn();
						
                        if (ifGoal(team, opponent, shooter))
                        {
                            output.Write("<Goal team=\"" + team.Abbreviation + "\" player=\"" + team.getPlayer(shooter).Name + "\">");
                            output.Write(Comment.getComment().getCommentString("GOAL"));
                            output.Write("</Goal>");
                            output.Flush();
                            if (!GoalCancelled)
                            {
                                team.increaseScore();
								
                                if (chance_assisted && (assister != shooter))
                                {
                                    ((ESMSPlayer) team.getPlayer(assister)).increaseAssists();
                                }
                                ((ESMSPlayer) team.getPlayer(shooter)).increaseGoals();
                                ((ESMSPlayer) opponent.Keeper).increaseConceded();
                            }
                        }
                        else
                        {
                            /*Saved*/
                            string[] parames = new string[]{opponent.Keeper.Name};
                            output.Write("<Save player=\"" + parames[0] + "\">");
                            output.Write(Comment.getComment().getCommentString("SAVE", parames));
                            output.Write("</Save>");
                            output.Flush();
                            ((ESMSPlayer) opponent.Keeper).increaseSaves();
                        }
                    }
                    else
                    {
                        /*Offtarget*/
                        ((ESMSPlayer) team.getPlayer(shooter)).increaseShotsOff();
                        team.increaseFinalShotsOff();
                        output.Write("<OffTarget>");
                        output.Write(Comment.getComment().getCommentString("OFFTARGET"));
                        output.Write("</OffTarget>");
                        output.Flush();
                    }
                }
            }
        }
		
        private int who_did_it(ESMSTeam team, int event_Renamed)
        {
            double total = 0, weight = 0;
            double[] ar = new double[team.NumPlayers + 1];
			
            for (int k = 1; k <= team.NumPlayers; k++)
            {
                switch (event_Renamed)
                {
					
                    case DID_SHOT:  {
                        weight += ((ESMSPlayer) team.getPlayer(k)).shootingContrib * 100.0;
                        total = team.Shooting;
                        break;
                    }
					
                    case DID_FOUL:  {
                        if (((ESMSPlayer) team.getPlayer(k)).Status == ESMSPlayer.PLAYING)
                            weight += ((ESMSPlayer) team.getPlayer(k)).getAggression() * 100.0;
                        total = team.Aggression;
                        break;
                    }
					
                    case DID_TACKLE:  {
                        weight += ((ESMSPlayer) team.getPlayer(k)).tacklingContrib * 100.0;
                        total = team.Tackling;
                        break;
                    }
					
                    case DID_ASSIST:  {
                        weight += ((ESMSPlayer) team.getPlayer(k)).passingContrib * 100.0;
                        total = team.Passing;
                        break;
                    }
					
                    default:  {
                        throw new System.Exception("Error: received unknown event in who_did_it method");
                    }
					
                }
				
                ar[k] = weight;
            }
			
            int randValue = Random.Next((int) (total * 100));
            int k2 = 0;
			
            for (k2 = 2; ar[k2] < randValue; k2++)
                if (k2 == team.NumPlayers)
                    throw new System.Exception("Inner error while executing who_did_it method");
			
            return k2;
        }
		
        public virtual void  play()
        {
            try
            {
                initData();
                for (currentMinute = 1; currentMinute <= 45; currentMinute++)
                {
                    homeTS.clean();
                    awayTS.clean();
					
                    this.updateStats();
					
                    this.if_shot(homeTS, awayTS);
                    this.if_foul(homeTS, awayTS);
                    this.randomInjury(homeTS, awayTS);
                    //ApplyConditionals
					
                    this.if_shot(awayTS, homeTS);
                    this.if_foul(awayTS, homeTS);
                    this.randomInjury(awayTS, homeTS);
                    //ApplyConditionals
                    checkConditionals(0);
                    checkConditionals(1);
                    /*Qui dovrei inserire quella storia dei FormalMinutes, per ora facciamo senza */
                    this.increaseMinutes();
                }
                /*Qui abbiamo finito il primo tempo, aggiungo injtime*/
                output.Write("<HalfTime>");
                output.Write(Comment.getComment().getCommentString("COMM_HALFTIME"));
                output.Write("</HalfTime>");
                output.Flush();
				
                for (currentMinute = 46; currentMinute <= 90; currentMinute++)
                {
                    homeTS.clean();
                    awayTS.clean();
					
                    this.updateStats();
					
                    this.if_shot(homeTS, awayTS);
                    this.if_foul(homeTS, awayTS);
                    this.randomInjury(homeTS, awayTS);
                    //ApplyConditionals
					
                    this.if_shot(awayTS, homeTS);
                    this.if_foul(awayTS, homeTS);
                    this.randomInjury(awayTS, homeTS);
                    //ApplyConditionals
                    checkConditionals(0);
                    checkConditionals(1);
                    /*Qui dovrei inserire quella storia dei FormalMinutes, per ora facciamo senza */
                    this.increaseMinutes();
                }
				
                output.Write("<FullTime>");
                output.Write(Comment.getComment().getCommentString("COMM_FULLTIME"));
                output.Write("</FullTime>");
                output.Flush();
				
				
                /*Here i've to play the penalty shootout if game allows it*/
				
                if (Config.getConfig().CupMatch == Config.SHOOTOUT_ASK)
                {
                    //Add a flag to take previous result (and automatically calculate if shootout are needed)
					
                    Console.WriteLine(homeTS.Name + " " + homeTS.Score + " - " + awayTS.Score + " " + awayTS.Name);
					
                    Console.WriteLine("Would you like to run a penalty shootout? (y/n)");
					
                    bool PS = false;
                    try
                    {
                        int ch = System.Console.Read();
                        if ((char) ch == 'y' || (char) ch == 'Y')
                            PS = true;
                    }
                    catch (System.Exception err)
                    {
                        Console.WriteLine("Error while reading from console");
                        System.Environment.Exit(ExitCodes.GENERIC_ERROR);
                    }
					
                    //I've to ask for a penalty shootout
                    //Let's say the answer is y
					
                    if (PS)
                    {
                        PenaltyShootout penalties = new PenaltyShootout(homeTS, awayTS, output);
                        penalties.RunPenaltyShootout();
                    }
                }
                else if (Config.getConfig().CupMatch == Config.SHOOTOUT_ALWAYS && homeTS.Score == awayTS.Score)
                {
                    PenaltyShootout penalties = new PenaltyShootout(homeTS, awayTS, output);
                    penalties.RunPenaltyShootout();
                }
				
                calcAbility();
                printFinalStats();
				
                output.Write("</Match>");
                output.Flush();
                output.Close();
				
                Console.WriteLine(homeTS.Name + " - " + awayTS.Name + " Successfully played.");
                //System.out.println(homeTS.getName()+" "+homeTS.getScore()+" - "+
                //awayTS.getScore()+" "+awayTS.getName());
            }
            catch (System.Exception err)
            {
                //UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Throwable.getMessage' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
                Console.WriteLine(err.Message);
                if (Debug())
                    SupportClass.WriteStackTrace(err, Console.Error);
                System.Environment.Exit(ExitCodes.GENERIC_ERROR);
            }
        }
        private void  increaseMinutes()
        {
            for (int i = 1; i <= homeTS.NumPlayers; i++)
            {
                ESMSPlayer p = ((ESMSPlayer) homeTS.getPlayer(i));
                if (p.Status == ESMSPlayer.PLAYING)
                {
                    p.increaseMinutes();
                }
            }
            for (int i = 1; i <= awayTS.NumPlayers; i++)
            {
                ESMSPlayer p = ((ESMSPlayer) awayTS.getPlayer(i));
                if (p.Status == ESMSPlayer.PLAYING)
                {
                    p.increaseMinutes();
                }
            }
        }
		
        internal ESMSTeam homeTS, awayTS;
        public static System.IO.StreamWriter output;
		
        public virtual void  writeXSLTransform(GenericSourceSupport XSL)
        {
            TransformerSupport tFactory = TransformerSupport.NewInstance();
            TransformerSupport temp_Transformer;
            temp_Transformer = TransformerSupport.NewTransform(tFactory);
            temp_Transformer.Load(XSL);
            TransformerSupport transformer = temp_Transformer;
            //UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
            transformer.DoTransform(new GenericSourceSupport(CommentaryName + ".xml"), new GenericResultSupport(new System.IO.FileStream(CommentaryName + ".out", System.IO.FileMode.Create)));
        }
		
        private void  initData()
        {
            if (!(homeTS.getPosition(1).Equals("GK")))
                throw new System.Exception("Error in team " + homeTS.Name + ":The first player in the teamsheet must be a GoalKeeper!");
            if (!(awayTS.getPosition(1).Equals("GK")))
                throw new System.Exception("Error in team " + awayTS.Name + ":The first player in the teamsheet must be a GoalKeeper!");
			
            //UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
            //UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
            output = new System.IO.StreamWriter(new System.IO.FileStream(homeTS.Abbreviation + "_" + awayTS.Abbreviation + ".xml", System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
			
            output.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
            if (externalUrl != null)
                output.Write("<?xml-stylesheet type=\"text/xsl\" href=\"" + externalUrl + "\"?>");
            //UPGRADE_ISSUE: Constructor 'java.text.SimpleDateFormat.SimpleDateFormat' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javatextSimpleDateFormat'"
            //UPGRADE_TODO: The equivalent in .NET for method 'java.util.Calendar.getTime' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
            //output.Write("<Match randomSeed=\"" + seed + "\" home=\"" + homeTS.Abbreviation + "\" away=\"" + awayTS.Abbreviation + "\" date=\"" + SupportClass.FormatDateTime(new SimpleDateFormat("ddMMyy"), SupportClass.CalendarManager.manager.GetDateTime(new System.Globalization.GregorianCalendar())) + "\">");
            output.Write("<Match randomSeed=\"" + seed + "\" home=\"" + homeTS.Abbreviation + "\" away=\"" + awayTS.Abbreviation + "\" date=\"" + DateTime.Today + "\">");
            output.Flush();
			
            initTeam(homeTS, awayTS, true);
            initTeam(awayTS, homeTS, false);
			
            printStartingTactics();
        }
		
        private void  printStartingTactics()
        {
            try
            {
                output.Write("<StartingFormation team=\"");
                output.Write(homeTS.Abbreviation);
                output.Write("\" tactic=\"" + homeTS.Formation + "\">");
                string[] parameters = new string[]{homeTS.Name, homeTS.Formation};
                output.Write(Comment.getComment().getCommentString("STARTINGFORMATION", parameters));
                output.Write("</StartingFormation>");
                output.Flush();
                output.Write("<StartingFormation team=\"");
                output.Write(awayTS.Abbreviation);
                output.Write("\" tactic=\"" + awayTS.Formation + "\">");
                string[] parameters2 = new string[]{awayTS.Name, awayTS.Formation};
                output.Write(Comment.getComment().getCommentString("STARTINGFORMATION", parameters2));
                output.Write("</StartingFormation>");
                output.Flush();
            }
            catch (System.Exception err)
            {
                Console.WriteLine("Unable to write Starting tactics on Match file");
                if (Debug())
                    SupportClass.WriteStackTrace(err, Console.Error);
                System.Environment.Exit(ExitCodes.ERROR_WRITING_COMMENTARY);
            }
        }
		
        private void  initTeam(ESMSTeam team, ESMSTeam opponent, bool isHome)
        {
            team.initTeam();
            int max = team.NumPlayers;
            for (int i = 1; i <= max; i++)
            {
                if (!team.getPosition(i).Equals("GK") && ((ESMSPlayer) team.getPlayer(i)).Status == ESMSPlayer.PLAYING)
                {
                    double tkMult = team.Tactic.getMult(opponent.Tactic.Name, team.getPosition(i), "TK");
                    double psMult = team.Tactic.getMult(opponent.Tactic.Name, team.getPosition(i), "PS");
                    double shMult = team.Tactic.getMult(opponent.Tactic.Name, team.getPosition(i), "SH");
					
                    ESMSPlayer temp = ((ESMSPlayer) team.getPlayer(i));
                    temp.tacklingContrib = tkMult * temp.Tackling * temp.fatigue;
                    temp.passingContrib = psMult * temp.Passing * temp.fatigue;
                    temp.shootingContrib = shMult * temp.Shooting * temp.fatigue;
                }
                else
                {
                    ESMSPlayer temp = ((ESMSPlayer) team.getPlayer(i));
                    temp.tacklingContrib = 0;
                    temp.passingContrib = 0;
                    temp.shootingContrib = 0;
                }
            }
            team.calcShotProb(opponent.Tackling, isHome);
            team.calcAggression();
        }
		
        private bool ifGoal(ESMSTeam team, ESMSTeam opponent, int scorer)
        {
            double temp = team.getPlayer(scorer).Shooting * ((ESMSPlayer) team.getPlayer(scorer)).fatigue * 200 - opponent.Keeper.Keeping * 200 + 3500;
			
            if (temp > 9000)
                temp = 9000;
            if (temp < 1000)
                temp = 1000;
            if (getThresold((int) temp))
                return true;
            else
                return false;
        }
		
        private bool ifOnTarget(ESMSTeam team, int shooter)
        {
            if (getThresold((int) (((ESMSPlayer) team.getPlayer(shooter)).fatigue * 5800.0)))
                return true;
            else
                return false;
        }
		
        private void  randomInjury(ESMSTeam team, ESMSTeam opponent)
        {
            int injured = team.randomInjury(opponent.Aggression);
            if (injured != 0)
            {
                string[] params_Renamed = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(injured).Name};
                output.Write("<Injury min=\"" + params_Renamed[0] + "\" team=\"" + params_Renamed[1] + "\" playerInjured=\"" + params_Renamed[2] + "\">");
                output.Write(Comment.getComment().getCommentString("INJURY", params_Renamed));
                output.Write("</Injury>");
                output.Flush();
                team.Injured = ((ESMSPlayer) team.getPlayer(injured));
				
                if (team.Substitutions >= Config.getConfig().Substitutions)
                {
                    ((ESMSPlayer) team.getPlayer(injured)).Status = ESMSPlayer.UNAVAILABLE;
                    output.Write("<NoSubsLeft>");
                    output.Write(Comment.getComment().getCommentString("NOSUBSLEFT"));
                    output.Write("</NoSubsLeft>");
                    output.Flush();
					
                    if (team.getPosition(injured).Equals("GK"))
                    {
                        /*I think this will be enough to take care of keeper change*/
                        int newKeeper = team.electNewKeeper();
                        if (((ESMSPlayer) team.getPlayer(newKeeper)).Status == ESMSPlayer.PLAYING)
                        {
                            team.changePosition(newKeeper, "GK");
                            string[] params2 = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(newKeeper).Name, "GK"};
                            output.Write("<ChangePosition min=\"" + params2[0] + "\" team=\"" + params2[1] + "\" player=\"" + params2[2] + "\" newPosition=\"" + params2[3] + "\">");
                            output.Write(Comment.getComment().getCommentString("CHANGEPOSITION", params2));
                            output.Write("</ChangePosition>");
                            output.Flush();
                        }
                        else
                        {
                            team.substitutePlayer(injured, newKeeper, "GK");
                            string[] params2 = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(newKeeper).Name, team.getPlayer(injured).Name, "GK"};
                            output.Write("<Substitution min=\"" + params2[0] + "\" team=\"" + params2[1] + "\" playerIn=\"" + params2[2] + "\" playerOut=\"" + params2[3] + "\" position=\"" + params2[4] + "\">");
                            output.Write(Comment.getComment().getCommentString("SUBSTITUTION", params2));
                            output.Write("</Substitution>");
                            output.Flush();
                        }
                    }
                }
                else
                {
                    int b = 12;
                    bool found = false;
                    while (!found && b <= team.NumPlayers)
                    {
                        if (team.getPosition(injured).Equals(team.getPosition(b)) && ((ESMSPlayer) team.getPlayer(b)).Status == ESMSPlayer.SUBSTITUTION)
                        {
                            team.substitutePlayer(injured, b, team.getPosition(b));
							
                            string[] params2 = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(b).Name, team.getPlayer(injured).Name, team.getPosition(injured)};
                            output.Write("<Substitution min=\"" + params2[0] + "\" team=\"" + params2[1] + "\" playerIn=\"" + params2[2] + "\" playerOut=\"" + params2[3] + "\" position=\"" + params2[4] + "\">");
                            output.Write(Comment.getComment().getCommentString("SUB", params2));
                            output.Write("</Substitution>");
                            output.Flush();
							
                            found = true;
                        }
                        else
                            b++;
                    }
                    if (!found)
                    {
						
                        b = team.electBestSub(team.getPosition(injured));
						
                        string[] params2 = new string[]{System.Convert.ToString(currentMinute), team.Abbreviation, team.getPlayer(b).Name, team.getPlayer(injured).Name, team.getPosition(injured)};
                        output.Write("<Substitution min=\"" + params2[0] + "\" team=\"" + params2[1] + "\" playerIn=\"" + params2[2] + "\" playerOut=\"" + params2[3] + "\" position=\"" + params2[4] + "\">");
                        output.Write(Comment.getComment().getCommentString("SUB", params2));
                        output.Write("</Substitution>");
                        output.Flush();
						
                        found = true;
                    }
                }
                ((ESMSPlayer) team.getPlayer(injured)).Injured = true;
                ((ESMSPlayer) team.getPlayer(injured)).Status = ESMSPlayer.UNAVAILABLE;
            }
        }
    }
}