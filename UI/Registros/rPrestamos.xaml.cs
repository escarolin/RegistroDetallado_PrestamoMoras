using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroDetallado_PrestamoMoras.Entidades;
using RegistroDetallado_PrestamoMoras.BLL;
using System.Windows;


namespace RegistroDetallado_PrestamoMoras.UI.Registros
{
    public partial class rPrestamos : Window
    {
        private Prestamos prestamos = new Prestamos();
        public rPrestamos()
        {
            InitializeComponent();

            this.DataContext = prestamos;

            PersonasIdComboBox.ItemsSource = PersonasBLL.GetPersonas();
            PersonasIdComboBox.SelectedValuePath = "PersonaId";
            PersonasIdComboBox.DisplayMemberPath = "Nombres";
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var prestamos = PrestamosBLL.Buscar(Utiidades.ToInt(PrestamoIdTextBox.Text));
            if (prestamos != null)
            {
                this.prestamos = prestamos;
                this.DataContext = this.prestamos;
            }
            else
            {
                this.prestamos = new Prestamos();
                this.DataContext = this.prestamos;
                MessageBox.Show("Este prestamos no fue encontrado.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Limpiar();
                PrestamoIdTextBox.SelectAll();
                PrestamoIdTextBox.Focus();
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

            var paso = PrestamosBLL.Guardar(this.prestamos);

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
            if (PrestamosBLL.Eliminar(Utiidades.ToInt(PrestamoIdTextBox.Text)))
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
            this.prestamos = new Prestamos();
            this.DataContext = this.prestamos;

        }

        private bool Validar()
        {
            bool esValido = true;

            if (ConceptoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
    }
}