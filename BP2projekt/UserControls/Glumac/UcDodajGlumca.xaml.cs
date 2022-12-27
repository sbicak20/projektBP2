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
    /// Interaction logic for UcDodajGlumca.xaml
    /// </summary>
    public partial class UcDodajGlumca : UserControl
    {
        public UcDodajGlumca()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            GlumacModel glumac = new GlumacModel
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
            };

            GlobalService.GlumacServis.DodajGlumca(glumac);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }
    }
}
