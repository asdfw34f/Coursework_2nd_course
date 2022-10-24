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
    public partial class AddTypeVclad : Form
    {
        public AddTypeVclad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter();

            string Code = textКод.Text;
            string minSum = textМинимальнаяСумма.Text;
            Convert.ToDecimal(minSum);
            string maxSum = textМаксимальнаяСумма.Text;
            Convert.ToDecimal(maxSum);
            string Ostatoc = textНеснижаемыйОстаток.Text;
            Convert.ToDecimal(Ostatoc);
            string srock = textСрок.Text;
            string Proc = textПроценты.Text;
            Convert.ToDecimal(Proc);
            string ProcCap = textПроцКапит.Text;
            Convert.ToDecimal(ProcCap);
            string age = textВозраст.Text;
            Convert.ToInt32(age);
            string val = textВалюта.Text;


            SqlCommand sqlCommand = new SqlCommand(@"insert into ВИДЫ_ВКЛАДОВ([КОД_УСЛУГИ], [МИНИМАЛЬНАЯ_СУММА], [МАКСИМАЛЬНАЯ_СУММА], [НЕСНИЖАЕМЫЙ_ОСТАТОК], [СРОК_В_НЕДЕЛЯХ], [ПРОЦЕНТЫ],[С_КАПИТАЛИЗАЦИЕЙ], [МИНИМАЛЬНЫЙ_ВОЗРАСТ], [ВАЛЮТА]) VALUES(@CODE, @MINSUM, @MAXSUM, @OST, @SROCK, @PROC, @PROCCAP, @AGE, @VAL)", MyConnection.GetConnection());
            try
            {
                //@CODE, @MINSUM, @MAXSUM, @OST, @SROCK, @PROC, @PROCCAP, @AGE, @VAL
                sqlCommand.Parameters.Add("@CODE", SqlDbType.VarChar).Value = Code;
                sqlCommand.Parameters.Add("@MINSUM", SqlDbType.Money).Value = minSum;
                sqlCommand.Parameters.Add("@MAXSUM", SqlDbType.Money).Value = maxSum;
                sqlCommand.Parameters.Add("@OST", SqlDbType.Money).Value = Ostatoc;
                sqlCommand.Parameters.Add("@SROCK", SqlDbType.Int).Value = srock;
                sqlCommand.Parameters.Add("@PROC", SqlDbType.Decimal).Value = Proc;
                sqlCommand.Parameters.Add("@PROCCAP", SqlDbType.Decimal).Value = ProcCap;
                sqlCommand.Parameters.Add("@AGE", SqlDbType.Int).Value = age;
                sqlCommand.Parameters.Add("@VAL", SqlDbType.VarChar).Value = val;

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
