using BazaPodataka;
using Modeli;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Servisi
{
    public class ReziserServis
    {
        public List<ReziserModel> GetRezisers()
        {
            List<ReziserModel> lista = new List<ReziserModel>();

            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit("SELECT * FROM Reziser;");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                ReziserModel reziser = new ReziserModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 0),
                    Ime = ReaderMethods.SafeGetString(reader, 1),
                    Prezime = ReaderMethods.SafeGetString(reader, 2),
                    Email = ReaderMethods.SafeGetString(reader, 3),
                    Osvojio_nagradu = ReaderMethods.SafeGetBoolean(reader, 4),
                    Nagrada = ReaderMethods.SafeGetString(reader, 5)
                };
                lista.Add(reziser);
            }

            GlobalDB.ZatvoriVezu();
            return lista;
        }

        public void DodajRezisera(ReziserModel reziser)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Reziser VALUES (default, '{reziser.Ime}', '{reziser.Prezime}', '{reziser.Email}', default, '{reziser.Nagrada}');");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void ObrisiRezisera(ReziserModel reziser)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"DELETE FROM Reziser WHERE '{reziser.Id}' = Reziser_id;");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }
    }
}
