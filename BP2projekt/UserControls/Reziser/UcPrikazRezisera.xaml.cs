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

namespace BP2projekt.UserControls.Reziser
{
    /// <summary>
    /// Interaction logic for UcPrikazRezisera.xaml
    /// </summary>
    public partial class UcPrikazRezisera : UserControl
    {
        public UcPrikazRezisera()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            dgReziseri.ItemsSource = GlobalService.RezServis.GetRezisers();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcDodajRezisera());
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgReziseri.SelectedItem != null)
            {
                ReziserModel dohvaceniReziser = (ReziserModel)dgReziseri.SelectedItem;
                if (dohvaceniReziser != null)
                {
                    GlobalService.RezServis.ObrisiRezisera(dohvaceniReziser);
                    Refresh();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void dgReziseri_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
