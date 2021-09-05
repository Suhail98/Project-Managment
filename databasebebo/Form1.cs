using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace databasebebo
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MyDataBase;Integrated Security=True");
        private int projectID;
        public Form1()
        {
            InitializeComponent();
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl51.Hide();
            userControl61.Hide();
            userControl41.Hide();
            userControl81.Hide();




        }
        public Form1(int projectID)
        {
            InitializeComponent();
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl51.Hide();
            userControl61.Hide();
            userControl41.Hide();
            userControl81.Hide();
            userControl11.setProjectID(projectID); 
            userControl21.setProjectID(projectID); 
            userControl31.setProjectID(projectID); 
            userControl51.setProjectID(projectID); 
            userControl61.setProjectID(projectID); 
            userControl41.setProjectID(projectID); 
            userControl81.setProjectID(projectID);




            this.projectID = projectID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
  

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        //--------------------------------Employee------------------------------------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void WorkingHour_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        //------------------------    Tasks    -----------------------------
        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
          
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
           

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl11.Hide();
            userControl31.Show();
            userControl31.BringToFront();

        }

        

        private void button6_Click_2(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl31.Hide();
            userControl11.Show();
            userControl11.BringToFront();




        }

        private void button14_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Hide();
            userControl21.Show();
            userControl21.BringToFront();

        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void userControl21_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Hide();
            userControl21.Hide();
            userControl51.Show();
            userControl51.BringToFront();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Hide();
            userControl21.Hide();
            userControl51.Hide();
            userControl61.Show();
            userControl61.BringToFront();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Hide();
            userControl21.Hide();
            userControl51.Hide();
            userControl61.Hide();
            userControl41.Show();
            userControl41.BringToFront();

        }

        private void userControl41_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Hide();
            userControl21.Hide();
            userControl51.Hide();
            userControl61.Hide();
            userControl41.Hide();
            userControl81.Show();
            userControl81.BringToFront();




        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(projectID);
            form3.Show();
        }

        private void button6_Click_3(object sender, EventArgs e)
        {
            Form4 form = new Form4(projectID);
            form.Show();
        }
    }
}
