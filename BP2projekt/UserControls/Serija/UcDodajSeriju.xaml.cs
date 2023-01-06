using Modeli;
using Servisi;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BP2projekt.UserControls.Serija
{
    /// <summary>
    /// Interaction logic for UcDodajSeriju.xaml
    /// </summary>
    public partial class UcDodajSeriju : UserControl
    {
        public UcDodajSeriju()
        {
            InitializeComponent();
        }

        private void LoadCMB()
        {
            cmbProdKuca.ItemsSource = GlobalService.ProdKucaServis.GetProdKucas();
            cmbReziser.ItemsSource = GlobalService.RezServis.GetRezisers();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            SerijaModel serija = new SerijaModel();

            serija.Naziv = txtNaziv.Text;
            serija.Opis = txtOpis.Text;
            serija.Ocjena_kritike = int.Parse(txtOcjenaKritike.Text);
            serija.Popularnost = int.Parse(txtPopularnost.Text);

            serija.ProdKuca = cmbProdKuca.SelectedItem as ProdKucaModel;
            serija.Reziser =  cmbReziser.SelectedItem as ReziserModel;

            GlobalService.SerijaServis.DodajSeriju(serija);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCMB();
        }
    }
}
