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
* PenaltyPlayer.java
*
* Created on 25 aprile 2004, 15.00
*/
using System;

namespace CSEsMS.ESMS
{
    /// <summary> A particular structure containing basic data about player shooter</summary>
    /// <author>   Angelo
    /// </author>
    class PenaltyPlayer
    {
        virtual public int Number
        {
            get
            {
                return number;
            }
			
        }
        virtual public string Name
        {
            get
            {
                return name;
            }
			
        }
        virtual public int Shooting
        {
            get
            {
                return shooting;
            }
			
        }
		
        private string name;
        private int shooting;
        private int number;
		
        /// <summary>Creates a new instance of PenaltyPlayer </summary>
        public PenaltyPlayer(string name, int number, int shooting)
        {
            this.name = name;
            this.number = number;
            this.shooting = shooting;
        }
    }
}