﻿using Modeli;
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

namespace BP2projekt.UserControls.Serija
{
    /// <summary>
    /// Interaction logic for UcPromijeniSeriju.xaml
    /// </summary>
    public partial class UcPromijeniSeriju : UserControl
    {
        private SerijaModel serija;
        public UcPromijeniSeriju(SerijaModel serija)
        {
            InitializeComponent();
            this.serija = serija;
        }

        private void LoadCMB()
        {
            cmbProdKuca.ItemsSource = GlobalService.ProdKucaServis.GetProdKucas();
            cmbReziser.ItemsSource = GlobalService.RezServis.GetRezisers();
        }

        private void btnPromijeni_Click(object sender, RoutedEventArgs e)
        {
            serija.Naziv = txtNaziv.Text;
            serija.Opis = txtOpis.Text;
            serija.Ocjena_kritike = int.Parse(txtOcjenaKritike.Text);
            serija.Popularnost = int.Parse(txtPopularnost.Text);

            serija.ProdKuca = cmbProdKuca.SelectedItem as ProdKucaModel;
            serija.Reziser = cmbReziser.SelectedItem as ReziserModel;

            GlobalService.SerijaServis.PromijeniSeriju(serija);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCMB();
            txtNaziv.Text = serija.Naziv;
            txtOpis.Text = serija.Opis;
            txtOcjenaKritike.Text = serija.Ocjena_kritike.ToString();
            txtPopularnost.Text = serija.Popularnost.ToString();

            for (int i = 0; i < cmbProdKuca.Items.Count; i++)
            {
                if (serija.ProdKuca.Id == (cmbProdKuca.Items[i] as ProdKucaModel).Id)
                {
                    cmbProdKuca.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbReziser.Items.Count; i++)
            {
                if (serija.Reziser.Id == (cmbReziser.Items[i] as ReziserModel).Id)
                {
                    cmbReziser.SelectedIndex = i;
                    break;
                }
            }

        }
    }
}
