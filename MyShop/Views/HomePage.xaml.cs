using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(this);

            /*BtnForum.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ForumPage());
            }
            BtnProducts.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ProductsPage());
            };
            /*
            BtnLocations.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new LocationsPage());
            };*/
            BtnImageSubmit.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ImageSubmitPage());
            };
            /*
            BtnLocalEvents.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new LocalEventsPage());
            };
            BtnCalculations.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new CalculationsPage());
            };*/
        }
    }
}

