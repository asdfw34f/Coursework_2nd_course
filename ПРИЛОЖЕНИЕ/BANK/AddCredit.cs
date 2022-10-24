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
    public partial class creditAdd : Form
    {
        public creditAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter();
            string numplastic = textBoxNum.Text;
            string money = textBoxMoney.Text;
            Convert.ToDecimal(money);
            string dog = textBoxContr.Text;
            Convert.ToInt32(dog);
            string code = textBoxcode.Text;
            string PIN = textBoxPIN.Text;

            SqlCommand sqlCommand = new SqlCommand(@"insert into [ОФОРМЛЕННЫЕ_КРЕДИТЫ](НОМЕР_ПЛАСТИКА, [СУММА], НОМЕР_ДОГОВОРА, КОД_УСЛУГИ, ПИН_КОД) VALUES(@NUM, @MON, @DOG, @CODE, @PIN)", MyConnection.GetConnection()) ;
            try
            {
                //@NUM, @MON, @DOG, @CODE, @PIN
                sqlCommand.Parameters.Add("@NUM", SqlDbType.VarChar).Value = numplastic;
                sqlCommand.Parameters.Add("@MON", SqlDbType.Money).Value = money;
                sqlCommand.Parameters.Add("@DOG", SqlDbType.Int).Value = dog;
                sqlCommand.Parameters.Add("@CODE", SqlDbType.VarChar).Value = code;
                sqlCommand.Parameters.Add("@PIN", SqlDbType.VarChar).Value = PIN;
                //sqlData.InsertCommand = sqlCommand;
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
