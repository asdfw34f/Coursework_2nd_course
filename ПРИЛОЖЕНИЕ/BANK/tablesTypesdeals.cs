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
    public partial class tablesTypesdeals : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        string selectTypecredit = @"SELECT * FROM [ВИДЫ_КРЕДИТОВ]";
        string selectTypevclads = @"SELECT * FROM [ВИДЫ_ВКЛАДОВ]";
        string selectTypecards = @"SELECT * FROM [ВИДЫ_ДЕБЕТОВЫХ_КАРТ]";

        private void UpdateTypeCreadits()
        {
            adapter.SelectCommand = null;
            if (dataGridViewTypeCredits.Rows.Count > 0)
            {
                MyElements.TypeCreadits.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectTypecredit;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.TypeCreadits);
            dataGridViewTypeCredits.DataSource = MyElements.TypeCreadits;
        }

        private void UpdateTypeVclads()
        {
            adapter.SelectCommand = null;
            if (dataGridViewTypeVclad.Rows.Count > 0)
            {
                MyElements.TypeVclads.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectTypevclads;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.TypeVclads);
            dataGridViewTypeVclad.DataSource = MyElements.TypeVclads;
        }

        private void UpdateTypeCards()
        {
            adapter.SelectCommand = null;
            if (dataGridViewTypeCards.Rows.Count > 0)
            {
                MyElements.TypeCards.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectTypecards;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.TypeCards);
            dataGridViewTypeCards.DataSource = MyElements.TypeCards;
        }

        public tablesTypesdeals()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateTypeCreadits();
        }

        private void tablesTypesdeals_Load(object sender, EventArgs e)
        {
            UpdateTypeCreadits();
            UpdateTypeVclads();
            UpdateTypeCards();
        }

        private void buttonsearchcredit_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [ВИДЫ_КРЕДИТОВ] WHERE [КОД_УСЛУГИ] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = textBoxTcredit.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.TypeCreadits.Clear();
                adapter.Fill(MyElements.TypeCreadits);
            }
            catch
            {
                if (MyElements.TypeCreadits.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }

        private void buttonsearchvclads_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [ВИДЫ_ВКЛАДОВ] WHERE [КОД_УСЛУГИ] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = textBoxvclad.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.TypeVclads.Clear();
                adapter.Fill(MyElements.TypeVclads);
            }
            catch
            {
                if (MyElements.TypeVclads.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }

        private void buttonsearchcards_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [ВИДЫ_ДЕБЕТОВЫХ_КАРТ] WHERE [КОД_УСЛУГИ] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = textBoxcards.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.TypeCards.Clear();
                adapter.Fill(MyElements.TypeCards);
            }
            catch
            {
                if (MyElements.TypeCards.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }
        private void buttonAddTVclad_Click(object sender, EventArgs e)
        {
            Form add = new AddTypeVclad();
            add.StartPosition = FormStartPosition.CenterScreen;
            add.Size = new Size(455, 270);
            add.Show();
        }

        private void buttonAddTCards_Click(object sender, EventArgs e)
        {
            Form add = new AddTypeCard();
            add.StartPosition = FormStartPosition.CenterScreen;
            add.Size = new Size(455, 270);
            add.Show();
        }

        private void buttonAddTcredit_Click(object sender, EventArgs e)
        {
            Form add = new AddTypeCredit();
            add.StartPosition = FormStartPosition.CenterScreen;
            add.Size = new Size(455, 270);
            add.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateTypeCreadits();
            textBoxTcredit.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTypeVclads();
            textBoxvclad.Text = null;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UpdateTypeCards();
            textBoxcards.Text = null;
        }

        private void buttonDeleteTcredit_Click(object sender, EventArgs e)
        {
            Form form = new DeleteTypeCredit();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDeleteTVclad_Click(object sender, EventArgs e)
        {
            Form form = new DeleteTypeVclad();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDeleteTcards_Click(object sender, EventArgs e)
        {
            Form form = new DeleteTypeCard();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }
    }
}
