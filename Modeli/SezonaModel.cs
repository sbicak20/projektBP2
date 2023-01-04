using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeli
{
    public class SezonaModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Datum_izlaska { get; set; }
        public int Broj_epizoda { get; set; }
        public int Ocjena_kritike { get; set; }
        public int Serija_id { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
