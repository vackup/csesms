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
* ESMSTeam.java
*
* Created on 27 dicembre 2003, 10.24
*/
using System;
using CSEsMS.Engine;
using CSEsMS.Engine.Actions;
using CSEsMS.Engine.Conditions;
using CSEsMS.ESMS.Actions;
using CSEsMS.ESMS.Conditions;
using Action=CSEsMS.Engine.Actions.Action;

namespace CSEsMS.ESMS
{
    /// <summary>
    /// HZ: El ESMSTeam hereda de TeamSheet y TeamSheet es la plantilla (formacion) de jugadores 
    /// que componen el equipo para el partido el equipo (formado por jugadores - players)
    /// que va a jugar, tanto titulares, suplentes, pateadores de penales, etc.
    /// Para que hereda si agrega tantas propiedades? Creo que es porque el ESMSTeam es el que juega? mmm
    /// </summary>
    public class ESMSTeam:Engine.TeamSheet
    {
        #region Campos
        internal int _score;
        internal int _finalShots_On;
        internal int _finalShots_Off;
        internal int _finalFouls;

        /// <summary>Substitutions made by the team. </summary>
        internal int _substitutions;
        
        internal int _injuries;
        internal int _aggression;

        internal double _shot_prob;
        internal double _team_tackling;
        internal double _team_passing;
        internal double _team_shooting;

        internal ESMSPlayer[] _players;
        internal ESMSPlayer _redCarded = null;
        internal ESMSPlayer _yellowCarded = null;
        internal ESMSPlayer _injured = null;
        #endregion

        #region Propiedades
        virtual public double ShotProb
        {
            get
            {
                return this._shot_prob;
            }
			
        }
        virtual public string Formation
        {
            get
            {
                int df, mf, fw;
                df = 0;
                mf = 0;
                fw = 0;
				
                for (int i = 2; i <= 11; i++)
                {
                    if (getPosition(i).Equals("DF"))
                        df++;
                    else if (getPosition(i).Equals("MF"))
                        mf++;
                    else if (getPosition(i).Equals("FW"))
                        fw++;
                }
                return df + "-" + mf + "-" + fw + " " + _tactic.Name;
            }
			
        }
        virtual public int Aggression
        {
            get
            {
                return this._aggression;
            }
			
        }
        virtual public int Score
        {
            get
            {
                return _score;
            }
			
        }
        virtual public Player Keeper
        {
            get
            {
                for (int i = 1; i <= this.NumPlayers; i++)
                {
                    if (this.getPosition(i).Equals("GK") && ((ESMSPlayer) this.getPlayer(i)).Status == ESMSPlayer.PLAYING)
                        return this.getPlayer(i);
                }
                throw new System.Exception("Unable to find active Goalkeeper!");
            }
			
        }
        virtual public double Passing
        {
            get
            {
                return _team_passing;
            }
			
        }
        virtual public double Shooting
        {
            get
            {
                return _team_shooting;
            }
			
        }
        virtual public double Tackling
        {
            get
            {
                return _team_tackling;
            }
			
        }
        virtual public Player PKicker
        {
            get
            {
                return _penaltyKicker;
            }
			
        }
        virtual public ESMSPlayer Injured
        {
            get
            {
                return _injured;
            }
			
            set
            {
                _injured = value;
            }
			
        }
        virtual public ESMSPlayer RedCarded
        {
            get
            {
                return _redCarded;
            }
			
            set
            {
                _redCarded = value;
            }
			
        }
        virtual public int Substitutions
        {
            get
            {
                return this._substitutions;
            }
			
        }
        virtual public ESMSPlayer YellowCarded
        {
            get
            {
                return _yellowCarded;
            }
			
            set
            {
                _yellowCarded = value;
            }
			
        }
        virtual public int ShotsOn
        {
            get
            {
                int answer = 0;
                for (int i = 1; i <= NumPlayers; i++)
                {
                    answer += ((ESMSPlayer) getPlayer(i)).ShotsOn;
                }
                return answer;
            }
			
        }
        virtual public int ShotsOff
        {
            get
            {
                int answer = 0;
                for (int i = 1; i <= NumPlayers; i++)
                {
                    answer += ((ESMSPlayer) getPlayer(i)).ShotsOff;
                }
                return answer;
            }

        }
        #endregion

