using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EduMaker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Maestro : ContentPage
    {
		public Maestro()
		{
            InitializeComponent();
        }

        private async void OnMenuClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Menú", "Cancelar", null, "Inicio", "Mis plantillas", "Mi contenido", "Mis grupos", "Cerrar sesión");

            switch (action)
            {
                case "Inicio":
                    await Navigation.PushAsync(new Maestro());
                    break;
                case "Mis plantillas":
                    await Navigation.PushAsync(new MisPlantillas());
                    break;
                case "Mi contenido":
                    await Navigation.PushAsync(new MiContenido());
                    break;
                case "Mis grupos":
                    await Navigation.PushAsync(new MisGrupos());
                    break;
                case "Cerrar sesión":
                    // Lógica para cerrar sesión
                    break;
            }
        }
        private async void OnMemoramaTapped(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new Memorama());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ha ocurrido un error: {ex.Message}", "OK");
            }
        }
        private async void OnSecuenciasTapped(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new Secuencias());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ha ocurrido un error: {ex.Message}", "OK");
            }
        }
    }
}