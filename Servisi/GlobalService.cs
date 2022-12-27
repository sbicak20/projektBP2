using Servisi.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servisi
{
    public static class GlobalService
    {
        public static ReziserServis RezServis = new ReziserServis();
        public static ProdKucaServis ProdKucaServis = new ProdKucaServis();
        public static GlumacServis GlumacServis = new GlumacServis();
        public static ZanrServis ZanrServis = new ZanrServis();
    }
}