        #region Constructores
        public ESMSTeam(string fileName):base(fileName)
        {
            try
            {
                _players = new ESMSPlayer[11 + Config.getConfig().NumSubs];
				
                /*Convert Actions and Conditions to ESMS counterparts*/
                // Rebuild the teamsheet to store ESMSPlayers instead of normal Players.
                for (int i = 0; i < _team.Length; i++)
                {
                    _team[i] = new ESMSPlayer(_team[i]);
                    if (_penaltyKicker.Name.Equals(_team[i].Name))
                        _penaltyKicker = _team[i];
                    ((ESMSPlayer) _team[i]).Status = ESMSPlayer.PLAYING;
                }
				
                for (int i = 0; i < _subs.Length; i++)
                {
                    _subs[i] = new ESMSPlayer(_subs[i]);
                    ((ESMSPlayer) _team[i]).Status = ESMSPlayer.SUBSTITUTION;
                }
				
                /* Find the penaltykicker */
				
                Conditional[] cond = Conditionals;
                /*Rebuild Conditional*/
                for (int i = 0; i < cond.Length; i++)
                    _vCond[i] = parseConditional(cond[i]);
            }
            catch (System.Exception err)
            {
                System.Console.Out.WriteLine("Exception raised while trying to read the number of subs from Configuration object");
                SupportClass.WriteStackTrace(err, Console.Error);
            }
        }
        #endregion

        /// <summary>This method is used to convert Engine conditionals to ESMS conditionals.
        /// It's extremely complicated to do a very simple and useless thing anyway it's
        /// necessary to keep Engine and ESMS separated.
        /// It's obvious that object orientation is not for faint-hearted ;o)
        /// </summary>
        public static Conditional parseConditional(Conditional cond)
        {
            Condition[] tempCond = new Condition[cond.Conditions.Length];
            for (int index = 0; index < cond.Conditions.Length; index++)
            {
                // HZ: cambie Engine.Conditions.Condition_Fields de STRUC a ENUM y agregue (Condition_Fields) en el SWITCH, ver si funciona
                switch ((Condition_Fields)cond.Conditions[index].Type)
                {
					
                    case Engine.Conditions.Condition_Fields.MINUTE:  {
                        tempCond[index] = new ESMSMinCondition(cond.Conditions[index]); break;
                    }
					
                    case Engine.Conditions.Condition_Fields.RED:  {
                        tempCond[index] = new ESMSRedCondition(cond.Conditions[index]); break;
                    }
					
                    case Engine.Conditions.Condition_Fields.INJURY:  {
                        tempCond[index] = new ESMSInjCondition(cond.Conditions[index]); break;
                    }
					
                    case Engine.Conditions.Condition_Fields.YELLOW:  {
                        tempCond[index] = new ESMSYellowCondition(cond.Conditions[index]); break;
                    }
					
                    case Engine.Conditions.Condition_Fields.SCORE:  {
                        tempCond[index] = new ESMSScoreCondition(cond.Conditions[index]); break;
                    }
					
                    default:  throw new System.Exception("Unknown Condition in conditional");
					
                }
            }
            Action tempAction = null;

            // HZ: cambie Engine.Conditions.Action_Fields de STRUC a ENUM y agregue (Action_Fields) en el SWITCH, ver si funciona
            switch ((Action_Fields)cond.Action.Type)
            {
				
                case Engine.Actions.Action_Fields.TACTIC:  {
                    tempAction = new ESMSTacticAction(cond.Action); break;
                }
				
                case Engine.Actions.Action_Fields.SUB:  {
                    tempAction = new ESMSSubAction(cond.Action); break;
                }
				
                case Engine.Actions.Action_Fields.CHANGE:  {
                    tempAction = new ESMSChangePosAction(cond.Action); break;
                }
				
                default:  throw new System.Exception("Unknown Action in conditional");
				
            }
            return new Conditional(tempAction, tempCond);
        }
		
        public virtual void  calcShotProb(double oppTeam_Tackling, bool isHome)
        {
            this._shot_prob = 1.8 * (this._aggression / 50.0 + 800.0 * System.Math.Pow(((1.0 / 3.0 * this._team_shooting + 2.0 / 3.0 * this._team_passing) / (oppTeam_Tackling + 1.0)), 2));
            if (isHome)
                this._shot_prob += (double)Config.getConfig().HomeBonus;
        }
		
