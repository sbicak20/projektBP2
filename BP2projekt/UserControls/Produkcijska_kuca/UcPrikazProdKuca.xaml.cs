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
    /// Interaction logic for UcPrikazProdKuca.xaml
    /// </summary>
    public partial class UcPrikazProdKuca : UserControl
    {
        public UcPrikazProdKuca()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            dgProdKuce.ItemsSource = GlobalService.ProdKucaServis.GetProdKucas();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgProdKuce.SelectedItem != null)
            {
                ProdKucaModel dohvacenaProdKuca = (ProdKucaModel)dgProdKuce.SelectedItem;
                if (dohvacenaProdKuca != null)
                {
                    GlobalService.ProdKucaServis.ObrisiProdKucu(dohvacenaProdKuca);
                    Refresh();
                }
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcDodajProdKucu());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
