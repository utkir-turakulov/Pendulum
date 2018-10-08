using System;
using System.Threading;
using System.Windows.Forms;

namespace Маятник
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellation;
        int startCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GraphicLogic logic = new GraphicLogic();
            if(startCount == 0)
            {
                cancellation = new CancellationTokenSource();               
                logic.Draw(this, cancellation.Token).Start();
                startCount++;
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancellation.Cancel();
            startCount = 0;
        }
    }
    }

