/* Program name: 	    <<Pacman>>
   Project file name:   Pacman_SenLi
   Author:		       <<Sen Li>>
   Date:	            16/11/2018
   Language:		    C#
   Platform:		    Microsoft Visual Studio 2017
   Purpose:		        To create sub class ghouls, which hold 4 fields.
   Description:		    Ghouls class has 5 method, which make ghouls change 
                        direction randomly, and kill pacman.
   Known Bugs:		    No.
   Additional Features: May follow Pacman
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_SenLi
{
    //sub class ghouls
    public class Ghouls : Character
    {
        //fields, also called private data member.
        private Direction ghoulDirection;
        private Point position;
        private Boolean eaten;
        private Random random;
       
        // constructer, to assign initial value
        public Ghouls(Bitmap image, Maze maze, Point position, Random random)
            : base(image, maze)
        {
            this.position = position;
            ghoulDirection = Direction.Right;
            this.random = random;
            
        }

       
        

        //method, to draw ghoul
        public override void Draw()
        {
            maze.Rows[position.Y].Cells[position.X].Value = image;
        }

        public void RandomDirection()
        {
            int randDir = random.Next(4);
            switch (randDir)
            {
                case 0:
                    {
                        ghoulDirection = Direction.Right;
                        break;
                    }

                case 1:
                    {
                        ghoulDirection = Direction.Left;
                        break;
                    }

                case 2:
                    {
                        ghoulDirection = Direction.Up;
                        break;
                    }

                case 3:
                    {
                        ghoulDirection = Direction.Down;
                        break;
                    }

            }
        }

        //to change the direction of the ghoul when it is moving
        public override void Move()
        {
            switch (ghoulDirection)
            {
                case Direction.Right:
                    {
                        position = new Point(position.X + 1, position.Y);
                        break;
                    }
                case Direction.Left:
                    {
                        position = new Point(position.X - 1, position.Y);
                        break;
                    }
                case Direction.Up:
                    {
                        position = new Point(position.X, position.Y - 1);
                        break;
                    }
                case Direction.Down:
                    {
                        position = new Point(position.X, position.Y + 1);
                        break;
                    }
            }
        }

        //to chech whether the pacman hit the wall, and return the status

        public override Boolean HitWall()
        {
            Point nextPosition = position;
            switch (ghoulDirection)
            {
                case Direction.Right:
                    {
                        nextPosition = new Point(position.X + 1, position.Y);
                        break;
                    }
                case Direction.Left:
                    {
                        nextPosition = new Point(position.X - 1, position.Y);
                        break;
                    }
                case Direction.Up:
                    {
                        nextPosition = new Point(position.X, position.Y - 1);
                        break;
                    }
                case Direction.Down:
                    {
                        nextPosition = new Point(position.X, position.Y + 1);
                        break;
                    }
            }
            int index = (nextPosition.Y * 20) + nextPosition.X;
            if (maze.Map.Substring(index, 1) == "w")
            {
                return (false);
            }

            return (true);

        }
        //pacman die, and return the value to implement pacman meet ghoul
        public Boolean PacmanDie(Point pacmanPosition)
        {
            Boolean hit = false;
            if (pacmanPosition == position)
            {
                hit = true;
            }
            return (hit);
        }

        //properties, to allow other classes use the value
        public Point Position { get => position; set => position = value; }
    } 
}

