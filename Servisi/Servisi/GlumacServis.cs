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
    public class GlumacServis
    {
        public List<GlumacModel> GetGlumce()
        {
            List<GlumacModel> lista = new List<GlumacModel>();

            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit("SELECT * FROM Glumac;");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                GlumacModel glumac = new GlumacModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 0),
                    Ime = ReaderMethods.SafeGetString(reader, 1),
                    Prezime = ReaderMethods.SafeGetString(reader, 2)
                };
                lista.Add(glumac);
            }

            GlobalDB.ZatvoriVezu();
            return lista;
        }

        public List<GlumacModel> GetGlumceZaFilm(int id)
        {
            List<GlumacModel> lista = new List<GlumacModel>();

            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"SELECT * FROM projektbp2.Glumac_Glumi_Film LEFT JOIN projektbp2.Glumac ON projektbp2.Glumac_Glumi_Film.Glumac_Glumac_id = projektbp2.Glumac.Glumac_id WHERE projektbp2.Glumac_Glumi_Film.Film_Film_id = {id};");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                GlumacModel glumac = new GlumacModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 2),
                    Ime = ReaderMethods.SafeGetString(reader, 3),
                    Prezime = ReaderMethods.SafeGetString(reader, 4)
                };
                lista.Add(glumac);
            }

            GlobalDB.ZatvoriVezu();
            return lista;
        }

        public List<GlumacModel> GetGlumceZaSeriju(int id)
        {
            List<GlumacModel> lista = new List<GlumacModel>();

            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"SELECT * FROM projektbp2.Glumac_glumi_Serija LEFT JOIN projektbp2.Glumac ON projektbp2.Glumac_glumi_Serija.Glumac_Glumac_id = projektbp2.Glumac.Glumac_id WHERE projektbp2.Glumac_glumi_Serija.Serija_Serija_id = {id};");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                GlumacModel glumac = new GlumacModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 2),
                    Ime = ReaderMethods.SafeGetString(reader, 3),
                    Prezime = ReaderMethods.SafeGetString(reader, 4)
                };
                lista.Add(glumac);
            }

            GlobalDB.ZatvoriVezu();
            return lista;
        }

        public void DodajGlumca(GlumacModel glumac)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Glumac VALUES (default, '{glumac.Ime}', '{glumac.Prezime}');");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void DodajGlumcaZaFilm(GlumacModel glumac, int id)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Glumac_glumi_Film VALUES ({glumac.Id}, {id});");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void DodajGlumcaZaSeriju(GlumacModel glumac, int id)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Glumac_glumi_Serija VALUES ({glumac.Id}, {id});");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void ObrisiGlumca(GlumacModel glumac)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"DELETE FROM Glumac WHERE {glumac.Id} = Glumac_id;");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }
    }
}
