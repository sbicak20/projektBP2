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
    /// Interaction logic for UcPromijeniFilm.xaml
    /// </summary>
    public partial class UcPromijeniFilm : UserControl
    {

        private FilmModel film;
        public UcPromijeniFilm(FilmModel film)
        {
            InitializeComponent();
            this.film = film;
        }

        private void btnPromijeni_Click(object sender, RoutedEventArgs e)
        {
            film.Naziv = txtNaziv.Text;
            film.Trajanje = TimeSpan.Parse(txtTrajanje.Text);
            film.Opis = txtOpis.Text;
            film.Reziser = cmbReziser.SelectedItem as ReziserModel;
            film.ProdKuca = cmbProdKuca.SelectedItem as ProdKucaModel;
            film.Dob = int.Parse(txtDob.Text);
            film.Popularnost = int.Parse(txtPopularnost.Text);
            film.OcjenaKritike = int.Parse(txtOcjenaKritike.Text);

            GlobalService.FilmServis.PromijeniFilm(film);
            GuiManager.CloseContent();
        }
        private void LoadCMB()
        {
            cmbProdKuca.ItemsSource = GlobalService.ProdKucaServis.GetProdKucas();
            cmbReziser.ItemsSource = GlobalService.RezServis.GetRezisers();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCMB();
            txtNaziv.Text = film.Naziv;
            txtDob.Text = film.Dob.ToString();
            txtOcjenaKritike.Text = film.OcjenaKritike.ToString();
            txtPopularnost.Text = film.Popularnost.ToString();
            txtTrajanje.Text = film.Trajanje.ToString();
            txtOpis.Text = film.Opis;

            for (int i = 0; i < cmbProdKuca.Items.Count; i++)
            {
                if (film.ProdKuca.Id == (cmbProdKuca.Items[i] as ProdKucaModel).Id)
                {
                    cmbProdKuca.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbReziser.Items.Count; i++)
            {
                if (film.Reziser.Id == (cmbReziser.Items[i] as ReziserModel).Id)
                {
                    cmbReziser.SelectedIndex = i;
                    break;
                }
            }

        }
    }
}
