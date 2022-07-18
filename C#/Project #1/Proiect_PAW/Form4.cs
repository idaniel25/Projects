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
    public partial class Form4 : Form
    {
        public List<Imobil> imobile = new List<Imobil>();   
        public Form4(List<Imobil> imobile)
        {
            InitializeComponent();            
            this.imobile = imobile;
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
        private void Form4_Load(object sender, EventArgs e)
        {
            populare();
            string[] items = { "Apartament", "Vila", "Penthouse" };
            tbTip.Items.AddRange(items);
        }
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lv.SelectedItems)
            {
                tbID.Text = lv.SelectedItems[0].Text;
                tbTip.SelectedItem = lv.SelectedItems[0].SubItems[1].Text;
                tbPret.Text = lv.SelectedItems[0].SubItems[2].Text;
            }
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
                if (lv.SelectedItems.Count > 0)
                {
                    DialogResult rezultat = MessageBox.Show("Doriti sa modificati imobilul selectat? ", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (rezultat == DialogResult.Yes)
                    {
                        lv.SelectedItems[0].Text = tbID.Text;
                        lv.SelectedItems[0].SubItems[1].Text = tbTip.Text;
                        lv.SelectedItems[0].SubItems[2].Text = tbPret.Text;
                        for (int i = 0; i < imobile.Count; i++)
                            for (int j = 0; j < lv.SelectedItems.Count; j++)
                            {
                                int index = lv.SelectedItems[j].Index;
                                imobile[index].Id = Convert.ToInt32(lv.SelectedItems[0].Text);
                                imobile[index].Tip = lv.SelectedItems[0].SubItems[1].Text;
                                imobile[index].Pret = Convert.ToInt32(lv.SelectedItems[0].SubItems[2].Text);
                            }
                    }

                    tbID.Text = "";
                    tbTip.SelectedIndex = -1;
                    tbPret.Text = "";

                    tbID.Focus();
                }
                else
                {
                    MessageBox.Show("Selectati un imobil!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tbPret_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
