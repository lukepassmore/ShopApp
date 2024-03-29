﻿using Xamarin.Forms;
using Plugin.ExternalMaps;
using MyShop.Helpers;

using Xamarin.Essentials;

namespace MyShop
{
    public class ProductViewModel : ViewModelBase
    {
        public Store Store { get; set; }
        public string Monday { get { return string.Format("{0} - {1}", Store.MondayOpen, Store.MondayClose); } }
        public string Tuesday { get { return string.Format("{0} - {1}", Store.TuesdayOpen, Store.TuesdayClose); } }
        public string Wednesday { get { return string.Format("{0} - {1}", Store.WednesdayOpen, Store.WednesdayClose); } }
        public string Thursday { get { return string.Format("{0} - {1}", Store.ThursdayOpen, Store.ThursdayClose); } }
        public string Friday { get { return string.Format("{0} - {1}", Store.FridayOpen, Store.FridayClose); } }
        public string Saturday { get { return string.Format("{0} - {1}", Store.SaturdayOpen, Store.SaturdayClose); } }
        public string Sunday { get { return string.Format("{0} - {1}", Store.SundayOpen, Store.SundayClose); } }


        public string Address1 { get { return Store.StreetAddress; } }
        public string Address2 { get { return string.Format("{0}, {1} {2}", Store.City, Store.State, Store.ZipCode); } }

        public ProductViewModel(Store store, Page page) : base(page)
        {
            this.Store = store;
        }

        Command navigateCommand;
        public Command NavigateCommand
        {
            get
            {
                return navigateCommand ?? (navigateCommand = new Command(() =>
                CrossExternalMaps.Current.NavigateTo(Store.Name, Store.Latitude, Store.Longitude)));
            }
        }

        Command callCommand;
        public Command CallCommand
        {
            get
            {
                return callCommand ?? 
                    (callCommand = new Command(() =>
                        PhoneDialer.Open(Store.PhoneNumber.CleanPhone())
                    ));
            }
        }

    }
}

