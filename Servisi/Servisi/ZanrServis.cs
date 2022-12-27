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
    public class ZanrServis
    {
        public List<ZanrModel> GetZanrove()
        {
            List<ZanrModel> lista = new List<ZanrModel>();

            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit("SELECT * FROM Zanr;");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                ZanrModel zanr = new ZanrModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 0),
                    Naziv = ReaderMethods.SafeGetString(reader, 1),
                    Opis = ReaderMethods.SafeGetString(reader, 2)
                };
                lista.Add(zanr);
            }

            GlobalDB.ZatvoriVezu();
            return lista;
        }

        public void DodajZanr(ZanrModel zanr)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Zanr VALUES (default, '{zanr.Naziv}', '{zanr.Opis}');");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void PromijeniZanr(ZanrModel zanr)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"UPDATE Zanr SET Naziv = '{zanr.Naziv}', Opis = '{zanr.Opis}' WHERE Zanr_id = {zanr.Id};");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void ObrisiZanr(ZanrModel zanr)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"DELETE FROM Zanr WHERE {zanr.Id} = Zanr_id;");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }
    }
}
