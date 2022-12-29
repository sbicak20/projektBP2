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
    /// Interaction logic for UcPrikazZanrova.xaml
    /// </summary>
    public partial class UcPrikazZanrova : UserControl
    {
        public UcPrikazZanrova()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            dgZanrovi.ItemsSource = GlobalService.ZanrServis.GetZanrove();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcDodajZanr());
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgZanrovi.SelectedItem != null)
            {
                ZanrModel dohvaceniZanr = (ZanrModel)dgZanrovi.SelectedItem;
                if (dohvaceniZanr != null)
                {
                    GlobalService.ZanrServis.ObrisiZanr(dohvaceniZanr);
                    Refresh();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void btnPromijeni_Click(object sender, RoutedEventArgs e)
        {
            if ((ZanrModel)dgZanrovi.SelectedItem != null){
                GuiManager.OpenContent(new UcPromijeniZanr((ZanrModel)dgZanrovi.SelectedItem));
            }
           
        }
    }
}
