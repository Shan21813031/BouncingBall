using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ball
{
    /// <summary>
    /// Independent Study Task 6.6 - 6.8
    /// Author: Shan Ahmed 21813031
    /// This application displays two balls bouncing inside
    /// a display that changes colour of the box and the size of the balls
    /// </summary>
    /// 

    public partial class bouncingBall : Form
    {

        int x1 = 200, y1 = 50, size = 30;        // start position of ball and size of the ball
        int x2 = 150, y2 = 60;
        int xmove = 10, ymove = 10; // amount of movement for each tick
        int x2move = 15, y2move = 15;
        int difference = 10; // amount to increase/decrease by
        private Random generate = new Random();
        public const int MAXCOLOUR = 256;



        public bouncingBall()
        {
            InitializeComponent();
        }




        private Color randomColor()
        {
            int r, g, b;

            r = generate.Next(MAXCOLOUR);
            g = generate.Next(MAXCOLOUR);
            b = generate.Next(MAXCOLOUR);

            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// control to increase/decrease the size through the up and down key
        /// and to change the colour of the display to a random colour
        /// </summary>
        /// 

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string input;
            input = keyData.ToString();

            if (input == "Down")
            {
                size -= difference;
                return true;
            }
            if (input == "Up")
            {
                size += difference;
                return true;
            }
            if (input == "C")
            {
                displayBox.BackColor = randomColor();
            }
            return false;
        }

            private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void displayBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;      // get a graphics object

 
              // draw a red ball, size 30, at x1, y1 position
            g.FillEllipse(Brushes.Red, x1, y1, size, size);
            g.FillEllipse(Brushes.Red, x2, y2, size, size);
        }

        /// <summary>
        /// the ball moves in the opposite direction if the ball hits the bottom of 
        /// the picture box or y1 = 30 and if the ball hits the right side of the picture box
        /// or x1 = 30
        /// </summary>

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            x1 += xmove;             // add 10 to x1 and y1 positions
            y1 += ymove;

            x2 += x2move;
            y2 += y2move; 

            Refresh();              // refresh the`screen .. calling Paint() again

            if (y1 + size >= displayBox.Height || y1 + size <= 30)                    
            {
                ymove = -ymove;
            }
            if (x1 + size >= displayBox.Width || x1 + size <= 30)
            {
                xmove = -xmove;
            }

            if (y2 + size >= displayBox.Height || y2 + size <= 30)
            {
                y2move = -y2move;
            }
            if (x2 + size >= displayBox.Width || x2 + size <= 30)
            {
                x2move = -x2move;
            }


        }



        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

  
        private void btnStart_Click(object sender, EventArgs e)
        {
            animationTimer.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            animationTimer.Enabled= false;
        }

    }
}