using catteryConsole;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace cattery
{
    public partial class AddCatsWPF : Window
    {
        public string? CatImagePath { get; private set; }
        public Cat? CreatedCat { get; private set; }

        public AddCatsWPF(AfterLoginWPF mainWPF)
        {
            InitializeComponent();
            MainWPF = mainWPF;
        }
        private AfterLoginWPF MainWPF;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text.Trim();
                string race = RaceTextBox.Text.Trim();
                Sex sex = (Sex)Enum.Parse(typeof(Sex), ((ComboBoxItem)SexComboBox.SelectedItem).Tag.ToString()!);
                string description = DescriptionTextBox.Text.Trim();
                DateOnly? birth = BirthDatePicker.SelectedDate.HasValue ? DateOnly.FromDateTime(BirthDatePicker.SelectedDate.Value) : null;
                DateOnly arrived = DateOnly.FromDateTime(ArrivedDatePicker.SelectedDate ?? DateTime.Today);
                DateOnly? left = LeftDatePicker.SelectedDate.HasValue ? DateOnly.FromDateTime(LeftDatePicker.SelectedDate.Value) : null;

                CreatedCat = new Cat(name, race, sex, description, birth, arrived, left, CatImagePath);
                MainWPF.CatteryWPF.AddCat(CreatedCat);
                MessageBox.Show("Cat was Successfully created!", "Done Creating!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();
                MainWPF.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Validazione", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ImageBorder_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    string sourceFilePath = files[0];
                    string appBasePath = AppDomain.CurrentDomain.BaseDirectory;
                    string targetDirectory = System.IO.Path.Combine(appBasePath, "Resources", "CatImages");

                    // se nn esiste la creo
                    if (!System.IO.Directory.Exists(targetDirectory))
                    {
                        System.IO.Directory.CreateDirectory(targetDirectory);
                    }

                    string targetFilePath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(sourceFilePath));

                    // Copia il file nella cartella delle risorse 
                    System.IO.File.Copy(sourceFilePath, targetFilePath, true);

                    CatImagePath = targetFilePath;
                    CatImagePreview.Source = new BitmapImage(new Uri(CatImagePath));
                }
            }
        }

        private void ImageBorder_DragEnter(object sender, DragEventArgs e)
        {
            ((Border)sender).Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightBlue);
        }

        private void ImageBorder_DragLeave(object sender, DragEventArgs e)
        {
            ((Border)sender).Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(238, 238, 238));
        }
    }
}
