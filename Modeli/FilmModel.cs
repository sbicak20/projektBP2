using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeli
{
    public class FilmModel
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
        public string Opis { get; set; }
        public TimeSpan Trajanje { get; set; }
        public int OcjenaKritike { get; set; }
        public int Popularnost { get; set; }
        public bool ZaOdrasle { get; set; }
        public int Dob { get; set; }
        public ProdKucaModel ProdKuca { get; set; }
        public ReziserModel Reziser { get; set; }
    }
}
