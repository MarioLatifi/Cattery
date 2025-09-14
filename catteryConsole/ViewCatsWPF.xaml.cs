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
        private int _currentCatIndex = -1; // Variabile per memorizzare l'indice del gatto selezionato  
        public Cattery CatteryWPF;
        private AfterLoginWPF MainWPF;

        public ViewCatsWPF(Cattery cattery, AfterLoginWPF mainWPF)
        {
            CatteryWPF = cattery;
            InitializeComponent();
            GenerateLabel(CatteryWPF.CatManagement.Cats.Count());
            MainWPF = mainWPF;
            // Pulsante Torna indietro
            Button backButton = new Button();
            backButton.Content = "Torna indietro";
            backButton.Width = 150;
            backButton.Height = 50;
            backButton.Background = Brushes.Gray;
            backButton.Foreground = Brushes.White;
            backButton.FontSize = 18;
            backButton.BorderBrush = Brushes.Transparent;
            backButton.Click += (sender, e) =>
            {
                MainWPF.Show();
                this.Close();
            };

            // Posiziona il pulsante in basso a sinistra
            Canvas.SetLeft(backButton, 20);
            Canvas.SetTop(backButton, ViewCatsCanvas.Height - backButton.Height - 20);
            ViewCatsCanvas.Children.Add(backButton);

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

                Button moreButton = new Button();
                moreButton.Content = "Altro..";
                moreButton.Width = 100;
                moreButton.Height = 40;
                moreButton.Background = Brushes.Blue;
                moreButton.Foreground = Brushes.White;
                moreButton.BorderBrush = Brushes.Transparent;
                int currentIndex = i; // Cattura l'indice corrente per l'uso nel gestore eventi  
                moreButton.Click += (sender, e) =>
                {
                    _currentCatIndex = currentIndex;
                    CatOverViewWPF catOverview = new CatOverViewWPF(CatteryWPF.CatManagement.Cats[_currentCatIndex],MainWPF);
                    
                    catOverview.Show();
                    this.Close();
                };

                Canvas.SetLeft(moreButton, x + (SIDE_SIZE / 2) - 50);
                Canvas.SetTop(moreButton, y + SIDE_SIZE + 140);
                ViewCatsCanvas.Children.Add(moreButton);

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

