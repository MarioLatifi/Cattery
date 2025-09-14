using cattery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace catteryConsole
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
            BackGroundLogin.Background = Brushes.LightBlue;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Adopter adopter = new Adopter(txtName.Text, txtSurname.Text, txtAddress.Text, txtCel.Text);
                // Apri la pagina AfterLoginWPF
                var afterLoginWindow = new AfterLoginWPF(adopter);
                afterLoginWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }
    }
}
