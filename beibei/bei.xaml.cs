using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace beibei
{
    

    public partial class Bei : ContentPage
    {



        JObject obj = JObject.Parse((new WebClient()).DownloadString("https://raw.githubusercontent.com/omartsan/linguas/main/hsk.json"));


        static Random rnd = new Random();

       // JObject obj =  DownloadString();


        public Bei()

        {



            InitializeComponent();





        }


        public void NextClicked(object sender, EventArgs e)
        {
            int length = rnd.Next(obj["hsk"].Count());



            // Perform action on clicks
            if (!trance.IsToggled)
            {
                phrase.Text = (string)obj["hsk"][length]["p1"];
                pinyin.Text = "";
                answer.Text = "";
            }
            else
            {
                phrase.Text = (string)obj["hsk"][length]["p2"];
                pinyin.Text = "";
                answer.Text = "";
            }



            ind.Text = length.ToString();


            //};

        }


        protected void checkClicked(object sender, EventArgs e)
        {


            if (!trance.IsToggled)
            {
                answer.Text = (string)obj["hsk"][Convert.ToInt32(ind.Text)]["p2"];

            }
            else
            {
                answer.Text = (string)obj["hsk"][Convert.ToInt32(ind.Text)]["p1"];

            }

            pinyin.Text = (string)obj["hsk"][Convert.ToInt32(ind.Text)]["py"];

        }



        public void contextClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new context_bei((string)obj["hsk"][Convert.ToInt32(ind.Text)]["key"]));



        }


        public void activated(object sender, ToggledEventArgs e)
        {

            phrase.Text = "";
            pinyin.Text = "";
            answer.Text = "";
            ind.Text = "";

        }


        public void ltgo(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new bei_main());

        }
    }
}
