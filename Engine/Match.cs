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
* Match.java
*
* Created on 24 agosto 2004, 11.18
*/
using System;

namespace CSEsMS.Engine
{
    /// <summary> </summary>
    /// <author>   Angelo Scotto
    /// </author>
    public class Match
    {
        virtual public long Seed
        {
            get
            {
                return seed;
            }
			
            set
            {
                this.seed = value;
            }
			
        }
        virtual public int HomeScore
        {
            get
            {
                return homeScore;
            }
			
        }
        virtual public int AwayScore
        {
            get
            {
                return awayScore;
            }
			
        }
        virtual public string HomeTeam
        {
            get
            {
                return homeAbbr;
            }
			
        }
        virtual public string AwayTeam
        {
            get
            {
                return awayAbbr;
            }
			
        }
        virtual public string Id
        {
            get
            {
                return this.id;
            }
			
            set
            {
                this.id = value;
            }
			
        }
		
        private string id;
        private string homeAbbr;
        private string awayAbbr;
		
        private int homeScore;
        private int awayScore;
        private bool played = false;
		
        // Notice, -1 must be a non valid value, when generating a seed for a match
        // i need to take care of -1 avoidance (hint: regenerate)
        private long seed = - 1;
		
        public virtual bool hasBeenPlayed()
        {
            return played;
        }
		
        public virtual void  printMatch()
        {
            System.Console.Out.WriteLine(homeAbbr + " - " + awayAbbr);
        }
        /// <summary>Creates a new instance of Match </summary>
        public Match(string id, string homeAbbr, string awayAbbr)
        {
            this.id = id;
            this.played = false;
            this.homeAbbr = homeAbbr;
            this.awayAbbr = awayAbbr;
        }
		
        public Match()
        {
        }
		
        public Match(string id, string homeAbbr, int homeScore, string awayAbbr, int awayScore)
        {
            this.id = id;
            this.played = true;
            this.homeAbbr = homeAbbr;
            this.awayAbbr = awayAbbr;
            this.homeScore = homeScore;
            this.awayScore = awayScore;
        }
		
        public virtual void  switchSides()
        {
            string temp = homeAbbr;
            homeAbbr = awayAbbr;
            awayAbbr = temp;
        }
		
        public virtual void  setScore(int homeScore, int awayScore)
        {
            this.homeScore = homeScore;
            this.awayScore = awayScore;
            this.played = true;
        }
    }
}