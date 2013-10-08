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
* fixtureFile.java
*
* Created on 27 agosto 2004, 19.58
*/
using System;
using Engine;
namespace Updater
{
	/// <summary> </summary>
	/// <author>   Angelo
	/// </author>
	public class FixtureParser
	{
		virtual public System.String CompetitionName
		{
			get
			{
				return f.CompetitionName;
			}
			
		}
		virtual public System.String[] Commentaries
		{
			get
			{
				return commentaries;
			}
			
		}
		
		internal System.String[] commentaries;
		internal Engine.Fixtures f;
		internal System.String filename;
		
		public virtual void  updateFixtures(Match[] matches)
		{
			Engine.Match[] m = f.getNextWeek().Matches;
			for (int i = 0; i < m.Length; i++)
				m[i].setScore(matches[i].HomeScore, matches[i].AwayScore);
			f.getNextWeek().Matches = m;
			try
			{
				f.writeFixtures(filename, externalUrl);
			}
			catch (System.Exception err)
			{
				System.Console.Out.WriteLine("Unable to write modified fixtures data to fixture file " + filename);
			}
		}
		
		internal System.String externalUrl = null;
		
		/// <summary>Creates a new instance of FixtureParser </summary>
		public FixtureParser(System.String filename, System.String xls)
		{
			this.externalUrl = xls;
			this.filename = filename;
			f = new Engine.Fixtures(filename);
			Engine.Week w = f.getNextWeek();
			Engine.Match[] m = w.Matches;
			commentaries = new System.String[m.Length];
			for (int i = 0; i < m.Length; i++)
			{
				commentaries[i] = Config.getConfig().getAbbreviationFromName(m[i].HomeTeam) + "_" + Config.getConfig().getAbbreviationFromName(m[i].AwayTeam) + ".xml";
			}
		}
	}
}