        public virtual void  initTeam()
        {
            this._injuries = 0;
            this._substitutions = 0;
            for (int i = 0; i < _team.Length; i++)
                ((ESMSPlayer) _team[i]).Status = ESMSPlayer.PLAYING;
            for (int i = 0; i < _subs.Length; i++)
                ((ESMSPlayer) _subs[i]).Status = ESMSPlayer.SUBSTITUTION;
			
            this._score = 0;
            this._finalShots_On = 0;
            this._finalShots_Off = 0;
            this._finalFouls = 0;
            this._team_tackling = 0;
            this._team_passing = 0;
            this._team_shooting = 0;
			
            for (int i = 1; i <= this.NumPlayers; i++)
            {
                ESMSPlayer temp = (ESMSPlayer) this.getPlayer(i);
                temp.initPlayer();
            }
        }

        public virtual void  calcAggression()
        {
            this._aggression = 0;
			
            for (int i = 1; i <= this.NumPlayers; i++)
            {
                ESMSPlayer player = (ESMSPlayer) getPlayer(i);
                if (player.Status == ESMSPlayer.PLAYING)
                    this._aggression += player.getAggression();
                // Alesk comment about aggressivity
                //if (player.getStatus()!=ESMSPlayer.PLAYING)
                //    player.setAggression(0);
                //this.aggression += player.getAggression();
            }
        }
		
        public virtual void  increaseFinalShotsOn()
        {
            this._finalShots_On++;
        }
		
        public virtual void  increaseFinalFouls()
        {
            this._finalFouls++;
        }
        public virtual void  increaseFinalShotsOff()
        {
            this._finalShots_On++;
        }
		
        public virtual void  increaseScore()
        {
            this._score++;
        }
		
        public virtual void  electNewPKicker()
        {
            /* Is there a situation in which the kicker chosen by the
			program is the wrong one ? */
            int max = getPlayer(1).Shooting;
            int max_index = 1;
			
            for (int i = 2; i <= this.NumPlayers; i++)
            {
                /* Is there a bug here? in the original code there's an OR */
                if (((ESMSPlayer) getPlayer(i)).Status == ESMSPlayer.PLAYING && ((ESMSPlayer) getPlayer(i)).Shooting > max)
                {
                    max = getPlayer(i).Shooting;
                    max_index = i;
                }
            }
			
            this._penaltyKicker = getPlayer(max_index);
        }
		
        public virtual void  clearCards()
        {
            _redCarded = null;
            _yellowCarded = null;
        }
		
        public virtual void  updateStats(ESMSTeam team)
        {
            this._team_tackling = 0;
            this._team_passing = 0;
            this._team_shooting = 0;
			
            this.calcAggression();
            for (int player = 2; player < NumPlayers; player++)
            {
                calcPlayerContributions(player, team);
                calcTeamContributions(player);
            }
            for (int player = 2; player < NumPlayers; player++)
            {
                ESMSPlayer temp = ((ESMSPlayer) getPlayer(player));
                if (temp.Status == ESMSPlayer.PLAYING)
                {
                    temp.fatigue *= 0.996;
                    /*Dovrei tagliare il float a 2 cifre decimali ma non ho idea del perche'*/
                }
            }
        }
		
        public virtual void  calcTeamContributions(int player)
        {
            ESMSPlayer p = ((ESMSPlayer) getPlayer(player));
            if (p.Status == ESMSPlayer.PLAYING)
            {
                this._team_tackling += p.tacklingContrib;
                this._team_shooting += p.shootingContrib;
                this._team_passing += p.passingContrib;
            }
        }
		
        public virtual void  calcPlayerContributions(int player, ESMSTeam opponent)
        {
			
            if (!getPosition(player).Equals("GK") && ((ESMSPlayer) getPlayer(player)).Status == ESMSPlayer.PLAYING)
            {
                double tkMult = Tactic.getMult(opponent.Tactic.Name, getPosition(player), "TK");
                double psMult = Tactic.getMult(opponent.Tactic.Name, getPosition(player), "PS");
                double shMult = Tactic.getMult(opponent.Tactic.Name, getPosition(player), "SH");
				
                ESMSPlayer temp = ((ESMSPlayer) getPlayer(player));
                temp.tacklingContrib = tkMult * temp.Tackling * temp.fatigue;
                temp.passingContrib = psMult * temp.Passing * temp.fatigue;
                temp.shootingContrib = shMult * temp.Shooting * temp.fatigue;
            }
            else
            {
                ESMSPlayer temp = ((ESMSPlayer) getPlayer(player));
                temp.tacklingContrib = 0;
                temp.passingContrib = 0;
                temp.shootingContrib = 0;
            }
        }
		
