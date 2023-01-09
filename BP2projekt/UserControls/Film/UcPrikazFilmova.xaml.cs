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

namespace BP2projekt.UserControls.Film
{
    /// <summary>
    /// Interaction logic for UcPrikazFilmova.xaml
    /// </summary>
    public partial class UcPrikazFilmova : UserControl
    {
        public UcPrikazFilmova()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            dgFilmovi.ItemsSource = GlobalService.FilmServis.GetFilms();
        }

        private FilmModel DohvatiFilm()
        {
            return dgFilmovi.SelectedItem as FilmModel;
        }

        private void RefreshGlumciZanr(FilmModel film)
        {
            dgGlumci.ItemsSource = GlobalService.GlumacServis.GetGlumceZaFilm(film.Id);
            dgZanrovi.ItemsSource = GlobalService.ZanrServis.GetZanroveZaFilm(film.Id);
        }

        private void LoadCMB()
        {
            cmbDodajGlumca.ItemsSource = GetGlumceZaCMB();
            cmbDodajZanr.ItemsSource = GetZanroveZaCMB();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.OpenContent(new UcDodajFilm());
        }

        private void btnPromijeni_Click(object sender, RoutedEventArgs e)
        {
            FilmModel dohvaceniFilm = DohvatiFilm();
            GuiManager.OpenContent(new UcPromijeniFilm(dohvaceniFilm));
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            FilmModel dohvaceniFilm = (FilmModel)dgFilmovi.SelectedItem;
            if (dohvaceniFilm != null)
            {
                GlobalService.FilmServis.ObrisiFilm(dohvaceniFilm);
                Refresh();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void btnDodajGlumca_Click(object sender, RoutedEventArgs e)
        {
            GlumacModel glumac = cmbDodajGlumca.SelectedItem as GlumacModel;
            FilmModel dohvaceniFilm = (FilmModel)dgFilmovi.SelectedItem;
            if (dohvaceniFilm != null)
            {
                LoadCMB();
                GlobalService.GlumacServis.DodajGlumcaZaFilm(glumac, dohvaceniFilm.Id);
                RefreshGlumciZanr(dohvaceniFilm);
            }
        }

        private void btnDodajZanr_Click(object sender, RoutedEventArgs e)
        {
            ZanrModel zanr = cmbDodajZanr.SelectedItem as ZanrModel;
            FilmModel dohvaceniFilm = (FilmModel)dgFilmovi.SelectedItem;
            if (dohvaceniFilm != null)
            {
                LoadCMB();
                GlobalService.ZanrServis.DodajZanrZaFilm(dohvaceniFilm.Id, zanr);
                RefreshGlumciZanr(dohvaceniFilm);
            }
        }

        private void dgFilmovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilmModel dohvaceniFilm = (FilmModel)dgFilmovi.SelectedItem;
            if (dohvaceniFilm != null)
            {
                RefreshGlumciZanr(dohvaceniFilm);
                LoadCMB();
            }
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
    }
}
