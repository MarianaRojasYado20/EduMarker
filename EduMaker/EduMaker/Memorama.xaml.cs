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
    public partial class Memorama : ContentPage
    {
        public Memorama()
        {
            InitializeComponent();
            CargarDatos();
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

        private void CargarDatos()
        {
            // Cargar el título desde las propiedades de la aplicación
            if (Application.Current.Properties.ContainsKey("tituloMemorama"))
            {
                lblTitulo.Text = Application.Current.Properties["tituloMemorama"].ToString();
            }

            // Cargar los números desde las propiedades de la aplicación
            if (Application.Current.Properties.ContainsKey("numerosMemorama"))
            {
                string numerosStr = Application.Current.Properties["numerosMemorama"].ToString();
                var numerosList = numerosStr.Split(',');

                // Limpiar el Grid y agregar los números
                for (int i = 0; i < numerosList.Length; i++)
                {
                    Button button = (Button)this.FindByName($"btn{i + 1}");
                    if (button != null)
                    {
                        button.Text = numerosList[i];
                    }
                }
            }
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Lógica para manejar el clic en el botón
                // Puedes cambiar el texto del botón o realizar otras acciones
                button.Text = button.Text == "?" ? "Ejemplo" : "?";
            }
        }

        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            // Guardar los cambios y regresar a la página principal
            await Navigation.PushAsync(new EditarContenido());
        }

        private async void OnEditContentClicked(object sender, EventArgs e)
        {
            // Navegar a la página de edición
            await Navigation.PushAsync(new EditarContenido());
        }
    }
}