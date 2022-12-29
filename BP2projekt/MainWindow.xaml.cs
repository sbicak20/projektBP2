using BazaPodataka;
using BP2projekt.UserControls.Film;
using BP2projekt.UserControls.Glumac;
using BP2projekt.UserControls.Produkcijska_kuca;
using BP2projekt.UserControls.Reziser;
using BP2projekt.UserControls.Zanr;
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

namespace BP2projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPrikazFilmova_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcPrikazFilmova());
        }

        private void btnPrikazSerija_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrikazRez_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcPrikazRezisera());
        }

        private void btnPrikazProd_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcPrikazProdKuca());
        }

        private void btnPrikazZanrova_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcPrikazZanrova());
        }

        private void btnCrtice_Click(object sender, RoutedEventArgs e)
        {
            GlobalDB.ConClose();
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GuiManager.mainWindow = this;
        }

        private void btnGlumci_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcPrikazGlumaca());
        }
    }
}
