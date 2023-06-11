using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp69
{

    public partial class Form3 : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cm = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=LAB206_7\SQLEXPRESS;Initial Catalog=Product;Integrated Security=SSPI");
        DataSet ds = new DataSet();
        public Form3()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            adapter = new SqlDataAdapter("SELECT * FROM Лист1$", con);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Ascending);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Descending);
        }

    }
}
