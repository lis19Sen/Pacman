/* Program name: 	    <<Pacman>>
   Project file name:   Pacman_SenLi
   Author:		       <<Sen Li>>
   Date:	            16/11/2018
   Language:		    C#
   Platform:		    Microsoft Visual Studio 2017
   Purpose:		        To create form class, which hold 4 directions,and the value is int.
   Description:		    To use timer_tick to run the game.
   Known Bugs:		    No.
   Additional Features: No.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pacman_SenLi
{
    public partial class Form1 : Form
    {
        //constant
        private const int FORMHEIGHT = 800;
        private const int FORMWIDTH = 800;

        //declare the Maze object so it can be used throughout the form
        private Maze maze;
        private Controller controller;
        private Random random;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            // set the Properties of the form:
            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;

            // create a Bitmap object for each image you want to display
            Bitmap k = Pacman_SenLi.Properties.Resources.kibble;
            Bitmap w = Pacman_SenLi.Properties.Resources.wall;
            Bitmap b = Pacman_SenLi.Properties.Resources.blank;

            // create an instance of a Maze:
            maze = new Maze(k, w, b);

            // important, need to add the maze object to the list of controls on the form
            Controls.Add(maze);

            //initialize controller
            controller = new Controller(maze, random);
            // remember the Timer Enabled Property is set to false as a default
            timer1.Enabled = true;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            maze.Draw();
            
            controller.StartGame();
            textBox1.Text = Convert.ToString(controller.Score);
            //textBox2.Text = Convert.ToString(maze.NKibbles);
            if (controller.GameOver)
            {
                timer1.Enabled = false;
                MessageBox.Show("Game Over");
            }

        }


        //use key_down to control pacman direction
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    controller.SetPacmanDirection(Direction.Left);
                    break;
                case Keys.Right:
                    controller.SetPacmanDirection(Direction.Right);
                    break;
                case Keys.Up:
                    controller.SetPacmanDirection(Direction.Up);
                    break;
                case Keys.Down:
                    controller.SetPacmanDirection(Direction.Down);
                    break;
                default:
                    break;

                 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled == false)
            {
                button1.Text = "Play";
            }
            if (timer1.Enabled == true)
            {
                button1.Text = "Pause";
            }

        }


    }
}
