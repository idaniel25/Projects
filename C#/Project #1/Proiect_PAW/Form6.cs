using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Proiect_PAW
{
    public partial class Form6 : Form
    {
        public List<Imobil> imobile = new List<Imobil>();
        public Form6(List<Imobil> imobile)
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            populare();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNume.Text))
            {
                errorProvider1.SetError(tbNume, "Introduceti numele!");
            }
            else
            {
                errorProvider1.Clear();
            }

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                errorProvider2.SetError(tbEmail, "Introduceti email-ul!");
            }
            else
            {
                errorProvider2.Clear();
            }

            if (string.IsNullOrEmpty(tbTel.Text))
            {
                errorProvider3.SetError(tbTel, "Introduceti numarul de telefon!");
            }
            else
            {
                errorProvider3.Clear();
            }

            if (string.IsNullOrEmpty(tbPret.Text))
            {
                errorProvider4.SetError(tbPret, "Introduceti numarul de telefon!");
            }
            else
            {
                errorProvider4.Clear();
            }

            if (!checkBox1.Checked)
            {
                errorProvider5.SetError(checkBox1, "Bifati casuta privind datele si conditiile!");
            }
            else
            {
                errorProvider5.Clear();
            }

            if(!(string.IsNullOrEmpty(tbNume.Text)) && !(string.IsNullOrEmpty(tbEmail.Text)) && !(string.IsNullOrEmpty(tbTel.Text)) && !(string.IsNullOrEmpty(tbPret.Text)) && !(!checkBox1.Checked))
            {
                if(lv.SelectedItems.Count > 0)
                {
                    if (Convert.ToDouble(lv.SelectedItems[0].SubItems[2].Text) - Convert.ToDouble(tbPret.Text) > 100)
                    {
                        MessageBox.Show("Diferenta dintre pretul imobilului si cel oferit este mai mare de 100 um. Oferiti un pret mai mare!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Utilizatorul " + tbNume.Text + " a cumparat imobilul " + lv.SelectedItems[0].SubItems[1].Text + " la pretul de "
                            + tbPret.Text + " um cu succes!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int i = 0; i < imobile.Count; i++)
                            for (int j = 0; j < lv.SelectedItems.Count; j++)
                            {
                                int index = lv.SelectedItems[j].Index;
                                imobile.RemoveAt(index);
                                lv.Items.Remove(lv.SelectedItems[j]);
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Selectati un imobil!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void tbTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void tbPret_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void tbEmail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if(Regex.IsMatch(tbEmail.Text, pattern))
            {
                errorProvider6.Clear();
            }
            else
            {
                errorProvider6.SetError(tbEmail, "Introduceti un email valid");
            }
        }
        private void tbTel_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{10}$");
            if (r.IsMatch(tbTel.Text))
            {
                errorProvider7.Clear();
            }
            else
            {
                errorProvider7.SetError(tbTel, "Introduceti un numar de telefon valid");
            }
        }
    }
}
