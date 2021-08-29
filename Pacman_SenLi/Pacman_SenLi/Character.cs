/* Program name: 	    <<Pacman>>
   Project file name:   Pacman_SenLi
   Author:		       <<Sen Li>>
   Date:	            16/11/2018
   Language:		    C#
   Platform:		    Microsoft Visual Studio 2017
   Purpose:		        To create a parent class character.
   Description:		    Character class has two fields, which are image and maze.
   Known Bugs:		    No.
   Additional Features: No.
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_SenLi
{
    //parent class
    public abstract class Character
    {
        //field, private data member
        protected Bitmap image;
        protected Maze maze;

      

        

        //constructer, assign initial values to the fields
        public Character(Bitmap image, Maze maze)
        {
            this.image = image;
            this.maze = maze;
            
            //this.position = position;
        }

        //method, to draw character
        public abstract void Draw();

        //method, to make character move
        public abstract void Move();

        //to check whether the character hit the wall, and return the status of character
        public abstract bool HitWall();

    }
}
