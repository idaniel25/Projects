using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_PAW
{
    public partial class Form2 : Form
    {
        public List<Imobil> imobile = new List<Imobil>();
        public static Form2 instance;
        public Form2(List<Imobil> imobile)
        {
            InitializeComponent();
            this.imobile = imobile;
            instance = this;
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
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string[] items = {"Apartament","Vila","Penthouse"};
            tbTip.Items.AddRange(items);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbID.Text)) 
            {
                errorProvider1.SetError(tbID, "Introduceti ID-ul!");
            }
            else
            {
                errorProvider1.Clear();
            }

            if (tbTip.SelectedItem == null)
            {
                errorProvider2.SetError(tbTip, "Introduceti tipul imobilului!");
            }
            else
            {
                errorProvider2.Clear();
            }

            if (string.IsNullOrEmpty(tbPret.Text))
            {
                errorProvider3.SetError(tbPret, "Introduceti pretul imobilului!");
            }
            else
            {
                errorProvider3.Clear();
            }

            if (!(string.IsNullOrEmpty(tbID.Text)) && tbTip.SelectedItem != null && !(string.IsNullOrEmpty(tbPret.Text)))
            {
                Imobil i = new Imobil();

                i.Id = Convert.ToInt32(tbID.Text);
                i.Tip = tbTip.SelectedItem.ToString();
                i.Pret = Convert.ToDouble(tbPret.Text);

                DialogResult rezultat = MessageBox.Show("Doriti sa adaugati imobilul " + i.Tip + ", avand ID-ul " + i.Id + " si pretul de " + i.Pret + " um? ", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (rezultat == DialogResult.Yes)
                {
                    imobile.Add(i);
                }

                tbID.Text = "";
                tbTip.SelectedIndex = -1;
                tbPret.Text = "";

                tbID.Focus();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            populare();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show("Doriti sa importati date din fisierul imobile.txt?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (rezultat == DialogResult.Yes)
            {
                string aLine;
                string[] imbData;
                lv.Items.Clear();
                ListViewItem item = new ListViewItem();
                StreamReader myReader = new StreamReader("imobile.txt");
                aLine = myReader.ReadLine();
                while (aLine != null)
                {
                    imbData = aLine.Split(',');
                    Imobil i = new Imobil();
                    imbData[0] = imbData[0].Trim();
                    imbData[1] = imbData[1].Trim();
                    imbData[2] = imbData[2].Trim();
                    item = new ListViewItem(imbData);
                    lv.Items.Add(item);
                    i.Id = Convert.ToInt32(imbData[0]);
                    i.Tip = imbData[1];
                    i.Pret = Convert.ToInt32(imbData[2]);
                    imobile.Add(i);
                    aLine = myReader.ReadLine();
                }
                myReader.Close();
            } 
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show("Doriti sa salvati datele in fisierul imobile.txt?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (rezultat == DialogResult.Yes)
            {

                StreamWriter myWriter = new StreamWriter("imobile.txt");
                string aLine;
                for (int i = 0; i < imobile.Count; i++)
                {
                    aLine = imobile[i].Id.ToString() + ", " + imobile[i].Tip.ToString() + ", " + imobile[i].Pret.ToString();
                    myWriter.WriteLine(aLine);
                }
                myWriter.Close();
            }
        }
        private void tbPret_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch!=8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
