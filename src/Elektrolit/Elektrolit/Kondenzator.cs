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

        public Kondenzator(int id, string kapacitas, string feszultseg, int darab, bool kell, string megjegyzes)
        {
            this.id = id;
            this.kapacitas = kapacitas;
            this.feszultseg = feszultseg;
            this.darab = darab;
            this.kell = kell;
            this.megjegyzes = megjegyzes;
        }

        public int id { get; set; }
        public string kapacitas { get; set; }
        public string feszultseg { get; set; }
        public int darab { get; set; }
        public bool kell { get; set; }
        public string megjegyzes { get; set; }
    }
}
