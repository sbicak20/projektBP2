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
    public class FilmServis
    {
        private ProdKucaModel prodKuca;
        private ReziserModel reziser;
        public List<FilmModel> GetFilms()
        {
            List<FilmModel> lista = new List<FilmModel>();
            FilmModel film;
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit("SELECT * FROM projektbp2.Film INNER JOIN projektbp2.Reziser ON projektbp2.Film.Reziser_Reziser_id = Reziser.Reziser_id INNER JOIN projektbp2.Produkcijska_kuca ON projektbp2.Film.Produkcijska_kuca_Produkcijska_kuca_id = projektbp2.Produkcijska_kuca.Produkcijska_kuca_id;");
            MySqlDataReader reader = GlobalDB.PozoviReadera();

            while (reader.Read())
            {
                film = new FilmModel
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 0),
                    Naziv = ReaderMethods.SafeGetString(reader, 1),
                    Opis = ReaderMethods.SafeGetString(reader, 2),
                    Trajanje = reader.GetTimeSpan(3),
                    OcjenaKritike = ReaderMethods.SafeGetInt32(reader, 4),
                    Popularnost = ReaderMethods.SafeGetInt32(reader, 5),
                    ZaOdrasle = ReaderMethods.SafeGetBoolean(reader, 6),
                    Dob = ReaderMethods.SafeGetInt32(reader, 7),
                };

                reziser = new ReziserModel // 12
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 10),
                    Ime = ReaderMethods.SafeGetString(reader, 11),
                    Prezime = ReaderMethods.SafeGetString(reader, 12),
                    Email = ReaderMethods.SafeGetString(reader, 13),
                    Osvojio_nagradu = ReaderMethods.SafeGetBoolean(reader, 14),
                    Nagrada = ReaderMethods.SafeGetString(reader, 15)
                };

                prodKuca = new ProdKucaModel // 8
                {
                    Id = ReaderMethods.SafeGetInt32(reader, 16),
                    Naziv = ReaderMethods.SafeGetString(reader, 17),
                    Zemlja_porijekla = ReaderMethods.SafeGetString(reader, 18)
                };



                film.ProdKuca = prodKuca;
                film.Reziser = reziser;
                lista.Add(film);
            }
            GlobalDB.ZatvoriVezu();
            return lista;
        }
        public void DodajFilm(FilmModel film)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"INSERT INTO Film VALUES (default, '{film.Naziv}', '{film.Opis}', '{film.Trajanje}', {film.OcjenaKritike}, {film.Popularnost}, default, {film.Dob}, {film.ProdKuca.Id}, {film.Reziser.Id});");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void PromijeniFilm(FilmModel film)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"UPDATE Film SET Naziv = '{film.Naziv}', Opis = '{film.Opis}', Trajanje = '{film.Trajanje}', Ocjena_kritike = {film.OcjenaKritike}, Popularnost = {film.Popularnost}, Dob = {film.Dob}, Produkcijska_kuca_Produkcijska_kuca_id = {film.ProdKuca.Id}, Reziser_Reziser_id = {film.Reziser.Id} WHERE Film_id = {film.Id};");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }

        public void ObrisiFilm(FilmModel film)
        {
            GlobalDB.OtvoriVezu();
            GlobalDB.NapisiUpit($"DELETE FROM Film WHERE {film.Id} = Film_id;");
            GlobalDB.PozoviReadera();
            GlobalDB.ZatvoriVezu();
        }
    }
}
