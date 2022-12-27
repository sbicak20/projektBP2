using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeli
{
    public class ReziserModel
    {
        public int Id { get; set; }
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public bool Osvojio_nagradu { get; set; }

        public string Nagrada { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
