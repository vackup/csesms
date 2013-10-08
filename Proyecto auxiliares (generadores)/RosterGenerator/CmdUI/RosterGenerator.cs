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
* RosterGenerator.java
*
* Created on 4 ottobre 2004, 22.37
*/
using System;
namespace RosterGenerator
{
	
	/// <summary> </summary>
	/// <author>   RemoteDesktop
	/// </author>
	public class RosterGenerator
	{
		
		private const int MAX_TRIES = 20;
		
		private static System.String CommandName = "rgen";
		
		private int playerNumber;
		
		private Engine.Player[] players;
		
		public static Engine.Player GeneratePlayer(GeneratorConfig c)
		{
			try
			{
				int keeping;
				int tackling;
				int passing;
				int shooting;
				int aggression;
				int age;
				int counter = 0;
				do 
				{
					keeping = c.generate(RosterGenerator.GeneratorConfig.KEEPING);
					tackling = c.generate(RosterGenerator.GeneratorConfig.TACKLING);
					passing = c.generate(RosterGenerator.GeneratorConfig.PASSING);
					shooting = c.generate(RosterGenerator.GeneratorConfig.SHOOTING);
					aggression = c.generate(RosterGenerator.GeneratorConfig.AGGRESSION);
					age = c.generate(RosterGenerator.GeneratorConfig.AGE);
					counter++;
				}
				while (!c.isValid(keeping + tackling + passing + shooting + aggression) && counter < MAX_TRIES);
				
				if (!c.isValid(keeping + tackling + passing + shooting + aggression))
					throw new TooMuchDiscardsException("Exception");
				Engine.Player p = new Engine.Player("Unnamed", "???", age, keeping, tackling, passing, shooting, aggression, 300, 300, 300, 300, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				
				return p;
			}
			catch (System.Exception err)
			{
				SupportClass.WriteStackTrace(err, Console.Error);
				System.Environment.Exit(- 1);
				return null;
			}
		}
		
		
		public static void  help()
		{
			System.Console.Out.WriteLine(Version.FullVersion);
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Usage: java " + CommandName + " [-h] -n:<N> -f:<configfile>");
			System.Console.Out.WriteLine();
			System.Console.Out.WriteLine("Where:");
			System.Console.Out.WriteLine("h: shows this help screen");
			System.Console.Out.WriteLine("-n:<N> set the numbers of players to generate.");
			System.Console.Out.WriteLine("-f:<configfile> indicate the file containing values used to generate players");
			System.Environment.Exit(0);
		}
		
		/// <summary>Creates a new instance of RosterGenerator </summary>
		public RosterGenerator(int playersToGenerate, System.String config)
		{
			GeneratorConfig c = new GeneratorConfig(config);
			
			this.playerNumber = playersToGenerate;
			
			players = new Engine.Player[playerNumber];
			//java.util.Random rnd = new java.util.Random();
			
			int counter = 0;
			for (int i = 0; i < playerNumber; i++)
			{
				players[counter++] = GeneratePlayer(c);
			}
		}
		
		public virtual void  writeRoster(System.String filename)
		{
			/* TODO Check if Roster has been initialized */
			//UPGRADE_TODO: Constructor 'java.io.OutputStreamWriter.OutputStreamWriter' was converted to 'System.IO.StreamWriter.StreamWriter' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioOutputStreamWriterOutputStreamWriter_javaioOutputStream_javalangString'"
			//UPGRADE_TODO: Constructor 'java.io.FileOutputStream.FileOutputStream' was converted to 'System.IO.FileStream.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioFileOutputStreamFileOutputStream_javalangString'"
			System.IO.StreamWriter w = new System.IO.StreamWriter(new System.IO.FileStream(filename, System.IO.FileMode.Create), System.Text.Encoding.GetEncoding("iso-8859-1"));
			w.Write("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
			w.Write("<Roster>");
			for (int i = 0; i < players.Length; i++)
			{
				players[i].WriteRoster(w);
			}
			w.Write("</Roster>");
			w.Flush();
			w.Close();
		}
		/// <param name="args">the command line arguments
		/// </param>
		public static void  main(System.String[] args)
		{
			System.Console.Out.WriteLine(Version.FullVersion);
			
			int numberOfPlayers = - 1;
			System.String configfile;
			
			configfile = null;
			
			for (int i = 0; i < args.Length; i++)
			{
				
				/* Parse parameter */
				if (args[i].ToLower().Equals("-h"))
					help();
				else if (args[i].ToLower().StartsWith("-n:"))
				{
					numberOfPlayers = System.Int32.Parse(args[i].Substring(3));
				}
				else if (args[i].ToLower().StartsWith("-f:"))
				{
					configfile = args[i].Substring(3);
				}
				else if (!args[i].StartsWith("-"))
				{
				}
				else
				{
					System.Console.Out.WriteLine("Illegal parameter passed to Roster Generator : use 'java " + CommandName + " -h' for help");
					System.Environment.Exit(- 1);
				}
			}
			if (numberOfPlayers == - 1)
			{
				System.Console.Out.WriteLine("You must indicate number of players to generate");
				System.Environment.Exit(- 1);
			}
			RosterGenerator rg = new RosterGenerator(numberOfPlayers, configfile);
			try
			{
				rg.writeRoster("players.xml");
			}
			catch (System.Exception err)
			{
			}
		}
	}
}