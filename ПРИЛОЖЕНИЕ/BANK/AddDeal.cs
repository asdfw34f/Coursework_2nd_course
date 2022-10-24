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
    public partial class AddDeal : Form
    {
        public AddDeal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string add = @"insert into [БАНКОВСКИЕ_УСЛУГИ](НОМЕР_УСЛУГИ, КОД_УСЛУГИ, НАЗВАНИЕ) VALUES(@NUM, @CODE, @NAME)";
                string number = textBox1.Text, code = textBox3.Text, name = textBox2.Text;
                SqlDataAdapter sqlData = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand(add, MyConnection.Connection);
                sqlCommand.Parameters.Add("@NUM", SqlDbType.Int).Value = number;
                sqlCommand.Parameters.Add("@CODE", SqlDbType.VarChar).Value = code;
                sqlCommand.Parameters.Add("@NAME", SqlDbType.VarChar).Value = name;
                sqlData.InsertCommand = sqlCommand;
                MyConnection.OpenConnection();
                sqlCommand.ExecuteNonQuery();
                MyConnection.CloseConnection();
                MessageBox.Show("Запись добавлена !", "Выполнение добавления записи");
            }
            catch
            {
                MessageBox.Show("Не удалось добавить запись!", "Ошибка добавления");
            }

        }
    }
}
