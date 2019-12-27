﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{
    public partial class ImageSubmitPage : ContentPage
    {
        ImageSubmitViewModel viewModel;
        public ImageSubmitPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ImageSubmitViewModel(this);


            PickerRating.SelectedIndex = 10;
            PickerServiceType.SelectedIndex = 0;

            PickerStore.SelectedIndexChanged += (sender, e) =>
            {
                viewModel.StoreName = PickerStore.Items[PickerStore.SelectedIndex];
            };

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var showAlert = false;
            try
            {
                var stores = await viewModel.GetStoreAsync();
                foreach (var store in stores)
                    PickerStore.Items.Add(store.Name);
            }
            catch (Exception)
            {

                showAlert = true;
            }
            if (showAlert)
                await DisplayAlert("Error", "Unable to get locations, don't worry you can still submit feedback.", "OK");


        }
    }
}

