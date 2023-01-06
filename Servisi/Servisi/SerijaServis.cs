using BazaPodataka;
using Modeli;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Servisi.Servisi
{
    public class SerijaServis
    {
        private ProdKucaModel prodKuca;
        private ReziserModel reziser;

        public List<SerijaModel> GetSerijas()
        {
            List<SerijaModel> lista = new List<SerijaModel>();
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit("SELECT * FROM projektbp2.Serija INNER JOIN projektbp2.Reziser ON projektbp2.Serija.Reziser_Reziser_id = Reziser.Reziser_id INNER JOIN projektbp2.Produkcijska_kuca ON projektbp2.Serija.Produkcijska_kuca_Produkcijska_kuca_id = projektbp2.Produkcijska_kuca.Produkcijska_kuca_id;");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                SerijaModel serija = new SerijaModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 0),
                    Naziv = ReaderMethods.SafeGetString(reader, 1),
                    Opis = ReaderMethods.SafeGetString(reader, 2),
                    Ocjena_kritike = ReaderMethods.SafeGetInt32(reader,4),
                    Popularnost = ReaderMethods.SafeGetInt32(reader, 5),
                };

                reziser = new ReziserModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 7),
                    Ime = ReaderMethods.SafeGetString(reader, 8),
                    Prezime = ReaderMethods.SafeGetString(reader, 9),
                    Email = ReaderMethods.SafeGetString(reader, 10),
                    Osvojio_nagradu = ReaderMethods.SafeGetBoolean(reader, 11),
                    Nagrada = ReaderMethods.SafeGetString(reader, 12)
                };

                prodKuca = new ProdKucaModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 13),
                    Naziv = ReaderMethods.SafeGetString(reader, 14),
                    Zemlja_porijekla = ReaderMethods.SafeGetString(reader, 15)
                };

                serija.ProdKuca = prodKuca;
                serija.Reziser = reziser;
                lista.Add(serija);
            }
            GlobalDB.ZatvoriVezu();
            return lista;
        }

        public void DodajSeriju(SerijaModel serija)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Serija VALUES (default, '{serija.Naziv}', '{serija.Opis}', {serija.Ocjena_kritike}, {serija.Popularnost}, {serija.ProdKuca.Id}, {serija.Reziser.Id});");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }
        public void PromijeniSeriju(SerijaModel serija)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"UPDATE Serija SET Naziv = '{serija.Naziv}', Opis = '{serija.Opis}', Ocjena_kritike = {serija.Ocjena_kritike}, Popularnost = {serija.Popularnost}, Produkcijska_kuca_Produkcijska_kuca_id = {serija.ProdKuca.Id}, Reziser_Reziser_id = {serija.Reziser.Id} WHERE Serija_id = {serija.Id};");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }
        public void ObrisiSeriju(SerijaModel serija)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"DELETE FROM Serija WHERE Serija_id = {serija.Id};");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }
    }
}
