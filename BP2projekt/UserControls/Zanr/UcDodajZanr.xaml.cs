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
    /// Interaction logic for UcDodajZanr.xaml
    /// </summary>
    public partial class UcDodajZanr : UserControl
    {
        public UcDodajZanr()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            ZanrModel zanr = new ZanrModel
            {
                Naziv = txtNaziv.Text,
                Opis= txtOpis.Text,
            };
            GlobalService.ZanrServis.DodajZanr(zanr);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }
    }
}
