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
    public partial class FormLogin : Form
    {
        Form form = new MainForm();
        
        public FormLogin()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void login_Load(object sender, EventArgs e)
        {
            form.Enabled = false;
            form.Show();

            try
            {
                MyConnection.OpenConnection();   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: Подключение отсутствует!" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            
            command.CommandText = @"select  * FROM ДАННЫЕ_ВХОДА WHERE  ((LEFT(LOGIN,5))) = 'ADMIN' AND [LOGIN] = @log AND [ПАРОЛЬ] = @pass";
            command.Parameters.Add("@log", SqlDbType.VarChar).Value = user.Text;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = userword.Text;

            table.Clear();
            command.Connection = MyConnection.Connection;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                this.Close();
                form.Enabled = true;
                MyElements.LOCK = true;
            }
            else 
            {
                command.CommandText = null;
                command.CommandText = @"SELECT * FROM ДАННЫЕ_ВХОДА where [LOGIN] = @log AND [ПАРОЛЬ] = @pass";
                command.Connection = MyConnection.Connection;
                table.Clear();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    this.Close();
                    form.Enabled = true;
                }
                else MessageBox.Show("Неправильный логин или пароль");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void userword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                in_log.PerformClick();
            }
        }

        private void user_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                userword.Focus();
            }
        }

        private void userword_TextChanged(object sender, EventArgs e)
        {
            userword.PasswordChar = '*';
        }

        private void userword_MouseUp(object sender, MouseEventArgs e)
        {
            string b = userword.Text;
            if (b == "Введите пароль")
            { 
                userword.Text = "";
            }    
        }

        private void user_MouseUp(object sender, MouseEventArgs e)
        {
            string a = user.Text;
            if (a == "Введите логин")
            {
                user.Text = "";
            }    
        }
    }
}