using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PAW
{
    public class Imobil
    {
        
        private int id;
        private string tip;
        private double pret;
       
        public Imobil()
        {
            this.id = 0;
            this.tip = "";
            this.pret = 0;
        }

        public Imobil(int id, string tip, double pret)
        {
            this.id = id;
            this.tip = tip;
            this.pret = pret;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Pret
        {
            get { return pret; }
            set { pret = value; }
        }

        public string Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public override string ToString()
        {
            return "ID: " + this.id + ", tip: " + this.tip + ", pret: " + this.pret;
        }

    }
}
