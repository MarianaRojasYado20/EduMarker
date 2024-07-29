using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EduMaker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void BtnInicio(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Maestro());
        }
        private async void BtnRegistro(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }
    }
}
