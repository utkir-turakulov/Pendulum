using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Маятник
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Pen pen = new Pen(Color.Black, 5);
            double radius = 45;
            Graphics graphics = this.CreateGraphics();

            int y0 = Size.Height / 2;
            int x0 = Size.Width / 2;

            int counter = 100;
            double x, y;
            double angle = 3;
            double speed = 0.3;

            while (counter > 0)
            { 
                counter--;
                x = x0 + radius * Math.Cos(angle * speed);
                y = y0 + radius * Math.Sin(angle * speed);
                graphics.DrawLine(pen, new Point(x0, y0), new Point((int)x, (int)y));
                Thread.Sleep(100);
                angle++;
                Refresh();
            }
        }
    }
}
