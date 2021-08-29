/* Program name: 	    <<Pacman>>
   Project file name:   Pacman_SenLi
   Author:		       <<Sen Li>>
   Date:	            16/11/2018
   Language:		    C#
   Platform:		    Microsoft Visual Studio 2017
   Purpose:		        To create a pacman class, and initialize it.
   Description:		    To create a pacman class, which hold Draw, Move, HitWall and EatKibble methods,
                        this class is to create a maze object.
   Known Bugs:		    Not clear.
   Additional Features: Not claer.
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_SenLi
{
    public class Pacman : Character
    {
        //field, private data member

        private Point position;
        private Direction direction;
        private Boolean mouseOpen;
        private Image image1;
        
     

        //constructer, used to assign initial value.
        public Pacman(Bitmap image, Bitmap image1, Maze maze, Point position)
            : base(image, maze)
        {
            this.image1 = image1;
            mouseOpen = true;
            direction = Direction.Right;
            this.position = position;  
        }

        //method
        public override void Draw()
        {
            switch (direction)
            {
                case Direction.Up:
                    if (mouseOpen)
                    {
                        maze.Rows[position.Y].Cells[position.X].Value = Properties.Resources.pacman1up;
                    }
                    else
                    {
                        maze.Rows[position.Y].Cells[position.X].Value = Properties.Resources.pacman2up;
                    }
                    
                    break;
                case Direction.Down:
                    if (mouseOpen)
                    {
                        maze.Rows[position.Y].Cells[position.X].Value = Properties.Resources.pacman1down;
                    }
                    else
                    {
                        maze.Rows[position.Y].Cells[position.X].Value = Properties.Resources.pacman2down;
                    }
                    break;
                case Direction.Left:
                    if (mouseOpen)
                    {
                        maze.Rows[position.Y].Cells[position.X].Value = Properties.Resources.pacman1left;
                    }
                    else
                    {
                        maze.Rows[position.Y].Cells[position.X].Value = Properties.Resources.pacman2left;
                    }
                    break;
                case Direction.Right:
                    if (mouseOpen)
                    {
                        maze.Rows[position.Y].Cells[position.X].Value = Properties.Resources.pacman1right;
                    }
                    else
                    {
                        maze.Rows[position.Y].Cells[position.X].Value = Properties.Resources.pacman2right;
                    }
                    break;
                default:
                    break;
            }
            mouseOpen = !mouseOpen;
            
        }
        //pacman move method
        public override void Move()
        {
            switch (direction)
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

        //to check whether pacman hit the wall, and return the status of the method
        public override bool HitWall()
        {
            Point nexPosition = new Point(0, 0);
            switch (direction)
            {
                case Direction.Right:
                    {
                        nexPosition = new Point(position.X + 1, position.Y);
                        break;
                    }
                case Direction.Left:
                    {
                        nexPosition = new Point(position.X - 1, position.Y);
                        break;
                    }
                case Direction.Up:
                    {
                        nexPosition = new Point(position.X, position.Y - 1);
                        break;
                    }
                case Direction.Down:
                    {
                        nexPosition = new Point(position.X, position.Y + 1);
                        break;
                    }
            }
            int index = (nexPosition.Y * 20) + nexPosition.X;
            if (maze.Map.Substring(index, 1) == "w")
            {
                return (false);
            }

            return (true);

        }

        //Pacman eat kibble method, to check the two bitmap met
        public Boolean PacmanEat()
        {
            
            DataGridViewCell nextPosition = null;
            Boolean kibbleEaten = false;
            nextPosition = maze.Rows[position.Y].Cells[position.X];
            if (nextPosition.Value == maze.Kibble)
            {
                kibbleEaten = true;
               
            }
            return (kibbleEaten);
        }

        // propertise, to pass value in different classes
        public Direction Direction { get => direction; set => direction = value; }
        public Point Position { get => position; set => position = value; }
        
    }
}
