using Modeli;
using Servisi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for UcDodajSezonu.xaml
    /// </summary>
    public partial class UcDodajSezonu : UserControl
    {
        private SerijaModel serija;
        public UcDodajSezonu(SerijaModel serija)
        {
            InitializeComponent();
            this.serija = serija;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            SezonaModel sezona = new SezonaModel();

            sezona.Naziv = txtNaziv.Text;
            sezona.Opis = txtOpis.Text;
            sezona.Ocjena_kritike = int.Parse(txtOcjenaKritike.Text);
            sezona.Datum_izlaska = (DateTime)cldDatumIzlaska.SelectedDate;
            sezona.Serija_id = serija.Id;
            sezona.Broj_epizoda = 0;

            GlobalService.SezonaServis.DodajSezonu(sezona);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtSerijaId.Text = serija.Id.ToString();
            txtSerijaNaziv.Text = serija.Naziv;
        }
    }
}
