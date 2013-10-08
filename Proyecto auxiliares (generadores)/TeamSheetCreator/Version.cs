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
* Version.java
*
* Created on 25 dicembre 2003, 21.55
*/
using System;
namespace TeamSheetCreator
{
	
	/// <summary> </summary>
	/// <author>   Angelo Scotto
	/// </author>
	public class Version
	{
		public static System.String Site
		{
			get
			{
				return website;
			}
			
		}
		public static System.String Features
		{
			get
			{
				return "Up to date with ESMS v" + ported;
			}
			
		}
		public static int Major
		{
			get
			{
				return major;
			}
			
		}
		public static int Minor
		{
			get
			{
				return minor;
			}
			
		}
		public static int Build
		{
			get
			{
				return build;
			}
			
		}
		public static System.String Name
		{
			get
			{
				return programName;
			}
			
		}
		public static System.String Author
		{
			get
			{
				return authorString;
			}
			
		}
		public static System.String Codename
		{
			get
			{
				return codename;
			}
			
		}
		public static System.String BuildDate
		{
			get
			{
				//UPGRADE_ISSUE: Constructor 'java.text.SimpleDateFormat.SimpleDateFormat' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javatextSimpleDateFormat'"
				//UPGRADE_TODO: The equivalent in .NET for method 'java.util.Calendar.getTime' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
				return SupportClass.FormatDateTime(new SimpleDateFormat("dd MMM yyyy"), SupportClass.CalendarManager.manager.GetDateTime(lastBuild));
			}
			
		}
		public static System.String FullVersion
		{
			get
			{
				//UPGRADE_ISSUE: Constructor 'java.text.SimpleDateFormat.SimpleDateFormat' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javatextSimpleDateFormat'"
				//UPGRADE_TODO: The equivalent in .NET for method 'java.util.Calendar.getTime' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
				return Name + " Version " + getVersion() + " - " + Codename + " (" + SupportClass.FormatDateTime(new SimpleDateFormat("dd MMM yyyy"), SupportClass.CalendarManager.manager.GetDateTime(lastBuild)) + ")\r\n" + Site + "\r\n" + Features + "\r\n" + Author;
			}
			
		}
		
		//UPGRADE_NOTE: The initialization of  'lastBuild' was moved to static method 'TeamSheetCreator.Version'. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1005'"
		private static System.Globalization.GregorianCalendar lastBuild;
		
		private static System.String authorString = "Angelo Scotto (scotto_a@hotmail.com)";
		private static System.String programName = "JEsMS Teamsheet Creator";
		private static System.String shortName = "TeamSheetCreator";
		
		private static System.String website = "http://asiloleague.altervista.org/JEsMS";
		private static int major = 1;
		private static int minor = 0;
		private static int build = 1;
		private static System.String revision = "424:425";
		
		private static System.String codename = "Romeo";
		
		private static System.String ported = "2.6";
		
		public static System.String getVersion()
		{
			return major + "." + minor + "." + build + "." + revision;
		}
		static Version()
		{
			System.Globalization.GregorianCalendar temp_calendar;
			temp_calendar = new System.Globalization.GregorianCalendar();
			SupportClass.CalendarManager.manager.Set(temp_calendar, 2004, 9, 16);
			lastBuild = temp_calendar;
		}
	}
}