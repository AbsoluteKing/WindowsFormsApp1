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

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Top_Click(object sender, EventArgs e)
        {
            program.A();
        }
    }

    public class Riot
    {
        public string Id { get; set; }
    }

    public class program
    {
        //static HttpClient client = new HttpClient();
        static string region = "jp";
        static string API_KEY = "0665043a-c220-4465-aaf9-7ece21e7df42";
        static string name = "AbsoluteKing";

        public static void A()
        {
            string uri = "http://weather.livedoor.com/forecast/webservice/json/v1?city=400040";
            GetString(uri).Wait();
        }

        public static async Task GetString(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                string response = await httpClient.GetStringAsync(uri);
                Console.Write(response);
            }
        }

        //static async Task<Uri>CreateProductAsync(Riot riot)
        //{
        //    string uristring = string.Format("https://jp1.api.riotgames.com/lol/summoner/v4/summoners/by-name/nananoko");
        //    Console.WriteLine(uristring);
        //    HttpResponseMessage response = await client.PostAsJsonAsync(uristring, riot);
        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.Headers.Location;
        //}

        //static async Task<Riot>GetProductAsync(string path)
        //{
        //    Riot riot = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //       riot = await response.Content.ReadAsAsync<Riot>();
        //    }
        //    return riot;
        //}



        //static async Task RunAsync()
        //{
        //    string uristring = string.Format("https://{0}.api.riotgames.com",region);
        //    Console.WriteLine(uristring);
        //    client.BaseAddress = new Uri(uristring);

        //    Riot riot = new Riot { Id = "0" };

        //    try
        //    {
        //        //var url = await CreateProductAsync(riot);
        //        //Console.WriteLine($"Created at {url}");
        //        //riot = await GetProductAsync(url.PathAndQuery);
        //        //ShowProduct(riot);


        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //}

    }

}
