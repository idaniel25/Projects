using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PAW
{
    public class Cerere
    {
        private int id;
        //lista de imobile 
        private double pretOferit;
        private int nr_cerute;

        public Cerere()
        {
            this.id = 0;
            this.pretOferit = 0;
            this.nr_cerute = 0;
        }

        public Cerere(int id, double pretOferit, int nr_cerute)
        {
            this.id = id;
            this.pretOferit = pretOferit;
            this.nr_cerute = nr_cerute;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public double PretOferit
        {
            get { return pretOferit; }
            set { pretOferit = value; }
        }

        public int Nr_cerute
        {
            get { return nr_cerute; }
            set { nr_cerute = value; }
        }

        public override string ToString()
        {
            return "ID: " + this.id + ", pret oferit: " + this.pretOferit + ", numar imobile cerute: " + this.nr_cerute;
        }
    }
}
