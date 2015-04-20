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
    public partial class pagePrincipale : Form
    {

        private Restaurant restaurant;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set { restaurant = value; }
        }

        public pagePrincipale()
        {
            InitializeComponent();
        }

        private void nouveauRestaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
