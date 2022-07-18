using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_PAW
{
    public partial class Form5 : Form
    {
        private DataTable dt;
        private DataView dv;
        public List<Imobil> imobile = new List<Imobil>();
        public Form5(List<Imobil> imobile)
        {
            InitializeComponent();
            this.imobile = imobile;
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Tip");
            dt.Columns.Add("Pret");
            fillDataTable(imobile);
            dv = new DataView(dt);
            populateListView(dv);
        }
        private void fillDataTable(List<Imobil> imobile)
        {
            foreach (Imobil i in imobile)
            {
                dt.Rows.Add(i.Id, i.Tip, i.Pret);
            }
        } 
        private void populateListView(DataView dv)
        {
            lv.Items.Clear();
            foreach (DataRow row in dv.ToTable().Rows)
            {
                lv.Items.Add(new ListViewItem(new String[] { row[0].ToString(), row[1].ToString(), row[2].ToString() }));
            }
        }
        private void tbs_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = String.Format("Tip Like '%{0}%'", tbs.Text);
            populateListView(dv);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private double calcMedie(string tip)
        {
            double suma = 0, nr = 0;
            for (int i = 0; i < Form2.instance.imobile.Count; i++)
            {
                if (Form2.instance.imobile[i].Tip == tip)
                {
                    suma += Form2.instance.imobile[i].Pret;
                    nr++;
                }
            }
            double medie = suma / nr;
            return medie;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tbMed.Text = calcMedie("Apartament").ToString();
            tbMed2.Text = calcMedie("Vila").ToString();
            tbMed3.Text = calcMedie("Penthouse").ToString();
        }
    }
}
