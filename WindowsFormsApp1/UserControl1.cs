using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControl1 : UserControl
    {
        public static TimeSpan InGameTime;
        public static TimeSpan InGameTime_now;
        public static DateTime OnClickedTime;
        public static bool Success = false;

        public UserControl1()
        {
            InitializeComponent();
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OnClickedTime = DateTime.Now;
                String SummonerName = textBox1.Text;
                program.summonername = SummonerName;
                //Visible = false;
                Task<TimeSpan> task = Task.Run(new Func<TimeSpan>(program.A));
                InGameTime = await task;

                Success = true;

                timer_game.Interval = 1000;
                timer_game.Enabled = true;
            }
            catch
            {

            }

        }

        private void timer_game_Tick(object sender, EventArgs e)
        {
            InGameTime_now = InGameTime + (DateTime.Now - OnClickedTime);
            label2.Text = InGameTime_now.ToString("hh':'mm':'ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
