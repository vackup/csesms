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
using IEvent = ESMS.NewCore.IEvent;
using Player = Engine.Player;
namespace ESMS.NewCore.Events
{
	
	/// <summary> </summary>
	/// <author>  a.scotto
	/// </author>
	public class StartMatchEvent : IEvent
	{
		/// <summary>Match is starting therefore minute is 0 </summary>
		virtual public int EventMinute
		{
			get
			{
				return 0;
			}
			
		}
		virtual public Player Subject
		{
			get
			{
				return null;
			}
			
		}
		virtual public Player Object
		{
			get
			{
				return null;
			}
			
		}
		virtual public System.String Type
		{
			/* TODO Maybe an enum ? */
			
			get
			{
				return "START_MATCH";
			}
			
		}
		
		public StartMatchEvent()
		{
		}
		
		public virtual System.Xml.XmlElement ToXmlElement()
		{
			return null;
		}
	}
}