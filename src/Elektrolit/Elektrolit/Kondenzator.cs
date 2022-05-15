using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrolit
{
    public class Kondenzator
    {
        public Kondenzator()
        {
        }

        public Kondenzator(int id, string kapacitas, string feszultseg, string hozzaadas_ideje)
        {
            this.id = id;
            this.kapacitas = kapacitas;
            this.feszultseg = feszultseg;
            this.hozzaadas_ideje = hozzaadas_ideje;
        }

        public int id { get; set; }
        public string kapacitas { get; set; }
        public string feszultseg { get; set; }
        public string hozzaadas_ideje { get; set; }
        public int darab { get; set; }
    }
}
