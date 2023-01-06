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
    /// Interaction logic for UcDodajFilm.xaml
    /// </summary>
    public partial class UcDodajFilm : UserControl
    {
        public UcDodajFilm()
        {
            InitializeComponent();
        }

        private void LoadCMB()
        {
            cmbProdKuca.ItemsSource = GlobalService.ProdKucaServis.GetProdKucas();
            cmbReziser.ItemsSource = GlobalService.RezServis.GetRezisers();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {

            FilmModel film = new FilmModel();
            
            film.Naziv = txtNaziv.Text;
            film.Trajanje = TimeSpan.Parse(txtTrajanje.Text);
            film.Opis = txtOpis.Text;
            film.Reziser = cmbReziser.SelectedItem as ReziserModel;
            film.ProdKuca = cmbProdKuca.SelectedItem as ProdKucaModel;
            film.Dob = int.Parse(txtDob.Text);
            film.Popularnost = int.Parse(txtPopularnost.Text);
            film.OcjenaKritike = int.Parse(txtOcjenaKritike.Text);

            GlobalService.FilmServis.DodajFilm(film);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCMB();
        }
    }
}
