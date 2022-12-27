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

namespace BP2projekt.UserControls.Zanr
{
    /// <summary>
    /// Interaction logic for UcPromijeniZanr.xaml
    /// </summary>
    public partial class UcPromijeniZanr : UserControl
    {
        private ZanrModel dohvaceniZanr;
        public UcPromijeniZanr(ZanrModel zanr)
        {
            InitializeComponent();
            dohvaceniZanr = zanr;
        }

        private void btnPromijeni_Click(object sender, RoutedEventArgs e)
        {
            dohvaceniZanr.Naziv = txtNaziv.Text;
            dohvaceniZanr.Opis = txtOpis.Text;

            GlobalService.ZanrServis.PromijeniZanr(dohvaceniZanr);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtNaziv.Text = dohvaceniZanr.Naziv;
            txtOpis.Text = dohvaceniZanr.Opis;
        }
    }
}
