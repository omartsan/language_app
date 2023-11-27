using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

using Xamarin.Forms;

namespace beibei
{
    public partial class context_bei : ContentPage


    {


        // JObject obj2 = JObject.Parse(System.IO.File.ReadAllText("/Users/omarsantoyo/Projects/beibei/beibei/json/context.json"));

        JObject obj2 = JObject.Parse((new WebClient()).DownloadString("https://raw.githubusercontent.com/omartsan/linguas/main/context.json"));

        static Random rnd = new Random();


        public JArray get_context(string word, JObject obj2)
        {
            JArray obj_filter = new JArray();
            // obj2 = JObject.Parse(System.IO.File.ReadAllText("/Users/omarsantoyo/Projects/beibei/beibei/json/context.json"));

      obj2 = JObject.Parse((new WebClient()).DownloadString("https://raw.githubusercontent.com/omartsan/linguas/main/context.json"));

            int size = obj2["context_phrases"].Count();


            for (int i = 0; i < size; i++)
            {
                if (((string)obj2["context_phrases"][i]["p1"]).Contains(word) == true)
                {

                    obj_filter.Add(obj2["context_phrases"][i]);
                        

                }

            }


            // return jsonobject filtered

            return obj_filter;

        }


        public context_bei(string wordkey)
        {



            InitializeComponent();

            string keyw = wordkey;
            key.Text = keyw;


        }



        protected void nextClicked(object sender, EventArgs e)
        {

            JArray obf = get_context(key.Text, obj2);

            try
            {

                int size = rnd.Next(obf.Count());


                phrase.Text = (string)obf[size]["p1"];
                pinyin.Text = "";
                answer.Text = "";
                ind.Text = size.ToString();
            }

            catch
            {
                phrase.Text = "No word";

            }




        }


        protected void checkClicked(object sender, EventArgs e)
        {
            JArray obf = get_context(key.Text, obj2);

             pinyin.Text = (string)obf[Convert.ToInt32(ind.Text)]["pinyin"]; ;
             answer.Text = (string)obf[Convert.ToInt32(ind.Text)]["p2"]; ;

        }



        protected void contextClicked(object sender, EventArgs e)
        {
           Navigation.PushModalAsync(new Bei());



        }





    }
}

