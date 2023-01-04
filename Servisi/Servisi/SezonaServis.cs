using BazaPodataka;
using Modeli;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servisi.Servisi
{
    public class SezonaServis
    {
        public List<SezonaModel> GetSezonas(int id)
        {
            List<SezonaModel> lista = new List<SezonaModel>();
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"SELECT * FROM Sezona WHERE Serija_serija_id = {id}");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                SezonaModel sezona = new SezonaModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 0),
                    Naziv = ReaderMethods.SafeGetString(reader, 1),
                    Opis = ReaderMethods.SafeGetString(reader, 2),
                    Datum_izlaska = reader.GetDateTime(3),
                    Broj_epizoda = ReaderMethods.SafeGetInt32(reader, 4),
                    Ocjena_kritike = ReaderMethods.SafeGetInt32(reader, 5),
                    Serija_id = ReaderMethods.SafeGetInt32(reader, 6),
                };
                lista.Add(sezona);
            }
            GlobalDB.ZatvoriVezu();
            return lista;
        }

        public void DodajSezonu(SezonaModel sezona)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Sezona VALUES (default, '{sezona.Naziv}', '{sezona.Opis}', GETDATE(), 0, {sezona.Ocjena_kritike}, {sezona.Serija_id};)");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void PromijeniSezonu(SezonaModel sezona)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"UPDATE Sezona SET Naziv = '{sezona.Naziv}', Opis = '{sezona.Opis}', Ocjena_kritike = {sezona.Ocjena_kritike}, Serija_serija_id = {sezona.Serija_id} WHERE Sezona = {sezona.Id};");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void ObrisiSezonu(SezonaModel sezona)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"DELETE FROM Sezona WHERE {sezona.Id} = Sezona_id;");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }
    }
}
