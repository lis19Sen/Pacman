/* Program name: 	    <<Pacman>>
   Project file name:   Pacman_SenLi
   Author:		       <<Sen Li>>
   Date:	            16/11/2018
   Language:		    C#
   Platform:		    Microsoft Visual Studio 2017
   Purpose:		        To create enum class, which hold 4 directions,and the value is int.
   Description:		    To create a Direction class.
   Known Bugs:		    No.
   Additional Features: No.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_SenLi
{
    public enum Direction : byte
    {
        Up,
        Down,
        Left,
        Right,
    }
}
