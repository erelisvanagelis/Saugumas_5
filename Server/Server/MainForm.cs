﻿using System;
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
            Receiver receiver = new Receiver(UpdatePackages, ShowMessages);
            Task task = Task.Run(() => receiver.Start());

        }

        public void UpdatePackages(Package package)
        {
            flowLayoutPanel1.Invoke((MethodInvoker)(() =>
            {
                flowLayoutPanel1.Controls.Add(new UserControl1(package));
            }));
        }

        public void ShowMessages(string message)
        {
            MessageBox.Show(message);
        }
    }
}
