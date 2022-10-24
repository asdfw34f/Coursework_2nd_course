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
    public partial class DeleteTypeCard : Form
    {
        DataTable table = new DataTable();
        SqlDataAdapter sqlData = new SqlDataAdapter();
        SqlCommand sqlCommand = new SqlCommand();

        public DeleteTypeCard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand.CommandText = null;
                string number = comboBox2.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                sqlCommand.CommandText = @"DELETE [ВИДЫ_ДЕБЕТОВЫХ_КАРТ] WHERE [КОД_УСЛУГИ] = @NUM";
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

        private void DeleteTypeCard_Load(object sender, EventArgs e)
        {
            sqlCommand.CommandText = "SELECT КОД_УСЛУГИ FROM [ВИДЫ_ДЕБЕТОВЫХ_КАРТ]";
            sqlCommand.Connection = MyConnection.Connection;
            sqlData.SelectCommand = sqlCommand;
            sqlData.Fill(table);
            comboBox2.DataSource = table;
            comboBox2.ValueMember = "КОД_УСЛУГИ";
            comboBox2.SelectAll();
        }
    }
}
