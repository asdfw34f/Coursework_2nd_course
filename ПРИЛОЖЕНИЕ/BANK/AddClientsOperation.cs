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
    public partial class AddClientsOperation : Form
    {
        SqlDataAdapter sqlData = new SqlDataAdapter();
        SqlCommand command = new SqlCommand(@"Insert into [ИСТОРИЯ_ОПЕРАЦИЙ]([НОМЕР_ОПЕРАЦИИ], [КОД_ОПЕРАЦИИ], [НОМЕР_СЧЁТА], [СУММА_ОПЕРАЦИИ]) VALUES(@OPER, @CODE, @CHET, @SUM)", MyConnection.GetConnection());
        public AddClientsOperation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string operation = textNumOperation.Text;
            Convert.ToInt32(operation);
            string codeoper = textCodeOperation.Text;
            string numchet = textChet.Text;
            string money = textSum.Text;
            Convert.ToDecimal(money);

            //@OPER, @CODE, @CHET, @SUM
            try
            {
                command.Parameters.Add("@OPER", SqlDbType.Int).Value = operation;
                command.Parameters.Add("@CODE", SqlDbType.VarChar).Value = codeoper;
                command.Parameters.Add("@CHET", SqlDbType.VarChar).Value = numchet;
                command.Parameters.Add("@SUM", SqlDbType.Money).Value = money;
                MyConnection.OpenConnection();
                command.ExecuteNonQuery();
                MyConnection.CloseConnection();
                MessageBox.Show("Запись добавлена !", "Выполнение добавления записи");
                textNumOperation.Text = null;
                textCodeOperation.Text = null;
                textChet.Text = null;
                textSum.Text = null;
            }
            catch
            {
                MessageBox.Show("Не удалось добавить запись!", "Ошибка добавления");
            }
        }
    }
}
