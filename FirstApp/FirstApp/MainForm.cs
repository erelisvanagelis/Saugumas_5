using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Sender - Creating package";
                Package package = new Package(textBox1.Text);
                this.Text = "Sender - Sending package";
                Sender senderBetKitoks = new Sender();
                senderBetKitoks.Send(package.ToString());
                this.Text = "Sender - Package sent";
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
