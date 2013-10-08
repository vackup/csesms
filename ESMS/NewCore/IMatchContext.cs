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
using System;
using Engine;
using System.Collections.Generic;
namespace ESMS.NewCore
{
	
	
	/// <summary> A MatchContext object contains all data needed by other CoreObject to generate a full match.</summary>
	public interface IMatchContext
	{
		/// <summary>Export current Rosters </summary>
		Roster HomeRoster
		{
			get;
			
		}
		Roster AwayRoster
		{
			get;
			
		}
		/// <summary>Export current TeamSheets </summary>
		TeamSheet HomeTeamSheet
		{
			get;
			
		}
		TeamSheet AwayTeamSheet
		{
			get;
			
		}
		/// <summary>Export current minute </summary>
		int CurrentMinute
		{
			get;
			
		}
		/// <summary>Export Current Scores </summary>
		int HomeScore
		{
			get;
			
		}
		int AwayScore
		{
			get;
			
			/// <summary>TODO Move to a typed collection </summary>
			
		}
	}
	//UPGRADE_ISSUE: The following fragment of code could not be parsed and was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1156'"
	public List < Player > getYellowCarded();
	//UPGRADE_ISSUE: The following fragment of code could not be parsed and was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1156'"
	public List < Player > getInjured();
	//UPGRADE_ISSUE: The following fragment of code could not be parsed and was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1156'"
	public List < Player > getRedCarded();
	
	//UPGRADE_ISSUE: The following fragment of code could not be parsed and was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1156'"
	}
}