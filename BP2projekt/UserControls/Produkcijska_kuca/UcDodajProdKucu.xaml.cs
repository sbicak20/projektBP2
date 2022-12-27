using BazaPodataka;
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

namespace BP2projekt.UserControls.Produkcijska_kuca
{
    /// <summary>
    /// Interaction logic for UcDodajProdKucu.xaml
    /// </summary>
    public partial class UcDodajProdKucu : UserControl
    {
        private ProdKucaModel prodKuca;
        public UcDodajProdKucu()
        {
            InitializeComponent();
            prodKuca = new ProdKucaModel();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            prodKuca.Zemlja_porijekla = txtZemljaPorijekla.Text;
            prodKuca.Naziv = txtNaziv.Text;

            GlobalService.ProdKucaServis.DodajProdKucu(prodKuca);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }
    }
}
