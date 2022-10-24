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
    public partial class AddVclad : Form
    {
        public AddVclad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter();
            string numvk = textBoxNum.Text;
            string money = textBoxMoney.Text;
            Convert.ToDecimal(money);
            string dog = textBoxContr.Text;
            Convert.ToInt32(dog);
            string code = textBoxcode.Text;

            SqlCommand sqlCommand = new SqlCommand(@"insert into [ОФОРМЛЕННЫЕ_ВКЛАДЫ]([НОМЕР_ВКЛАДА], [КОД_УСЛУГИ], [НОМЕР_ДОГОВОРА], [СУММА]) VALUES(@NUM, @CODE, @DOG, @MON)", MyConnection.GetConnection());
            try
            {
                sqlCommand.Parameters.Add("@NUM", SqlDbType.VarChar).Value = numvk;
                sqlCommand.Parameters.Add("@MON", SqlDbType.Money).Value = money;
                sqlCommand.Parameters.Add("@DOG", SqlDbType.Int).Value = dog;
                sqlCommand.Parameters.Add("@CODE", SqlDbType.VarChar).Value = code;
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
