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
    /// Logica di interazione per ViewCatsWPF.xaml  
    /// </summary>  
    public partial class ViewCatsWPF : Window
    {
        private const int SIDE_SIZE = 300;
        private const int SPACING_DISTANCE = 150;
        private int selectedCatIndex = -1; // Variabile per memorizzare l'indice del gatto selezionato  
        public Cattery CatteryWPF;
        private MainWindow MainWPF;

        public ViewCatsWPF(Cattery cattery, MainWindow mainWPF)
        {
            CatteryWPF = cattery;
            InitializeComponent();
            GenerateLabel(CatteryWPF.CatManagement.Cats.Count());
            MainWPF = mainWPF;
        }

        private void GenerateLabel(int numberOFLabels)
        {
            double pixelsum = 0;
            int rows = 0;
            double x = 0;
            double y = 20;
            bool changeLine = false;
            string catImagesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "CatImages");
            for (int i = 0; i < CatteryWPF.CatManagement.Cats.Count(); i++)
            {
                if (i == 0 || changeLine)
                {
                    x = 90;
                    changeLine = false;
                }
                else
                {
                    x += (SIDE_SIZE + SPACING_DISTANCE);
                }

                Label lbl = new Label();
                lbl.Width = SIDE_SIZE;
                lbl.Height = SIDE_SIZE;
                lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                lbl.VerticalContentAlignment = VerticalAlignment.Center;

                string imageFile;
                try
                {
                    imageFile = System.IO.Path.Combine(catImagesPath, CatteryWPF.CatManagement.Cats[i].CatImage);
                }
                catch (Exception e)
                {
                    imageFile = System.IO.Path.Combine(catImagesPath, "noPhoto.jpg");
                }
                lbl.Background = new ImageBrush(new BitmapImage(new Uri(imageFile, UriKind.Absolute)));

                Canvas.SetLeft(lbl, x);
                Canvas.SetTop(lbl, y + 30);
                ViewCatsCanvas.Children.Add(lbl);

                TextBlock nameBlock = new TextBlock();
                nameBlock.Text = "Nome: " + CatteryWPF.CatManagement.Cats[i].Name;
                nameBlock.TextAlignment = TextAlignment.Center;
                nameBlock.Width = SIDE_SIZE;
                nameBlock.FontSize = 20;
                Canvas.SetLeft(nameBlock, x);
                Canvas.SetTop(nameBlock, y + SIDE_SIZE + 40);
                ViewCatsCanvas.Children.Add(nameBlock);

                ScrollViewer scrollViewer = new ScrollViewer();
                scrollViewer.Width = SIDE_SIZE;
                scrollViewer.Height = 50;
                scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

                TextBlock description = new TextBlock();
                description.Text = CatteryWPF.CatManagement.Cats[i].Description;
                description.TextWrapping = TextWrapping.Wrap;
                description.FontSize = 15;
                scrollViewer.Content = description;

                Canvas.SetLeft(scrollViewer, x);
                Canvas.SetTop(scrollViewer, y + SIDE_SIZE + 80);
                ViewCatsCanvas.Children.Add(scrollViewer);

                Button adoptButton = new Button();
                adoptButton.Content = "Adopt";
                adoptButton.Width = 100;
                adoptButton.Height = 40;
                adoptButton.Background = Brushes.Green;
                adoptButton.Foreground = Brushes.Black;
                adoptButton.BorderBrush = Brushes.Transparent;
                adoptButton.Click += (sender, e) => { selectedCatIndex = i; MessageBox.Show($"Selected Cat Index: {selectedCatIndex}"); };

                Canvas.SetLeft(adoptButton, x + (SIDE_SIZE / 2) - 50);
                Canvas.SetTop(adoptButton, y + SIDE_SIZE + 140);
                ViewCatsCanvas.Children.Add(adoptButton);

                pixelsum += (SIDE_SIZE + SPACING_DISTANCE);
                if (pixelsum > ViewCatsCanvas.Width)
                {
                    changeLine = true;
                    rows++;
                    pixelsum = 0;
                    y += (SIDE_SIZE + SPACING_DISTANCE + 180);
                }
            }
        }

    }
}

