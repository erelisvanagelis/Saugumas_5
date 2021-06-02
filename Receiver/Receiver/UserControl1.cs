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

namespace Receiver
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

        private void validateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(RSATool.ValidateSignature(package.S, package.E, package.N, package.X))
                {
                    validateButton.Text = "Valid";
                    validateButton.Enabled = false;
                    throw new Exception("Password is valid");
                }
                else
                {
                    validateButton.Text = "Invalid";
                    validateButton.Enabled = false;
                    throw new Exception("Password is invalid");
                }

            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
