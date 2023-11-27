using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace beibei
{
    public partial class bei_trance : ContentPage
    {
        //JObject obj = JObject.Parse(System.IO.File.ReadAllText("/Users/omarsantoyo/Projects/beibei/beibei/json/hsk.json"));

        JObject obj_trance = JObject.Parse((new WebClient()).DownloadString("https://raw.githubusercontent.com/omartsan/linguas/main/context.json"));
        static Random rnd_trance = new Random();


        public bei_trance()

        {



            InitializeComponent();





        }


        public void nextTrance(object sender, EventArgs e)
        {
            int length_trance = rnd_trance.Next(obj_trance["context_phrases"].Count());

            ind_trance.Text = length_trance.ToString();


            phrase_trance.Text = (string)obj_trance["context_phrases"][Convert.ToInt32(ind_trance.Text)]["p1"];
            pinyin_trance.Text = (string)obj_trance["context_phrases"][Convert.ToInt32(ind_trance.Text)]["pinyin"];

            phrase2_trance.Text = (string)obj_trance["context_phrases"][Convert.ToInt32(ind_trance.Text)+1]["p2"];

            answer_trance.Text = "";



        }


        protected void checkTrance(object sender, EventArgs e)
        {


      
                answer_trance.Text = (string)obj_trance["context_phrases"][Convert.ToInt32(ind_trance.Text)+1]["p1"];

           
            

        }



     

        public void ltgo(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new bei_main());

        }
    }
}
