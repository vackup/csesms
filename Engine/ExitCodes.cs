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

namespace CSEsMS.Engine
{
    /// <summary> </summary>
    /// <author>  Angelo
    /// </author>
    public class ExitCodes
    {
		
        public const int FILE_NOT_FOUND = 1;
        public const int FILE_CONVERSION_ERROR = 2;
        public const int XSL_TRANSFORMATION_ERROR = 3;
        public const int ERROR_WRITING_COMMENTARY = 4;
        public const int GENERIC_ERROR = - 1;
		
		
		
        public ExitCodes()
        {
        }
    }
}