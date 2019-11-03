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

namespace PC_Protected_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ReceiveLoop()
        {
            while (true)
            {
                label1.Text = new Tcp_S_R.Tcp_S_R().ReceiveMessage();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(ReceiveLoop)).Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Tcp_S_R.Tcp_S_R(/*"192.168.100.2"*/).SendMessage(richTextBox1.Text);
        }
    }
}
