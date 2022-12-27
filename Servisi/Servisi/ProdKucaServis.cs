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
    public class ProdKucaServis
    {
        public List<ProdKucaModel> GetProdKucas()
        {
            List<ProdKucaModel> lista = new List<ProdKucaModel>();

            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit("SELECT * FROM Produkcijska_kuca;");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                ProdKucaModel prodKuca = new ProdKucaModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 0),
                    Naziv =  ReaderMethods.SafeGetString(reader, 1),
                    Zemlja_porijekla = ReaderMethods.SafeGetString(reader, 2)  
                };
                lista.Add(prodKuca);
            }

            GlobalDB.ZatvoriVezu();
            return lista;
        }

        public void DodajProdKucu(ProdKucaModel prodKuca)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Produkcijska_kuca VALUES (default, '{prodKuca.Naziv}', '{prodKuca.Zemlja_porijekla}');");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void ObrisiProdKucu(ProdKucaModel prodKuca)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"DELETE FROM Produkcijska_kuca WHERE {prodKuca.Id} = Produkcijska_kuca_id;");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }
    }
}
