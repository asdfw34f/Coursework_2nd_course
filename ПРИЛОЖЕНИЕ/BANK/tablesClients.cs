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
    public partial class tablesClients : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        string selectallclients = @"SELECT * FROM [КЛИЕНТЫ]";
        string selectalldogovotclient = @"SELECT * FROM [ДОГОВОРЫ_КЛИЕНТОВ]";
        string selectallchets = @"SELECT * FROM [СЧЕТА]";
        string selectallhistoryoper = @"SELECT * FROM [ИСТОРИЯ_ОПЕРАЦИЙ]";

        private void UpdateClients()
        {
            adapter.SelectCommand = null;
            if (dataGridViewClients.Rows.Count > 0)
            {
                MyElements.tableClients.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectallclients;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.tableClients);
            dataGridViewClients.DataSource = MyElements.tableClients;
        }

        private void UpdateDogovors()
        {
            adapter.SelectCommand = null;
            if (dataGridViewDogovors.Rows.Count > 0)
            {
                MyElements.tableDogovotClients.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectalldogovotclient;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.tableDogovotClients);
            dataGridViewDogovors.DataSource = MyElements.tableDogovotClients;
        }

        private void UpdateChets()
        {
            adapter.SelectCommand = null;
            if (dataGridViewChets.Rows.Count > 0)
            {
                MyElements.tableChet.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectallchets;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.tableChet);
            dataGridViewChets.DataSource = MyElements.tableChet;
        }

        private void UpdateHistory()
        {
            adapter.SelectCommand = null;
            if (dataGridViewHistory.Rows.Count > 0)
            {
                MyElements.tableHistoryOper.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectallhistoryoper;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.tableHistoryOper);
            dataGridViewHistory.DataSource = MyElements.tableHistoryOper;
        }
        public tablesClients()
        {
            InitializeComponent();
        }



        private void button11_Click(object sender, EventArgs e)
        {
            UpdateChets();
        }

        private void tablesClients_Load(object sender, EventArgs e)
        {
            UpdateClients();
            UpdateDogovors();
            UpdateChets();
            UpdateHistory();
        }

        private void buttonUpdateHistory_Click(object sender, EventArgs e)
        {
            UpdateHistory();
        }

        private void buttonUpdateDogovorsClients_Click(object sender, EventArgs e)
        {
            UpdateDogovors();
        }

        private void buttonUpdateClients_Click(object sender, EventArgs e)
        {
            UpdateClients();
        }

        private void buttonAddClients_Click(object sender, EventArgs e)
        {
            Form form = new AddClients();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonAddChet_Click(object sender, EventArgs e)
        {
            Form form = new AddClientsChets();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonAddDogovorClient_Click(object sender, EventArgs e)
        {
            Form form = new AddClientsDogovors();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonAddHistory_Click(object sender, EventArgs e)
        {
            Form form = new AddClientsOperation();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDeleteClients_Click(object sender, EventArgs e)
        {
            Form form = new DeleteClients();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDeleteDogovorClients_Click(object sender, EventArgs e)
        {
            Form form = new DeleteClientsDogovors();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDeleteHistory_Click(object sender, EventArgs e)
        {
            Form form = new DeleteClientsOperation();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonSearchClients_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                string sel = textClients.Text;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [КЛИЕНТЫ] WHERE [СЕРИЯ_НОМЕР] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = textClients.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.tableClients.Clear();
                adapter.Fill(MyElements.tableClients);
            }
            catch
            {
                if (MyElements.tableClients.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }

        private void buttonSearchChet_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                string sel = textBoxChets.Text;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [СЧЕТА] WHERE [НОМЕР_КЛИЕНТА] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = textBoxChets.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.tableChet.Clear();
                adapter.Fill(MyElements.tableChet);
            }
            catch
            {
                if (MyElements.tableChet.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }

        private void buttonSearchHistory_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                string sel = textBoxHistory.Text;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [ИСТОРИЯ_ОПЕРАЦИЙ] WHERE [НОМЕР_СЧЁТА] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = textBoxHistory.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.tableHistoryOper.Clear();
                adapter.Fill(MyElements.tableHistoryOper);
            }
            catch
            {
                if (MyElements.tableHistoryOper.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }

        private void buttonSearchDogovorClients_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                string sel = textBoxDogovorClient.Text;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [ДОГОВОРЫ_КЛИЕНТОВ] WHERE [НОМЕР_КЛИЕНТА] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.Int).Value = textBoxDogovorClient.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.tableDogovotClients.Clear();
                adapter.Fill(MyElements.tableDogovotClients);
            }
            catch
            {
                if (MyElements.tableDogovotClients.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }
    }
}
