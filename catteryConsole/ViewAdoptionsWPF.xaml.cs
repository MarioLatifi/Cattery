using System;
using System.Windows;
using System.Windows.Controls;
using cattery;
using catteryLib;

namespace catteryConsole
{
    public partial class ViewAdoptionsWPF : Window
    {
        private Cattery CatteryWPF;
        private AfterLoginWPF MainWPF;

        public ViewAdoptionsWPF(Cattery cattery, AfterLoginWPF mainWPF)
        {
            InitializeComponent();
            CatteryWPF = cattery;
            MainWPF = mainWPF;
            lvAdoptions.ItemsSource = CatteryWPF.AdoptionManagement.Adoptions;//NON lo so, me lo ha consigliato chat
                                                                              // Pulsante Torna indietro
            Button backButton = new Button();
            backButton.Content = "Torna indietro";
            backButton.Width = 150;
            backButton.Height = 50;
            backButton.Background = System.Windows.Media.Brushes.Gray;
            backButton.Foreground = System.Windows.Media.Brushes.White;
            backButton.FontSize = 18;
            backButton.BorderBrush = System.Windows.Media.Brushes.Transparent;
            backButton.Click += (sender, e) =>
            {
                MainWPF.Show();
                this.Close();
            };

            // Posiziona il pulsante in basso a sinistra
            if (this.Content is Panel panel)
            {
                panel.Children.Add(backButton);
                backButton.Margin = new Thickness(20, panel.ActualHeight - backButton.Height - 20, 0, 0);
            }

        }

        private void BtnRefund_Click(object sender, RoutedEventArgs e)
        {
            // Ottieni l'adozione associata al pulsante cliccato
            if ((sender as Button)?.DataContext is Adoption adoption)
            {
                if (adoption.AdoptionCat.LeftCattery == null)
                {
                    MessageBox.Show("Questa adozione è già stata revocata.", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    $"Vuoi revocare l'adozione di {adoption.AdoptionCat.Name}?",
                    "Conferma revoca",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    DateOnly refundDate = DateOnly.FromDateTime(DateTime.Now);
                    MainWPF.CatteryWPF.RefundCat(adoption.AdoptionCat, refundDate);
                    MainWPF.SerializeCatAndAdoptionManagement();
                    lvAdoptions.Items.Refresh();
                    MessageBox.Show("Adozione revocata!", "Revoca", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            MainWPF.SerializeCatAndAdoptionManagement();
        }
    }
}
