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

namespace BP2projekt.UserControls.Glumac
{
    /// <summary>
    /// Interaction logic for UcPrikazGlumaca.xaml
    /// </summary>
    public partial class UcPrikazGlumaca : UserControl
    {
        public UcPrikazGlumaca()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            dgGlumci.ItemsSource = GlobalService.GlumacServis.GetGlumce();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcDodajGlumca());
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgGlumci.SelectedItem != null)
            {
                GlumacModel dohvaceniGlumac = (GlumacModel)dgGlumci.SelectedItem;
                if (dohvaceniGlumac != null)
                {
                    GlobalService.GlumacServis.ObrisiGlumca(dohvaceniGlumac);
                    Refresh();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
