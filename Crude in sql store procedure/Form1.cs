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

namespace Crude_in_sql_store_procedure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-5LGL34O SQLEXP;Initial Catalog=Raj;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text, empcity = comboBox1.Text, contact = textBox4.Text, sex = "";
            double age = double.Parse(textBox3.Text);
            DateTime joingdate = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { sex = "Male"; }
            { sex = "Female"; }
            conn.Open();
            
            SqlCommand c = new SqlCommand(" exec insertemployeesb '" + empid + "','" + empname + "','" + empcity + "','" + age + "','" + sex + "','" + joingdate + "','" + contact + "'", conn);
            c.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted....");
            GetEmpList();
        }
        void GetEmpList()
        {
            SqlCommand c = new SqlCommand("exec Listemployeesb",conn);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetEmpList();

        }
    }
}
