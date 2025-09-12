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
        
        public ViewCatsWPF(Cattery cattery,MainWindow mainWPF)
        {
            CatteryWPF=cattery;
            InitializeComponent();
            GenerateLabel(CatteryWPF.CatManagement.Cats.Count());
            MainWPF=mainWPF;
        }
        private MainWindow MainWPF;
        public Cattery CatteryWPF;
        //voglio che sia autoregolabile quindi dopo tot quadrati si sposti nella fila sotto dato che non ci sta
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
                Label lbl = new Label();
                lbl.Width = SIDE_SIZE;
                lbl.Height = SIDE_SIZE;
                
                lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                lbl.VerticalContentAlignment = VerticalAlignment.Center;
                //e ora modifico il colore della label in blu
                
                string imageFile = System.IO.Path.Combine(catImagesPath, CatteryWPF.CatManagement.Cats[i].CatImage);
                lbl.Background = new ImageBrush(new BitmapImage(new Uri(imageFile, UriKind.Absolute)));
                
                if (i == 0||changeLine)
                {
                     x = 90;
                    changeLine = false;
                }
                else { x +=(SIDE_SIZE+SPACING_DISTANCE); }
                
                pixelsum += x;
                Canvas.SetLeft(lbl, x);
                Canvas.SetTop(lbl, y);
                ViewCatsCanvas.Children.Add(lbl);
                if(pixelsum > ViewCatsCanvas.Width)
                {
                    changeLine = true;
                    rows++;
                    pixelsum = 0;
                    y += (SIDE_SIZE + SPACING_DISTANCE);
                }

            }
        }
    }
}
