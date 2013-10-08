/*
* PunkBuster.java
*
* Created on 12 marzo 2005, 11.07
*/
using System;
namespace Fixtures
{
	
	/// <summary> A simple class used to add a seed, if necessary, to each match of a competition.
	/// 
	/// </summary>
	/// <author>   Angelo
	/// </author>
	public class PunkBuster
	{
		
		private static System.Random r = new System.Random();
		
		public static void  GenerateSeeds(IGenerator competition)
		{
			// I need to be able to retrieve match set from IGenerator object.
			Engine.Match[] m = competition.Matches;
			
			for (int i = 0; i < m.Length; i++)
			{
				
				long seed;
				do 
				{
					//UPGRADE_TODO: Method 'java.util.Random.nextLong' was converted to 'SupportClass.NextLong' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilRandomnextLong'"
					seed = SupportClass.NextLong(r);
				}
				while (seed == - 1);
				// Match object must have a method to set a new seed.
				m[i].Seed = seed;
			}
		}
	}
}