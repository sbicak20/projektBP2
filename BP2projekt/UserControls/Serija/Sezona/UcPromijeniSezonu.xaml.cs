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

namespace BP2projekt.UserControls.Serija.Sezona
{
    /// <summary>
    /// Interaction logic for UcPromijeniSezonu.xaml
    /// </summary>
    public partial class UcPromijeniSezonu : UserControl
    {
        private SezonaModel sezona;
        public UcPromijeniSezonu(SezonaModel sezona)
        {
            InitializeComponent();
            this.sezona = sezona;
        }

        private void btnPromijeni_Click(object sender, RoutedEventArgs e)
        {
           
            sezona.Naziv = txtNaziv.Text;
            sezona.Opis = txtOpis.Text;
            sezona.Ocjena_kritike = int.Parse(txtOcjenaKritike.Text);
            sezona.Datum_izlaska = (DateTime)cldDatumIzlaska.SelectedDate;

            GlobalService.SezonaServis.PromijeniSezonu(sezona);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtNaziv.Text = sezona.Naziv;
            txtOcjenaKritike.Text = sezona.Ocjena_kritike.ToString();
            txtOpis.Text = sezona.Opis;
            cldDatumIzlaska.SelectedDate = sezona.Datum_izlaska;

            txtSerijaId.Text = sezona.Serija_id.ToString();
        }
    }
}
