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

        public List<ZanrModel> GetZanroveZaFilm(int id)
        {
            List<ZanrModel> lista = new List<ZanrModel>();

            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"SELECT * FROM projektbp2.Film_pripada_Zanr LEFT JOIN projektbp2.Zanr ON projektbp2.Film_pripada_Zanr.Zanr_Zanr_id = projektbp2.Zanr.Zanr_id WHERE projektbp2.Film_pripada_Zanr.Film_Film_id = {id};");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                ZanrModel zanr = new ZanrModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 2),
                    Naziv = ReaderMethods.SafeGetString(reader, 3),
                    Opis = ReaderMethods.SafeGetString(reader, 4)
                };
                lista.Add(zanr);
            }

            GlobalDB.ZatvoriVezu();
            return lista;
        }

        public List<ZanrModel> GetZanroveZaSeriju(int id)
        {
            List<ZanrModel> lista = new List<ZanrModel>();

            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"SELECT * FROM projektbp2.Serija_pripada_Zanr LEFT JOIN projektbp2.Zanr ON projektbp2.Serija_pripada_Zanr.Zanr_Zanr_id = projektbp2.Zanr.Zanr_id WHERE projektbp2.Serija_pripada_Zanr.Serija_Serija_id = {id};");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                ZanrModel zanr = new ZanrModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 2),
                    Naziv = ReaderMethods.SafeGetString(reader, 3),
                    Opis = ReaderMethods.SafeGetString(reader, 4)
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

        public void DodajZanrZaFilm(int id, ZanrModel zanr)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Film_pripada_zanr VALUES ({id},{zanr.Id});");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void DodajZanrZaSeriju(int id, ZanrModel zanr)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Serija_pripada_zanr VALUES ({id},{zanr.Id});");
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