        /*Ora è tardi però converrebbe trasformare la electNewKeeper affinchè
		restituisca il numero del giocatore senza fare alcun cambio, dall'esterno
		il programma controlla lo stato del giocatore selezionato: se è attivo vuol dire
		che è un CHANGEPOS altrimenti che é un SUBSTITUTION */
        public virtual int electNewKeeper()
        {
            bool found = false;
            int i = 12;
            if (_substitutions < Config.getConfig().Substitutions)
            {
				
                while (!found && i <= NumPlayers)
                {
                    if (getPosition(i).Equals("GK") && ((ESMSPlayer) getPlayer(i)).Status == ESMSPlayer.SUBSTITUTION)
                    {
                        int n = 11;
						
                        found = true;
						
                        while (((ESMSPlayer) getPlayer(n)).Status != ESMSPlayer.PLAYING)
                            n--;
                        //substitutePlayer(n,i,"GK");
                        return i;
                    }
                    else
                    {
                        found = false;
                        i++;
                    }
                }
				
                if (!found)
                {
                    /* Meglio sarebbe trovare il giocatore con la più alta keeping */
                    int nkNumber = - 1;
                    int nkSt = - 1;
                    for (int j = 1; j <= NumPlayers; j++)
                    {
                        if (getPlayer(j).Keeping > nkSt && ((ESMSPlayer) getPlayer(j)).Status == ESMSPlayer.PLAYING && !getPosition(j).Equals("GK"))
                        {
                            nkSt = getPlayer(j).Keeping;
                            nkNumber = j;
                        }
                    }
					
                    return nkNumber;
                    //changePosition(n,"GK");
                }
            }
            else
            {
                /* Meglio sarebbe trovare il giocatore con la più alta keeping */
                int nkNumber = - 1;
                int nkSt = - 1;
                for (int j = 1; j <= NumPlayers; j++)
                {
                    if (getPlayer(j).Keeping > nkSt && (((ESMSPlayer) getPlayer(j)).Status == ESMSPlayer.PLAYING || ((ESMSPlayer) getPlayer(j)).Status == ESMSPlayer.SUBSTITUTION) && !getPosition(j).Equals("GK"))
                    {
                        nkSt = getPlayer(j).Keeping;
                        nkNumber = j;
                    }
                }
				
                return nkNumber;
            }
            return - 1;
        }
		
        public virtual void  changeTactic(string newTactic)
        {
            this._tactic = (Tactic) Tactic._Tactics[newTactic];
        }

        public virtual int randomInjury(double oppAggression)
        {
            int injured = 0;
            if (CSEsMS.ESMS.ESMS.getThresold((int) ((1500 + oppAggression) / 50)))
            {
                ++_injuries;
                do 
                {
                    injured = CSEsMS.ESMS.ESMS.Random.Next(NumPlayers + 1);
                }
                while (injured == 0 || ((ESMSPlayer) getPlayer(injured)).Status != ESMSPlayer.PLAYING);
            }
            return injured;
        }
		
        public virtual void  changePosition(int player, string role)
        {
            if (!getPosition(player).Equals("GK") && ((ESMSPlayer) getPlayer(player)).Status == ESMSPlayer.PLAYING)
            {
                if (!getPosition(player).Equals(role))
                {
                    /*WriteChangePosition*/
                    /* Potrebbe occuparsene il tipo dall'esterno se ritorno un true o false*/
					
                    setPosition(player, role);
                }
            }
        }
		
        /// <summary>Method used to clear counter of yellowCarded, redCarded and injured players. </summary>
        public virtual void  clean()
        {
            this._yellowCarded = null;
            this._redCarded = null;
            this._injured = null;
        }
		
        /* Has raised an error */
        public virtual void  substitutePlayer(int out_Renamed, int in_Renamed, string newrole)
        {
            int maxSubstitutions = Config.getConfig().Substitutions;
			
            if (((ESMSPlayer) getPlayer(out_Renamed)).Status == ESMSPlayer.PLAYING && ((ESMSPlayer) getPlayer(in_Renamed)).Status == ESMSPlayer.SUBSTITUTION && this._substitutions < maxSubstitutions)
            {
                ((ESMSPlayer) getPlayer(out_Renamed)).Status = ESMSPlayer.UNAVAILABLE;
                ((ESMSPlayer) getPlayer(in_Renamed)).Status = ESMSPlayer.PLAYING;
				
                if (getPosition(out_Renamed).Equals("GK"))
                    setPosition(in_Renamed, "GK");
                else
                    setPosition(in_Renamed, newrole);
				
                _substitutions++;
            }
        }
		
