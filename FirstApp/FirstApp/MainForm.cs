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
                int q = RSATool.GetRandomPrime();
                int p = RSATool.GetRandomPrime();
                BigInteger n = RSATool.GetN(q, p);
                BigInteger phi = RSATool.GetPhi(q, p);
                BigInteger eBetKitoks = RSATool.GetE(phi);
                BigInteger d = RSATool.GetD(eBetKitoks, phi);
                BigInteger x = RSATool.GetRandom();
                BigInteger s = RSATool.GetS(x, (int)d, n);

                Package package = new Package(textBox1.Text);
                Console.WriteLine(package.ToString());

                Sender senderBetKitoks = new Sender();
                senderBetKitoks.Send(package.ToString());
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
