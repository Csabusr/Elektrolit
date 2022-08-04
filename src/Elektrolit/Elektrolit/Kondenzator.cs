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
        }

        public int id { get; set; }
        public string kapacitas { get; set; }
        public string feszultseg { get; set; }
        public int darab { get; set; }
    }

    public class beszerKondenzator
    {
        public beszerKondenzator()
        {
        }

        public beszerKondenzator(int id, string kapacitas, string feszultseg, int darabkell, int darabvan, string megjegyzes, bool kell)
        {
            this.id = id;
            this.kapacitas = kapacitas;
            this.feszultseg = feszultseg;
            this.darabkell = darabkell;
            this.darabvan = darabvan;
            this.megjegyzes = megjegyzes;
            this.kell = kell;
        }

        public int id { get; set; }
        public string kapacitas { get; set; }
        public string feszultseg { get; set; }
        public int darabkell { get; set; }
        public int darabvan { get; set; }
        public string megjegyzes { get; set; }
        public bool kell { get; set; }
    }
}
