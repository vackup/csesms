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
* Leader.java
*
* Created on 2 gennaio 2004, 21.21
*/
using System;
using Leaders;

/// <summary> </summary>
/// <author>   Angelo Scotto
/// </author>
public class leaders
{
	
	/// <summary>Creates a new instance of Leader </summary>
	public leaders()
	{
	}
	
	/// <param name="args">the command line arguments
	/// </param>
	[STAThread]
	public static void  Main(System.String[] args)
	{
		Leaders.Leaders.main(args);
	}
}