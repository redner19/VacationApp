using StartVacation.Model;
using StartVacation.ViewModel;
using StartVacation.ViewPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace StartVacation
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();
        }

        private void SelectedType(object sender, EventArgs e)
        {
            var view = sender as View;
            var parent = view.Parent as StackLayout;

            foreach (var child in parent.Children)
            {
                ChangeTextColor(child, "#707070", "#FFFFFF");
            }
            ChangeTextColor(view, "#FFFFFF", "#ABC0FF");

            var result = (sender as View).BindingContext as PropertyType;
            if (result.TypeName.Equals("Queens Bed"))
            {
                viewModel.QueensBed();
            }else if (result.TypeName.Equals("Kings Bed"))
            {
                viewModel.KingsBed();
            }
            else {
                viewModel.Beds(result.TypeName);
            }

        }

        private void ChangeTextColor(View child, string hexTextColor, string hexViewColor)
        {
            var txtCtrl = child.FindByName<Label>("PropertyTypeName");
            var pancakeContainer = child.FindByName<PancakeView>("PropertyContainer");


            if (txtCtrl != null)
                txtCtrl.TextColor = Color.FromHex(hexTextColor);

            if (pancakeContainer != null)
                pancakeContainer.BackgroundColor = Color.FromHex(hexViewColor);
        }

        private async void PropertySelected(object sender, EventArgs e)
        {
            var property = (sender as View).BindingContext as Property;
            await Navigation.PushAsync(new DetailsPage(property));

        }

        private async void PropertyBookMarkSelected(object sender, EventArgs e)
        {
            var property = (sender as View).BindingContext as Property;
            if (property != null)
            {
               var result = await DisplayAlert("", $"Do you want to bookmark {property.PropertyName}", "Ok", "Cancel");

                if (result)
                {

                }
            }
        }
    }
}
