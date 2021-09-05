using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databasebebo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            userControl71.Hide();
            userControl11.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            userControl71.Hide();
            userControl11.Show();
            userControl11.BringToFront();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl71.Show();
            userControl71.BringToFront();
        }

        private void userControl71_Load(object sender, EventArgs e)
        {

        }
    }
}
