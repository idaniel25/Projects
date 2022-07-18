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
    public partial class Form3 : Form
    {
        public List<Imobil> imobile = new List<Imobil>();
        public Form3(List<Imobil> imobile)
        {
            InitializeComponent();
            this.imobile = imobile;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            populare();
        }
        private void populare()
        {
            lv.Items.Clear();
            foreach (Imobil i in imobile)
            {
                ListViewItem itm = new ListViewItem(i.Id.ToString());
                itm.SubItems.Add(i.Tip.ToString());
                itm.SubItems.Add(i.Pret.ToString());
                itm.Tag = i;
                lv.Items.Add(itm);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < imobile.Count; i++)   
                for(int j=0;j<lv.SelectedItems.Count;j++)   
                {
                    int index = lv.SelectedItems[j].Index;
                    imobile.RemoveAt(index);
                    lv.Items.Remove(lv.SelectedItems[j]);
                }
        }
    }
}
