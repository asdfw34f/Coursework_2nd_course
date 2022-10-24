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
    public partial class AddClients : Form
    {
        SqlDataAdapter sqlData = new SqlDataAdapter();
        SqlCommand command = new SqlCommand(@"Insert into [КЛИЕНТЫ]([НОМЕР_КЛИЕНТА], [ИМЯ], [ОТЧЕСТВО], [ФАМИЛИЯ], [ДАТА_РОЖДЕНИЯ], [ПОЛ], [ТЕЛЕФОН], [EMAIL], [АДРЕС_РЕГИСТРАЦИИ], [ФАКТИЧЕСКИЙ_АДРЕС], [СЕРИЯ_НОМЕР]) VALUES(@NUMBER, @NAME, @OTCHE, @FAMILY, @DATEBIRTHDAY, @POL, @PHONE, @EMAIL, @ADRESSREG, @ADRESSFACT, @PASS)", MyConnection.GetConnection());

        public AddClients()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = Номер.Text;
            Convert.ToInt32(num);
            string name = Имя.Text;
            string fam = Фамилия.Text;
            string otch = Отчество.Text;
            string phone = Телефон.Text;
            string adressReg = Адресрег.Text;
            string adressFact = Адресфакт.Text;
            string Email = email.Text;
            string pol = Пол.Text;
            string DateB = Рождение.Text;
            string SeriaNum = СерияНомер.Text;

            try
            {
                command.Parameters.Add("@NUMBER", SqlDbType.Int).Value = num;
                command.Parameters.Add("@NAME", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@OTCHE", SqlDbType.VarChar).Value = otch;
                command.Parameters.Add("@FAMILY", SqlDbType.VarChar).Value = fam;
                command.Parameters.Add("@DATEBIRTHDAY", SqlDbType.Date).Value = DateB;
                command.Parameters.Add("@POL", SqlDbType.Char).Value = pol;
                command.Parameters.Add("@PHONE", SqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = Email;
                command.Parameters.Add("@ADRESSREG", SqlDbType.VarChar).Value = adressReg;
                command.Parameters.Add("@ADRESSFACT", SqlDbType.VarChar).Value = adressFact;
                command.Parameters.Add("@PASS", SqlDbType.VarChar).Value = SeriaNum;
                MyConnection.OpenConnection();
                
                MyConnection.CloseConnection();
                MessageBox.Show("Запись добавлена !", "Выполнение добавления записи");
                Номер.Text = null;
                Имя.Text = null;
                Фамилия.Text = null;
                Отчество.Text = null;
                Телефон.Text = null;
                Адресрег.Text = null;
                Адресфакт.Text = null;
                email.Text = null;
                Пол.Text = null;
                Рождение.Text = null;
                СерияНомер.Text = null;
            }
            catch
            {
                MessageBox.Show("Не удалось добавить запись!", "Ошибка добавления");
            }
        }
    }
}