        public virtual void  calcAbility(int score, int oppScore)
        {
            //Add simple bonuses
            for (int i = 1; i <= NumPlayers; i++)
            {
                ESMSPlayer p = ((ESMSPlayer) getPlayer(i));
                p.esmsShootingAbility += Config.getConfig().AbGoal * p.getGoals();
                p.esmsPassingAbility += Config.getConfig().AbAssist * p.getAssists();
                p.esmsTacklingAbility += Config.getConfig().AbKeyTackling * p.getTackles();
                p.esmsPassingAbility += Config.getConfig().AbKeyPasses * p.getKeyPasses();
                p.esmsShootingAbility += Config.getConfig().AbShotsOn * p.ShotsOn;
                p.esmsShootingAbility += Config.getConfig().AbShotsOff * p.ShotsOff;
                p.esmsKeepingAbility += Config.getConfig().AbSaves * p.getSaves();
                p.esmsKeepingAbility += Config.getConfig().AbConceded * p.Conceded;
				
                if (getPosition(i).Equals("GK"))
                {
                    p.esmsKeepingAbility += Config.getConfig().AbYellow * p.YellowCards;
                    p.esmsKeepingAbility += Config.getConfig().AbRed * p.RedCard;
                }
                else
                {
                    p.esmsShootingAbility += Config.getConfig().AbYellow * p.YellowCards;
                    p.esmsShootingAbility += Config.getConfig().AbRed * p.RedCard;
                    p.esmsTacklingAbility += Config.getConfig().AbYellow * p.YellowCards;
                    p.esmsTacklingAbility += Config.getConfig().AbRed * p.RedCard;
                    p.esmsPassingAbility += Config.getConfig().AbYellow * p.YellowCards;
                    p.esmsPassingAbility += Config.getConfig().AbRed * p.RedCard;
                }
            }
            //Add Random Victory Bonuses
            if (score > oppScore)
            {
                int num = 0, n = 0;
                ESMSPlayer p;
                /* Only two player get the ability increase (this explains why
				using a single num variable) */
                for (int k = 1; k <= 2; k++)
                {
                    do 
                    {
                        n = CSEsMS.ESMS.ESMS.Random.Next(NumPlayers) + 1;
                        p = ((ESMSPlayer) getPlayer(n));
                    }
                    while (p.Minutes == 0 || n == num);
                    if (getPosition(n).Equals("GK"))
                    {
                        p.esmsKeepingAbility += Config.getConfig().AbVictoryRandom;
                    }
                    else
                    {
                        p.esmsShootingAbility += Config.getConfig().AbVictoryRandom;
                        p.esmsTacklingAbility += Config.getConfig().AbVictoryRandom;
                        p.esmsPassingAbility += Config.getConfig().AbVictoryRandom;
                    }
					
                    num = n;
                }
            }
                //Add Random Defeat Maluses
            else if (score < oppScore)
            {
                int num = 0, n = 0;
                ESMSPlayer p;
				
                /* Only two player get the ability decrease (this explains why
				using a single num variable) */
                for (int k = 1; k <= 2; k++)
                {
                    do 
                    {
                        n = CSEsMS.ESMS.ESMS.Random.Next(NumPlayers) + 1;
                        p = ((ESMSPlayer) getPlayer(n));
                    }
                    while (p.Minutes == 0 || n == num);
                    if (getPosition(n).Equals("GK"))
                    {
                        p.esmsKeepingAbility += Config.getConfig().AbDefeatRandom;
                    }
                    else
                    {
                        p.esmsShootingAbility += Config.getConfig().AbDefeatRandom;
                        p.esmsTacklingAbility += Config.getConfig().AbDefeatRandom;
                        p.esmsPassingAbility += Config.getConfig().AbDefeatRandom;
                    }
					
                    num = n;
                }
            }
            //Add Clean Sheet Bonuses (if oppScore==0)
            if (oppScore == 0)
            {
                //int n = 0;
                for (int i = 1; i <= NumPlayers; i++)
                {
                    ESMSPlayer p = ((ESMSPlayer) getPlayer(i));
                    if (getPosition(i).Equals("GK") && p.Minutes > 46)
                    {
                        p.esmsKeepingAbility += Config.getConfig().AbCleanSheet;
                    }
                        /* It shouldn't be better to keep the condition of >46 
					also for defenders? */
                    else if (getPosition(i).Equals("DF") && p.Minutes > 0)
                    {
                        p.esmsTacklingAbility += Config.getConfig().AbCleanSheet;
                    }
                }
            }
        }
		
