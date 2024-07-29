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
    public partial class EditarContenido : ContentPage
    {
        public EditarContenido()
        {
            InitializeComponent();
        }

        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string nuevoTitulo = entryTitulo.Text;
            string nuevosNumeros = editorNumeros.Text;

            // Validar y procesar los números
            var numerosList = nuevosNumeros.Split(',');
            if (numerosList.Length != 20)
            {
                await DisplayAlert("Error", "Debe ingresar 20 números separados por comas.", "OK");
                return;
            }

            // Guardar los cambios (puedes ajustar esto según tu lógica de almacenamiento)
            Application.Current.Properties["tituloMemorama"] = nuevoTitulo;
            Application.Current.Properties["numerosMemorama"] = nuevosNumeros;
            await Application.Current.SavePropertiesAsync();

            // Mostrar mensaje de guardado
            await DisplayAlert("Guardado", "Los cambios han sido guardados.", "OK");

            // Redirigir a la página Memorama
            await Navigation.PushAsync(new Memorama());
        }

        private async void OnCancelarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}