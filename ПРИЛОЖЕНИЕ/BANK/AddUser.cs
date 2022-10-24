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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string LOGIN = ЛОГИН.Text;
            string PASS = ПАРОЛЬ.Text;
            string NUM = НОМЕРСОТРУДНИКА.Text;
            Convert.ToInt32(NUM);

            SqlDataAdapter sqlData = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(@"Insert into [ДАННЫЕ_ВХОДА]([LOGIN], [ПАРОЛЬ], [НОМЕР_СОТРУДНИКА]) VALUES(@LOG, @PASS, @NUMBEROFWORKER)", MyConnection.GetConnection());
            //@LOG, @PASS, @NUMBEROFWORKER
            command.Parameters.Add("@LOG", SqlDbType.VarChar).Value = LOGIN;
            command.Parameters.Add("@PASS", SqlDbType.VarChar).Value = PASS;
            command.Parameters.Add("@NUMBEROFWORKER", SqlDbType.Int).Value = NUM;

            MyConnection.OpenConnection();
            command.ExecuteNonQuery();
            MyConnection.CloseConnection();
            MessageBox.Show("Запись добавлена !", "Выполнение добавления записи");
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }
    }
}
