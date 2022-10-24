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
    public partial class AddTypeCredit : Form
    {
        public AddTypeCredit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter();

            string code = textКод.Text;
            string minsroc = textСрокМин.Text;
            string maxsroc = textСрокМакс.Text;
            string proc = textПроценты.Text;
            Convert.ToDecimal(proc);
            string minsum = textМинимальнаяСумма.Text;
            Convert.ToDecimal(minsum);
            string maxsum = textМаксимальнаяСумма.Text;
            Convert.ToDecimal(maxsum);

            SqlCommand sqlCommand = new SqlCommand(@"insert into [ВИДЫ_КРЕДИТОВ]([КОД_УСЛУГИ], [МИНИМАЛЬНЫЙ_СРОК_КРЕДИТА], [МАКСИМАЛЬНЫЙ_СРОК_КРЕДИТА], [ПРОЦЕНТЫ], [МИНИМАЛЬНАЯ_СУММА], [МАКСИМАЛЬНАЯ_СУММА]) VALUES(@CODE, @MINSROK, @MAXSROK, @PROC, @MINSUM, @MAXSUM)", MyConnection.GetConnection());
            try
            {
                //@CODE, @MINSROK, @MAXSROK, @PROC, @MINSUM, @MAXSUM
                sqlCommand.Parameters.Add("@CODE", SqlDbType.VarChar).Value = code;
                sqlCommand.Parameters.Add("@MINSROK", SqlDbType.Int).Value = minsroc;
                sqlCommand.Parameters.Add("@MAXSROK", SqlDbType.Int).Value = maxsroc;
                sqlCommand.Parameters.Add("@PROC", SqlDbType.Decimal).Value = proc;
                sqlCommand.Parameters.Add("@MINSUM", SqlDbType.Money).Value = minsum;
                sqlCommand.Parameters.Add("@MAXSUM", SqlDbType.Money).Value = maxsum;
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
