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
        public delegate void RemoveControl(UserControl1 userControl1);
        RemoveControl removeControl;

        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(Package package, RemoveControl removeControl)
        {
            InitializeComponent();

            this.package = package;
            nTextBox.Text = package.N.ToString();
            eTextBox.Text = package.E.ToString();
            xTextBox.Text = package.X.ToString();
            sTextBox.Text = package.S.ToString();
            messageTextBox.Text = package.Message.ToString();
            this.removeControl = removeControl;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            package.X = BigInteger.Parse(xTextBox.Text);
            package.S = BigInteger.Parse(sTextBox.Text);

            removeControl(this);
        }
    }
}
