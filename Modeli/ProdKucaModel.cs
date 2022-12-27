using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Modeli
{
    public class ProdKucaModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Zemlja_porijekla { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
