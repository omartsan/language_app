using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace beibei
{
    public partial class bei_main : ContentPage
    {
        public bei_main()
        {
            InitializeComponent();


        }



        public void beibeigo(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Bei());


        }



        public void beifilesgo(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new beifiles());


        }



        public void beitrancego(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new bei_trance());


        }

        public void ltgo(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Main());

        }

    }
}
