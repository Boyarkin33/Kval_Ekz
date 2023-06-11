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
    public partial class Form2 : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cm = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=LAB206_7\SQLEXPRESS;Initial Catalog=Product;Integrated Security=SSPI");
        DataSet ds = new DataSet();
        public Form2()
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaintRows();
        }

        private void PaintRows()
        {
            var c = System.Drawing.ColorTranslator.FromHtml("#7fff00");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (int.Parse(row.Cells[5].Value.ToString())>15)
                    {
                        row.DefaultCellStyle.BackColor = c;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    
                }
                catch { }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                    break;
                case 1:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[Размер максимально возможной скидки] <=9";
                    break;
                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[Размер максимально возможной скидки] >=10 AND [Размер максимально возможной скидки] <=14";
                    break;
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[Размер максимально возможной скидки] >=15";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[textBox1.Text], ListSortDirection.Ascending);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[textBox1.Text], ListSortDirection.Descending);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }
    }
}
