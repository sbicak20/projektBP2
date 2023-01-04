using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeli
{
    public class SerijaModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int Ocjena_kritike { get; set; }
        public int Popularnost { get; set; }

        public ProdKucaModel ProdKuca { get; set; }
        public ReziserModel Reziser { get; set; }
        public override string ToString()
        {
            return Naziv;
        }
    }
}
