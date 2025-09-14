using cattery;
using catteryLib;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.IO;
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
    public partial class AfterLoginWPF : Window
    {
        public AfterLoginWPF(Adopter adopter)
        {
            /*
            InitializeComponent();
            CatManagementWPF = new ManageCat();
            AdoptionManagementWPF= new ManageAdoption();
            CatManagementWPF.Cats.Add(new Cat("jo", "pastor", Sex.Male, "as", new DateOnly(1999, 12, 13), new DateOnly(1999, 12, 14), null, "cat1.jpg"));
            CatManagementWPF.Cats.Add(new Cat("benjamin", "pastor", Sex.Male, "fdsd", new DateOnly(1999, 12, 13), new DateOnly(1999, 12, 14), null,"cat2.jpg"));
            CatManagementWPF.Cats.Add(new Cat("rocco", "bau", Sex.Male, "asdjhkashjg", new DateOnly(1929, 9, 13), new DateOnly(1999, 12, 14), null, null));
            CatManagementWPF.Cats.Add(new Cat("Mohammed", "labrador", Sex.Male, "ciao can", new DateOnly(1939, 11, 13), new DateOnly(1999, 12, 14), null, null));
            CatteryWPF =  new Cattery(CatManagementWPF,AdoptionManagementWPF);
            CatteryWPF.AdoptCat(CatManagementWPF.Cats[0], new Adopter("a", "a", "a", "A"), new DateOnly(2023, 12, 12));
            SerializeCatAndAdoptionManagement();
            */
            //usato per generare  il file da deserializzare
            
            InitializeComponent();
            DeserializeCatAndAdoptionManagement();
            CurrentUser = adopter;
            Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources","OtherEffects", "bg.png"))));
            CatteryWPF = new Cattery(CatManagementWPF, AdoptionManagementWPF);
        }
        public Adopter CurrentUser { get; private set; }
        private void DeserializeCatAndAdoptionManagement()
        {
            string catsJson = File.ReadAllText("cats.json");

            CatManagementWPF = JsonSerializer.Deserialize<ManageCat>(catsJson);
            

            string adoptionsJson = File.ReadAllText("adoptions.json");
            AdoptionManagementWPF = JsonSerializer.Deserialize<ManageAdoption>(adoptionsJson);
        }

        public void SerializeCatAndAdoptionManagement() 
        {
            string cats = JsonSerializer.Serialize(CatManagementWPF);
            File.WriteAllText("cats.json", cats);//importato system IO
            string adoptions = JsonSerializer.Serialize(AdoptionManagementWPF);
            File.WriteAllText("adoptions.json",adoptions);
        }
        //devo mettere finti dati per farlo andare  ed infine il json serializer
        public ManageCat CatManagementWPF { get; set; }
        public ManageAdoption AdoptionManagementWPF { get; set; }
        public Cattery CatteryWPF { get; set; }
        private void btn_ViewCats_Click(object sender, RoutedEventArgs e)
        {
            //do per scontato che il sender  sia il bottone, pk non lo  chiamo da altre parti.
            ViewCatsWPF newWindow = new ViewCatsWPF(CatteryWPF,this);
            newWindow.Show();
            this.Hide();
        }
        private void btn_ViewAdoptions_Click(object sender, RoutedEventArgs e)
        {
            ViewAdoptionsWPF newWindow = new ViewAdoptionsWPF(CatteryWPF, this);
            newWindow.Show();
            this.Hide();
        }
    }
}