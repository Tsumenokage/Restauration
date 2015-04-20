using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restauration_Form
{
    public partial class Nouveaurestaurant : Form
    {
        pagePrincipale _pagePrincipale;

        public Nouveaurestaurant()
        {
            InitializeComponent();
        }

        public Nouveaurestaurant(pagePrincipale _pagePrincipale)
        {
            InitializeComponent();
            this._pagePrincipale = _pagePrincipale;
        }

        private void Nouveaurestaurant_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nom = textBox1.Text.Trim();
            Boolean nomOk = false;

            if(nom == "")
            {
                MessageBox.Show("Vous devez entrer un nom de restaurant", "Nom de restaurant manquant", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _pagePrincipale.Restaurant = new Restaurant(nom);
            }
        }
    }
}
