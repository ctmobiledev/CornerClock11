using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * 
 *      CORNER CLOCK 11, a Windows 11 system tray clock alternative
 * 
 *      Version 1.0.0
 *      
 *      Charles Tatum II - charlestatumuiuc@outlook.com
 * 
 *      Runs a static digital clock in 24-hour mode in the lower right corner of
 *      a Windows 11 screen. Replacement for the removal of the digital clock when
 *      the time/date was clicked in the system tray.
 * 
 */ 

namespace CornerClock11
{
    public partial class Form1 : Form
    {

        private Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = this.lblTime.BackColor;
            this.TransparencyKey = this.lblTime.BackColor;
            lblTime.Visible = false;

            // Seed with current time
            String timeNow = DateTime.Now.ToString("HH:mm:ss");
            timeNow = lblTime.Text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Text = "CornerClock11";
            notifyIcon1.Visible = true;

            // Reposition to lower right corner above system tray
            this.Top = SystemInformation.VirtualScreen.Height - this.Height - 72;
            this.Left = SystemInformation.VirtualScreen.Width - this.Width;

            // Set up to continue running until killed off; 1/10 second will help smooth time changes
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = 100;                           
            timer.Start();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            timer = null;
            this.Dispose();
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            timer = null;
            this.Dispose();
            Application.Exit();
        }

        public void TimerTick(Object myObject, EventArgs myEventArgs)
        {
            String timeNow = DateTime.Now.ToString("HH:mm:ss");
            lblTime.Text = timeNow;
            lblTime.Visible = true;
        }
    }
}
