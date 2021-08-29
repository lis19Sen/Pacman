/* Program name: 	    <<Pacman>>
   Project file name:   Pacman_SenLi
   Author:		       <<Sen Li>>
   Date:	            16/11/2018
   Language:		    C#
   Platform:		    Microsoft Visual Studio 2017
   Purpose:		        To create controller class.
   Description:		    The controller class has 7 fields.
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
    public class Controller
    {
        //constant
        private const int GHOULLAN = 19;
        private const int GHOUL1X = 4;
        private const int GHOUL1Y = 7;
        private const int GHOUL2X = 9;
        private const int GHOUL2Y = 10;
        private const int GHOUL3X = 13;
        private const int GHOUL3Y = 17;
       
        
        //fields, also called private data member
        private Pacman pacman;
        private Maze maze;
        private List<Ghouls> ghouls;
        private Random random;
        private int score = 0;
        private Boolean gameOver;
        private int kibbles;

       

        //constructer, used to initial 
        public Controller(Maze maze, Random random)
        {
            this.maze = maze;
            this.random = random;
            kibbles = maze.NKibbles;
            pacman = new Pacman(Properties.Resources.pacman2right, Properties.Resources.pacman1right, maze, new Point(1, 1));
            ghouls = new List<Ghouls>();
            ghouls.Add(new Ghouls(Properties.Resources.green_ghoul, maze, new Point(GHOUL1X, GHOUL1Y), random));
            ghouls.Add(new Ghouls(Properties.Resources.red_ghoul, maze, new Point(GHOUL2X, GHOUL2Y), random));
            ghouls.Add(new Ghouls(Properties.Resources.purple_ghoul, maze, new Point(GHOUL3X, GHOUL3Y), random));
            gameOver = false;
        }

        //method, to play game
        public void StartGame()
        {
            foreach (Ghouls ghoul in ghouls)
            {
                ghoul.RandomDirection();
                if (ghoul.HitWall())
                {
                    ghoul.Move();

                }
                ghoul.Draw();
                if (ghoul.PacmanDie(pacman.Position))
                {
                    gameOver = true;
                }
            }
            pacman.Draw();
            if (pacman.HitWall())
            {
                pacman.Move();
            }
            if (pacman.PacmanEat())
            {
                maze.KibbleToBlank(pacman.Position, "b");
                score++;
                kibbles--;    
            }
            if (kibbles == 0)
            {
                gameOver = true;
            }
        }

        //to change pacman's direction by passing in a direction
        public void SetPacmanDirection(Direction direction)
        {
            pacman.Direction = direction;
        }
        //properties, to allow other classed get the value.
        public int Score { get => score; set => score = value; }
        public bool GameOver { get => gameOver; set => gameOver = value; }
    }

}
