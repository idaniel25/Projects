using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PAW
{
    public class Oferta
    {
        private int id;
        private double pretCerut;
        private int nr_oferite;

        public Oferta()
        {
            this.id = 0;
            this.pretCerut = 0;
            this.nr_oferite = 0;
        }

        public Oferta(int id, double pretCerut, int nr_oferite)
        {
            this.id = id;
            this.pretCerut = pretCerut;
            this.nr_oferite = nr_oferite;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public double PretCerut
        {
            get { return pretCerut; }
            set { pretCerut = value; }
        }

        public int Nr_oferite
        {
            get { return nr_oferite; }
            set { nr_oferite = value; }
        }

        public override string ToString()
        {
            return "ID: " + this.id + ", pret cerut: " + this.pretCerut + ", numar imobile oferite: " + this.nr_oferite;
        }
    }
}
