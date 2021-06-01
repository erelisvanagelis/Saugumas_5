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

namespace Server
{
    public partial class UserControl1 : UserControl
    {
        protected Package package;

        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(Package package)
        {
            InitializeComponent();

            this.package = package;
            nTextBox.Text = package.N.ToString();
            eTextBox.Text = package.E.ToString();
            xTextBox.Text = package.X.ToString();
            sTextBox.Text = package.S.ToString();
            messageTextBox.Text = package.Message.ToString();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            package.X = BigInteger.Parse(xTextBox.Text);
            package.S = BigInteger.Parse(sTextBox.Text);
        }
    }
}
