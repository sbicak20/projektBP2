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

namespace BP2projekt.UserControls.Serija.Sezona.Epizoda
{
    /// <summary>
    /// Interaction logic for UcDodajEpizodu.xaml
    /// </summary>
    public partial class UcDodajEpizodu : UserControl
    {
        private SezonaModel sezona;

        public UcDodajEpizodu(SezonaModel sezona)
        {
            InitializeComponent();
            this.sezona = sezona;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            EpizodaModel epizoda = new EpizodaModel();

            epizoda.Naziv = txtNaziv.Text;
            epizoda.Datum_izlaska = (DateTime)cldDatumIzlaska.SelectedDate;
            epizoda.Sezona_id = sezona.Id;
            epizoda.Trajanje = TimeSpan.Parse(txtTrajanje.Text);

            GlobalService.EpizodaServis.DodajEpizodu(epizoda);
            GuiManager.CloseContent();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            GuiManager.CloseContent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtSezonaId.Text = sezona.Id.ToString();
        }
    }
}