        public virtual void  checkConditionals(ESMSTeam opponent, int minute)
        {
            bool isTrue;
            Conditional[] cond = Conditionals;
            for (int i = 0; i < cond.Length; i++)
            {
                isTrue = true;
                for (int condition = 0; condition < cond[i].Conditions.Length; condition++)
                {
                    if (!((ESMSCondition) (cond[i].Conditions[condition])).isTrue(this, opponent, minute))
                        isTrue = false;
                }
                if (isTrue)
                {
                    try
                    {
                        ((ESMSAction) cond[i].Action).execute(this);
                    }
                    catch (System.Exception err)
                    {
                    }
                }
            }
        }
		
        public virtual int electBestSub(string pos)
        {
            int player = - 1;
            int level = - 1;
            /* Here calculus are made using nominal skills but probably it's better
			* to use actual match skills */
            for (int i = 1; i <= NumPlayers; i++)
            {
                if (getPosition(i).Equals(pos) && ((ESMSPlayer) getPlayer(i)).Status == ESMSPlayer.SUBSTITUTION)
                {
                    if (pos.Equals("GK") && getPlayer(i).Keeping > level)
                    {
                        level = getPlayer(i).Keeping;
                        player = i;
                    }
                    if (pos.Equals("DF") && getPlayer(i).Tackling > level)
                    {
                        level = getPlayer(i).Tackling;
                        player = i;
                    }
                    else if (pos.Equals("MF") && getPlayer(i).Passing > level)
                    {
                        level = getPlayer(i).Passing;
                        player = i;
                    }
                    else if (pos.Equals("FW") && getPlayer(i).Shooting > level)
                    {
                        level = getPlayer(i).Shooting;
                        player = i;
                    }
                }
            }
            if (player == - 1)
            {
                for (int i = 1; i <= NumPlayers; i++)
                {
                    if (((ESMSPlayer) getPlayer(i)).Status == ESMSPlayer.SUBSTITUTION)
                    {
                        if (pos.Equals("GK") && getPlayer(i).Keeping > level)
                        {
                            level = getPlayer(i).Keeping;
                            player = i;
                        }
                        if (pos.Equals("DF") && getPlayer(i).Tackling > level)
                        {
                            level = getPlayer(i).Tackling;
                            player = i;
                        }
                        else if (pos.Equals("MF") && getPlayer(i).Passing > level)
                        {
                            level = getPlayer(i).Passing;
                            player = i;
                        }
                        else if (pos.Equals("FW") && getPlayer(i).Shooting > level)
                        {
                            level = getPlayer(i).Shooting;
                            player = i;
                        }
                    }
                }
            }
			
            return player;
        }
		
        public virtual int electWorsePlayer(string pos)
        {
            int player = - 1;
            int level = 1000;
            /* Here calculus are made using nominal skills but probably it's better
			* to use actual match skills */
            for (int i = 1; i <= NumPlayers; i++)
            {
                if (getPosition(i).Equals(pos) && ((ESMSPlayer) getPlayer(i)).Status == ESMSPlayer.PLAYING)
                {
                    if (pos.Equals("GK") && getPlayer(i).Tackling < level)
                    {
                        level = getPlayer(i).Keeping;
                        player = i;
                    }
                    if (pos.Equals("DF") && getPlayer(i).Tackling < level)
                    {
                        level = getPlayer(i).Tackling;
                        player = i;
                    }
                    else if (pos.Equals("MF") && getPlayer(i).Passing < level)
                    {
                        level = getPlayer(i).Passing;
                        player = i;
                    }
                    else if (pos.Equals("FW") && getPlayer(i).Shooting < level)
                    {
                        level = getPlayer(i).Shooting;
                        player = i;
                    }
                }
            }
            return player;
        }
    }
}