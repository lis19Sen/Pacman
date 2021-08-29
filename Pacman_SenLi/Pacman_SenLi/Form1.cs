using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private const int FORMHEIGHT = 800;
        private const int FORMWIDTH = 600;

        //declare the Maze object so it can be used throughout the form
        private Maze maze;

        public Form1()
        {
            InitializeComponent();

            // set the Properties of the form:
            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;

            // create a Bitmap object for each image you want to display
            Bitmap k = Pacman_SenLi.Properties.Resources.kibble;
            Bitmap w = Pacman_SenLi.Properties.Resources.wall1;
            Bitmap b = Pacman_SenLi.Properties.Resources.blank;

            // create an instance of a Maze:
            maze = new Maze(k, w, b);

            // important, need to add the maze object to the list of controls on the form
            Controls.Add(maze);
            maze.Draw();

            // remember the Timer Enabled Property is set to false as a default
            timer1.Enabled = true;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            maze.Draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
