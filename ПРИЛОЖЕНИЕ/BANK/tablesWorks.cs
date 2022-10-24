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
    public partial class tablesWorks : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        string selectallworkers = @"SELECT * FROM [СОТРУДНИКИ]";
        string selectalluser = @"SELECT * FROM [ДАННЫЕ_ВХОДА]";

        private void UpdateWorks()
        {
            adapter.SelectCommand = null;
            if (dataGridViewСотрудники.Rows.Count > 0)
            {
                MyElements.tableWorks.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectallworkers;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.tableWorks);
            dataGridViewСотрудники.DataSource = MyElements.tableWorks;
        }

        private void UpdateUsers()
        {
            adapter.SelectCommand = null;
            if (dataGridViewПользователи.Rows.Count > 0)
            {
                MyElements.tableUser.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectalluser;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.tableUser);
            dataGridViewПользователи.DataSource = MyElements.tableUser;
        }

        public tablesWorks()
        {
            InitializeComponent();
        }

        private void tablesWorks_Load(object sender, EventArgs e)
        {
            UpdateWorks();
            UpdateUsers();
            if (MyElements.LOCK == false)
            {
                dataGridViewПользователи.Visible = false;
                textUsers.Visible = false;
                buttonAddUser.Visible = false;
                buttonDeleteUsers.Visible = false;
                buttonSearchUser.Visible = false;
                buttonUpDateUsers.Visible = false;
                label2.Visible = false;
            }
            else
            {
                dataGridViewПользователи.Visible = true;
                textUsers.Visible = true;
                buttonAddUser.Visible = true;
                buttonDeleteUsers.Visible = true;
                buttonSearchUser.Visible = true;
                buttonUpDateUsers.Visible = true;
                label2.Visible = true;
            }
        }

        private void buttonUpDateWorkers_Click(object sender, EventArgs e)
        {
            UpdateWorks();
        }

        private void buttonUpDateUsers_Click(object sender, EventArgs e)
        {
            UpdateUsers();
        }

        private void buttonAddWorkers_Click(object sender, EventArgs e)
        {
            Form form = new AddWorkers();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            Form form = new AddUser();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDeleteWorkers_Click(object sender, EventArgs e)
        {
            Form form = new DeleteWorkers();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDeleteUsers_Click(object sender, EventArgs e)
        {
            Form form = new DeleteUser();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonSearchWorkers_Click(object sender, EventArgs e)
        {
            adapter.SelectCommand = null;
            string sel = textWorkers.Text;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"SELECT * FROM [СОТРУДНИКИ] WHERE [СЕРИЯ_НОМЕР] = @sel";
            sqlCommand.Connection = MyConnection.Connection;
            sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = sel;
            adapter.SelectCommand = sqlCommand;
            MyElements.tableWorks.Clear();
            adapter.Fill(MyElements.tableWorks);
            textWorkers.Text = null;
            if (MyElements.tableWorks.Rows.Count < 1)
            {
                MessageBox.Show("Услуги с таким названием не существует");
            }
        }

        private void buttonSearchUser_Click(object sender, EventArgs e)
        {
            adapter.SelectCommand = null;
            string sel = textUsers.Text;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"SELECT * FROM [ДАННЫЕ_ВХОДА] WHERE [LOGIN] = @sel";
            sqlCommand.Connection = MyConnection.Connection;
            sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = sel;
            adapter.SelectCommand = sqlCommand;
            MyElements.tableUser.Clear();
            adapter.Fill(MyElements.tableUser);
            textUsers.Text = null;
            if (MyElements.tableUser.Rows.Count < 1)
            {
                MessageBox.Show("Услуги с таким названием не существует");

            }
        }

        private void buttonDeleteWorkers_Click_1(object sender, EventArgs e)
        {
            Form form = new DeleteWorkers();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDeleteUsers_Click_1(object sender, EventArgs e)
        {
            Form form = new DeleteUser();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonSearchWorkers_Click_1(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                string sel = textWorkers.Text;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [СОТРУДНИКИ] WHERE [СЕРИЯ_НОМЕР] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = textWorkers.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.tableWorks.Clear();
                adapter.Fill(MyElements.tableWorks);
            }
            catch
            {
                if (MyElements.tableWorks.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }

        private void buttonSearchUser_Click_1(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                string sel = textUsers.Text;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [ДАННЫЕ_ВХОДА] WHERE [LOGIN] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = textUsers.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.tableUser.Clear();
                adapter.Fill(MyElements.tableUser);
            }
            catch
            {
                if (MyElements.tableUser.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }

        private void buttonAddUser_Click_1(object sender, EventArgs e)
        {
            Form form = new AddUser();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }
    }
}
