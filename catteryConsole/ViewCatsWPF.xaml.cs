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
        private const int SIDE_SIZE = 50;
        private const int SPACING_DISTANCE = 10;
        public ViewCatsWPF(Cattery cattery,MainWindow mainWPF)
        {
            CatteryWPF=cattery;
            InitializeComponent();
            GenerateLabel(CatteryWPF.CatManagement.Cats.Count());
            MainWPF=mainWPF;
        }
        private MainWindow MainWPF;
        public Cattery CatteryWPF;
        private void GenerateLabel(int numberOFLabels)
        {
            for (int i = 0; i < numberOFLabels; i++)
            {
                Label lbl = new Label();
                lbl.Width = SIDE_SIZE;
                lbl.Height = SPACING_DISTANCE;
                lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                lbl.VerticalContentAlignment = VerticalAlignment.Center;
                double x = i * (SIDE_SIZE) + i * SPACING_DISTANCE;
                double y = 0;
                Canvas.SetLeft(lbl, x);
                Canvas.SetTop(lbl, y);
                ViewCatsCanvas.Children.Add(lbl);
            }
        }
    }
}
