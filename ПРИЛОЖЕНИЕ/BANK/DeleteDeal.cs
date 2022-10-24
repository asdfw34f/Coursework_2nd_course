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


namespace BANK
{
    public partial class DeleteDeal : Form
    {

        DataTable table = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand sqlCommand = new SqlCommand();
        public DeleteDeal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string number = comboBox1.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                sqlCommand.CommandText = @"DELETE [БАНКОВСКИЕ_УСЛУГИ] WHERE [НОМЕР_УСЛУГИ] = @NUM";
                sqlCommand.Parameters.Add("@NUM", SqlDbType.Int).Value = number;
                sqlCommand.Connection = MyConnection.Connection;
                MyConnection.OpenConnection();
                sqlCommand.ExecuteNonQuery();
                MyConnection.CloseConnection();
                MessageBox.Show("Удаление выполнено!", "Удаление записи");
            }
            catch
            { 
                MessageBox.Show("Ошибка удаления!", "Удаление записи");
            }
        }

        private void dealsDelete_Load(object sender, EventArgs e)
        {
            sqlCommand.CommandText = "SELECT НОМЕР_УСЛУГИ FROM [БАНКОВСКИЕ_УСЛУГИ]";
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.ValueMember = "НОМЕР_УСЛУГИ";
            comboBox1.SelectAll();

        }
    }
}
