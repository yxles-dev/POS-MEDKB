using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.Timers;

namespace POS_MEDKB
{
    public partial class SplashScreen : Form
    {
        System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
        public SplashScreen()
        {
            InitializeComponent();
            aTimer.Interval = 4000;
            aTimer.Tick += aTimer_Tick;
            aTimer.Start();
        }

        private void aTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Executed");
            aTimer.Stop();
            this.Hide();
            Login form1 = new Login();
            form1.Show();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
