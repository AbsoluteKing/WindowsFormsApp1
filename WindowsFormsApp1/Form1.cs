using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Diagnostics;
using KeyHook;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        DateTime Time_Used_TOP; bool OnCoolTime_TOP = false; TimeSpan Time_Span_TOP;
        DateTime Time_Used_JG;  bool  OnCoolTime_JG = false;  TimeSpan Time_Span_JG;
        DateTime Time_Used_MID; bool OnCoolTime_MID = false; TimeSpan Time_Span_MID;
        DateTime Time_Used_BOT; bool OnCoolTime_BOT = false; TimeSpan Time_Span_BOT;
        DateTime Time_Used_SUP; bool OnCoolTime_SUP = false; TimeSpan Time_Span_SUP;


        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            var interceptKeyboard = new KeyHook.InterceptKeyboard();

            interceptKeyboard.KeyDownEvent += InterceptKeyboard_KeyDownEvent;
            interceptKeyboard.KeyUpEvent += InterceptKeyboard_KeyUpEvent;
            interceptKeyboard.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void InterceptKeyboard_KeyUpEvent(object sender, InterceptKeyboard.OriginalKeyEventArg e)
        {
            UserControl1 control1 = new UserControl1();
            if (UserControl1.Success == true)
            {
                if (e.KeyCode == 112)
                {
                    OnCoolTime_TOP = true;
                    Console.WriteLine("Keyup KeyCode {0}", e.KeyCode);
                    OnPressF1();
                }

                if (e.KeyCode == 113)
                {
                    OnCoolTime_JG = true;
                    Console.WriteLine("Keyup KeyCode {0}", e.KeyCode);
                    OnPressF2();
                }

                if (e.KeyCode == 114)
                {
                    OnCoolTime_MID = true;
                    Console.WriteLine("Keyup KeyCode {0}", e.KeyCode);
                    OnPressF3();
                }
                if (e.KeyCode == 115)
                {
                    OnCoolTime_BOT = true;
                    Console.WriteLine("Keyup KeyCode {0}", e.KeyCode);
                    OnPressF4();
                }
                if (e.KeyCode == 116)
                {
                    OnCoolTime_SUP = true;
                    Console.WriteLine("Keyup KeyCode {0}", e.KeyCode);
                    OnPressF5();
                }
            }

            
        }

        private static void InterceptKeyboard_KeyDownEvent(object sender, InterceptKeyboard.OriginalKeyEventArg e)
        {
            Console.WriteLine("Keydown KeyCode {0}", e.KeyCode);
        }

        private void CopyOnCrip(bool top, bool jg, bool mid, bool bot, bool sup)
        {
            string TopTime, JgTime, MidTime, BotTime, SupTime;
            if (top == true) { TopTime = ("　Top：" + (Time_Span_TOP + UserControl1.InGameTime_now).ToString("hh':'mm':'ss")); }
            else { TopTime = ""; }
            if (jg == true) { JgTime = ("　Jg：" + (Time_Span_JG + UserControl1.InGameTime_now).ToString("hh':'mm':'ss")); }
            else { JgTime = ""; }
            if (mid == true) { MidTime = ("Mid：" + (Time_Span_MID + UserControl1.InGameTime_now).ToString("hh':'mm':'ss")); }
            else { MidTime = ""; }
            if (bot == true) { BotTime = ("　Bot：" + (Time_Span_BOT + UserControl1.InGameTime_now).ToString("hh':'mm':'ss")); }
            else { BotTime = ""; }
            if (sup == true) { SupTime = ("　Sup：" + (Time_Span_SUP + UserControl1.InGameTime_now).ToString("hh':'mm':'ss")); }
            else { SupTime = ""; }

            Clipboard.SetText(TopTime + JgTime + MidTime + BotTime + SupTime);
        }

        #region OnPressAction
        private void OnPressF1()
        {
            Time_Used_TOP = DateTime.Now.Add(new TimeSpan(00, 05, 00));
            timer_Top.Interval = 1000;
            Time_Span_TOP = UserControl1.InGameTime_now.Add(new TimeSpan(00, 05, 00));
            CopyOnCrip(OnCoolTime_TOP, OnCoolTime_JG, OnCoolTime_MID, OnCoolTime_BOT, OnCoolTime_SUP);
            timer_Top.Enabled = true;

        }
        private void OnPressF2()
        {
            Time_Used_JG = DateTime.Now.Add(new TimeSpan(00, 05, 00));
            timer_Top.Interval = 1000;
            Time_Span_JG = UserControl1.InGameTime_now.Add(new TimeSpan(00, 05, 00));
            CopyOnCrip(OnCoolTime_TOP, OnCoolTime_JG, OnCoolTime_MID, OnCoolTime_BOT, OnCoolTime_SUP);
            timer_Jg.Enabled = true;
        }
        private void OnPressF3()
        {
            Time_Used_MID = DateTime.Now.Add(new TimeSpan(00, 05, 00));
            timer_Mid.Interval = 1000;
            Time_Span_MID = UserControl1.InGameTime_now.Add(new TimeSpan(00, 05, 00));
            CopyOnCrip(OnCoolTime_TOP, OnCoolTime_JG, OnCoolTime_MID, OnCoolTime_BOT, OnCoolTime_SUP);
            timer_Mid.Enabled = true;
        }
        private void OnPressF4()
        {
            Time_Used_BOT = DateTime.Now.Add(new TimeSpan(00, 05, 00));
            timer_Bot.Interval = 1000;
            Time_Span_BOT = UserControl1.InGameTime_now.Add(new TimeSpan(00, 05, 00));
            CopyOnCrip(OnCoolTime_TOP, OnCoolTime_JG, OnCoolTime_MID, OnCoolTime_BOT, OnCoolTime_SUP);
            timer_Bot.Enabled = true;
        }
        private void OnPressF5()
        {
            Time_Used_SUP = DateTime.Now.Add(new TimeSpan(00, 05, 00));
            timer_Sup.Interval = 1000;
            Time_Span_SUP = UserControl1.InGameTime_now.Add(new TimeSpan(00, 05, 00));
            CopyOnCrip(OnCoolTime_TOP, OnCoolTime_JG, OnCoolTime_MID, OnCoolTime_BOT, OnCoolTime_SUP);
            timer_Sup.Enabled = true;
        }
        #endregion

        #region TimerAction
        //Top
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeSpan t = Time_Used_TOP - DateTime.Now;
            label1.Text = t.ToString("hh':'mm':'ss");
            if (t <= new TimeSpan(00, 00, 00))
            {
                timer_Top.Enabled = false;
                OnCoolTime_TOP = false;
                label1.Text = "READY";
            }
        }
        //Jg
        private void timer_Jg_Tick(object sender, EventArgs e)
        {
            TimeSpan t = Time_Used_JG - DateTime.Now;
            label2.Text = t.ToString();
            if (t <= new TimeSpan(00, 00, 00))
            {
                timer_Jg.Enabled = false;
                OnCoolTime_JG = false;
                label2.Text = "READY";
            }
        }
        //mid
        private void timer_Mid_Tick(object sender, EventArgs e)
        {
            TimeSpan t = Time_Used_MID - DateTime.Now;
            label3.Text = t.ToString();
            if (t <= new TimeSpan(00, 00, 00))
            {
                timer_Mid.Enabled = false;
                OnCoolTime_MID = false;
                label2.Text = "READY";
            }
        }
        //bot
        private void timer_Bot_Tick(object sender, EventArgs e)
        {
            TimeSpan t = Time_Used_BOT - DateTime.Now;
            label4.Text = t.ToString();
            if (t <= new TimeSpan(00, 00, 00))
            {
                timer_Bot.Enabled = false;
                OnCoolTime_BOT = false;
                label4.Text = "READY";
            }
        }
        //sup
        private void timer_Sup_Tick(object sender, EventArgs e)
        {
            TimeSpan t = Time_Used_SUP - DateTime.Now;
            label5.Text = t.ToString();
            if (t <= new TimeSpan(00, 00, 00))
            {
                timer_Sup.Enabled = false;
                OnCoolTime_SUP = false;
                label5.Text = "READY";
            }
        }
        #endregion

        private void timer_general_Tick(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        #region ButtunEvent

        private void button1_Click(object sender, EventArgs e)
        {
            Time_Span_TOP = StringToTimeSpan(textBox1.Text)-UserControl1.InGameTime_now;
            Time_Used_TOP = DateTime.Now.Add(Time_Span_TOP);
            Console.WriteLine(Time_Span_TOP);
            Console.WriteLine(Time_Used_TOP);
            OnCoolTime_TOP = true;
            textBox1.ResetText();
            CopyOnCrip(OnCoolTime_TOP, OnCoolTime_JG, OnCoolTime_MID, OnCoolTime_BOT, OnCoolTime_SUP);
            timer_Top.Interval = 1000;
            timer_Top.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Time_Span_JG = StringToTimeSpan(textBox2.Text) - UserControl1.InGameTime_now;
            Time_Used_JG = DateTime.Now.Add(Time_Span_JG);
            OnCoolTime_JG = true;
            textBox2.ResetText();
            CopyOnCrip(OnCoolTime_TOP, OnCoolTime_JG, OnCoolTime_MID, OnCoolTime_BOT, OnCoolTime_SUP);
            timer_Jg.Interval = 1000;
            timer_Jg.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Time_Span_MID = StringToTimeSpan(textBox3.Text) - UserControl1.InGameTime_now;
            Time_Used_MID = DateTime.Now.Add(Time_Span_MID);
            OnCoolTime_MID = true;
            textBox3.ResetText();
            CopyOnCrip(OnCoolTime_TOP, OnCoolTime_JG, OnCoolTime_MID, OnCoolTime_BOT, OnCoolTime_SUP);
            timer_Mid.Interval = 1000;
            timer_Mid.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Time_Span_BOT = StringToTimeSpan(textBox4.Text) - UserControl1.InGameTime_now;
            Time_Used_BOT = DateTime.Now.Add(Time_Span_BOT);
            OnCoolTime_BOT = true;
            textBox4.ResetText();
            CopyOnCrip(OnCoolTime_TOP, OnCoolTime_JG, OnCoolTime_MID, OnCoolTime_BOT, OnCoolTime_SUP);
            timer_Bot.Interval = 1000;
            timer_Bot.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Time_Span_SUP = StringToTimeSpan(textBox5.Text) - UserControl1.InGameTime_now;
            Time_Used_SUP = DateTime.Now.Add(Time_Span_BOT);
            OnCoolTime_SUP = true;
            textBox5.ResetText();
            CopyOnCrip(OnCoolTime_TOP, OnCoolTime_JG, OnCoolTime_MID, OnCoolTime_BOT, OnCoolTime_SUP);
            timer_Sup.Interval = 1000;
            timer_Sup.Enabled = true;
        }

        #endregion

        public TimeSpan StringToTimeSpan(string timespan_s)
        {
            TimeSpan timeSpan=new TimeSpan(00,00,00);
            if (timespan_s.Length==4)
            {
                int minute = 10*ToInt(timespan_s[0])+ToInt(timespan_s[1]);
                int second = 10 + ToInt(timespan_s[2]) + ToInt(timespan_s[0]);
                timeSpan = new TimeSpan(00, minute, second);
            }
            return timeSpan;
        }

        public static int ToInt(char self)
        {
            return self - '0';
        }

        
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string summonerLevel { get; set; }
    }

    public class InGame
    {
        public string gameLength { get; set; }
        public long gameStartTime { get; set; }
    }

    public class program
    {
        public static string region = "jp";
        public static string API_KEY = "XXXXXXXXXXXXXXXXX";
        public static string summonername;

        public static TimeSpan A()
        {

            string uri = $"https://jp1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonername}?api_key={API_KEY}";
            GetSummonerId(uri).GetAwaiter().GetResult();

            var jsonDes = GetSummonerId(uri).GetAwaiter().GetResult();
            string formattedJson = JsonConvert.SerializeObject(jsonDes, Formatting.Indented);
            Console.WriteLine(formattedJson);
            String SummonerId = jsonDes.Id;

            string uri1 = $"https://jp1.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{SummonerId}?api_key={API_KEY}";
            InGame jsonDes1 = GetGameLength(uri1).GetAwaiter().GetResult();
            Console.WriteLine(jsonDes1.gameLength);
            TimeSpan timespan = GetEpochMillis(jsonDes1.gameStartTime);
            return timespan;

        }

        public static async Task<Product> GetSummonerId(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                string response = await httpClient.GetStringAsync(uri);
                var result = await httpClient.GetAsync(uri);
                var jsonString = await result.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<Product>(jsonString);
                Console.Write(response);
                return res;
            }
        }

        public static async Task<InGame> GetGameLength(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                string response = await httpClient.GetStringAsync(uri);
                var result = await httpClient.GetAsync(uri);
                var jsonString = await result.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<InGame>(jsonString);
                Console.Write(response);
                return res;
            }
        }

        public static TimeSpan GetEpochMillis(long inGame)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 09, 00, 30);
            DateTime ts = dateTime.AddMilliseconds(inGame);
            DateTime dateTime_now = DateTime.Now;
            //経過時間
            TimeSpan InGameTime = dateTime_now - ts;
            Console.WriteLine("ingame:" + inGame + "ts:" + ts + "InGameTime:" + InGameTime);

            return InGameTime;
        }
    }
}

