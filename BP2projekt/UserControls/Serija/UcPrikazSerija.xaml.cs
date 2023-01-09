using BP2projekt.UserControls.Serija.Sezona;
using BP2projekt.UserControls.Serija.Sezona.Epizoda;
using Modeli;
using Servisi;
using Servisi.Servisi;
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

namespace BP2projekt.UserControls.Serija
{
    /// <summary>
    /// Interaction logic for UcPrikazSerija.xaml
    /// </summary>
    public partial class UcPrikazSerija : UserControl
    {
        public UcPrikazSerija()
        {
            InitializeComponent();
        }

        private List<GlumacModel> GetGlumceZaCMB()
        {
            List<GlumacModel> cijelaLista = GlobalService.GlumacServis.GetGlumce();
            return cijelaLista.ToList();
        }

        private List<ZanrModel> GetZanroveZaCMB()
        {
            List<ZanrModel> cijelaLista = GlobalService.ZanrServis.GetZanrove();
            return cijelaLista.ToList();
        }

        private void LoadCMB()
        {
            cmbDodajGlumca.ItemsSource = GetGlumceZaCMB();
            cmbDodajZanr.ItemsSource = GetZanroveZaCMB();
        }

        private void RefreshGlumciZanr()
        {
            dgGlumci.ItemsSource = GlobalService.GlumacServis.GetGlumceZaSeriju(GlobalSerije.dohvacenaSerija.Id);
            dgZanrovi.ItemsSource = GlobalService.ZanrServis.GetZanroveZaSeriju(GlobalSerije.dohvacenaSerija.Id);
        }


        private SezonaModel DohvatiSezonu()
        {
            return dgSezone.SelectedItem as SezonaModel;
        }

        private SerijaModel DohvatiSeriju()
        {
            return dgSerije.SelectedItem as SerijaModel;
        }

        private EpizodaModel DohvatiEpizodu()
        {
            return dgEpizode.SelectedItem as EpizodaModel;
        }

        private void RefreshSerije()
        {
            dgSerije.ItemsSource = GlobalService.SerijaServis.GetSerijas();
        }

        private void RefreshSezone(SerijaModel serija)
        {
            if (serija == null)
            {
                return;
            }
            dgSezone.ItemsSource = GlobalService.SezonaServis.GetSezona(serija.Id);
        }
        private void RefreshEpizode(SezonaModel sezona)
        {
            if (sezona == null)
            {
                return;
            }
            dgEpizode.ItemsSource = GlobalService.EpizodaServis.GetEpizodas(sezona.Id);
        }

        private void dgSerije_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSerije.CurrentItem != null)
            {
                GlobalSerije.dohvacenaSerija = DohvatiSeriju();
                RefreshSezone(GlobalSerije.dohvacenaSerija);
                RefreshGlumciZanr();
            }
        }

        private void btnDodajSeriju_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcDodajSeriju());
        }

        private void btnPromijeniSeriju_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcPromijeniSeriju(DohvatiSeriju()));
        }

        private void btnObrisiSeriju_Click(object sender, RoutedEventArgs e)
        {
            GlobalSerije.dohvacenaSerija = DohvatiSeriju();
            GlobalService.SerijaServis.ObrisiSeriju(GlobalSerije.dohvacenaSerija);
            RefreshSerije();
        }

        private void dgSezone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalSerije.dohvacenaSezona = DohvatiSezonu();
            if (GlobalSerije.dohvacenaSezona != null)
            {
                RefreshEpizode(GlobalSerije.dohvacenaSezona);
            }
            
        }

        private void btnDodajSezonu_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcDodajSezonu(GlobalSerije.dohvacenaSerija));
        }

        private void btnPromijeniSezonu_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcPromijeniSezonu(GlobalSerije.dohvacenaSezona));
        }

        private void btnObrisiSezonu_Click(object sender, RoutedEventArgs e)
        {
            GlobalSerije.dohvacenaSezona = DohvatiSezonu();
            GlobalService.SezonaServis.ObrisiSezonu(GlobalSerije.dohvacenaSezona);
            RefreshSezone(GlobalSerije.dohvacenaSerija);
            RefreshEpizode(GlobalSerije.dohvacenaSezona);
        }

        private void btnDodajEpizodu_Click(object sender, RoutedEventArgs e)
        {
            GlobalSerije.dohvacenaSezona = DohvatiSezonu();
            GuiManager.OpenContent(new UcDodajEpizodu(GlobalSerije.dohvacenaSezona));
            RefreshEpizode(GlobalSerije.dohvacenaSezona);
            RefreshSezone(GlobalSerije.dohvacenaSerija);
        }

        private void btnObrisiEpizodu_Click(object sender, RoutedEventArgs e)
        {
            EpizodaModel epizoda = DohvatiEpizodu();
            GlobalService.EpizodaServis.ObrisiEpizodu(epizoda);
            RefreshEpizode(GlobalSerije.dohvacenaSezona);
            RefreshSezone(GlobalSerije.dohvacenaSerija);
        }

        private void btnPromijeniEpizodu_Click(object sender, RoutedEventArgs e)
        {
            EpizodaModel epizoda = DohvatiEpizodu();
            GuiManager.OpenContent(new UcPromijeniEpizodu(epizoda));
            RefreshEpizode(GlobalSerije.dohvacenaSezona);
            RefreshSezone(GlobalSerije.dohvacenaSerija);
        }

        private void dgEpizode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshSerije();
            RefreshSezone(GlobalSerije.dohvacenaSerija);
            RefreshEpizode(GlobalSerije.dohvacenaSezona);
            LoadCMB();
        }

        private void btnDodajGlumca_Click(object sender, RoutedEventArgs e)
        {
            GlumacModel glumac = cmbDodajGlumca.SelectedItem as GlumacModel;
            if (GlobalSerije.dohvacenaSerija != null)
            {
                LoadCMB();
                GlobalService.GlumacServis.DodajGlumcaZaSeriju(glumac, GlobalSerije.dohvacenaSerija.Id);
                RefreshGlumciZanr();
            }
        }

        private void btnDodajZanr_Click(object sender, RoutedEventArgs e)
        {
            ZanrModel zanr = cmbDodajZanr.SelectedItem as ZanrModel;
            if (GlobalSerije.dohvacenaSerija != null)
            {
                LoadCMB();
                GlobalService.ZanrServis.DodajZanrZaSeriju(GlobalSerije.dohvacenaSerija.Id, zanr);
                RefreshGlumciZanr();
            }
        }
    }
}
