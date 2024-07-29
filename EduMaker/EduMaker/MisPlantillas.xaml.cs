using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EduMaker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MisPlantillas : ContentPage
	{
		public MisPlantillas ()
		{
			InitializeComponent ();
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
    }
}