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
* ESMSPlayer.java
*
* Created on 27 dicembre 2003, 10.49
*/
using System;
using CSEsMS.Engine;

namespace CSEsMS.ESMS
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    public class ESMSPlayer:Player
    {
        virtual public int Status
        {
            get
            {
                return active;
            }
			
            set
            {
                if (value < - 1 || value > 2)
                    throw new System.Exception("Error while setting player status: status unknown");
                else
                    this.active = value;
            }
			
        }
        virtual public bool Injured
        {
            get
            {
                return injured;
            }
			
            set
            {
                injured = value;
            }
			
        }
        virtual public int Minutes
        {
            get
            {
                return minutes;
            }
			
        }
        virtual public int YellowCards
        {
            get
            {
                return this.esmsYellowCard;
            }
			
        }
        virtual public int ShotsOn
        {
            get
            {
                return shotsOn;
            }
			
        }
        virtual public int ShotsOff
        {
            get
            {
                return shotsOff;
            }
			
        }
        virtual public int RedCard
        {
            get
            {
                return esmsRedCard;
            }
			
        }
        virtual public int Conceded
        {
            get
            {
                return conceded;
            }
			
        }
		
        /// <summary>Horrific constructor of ESMSPlayer object: it is called directly inside the XML parser
        /// of roster file 
        /// </summary>
        public ESMSPlayer(string name, string nationality, int age, int keeping, int tackling, int passing, int shooting, int aggression, int keepingAbility, int tacklingAbility, int passingAbility, int shootingAbility, int games, int saves, int tackles, int keyPasses, int shots, int goals, int assists, int dps, int injury, int suspension):base(name, nationality, age, keeping, tackling, passing, shooting, aggression, keepingAbility, tacklingAbility, passingAbility, shootingAbility, games, saves, tackles, keyPasses, shots, goals, assists, dps, injury, suspension)
        {
        }
		
        public const int UNAVAILABLE = 0;
        public const int PLAYING = 1;
        public const int SUBSTITUTION = 2;
		
        public ESMSPlayer(Player p):base(p.Name, p.Nationality, p.Age, p.Keeping, p.Tackling, p.Passing, p.Shooting, p.getAggression(), p.getKeepingAbility(), p.getTacklingAbility(), p.getPassingAbility(), p.getShootingAbility(), p.Games, p.getSaves(), p.getTackles(), p.getKeyPasses(), p.getShots(), p.getGoals(), p.getAssists(), p.Dps, p.Injury, p.Suspension)
        {
        }
		
        public double tacklingContrib;
        public double passingContrib;
        public double shootingContrib;
        public double fatigue;
		
        private bool injured;
		
        /// <summary>This field indicates if the player is currently unavailable (0), playing (1) or
        /// available for substitution (2)
        /// </summary>
        private int active;
		
        public override void  setAggression(int value_Renamed)
        {
            this.aggression = value_Renamed;
        }
		
        public virtual void  clearYellowCards()
        {
            this.esmsYellowCard = 0;
        }
		
        public virtual void  increaseYellowCards()
        {
            this.esmsYellowCard++;
        }
		
        public virtual void  increaseRedCards()
        {
            this.esmsRedCard++;
        }
		
        public override int getShots()
        {
            return this.esmsShots;
        }
		
        public virtual void  increaseTackles()
        {
            this.esmsTackles++;
        }
		
        public virtual void  increaseShots()
        {
            this.esmsShots++;
        }
		
        public virtual void  increaseShotsOn()
        {
            this.shotsOn++;
        }
        public virtual void  increaseShotsOff()
        {
            this.shotsOff++;
        }
        public virtual void  increaseFouls()
        {
            this.esmsFouls++;
        }
		
        public virtual void  increasePasses()
        {
            this.esmsKeyPasses++;
        }
        public virtual void  increaseAssists()
        {
            this.esmsAssists++;
        }
		
        /*This should increase goals for this match only*/
        public virtual void  increaseGoals()
        {
            this.esmsGoals++;
        }
		
        public virtual void  increaseConceded()
        {
            this.conceded++;
        }
		
        public virtual void  increaseSaves()
        {
            this.esmsSaves++;
        }
		
        public virtual void  initPlayer()
        {
            this.tacklingContrib = 0;
            this.passingContrib = 0;
            this.shootingContrib = 0;
			
            this.fatigue = 1.0;
            this.esmsYellowCard = 0;
            this.esmsRedCard = 0;
            this.injured = false;
            this.esmsTacklingAbility = 0;
            this.esmsPassingAbility = 0;
            this.esmsShootingAbility = 0;
            this.esmsKeepingAbility = 0;
			
            this.minutes = 0;
            this.shots = 0;
            this.goals = 0;
            this.saves = 0;
            this.assists = 0;
            this.tackles = 0;
            this.keyPasses = 0;
            this.esmsFouls = 0;
            this.conceded = 0;
            this.shotsOn = 0;
            this.shotsOff = 0;
        }
        /*    public int getAggression()
		{
		return this.aggression;
		}*/
		
        public virtual void  increaseMinutes()
        {
            minutes++;
        }
		
        public override int getGoals()
        {
            return esmsGoals;
        }
		
        public override int getAssists()
        {
            return esmsAssists;
        }
        public override int getTackles()
        {
            return esmsTackles;
        }
        public override int getKeyPasses()
        {
            return esmsKeyPasses;
        }
		
        public override int getSaves()
        {
            return esmsSaves;
        }
		
        public override int getKeepingAbility()
        {
            return this.esmsKeepingAbility;
        }
		
        public override int getTacklingAbility()
        {
            return this.esmsTacklingAbility;
        }
		
        public override int getPassingAbility()
        {
            return this.esmsPassingAbility;
        }
		
        public override int getShootingAbility()
        {
            return this.esmsShootingAbility;
        }
		
        /*---------- Variables used by ESMS for final stats ----------*/
        private int minutes;
        private int esmsShots;
        private int esmsGoals;
        private int esmsSaves;
        private int esmsTackles;
        /*Manca increaseKeyPasses, possibile? */
        private int esmsKeyPasses;
        private int esmsAssists;
        private int esmsFouls;
        private int esmsYellowCard;
        private int esmsRedCard;
		
        private int shotsOn, shotsOff, conceded;
        public int esmsKeepingAbility;
        public int esmsTacklingAbility;
        public int esmsPassingAbility;
        public int esmsShootingAbility;
    }
}