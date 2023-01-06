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

namespace BP2projekt.UserControls.Serija.Sezona.Epizoda
{
    /// <summary>
    /// Interaction logic for UcPromijeniEpizodu.xaml
    /// </summary>
    public partial class UcPromijeniEpizodu : UserControl
    {
        private EpizodaModel epizoda;
        public UcPromijeniEpizodu(EpizodaModel epizoda)
        {
            InitializeComponent();
            this.epizoda = epizoda;
        }

        private void btnPromijeni_Click(object sender, RoutedEventArgs e)
        {

            epizoda.Naziv = txtNaziv.Text;
            epizoda.Datum_izlaska = (DateTime)cldDatumIzlaska.SelectedDate;
            epizoda.Trajanje = TimeSpan.Parse(txtTrajanje.Text);

            GlobalService.EpizodaServis.PromijeniEpizodu(epizoda);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtNaziv.Text = epizoda.Naziv;
            txtSezonaId.Text = epizoda.Sezona_id.ToString();
            txtTrajanje.Text = epizoda.Trajanje.ToString();
            cldDatumIzlaska.SelectedDate = epizoda.Datum_izlaska;
        }
    }
}
