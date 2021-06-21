using StartVacation.Model;
using StartVacation.ViewPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StartVacation.ViewModel
{
    public class DetailsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private Property property;

        public Property Property
        {
            get { return property; }
            set { property = value;
                OnPropertyChanged(nameof(Property));
            }
        }
        private int countDays;


        public int CountDays
        {
            get { return countDays; }
            set
            {
                countDays = value;
                OnPropertyChanged(nameof(CountDays));
            }
        }

        public Command Add { get; set; }
        public Command Subtract { get; set; }

        public Command GoBack { get; set; }
        public Command GoToEmail { get; set; }
        public Command GoToPhone { get; set; }
        public Command GoToMap { get; set; }
        public Command GoToMore { get; set; }

        private float OriginalPrice;

        private string currentPrice;

        public string CurrentPrice
        {
            get { return currentPrice; }
            set { currentPrice = value;
                OnPropertyChanged(nameof(CurrentPrice));
            }
        }

        public DetailsPageViewModel(Property property)
        {
            Add = new Command(() => AddDays());
            Subtract = new Command(() => SubtractDays());


            GoBack = new Command(() => BackToMenu());

            GoToEmail = new Command(() => ProceedToEmail());
            GoToPhone = new Command(() => ProceedToPhone());
            GoToMap = new Command(() => ProceedToMap());
            GoToMore = new Command(() => ProceedToMore());

            this.Property = property;
            CurrentPrice = property.Price;
            this.OriginalPrice = float.Parse(CurrentPrice);

            countDays = 1;

        }
      

        public void AddDays()
        {
            //this is increment countDays by 1
            CountDays++;
            CurrentPrice = (OriginalPrice * countDays).ToString("#,##0");
            Property = Property;

        }
        public void SubtractDays()
        {
            //if countDays is 1 return 
            if (CountDays == 1) return;

            //Decrement countDays by 1
            CountDays--;
            CurrentPrice = (float.Parse(CurrentPrice) - OriginalPrice).ToString("#,##0");

            Property = Property;
            

        }

        public async void BackToMenu()
        {
            //when pressing back button this will trigger, it will wait for a boolean since this is an async function it will not trigger the
            //condition yet.
            var result = await App.Current.MainPage.DisplayAlert("", "Do you want to go back?", "Yes", "No");
            if (result)
            {
                //this will pop or close the current page
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        private void ProceedToPhone() {
            //This function will open the PhoneDialer, it will throw an exception when the number given is null, phone dialer is not supported example a tablet it no simcard;
            try
            {
                PhoneDialer.Open(Property.Contact);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
        private void ProceedToEmail() { }
        private async void ProceedToMap() {
            //when pressing map button this will trigger, it will wait for a boolean since this is an async function it will not trigger the
            //condition yet.
            var result = await App.Current.MainPage.DisplayAlert("", "Do you want to open map?", "Ok", "Cancel");

            if (result)
                await App.Current.MainPage.Navigation.PushModalAsync(new MapPage());
        }
        private void ProceedToMore() {  }

      
    }
}
