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
    public partial class Form1 : Form
    {
        List<Imobil> imobile = new List<Imobil>();
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void customizeDesign()
        {
            panelImobileSubmenu.Visible = false;
            panelCerereSubmenu.Visible = false;
            panelOfertaSubmenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if(panelImobileSubmenu.Visible==true)
                panelImobileSubmenu.Visible=false;
            if (panelCerereSubmenu.Visible == true)
                panelCerereSubmenu.Visible = false;
            if (panelOfertaSubmenu.Visible == true)
                panelOfertaSubmenu.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btnImobile_Click(object sender, EventArgs e)
        {
            showSubMenu(panelImobileSubmenu);
        }
        private void btnAddImb_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2(imobile));
            hideSubMenu();
        }
        private void btnModImb_Click(object sender, EventArgs e)
        {
            openChildForm(new Form4(imobile));
            hideSubMenu();
        }
        private void btnDelImb_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3(imobile));
            hideSubMenu();
        }
        private void btnCerere_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCerereSubmenu);
        }
        private void btnAddCerere_Click(object sender, EventArgs e)
        {

            openChildForm(new Form6(imobile));
            hideSubMenu();
        }
        private void btnOferta_Click(object sender, EventArgs e)
        {
            showSubMenu(panelOfertaSubmenu);
        }
        private void btnAddOferta_Click(object sender, EventArgs e)
        {
            openChildForm(new Form5(imobile));
            hideSubMenu();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Form7());
        }
    }
}
