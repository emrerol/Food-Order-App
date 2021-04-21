using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YemekSepeti.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageView : ContentPage
    {
        public MainPageView()
        {
            InitializeComponent();
        }

        async private void UyeGirisiBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginView());
        }

        async private void KayitOlBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterView());
        }
        
    }
}