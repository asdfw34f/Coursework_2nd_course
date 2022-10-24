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
    public partial class AddTypeCard : Form
    {
        public AddTypeCard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter();

            string code = textКод.Text;
            string money = textстоимость.Text;
            Convert.ToDecimal(money);
            string agemin = textстоимость.Text;
            string agemax = textстоимость.Text;
            string cashback = textстоимость.Text;
            Convert.ToDecimal(cashback);

            SqlCommand sqlCommand = new SqlCommand(@"insert into [ВИДЫ_ДЕБЕТОВЫХ_КАРТ]([КОД_УСЛУГИ], [ОБСЛУЖИВАНИЕ_В_МЕСЯЦ], [МИНИМАЛЬНЫЙ_ВОЗРАСТ], [МАКСИМАЛЬНЫЙ_ВОЗРАСТ], [КЭШБЭК]) VALUES(@CODE, @MON, @MINAGE, @MAXAGE, @CASH)", MyConnection.GetConnection());
            try
            {
                //@CODE, @MON, @MINAGE, @MAXAGE, @CASH
                sqlCommand.Parameters.Add("@CODE", SqlDbType.VarChar).Value = code;
                sqlCommand.Parameters.Add("@MON", SqlDbType.Money).Value = money;
                sqlCommand.Parameters.Add("@MINAGE", SqlDbType.Int).Value = agemin;
                sqlCommand.Parameters.Add("@MAXAGE", SqlDbType.Int).Value = agemax;
                sqlCommand.Parameters.Add("@CASH", SqlDbType.Decimal).Value = cashback;
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
