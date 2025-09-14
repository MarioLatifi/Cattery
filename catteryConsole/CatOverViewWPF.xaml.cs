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
using cattery;
using catteryLib;
namespace catteryConsole
{
    /// <summary>  
    /// Logica di interazione per CatOverViewWPF.xaml  
    /// </summary>  
    public partial class CatOverViewWPF : Window
    {
        public CatOverViewWPF(Cat cat, AfterLoginWPF main)
        {
            InitializeComponent();
            DisplayCatInfo(cat);
            Main = main;
            CurrentCat = cat;
        }
        private ViewCatsWPF ViewCats;
        private Cat CurrentCat;
        private AfterLoginWPF Main;
        private void DisplayCatInfo(Cat cat)
        {
            // Set the title of the window to the cat's name  
            this.Title = $"Dettagli di {cat.Name}";

            // Display cat information  
            lblName.Content = $"Nome: {cat.Name}";
            lblAge.Content = $"Sesso: {cat.CatSex}";
            lblBreed.Content = $"Razza: {cat.Race}";
            lblDescription.Text = cat.Description;
            lblBirth.Content = cat.Birth.HasValue ? $"Data di nascita: {cat.Birth.Value:dd/MM/yyyy}" : "Data di nascita: N/A";
            lblArrived.Content = $"Data di arrivo al gattile: {cat.ArrivedToCattery:dd/MM/yyyy}";
            lblLeft.Content = cat.LeftCattery.HasValue ? $"Data di uscita dal gattile: {cat.LeftCattery.Value:dd/MM/yyyy}" : "Data di uscita dal gattile: Ancora presente";

            // Display cat photo  
            if (!string.IsNullOrEmpty(cat.CatImage))
            {
                string catImagesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "CatImages");
                string imageFile;
                try
                {
                    imageFile = System.IO.Path.Combine(catImagesPath, cat.CatImage);
                }
                catch
                {
                    imageFile = System.IO.Path.Combine(catImagesPath, "noPhoto.jpg");
                }
                imgCatPhoto.Source = new BitmapImage(new Uri(imageFile, UriKind.Absolute));
            }
        }
        private void btnAdoptNow_Click(object sender, RoutedEventArgs e)
        {
            // Adotta il gatto usando l'adottante corrente
            Main.CatteryWPF.AdoptCat(CurrentCat, Main.CurrentUser, DateOnly.FromDateTime(DateTime.Now));
            MessageBox.Show($"Hai adottato {CurrentCat.Name}!", "Adozione completata", MessageBoxButton.OK, MessageBoxImage.Information);
            ViewCats = new ViewCatsWPF(Main.CatteryWPF, Main);
            ViewCats.Show();
            this.Close(); // Chiudi la finestra dopo l'adozione (se vuoi)
            Main.SerializeCatAndAdoptionManagement();
        }
    }
}
