using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeli
{
    public class EpizodaModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum_izlaska { get; set; }
        public TimeSpan Trajanje { get; set; }
        public int Sezona_id { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
