using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroDetallado_PrestamoMoras.BLL;
using RegistroDetallado_PrestamoMoras.Entidades;

namespace RegistroDetallado_PrestamoMoras.UI.Registros
{
    public partial class rPersonas : Window
    {
        private Personas personas = new Personas();

        public rPersonas()
        {
            InitializeComponent();
            this.DataContext = personas;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var personas = PersonasBLL.Buscar(Utiidades.ToInt(PersonasIdTextBox.Text));
            if (personas != null)
            {
                this.personas = personas;
                this.DataContext = this.personas;
            }

        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        public void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = PersonasBLL.Guardar(this.personas);

            if (paso)
            {


                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonasBLL.Eliminar(Utiidades.ToInt(PersonasIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Limpiar()
        {
            this.personas = new Personas();
            this.DataContext = this.personas;

        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

                return esValido;
            }
            return esValido;
        }
    }
}