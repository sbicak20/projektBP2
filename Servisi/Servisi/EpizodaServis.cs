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
    public class EpizodaServis
    {
        public List<EpizodaModel> GetEpizodas(int id)
        {
            List<EpizodaModel> lista = new List<EpizodaModel>();
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"SELECT * FROM Epizoda WHERE Sezona_Sezona_id = {id};");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                EpizodaModel epizoda = new EpizodaModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 0),
                    Naziv = ReaderMethods.SafeGetString(reader, 1),
                    Datum_izlaska = reader.GetDateTime(2),
                    Trajanje = reader.GetTimeSpan(3),
                    Sezona_id = ReaderMethods.SafeGetInt32(reader, 4)
                };
                lista.Add(epizoda);
            }
            GlobalDB.ZatvoriVezu();
            return lista;
        }

        public void DodajEpizodu(EpizodaModel epizoda)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Epizoda VALUES (default, '{epizoda.Naziv}', '{epizoda.Datum_izlaska:yyyy-MM-dd}', '{epizoda.Trajanje}', {epizoda.Sezona_id});");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void PromijeniEpizodu(EpizodaModel epizoda)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"UPDATE Epizoda SET Naziv = '{epizoda.Naziv}', Trajanje = '{epizoda.Trajanje}', Datum_izlaska = '{epizoda.Datum_izlaska:yyyy-MM-dd}', Sezona_Sezona_id = {epizoda.Sezona_id} WHERE Epizoda_id = {epizoda.Id};");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void ObrisiEpizodu(EpizodaModel epizoda)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"DELETE FROM Epizoda WHERE {epizoda.Id} = Epizoda_id;");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }
    }
}
