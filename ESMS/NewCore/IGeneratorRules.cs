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
namespace ESMS.NewCore
{
	/// <summary> </summary>
	/// <author>  a.scotto
	/// </author>
	public interface IGeneratorRules
	{
		
		/// <summary>Event could be null, in some methods this has sense, anyway methods should expect this. </summary>
		
		bool isMatchConcluded(IMatchContext context, IEvent event_Renamed);
		bool isFirstHalfConcluded(IMatchContext context);
		
		bool isFoul(IMatchContext context, IEvent event_Renamed);
		bool shouldBeRedCarded(IMatchContext context, IEvent event_Renamed);
		bool shouldBeYellowCarded(IMatchContext context, IEvent event_Renamed);
		bool shouldBeInjured(IMatchContext context, IEvent event_Renamed);
		
		bool isShot(IMatchContext context, IEvent event_Renamed);
		bool isGoal(IMatchContext context, IEvent event_Renamed);
		bool isShotOut(IMatchContext context, IEvent event_Renamed);
		bool isChanceTackled(IMatchContext context, IEvent event_Renamed);
		
		bool isPenalty(IMatchContext context, IEvent event_Renamed);
	}
}