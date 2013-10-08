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
* Week.java
*
* Created on 24 agosto 2004, 11.18
*/
using System;

namespace CSEsMS.Engine
{
    /// <summary> </summary>
    /// <author>   Angelo
    /// </author>
    public class Week
    {
        virtual public bool Played
        {
            set
            {
                this.played = value;
            }
			
        }
        virtual public string Id
        {
            get
            {
                return this.id;
            }
			
        }
        virtual public Match[] Matches
        {
            get
            {
                return (Match[]) SupportClass.ICollectionSupport.ToArray(matches, new Match[0]);
            }
			
            set
            {
                this.played = value[0].hasBeenPlayed();
                //UPGRADE_TODO: Method 'java.util.Arrays.asList' was converted to 'System.Collections.ArrayList' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilArraysasList_javalangObject[]'"
                matches = new System.Collections.ArrayList(new System.Collections.ArrayList(value));
            }
			
        }
		
        private bool played = false;
        private System.Collections.ArrayList matches;
        private string id;
		
        public virtual bool hasBeenPlayed()
        {
            return played;
        }
		
        /// <summary>Creates a new instance of Week </summary>
        public Week(string id)
        {
            this.id = id;
            matches = new System.Collections.ArrayList();
        }
		
        // DEBUG Only
        public virtual void  printWeek()
        {
            System.Console.Out.WriteLine("Week " + id);
            for (int i = 0; i < matches.Count; i++)
            {
                ((Match) matches[i]).printMatch();
            }
        }
		
        public virtual Week copyAndSwitch(string id)
        {
            Week w = new Week(id);
            for (int i = 0; i < matches.Count; i++)
            {
                Match tc = (Match) matches[i];
                Match m = new Match("W" + id + System.Convert.ToString(i), tc.AwayTeam, tc.HomeTeam);
                w.addMatch(m);
            }
            return w;
        }
		
        public virtual void  switchSides()
        {
            for (int i = 0; i < matches.Count; i++)
            {
                ((Match) matches[i]).switchSides();
            }
        }
		
        public virtual void  addMatch(Match m)
        {
            matches.Add(m);
        }
    }
}