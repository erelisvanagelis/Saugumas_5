using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Receiver receiver = new Receiver(AddPackages, ShowMessages);
            Task task = Task.Run(() => receiver.Start());

        }

        public void AddPackages(Package package)
        {
            Invoke((MethodInvoker)(() =>
            {
                flowLayoutPanel1.Controls.Add(new UserControl1(package, RemovePackage));
            }));
        }

        public void ShowMessages(string message)
        {
            Invoke((MethodInvoker)(() =>
            {
                MessageBox.Show(message);
            }));
        }

        public void RemovePackage(UserControl1 userControl1)
        {
            Invoke((MethodInvoker)(() =>
            {
                flowLayoutPanel1.Controls.Remove(userControl1);
            }));
        }
    }
}
