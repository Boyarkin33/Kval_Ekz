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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlConnection con = new SqlConnection(@"Data Source=LAB206_7\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True");
            try
            {
                string f = string.Format("SELECT * FROM User$ WHERE Login='" + loginUser.Text + "' AND Password='" + passUser.Text + "';");
                SqlCommand check = new SqlCommand(f, con);
                con.Open();
                if (check.ExecuteScalar()!=null)
                {
                    Form2 main = new Form2();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный логин либо пароль", "Ошибка");
                }
            }
            finally
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 main = new Form3();
            main.Show();
            this.Hide();
        }
    }
}
