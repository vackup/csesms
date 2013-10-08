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
* FixturesParser.java
*
* Created on 10 ottobre 2004, 20.07
*/
using System;
using Engine;
namespace League
{
	
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class FixturesParser
	{
		virtual public Engine.Match[] Matches
		{
			get
			{
				int counter = 0;
				Engine.Match[] answer = new Engine.Match[weeks.Length * weeks[0].Matches.Length];
				for (int i = 0; i < weeks.Length; i++)
				{
					Engine.Match[] w = weeks[i].Matches;
					for (int j = 0; j < w.Length; j++)
					{
						answer[counter++] = w[j];
					}
				}
				return answer;
			}
			
		}
		
		internal Week[] weeks;
		
		/// <summary>Creates a new instance of FixturesParser </summary>
		public FixturesParser(System.String filename)
		{
			Fixtures f = new Fixtures(filename);
			weeks = f.Weeks;
		}
	}
}