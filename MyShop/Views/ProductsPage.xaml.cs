using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{
    public partial class ProductsPage : ContentPage
    {
        ProductsViewModel viewModel;
        public Action<Store> ItemSelected
        {
            get { return viewModel.ItemSelected; }
            set { viewModel.ItemSelected = value; }
        }
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProductsViewModel(this);

            /*if (Device.RuntimePlatform == Device.WinPhone || (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone))
            {
                //StoreList.IsGroupingEnabled = false;
                //StoreList.ItemsSource = viewModel.Stores;
            }*/
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Stores.Count > 0 || viewModel.IsBusy)
                return;

            viewModel.GetStoresCommand.Execute(null);
        }
    }
}

