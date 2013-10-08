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

namespace CSEsMS.Engine
{
    /// <summary> </summary>
    /// <author>   Angelo Scotto
    /// </author>
    public class Version
    {
        public static string Features
        {
            get
            {
                return "Up to date with ESMS v" + ported;
            }
			
        }
        public static System.Globalization.GregorianCalendar LastBuild
        {
            get
            {
                return lastBuild;
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
        public static string Name
        {
            get
            {
                return programName;
            }
			
        }
        public static string Author
        {
            get
            {
                return authorString;
            }
			
        }
        public static string Codename
        {
            get
            {
                return codename;
            }
			
        }
        public static string FullVersion
        {
            get
            {
                //UPGRADE_ISSUE: Constructor 'java.text.SimpleDateFormat.SimpleDateFormat' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javatextSimpleDateFormat'"
                //UPGRADE_TODO: The equivalent in .NET for method 'java.util.Calendar.getTime' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
                //return Name + " Version " + getVersion() + " - " + Codename + " (" + SupportClass.FormatDateTime(new SimpleDateFormat("dd MMM yyyy"), SupportClass.CalendarManager.manager.GetDateTime(lastBuild)) + ")\r\n" + Features + "\r\n" + Author;
                return Name + " Version " + getVersion() + " - " + Codename + " (" + DateTime.Today + ")\r\n" + Features + "\r\n" + Author;
            }
			
        }
		
        //UPGRADE_NOTE: The initialization of  'lastBuild' was moved to static method 'Engine.Version'. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1005'"
        private static System.Globalization.GregorianCalendar lastBuild;
		
        private static string authorString = "Angelo Scotto (scotto_a@hotmail.com)";
        private static string programName = "JEsMS Engine";
        private static int major = 1;
        private static int minor = 0;
        private static int build = 0;
        private static string codename = "Romeo";
		
        private static string ported = "2.7.2";
		
        public static string getVersion()
        {
            return major + "." + minor + "." + build;
        }
        static Version()
        {
            System.Globalization.GregorianCalendar temp_calendar;
            temp_calendar = new System.Globalization.GregorianCalendar();
            SupportClass.CalendarManager.manager.Set(temp_calendar, 2006, 0, 7);
            lastBuild = temp_calendar;
        }
    }
}