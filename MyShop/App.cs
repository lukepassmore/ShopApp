using MyShop.Services;
using System;
using System.Linq;
using Xamarin.Forms;

namespace MyShop
{
    public static class ViewModelLocator
    {
	static bool UseDesignTime => false;

        static ImageSubmitViewModel feedbackVM;

        public static ImageSubmitViewModel ImageSubmitViewModel
        => feedbackVM ?? (feedbackVM = new ImageSubmitViewModel(null));


        static ProductsViewModel productsViewModel;

        public static ProductsViewModel ProductsViewModel
        {
            get
            {
		    if(!UseDesignTime)
			    return null;
		    
                if (productsViewModel != null)
                    return productsViewModel;
                              
                productsViewModel = new ProductsViewModel(null);
                productsViewModel.GetStoresCommand.Execute(null);
                return productsViewModel;
            }
        }

        static ProductViewModel productViewModel;

        public static ProductViewModel ProductViewModel
        { 
            get
            {
		    
		    if(!UseDesignTime)
			    return null;
		    
                if (productViewModel != null)
                    return productViewModel;

                var offline = new OfflineDataStore();
                var task = offline.GetStoresAsync();
                task.Wait();
                var store = task.Result.First();
                productViewModel = new ProductViewModel(store, null);
                return productViewModel;
            }
        }

    }
    public class App : Application
    {
        public App() =>
            // The root page of your application
            MainPage = new NavigationPage(new HomePage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#f4c031")
            };

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

