using cattery;
using catteryLib;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace catteryConsole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CatManagementWPF = new ManageCat();
            ManageAdoptionWPF= new ManageAdoption(CatManagementWPF);
            CatteryWPF=  new Cattery(CatManagementWPF,ManageAdoptionWPF);
        }
        //devo mettere finti dati per farlo andare  ed infine il json serializer
        public ManageCat CatManagementWPF { get; set; }
        public ManageAdoption ManageAdoptionWPF { get; set; }
        public Cattery CatteryWPF { get; set; }
        private void btn_AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            //do per scontato che il sender  sia il bottone, pk non lo  chiamo da altre parti.
            ViewCatsWPF newWindow = new ViewCatsWPF(CatteryWPF,this);
            newWindow.Show();
            this.Hide();
        }
    }
}