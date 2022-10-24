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
    public partial class DeleteVclads : Form
    {
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public DeleteVclads()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand.CommandText = null;
                string number = comboNumPlas.Text;
                sqlCommand.CommandText = @"DELETE [ОФОРМЛЕННЫЕ_ВКЛАДЫ] WHERE [НОМЕР_ВКЛАДА] = @NUM";
                sqlCommand.Parameters.Add("@NUM", SqlDbType.VarChar).Value = number;
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

        private void VcladsDelete_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            sqlCommand.CommandText = "SELECT НОМЕР_ВКЛАДА FROM [ОФОРМЛЕННЫЕ_ВКЛАДЫ]";
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            comboNumPlas.DataSource = dataTable;
            comboNumPlas.ValueMember = "НОМЕР_ВКЛАДА";
            comboNumPlas.SelectAll();
        }
    }
}
