using StartVacation.Model;
using StartVacation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StartVacation.ViewPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public bool isOpened { get; set; }

        private DetailsPageViewModel viewModel;

        public DetailsPage(Property property)
        {
            InitializeComponent();
            BindingContext = viewModel = new DetailsPageViewModel(property);
            isOpened = false;
        }
      
        private async void BookNow(object sender, EventArgs e)
        {
            var result = await DisplayAlert("", "Do you want to book now?", "Yes", "No");
            if (result)
                await DisplayAlert("", "Sucessfully book room", "Ok");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!isOpened)
            {
                DetailsView.TranslationY = 600;
                DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
                isOpened = true;
            }       
        }

        protected override bool OnBackButtonPressed()
        {
            viewModel.BackToMenu();
            return true;
        }
    }
}