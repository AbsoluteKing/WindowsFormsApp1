using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Riot;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        public static TimeSpan GameStartedTime;
        public Form2()
        {
            InitializeComponent();
            AllocConsole();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Close();
            string summonername = textBox1.Text;

            Task<TimeSpan> task = Task.Run(new Func<TimeSpan>(program.A));
            GameStartedTime = await task;

            Application.Run(new Form1());

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
        static string region = "jp";
        static string API_KEY = "0665043a-c220-4465-aaf9-7ece21e7df42";
        static string name = "AbsoluteKing";

        public static TimeSpan A()
        {

            string uri = "https://jp1.api.riotgames.com/lol/summoner/v4/summoners/by-name/スタンミジャパン?api_key=RGAPI-ca09b0fc-b50a-4e74-a5d0-8be9b4bb82c5";
            GetSummonerId(uri).GetAwaiter().GetResult();

            var jsonDes = GetSummonerId(uri).GetAwaiter().GetResult();
            string formattedJson = JsonConvert.SerializeObject(jsonDes, Formatting.Indented);
            Console.WriteLine(formattedJson);
            String SummonerId = jsonDes.Id;

            string uri1 = $"https://jp1.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{SummonerId}?api_key=RGAPI-ca09b0fc-b50a-4e74-a5d0-8be9b4bb82c5";
            InGame jsonDes1 = GetGameLength(uri1).GetAwaiter().GetResult();
            Console.WriteLine(jsonDes1.gameLength);
            TimeSpan timespan = GetEpochMillis(jsonDes1.gameStartTime);
            TimeSpan FlashTime = timespan.Add(new TimeSpan(00, 05, 00));
            return FlashTime;

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
