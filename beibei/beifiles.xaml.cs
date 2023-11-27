using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using beibei.DataModels;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace beibei
{
    public partial class beifiles : ContentPage
    {

        JObject obj2 = JObject.Parse((new WebClient()).DownloadString("https://raw.githubusercontent.com/omartsan/linguas/main/context.json"));




        List<hskInfo> myList;

        public beifiles()
        {
            InitializeComponent();

            myList = new List<hskInfo> { };


            int size = obj2["context_phrases"].Count();

            for (int i = 0; i < size; i++)
            {


                myList.Add(new hskInfo { P1 = (string)obj2["context_phrases"][i]["p1"], P2 = (string)obj2["context_phrases"][i]["p2"], Py = (string)obj2["context_phrases"][i]["pinyin"] });

            }

            myListView.ItemsSource = myList;



        }





        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var hsk_phrase = e.Item as hskInfo;

            DisplayAlert("Translation",$"{hsk_phrase.P2}", "OK");

        }


        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            myListView.ItemsSource  = myList.Where(s => s.P1.StartsWith(e.NewTextValue));

        }


        protected void back(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new bei_main());



        }

    }

}
