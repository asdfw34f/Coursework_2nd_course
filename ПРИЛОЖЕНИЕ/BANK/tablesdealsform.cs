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
    public partial class tablesdealsform : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        string selectdeal = @"SELECT * FROM [БАНКОВСКИЕ_УСЛУГИ]";
        string selectcredit = @"SELECT * FROM [ОФОРМЛЕННЫЕ_КРЕДИТЫ]";
        string selectvclads = @"SELECT * FROM [ОФОРМЛЕННЫЕ_ВКЛАДЫ]";
        string selectcards = @"SELECT * FROM [ОФОРМЛЕННЫЕ_ДЕБЕТОВЫЕ_КАРТЫ]";

        private void UpdateDeals()
        {
            adapter.SelectCommand = null;
            if (dataGridViewdealse.Rows.Count > 0)
            {
                MyElements.tablefordeals.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectdeal;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.tablefordeals);
            dataGridViewdealse.DataSource = MyElements.tablefordeals;
        }

        private void UpdateCredits()
        {
            adapter.SelectCommand = null;
            if (dataGridViewCredits.Rows.Count > 0)
            {
                MyElements.tableforCreadits.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectcredit;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.tableforCreadits);
            dataGridViewCredits.DataSource = MyElements.tableforCreadits;
        }

        private void UpdateVclads()
        {
            adapter.SelectCommand = null;
            if (dataGridViewVclads.Rows.Count > 0)
            {
                MyElements.tableforVclads.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectvclads;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.tableforVclads);
            dataGridViewVclads.DataSource = MyElements.tableforVclads;
        }

        private void UpdateCards()
        {
            adapter.SelectCommand = null;
            if (dataGridViewCards.Rows.Count > 0)
            {
                MyElements.tableforCards.Clear();
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = selectcards;
            sqlCommand.Connection = MyConnection.Connection;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(MyElements.tableforCards);
            dataGridViewCards.DataSource = MyElements.tableforCards;
        }

        public tablesdealsform()
        {
            InitializeComponent();
        }

        private void deals_Load(object sender, EventArgs e)
        {
            UpdateDeals();
            UpdateCredits();
            UpdateVclads();
            UpdateCards();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapter.SelectCommand = null;
            string sel = select_deals_text.Text;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"SELECT * FROM [БАНКОВСКИЕ_УСЛУГИ] WHERE [НАЗВАНИЕ] = @sel";
            sqlCommand.Connection = MyConnection.Connection;
            sqlCommand.Parameters.Add("@sel", SqlDbType.VarChar).Value = sel;
            adapter.SelectCommand = sqlCommand;
            MyElements.tablefordeals.Clear();
            adapter.Fill(MyElements.tablefordeals);
            if (MyElements.tablefordeals.Rows.Count < 1)
            {
                MessageBox.Show("Услуги с таким названием не существует");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDeals();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form add = new AddDeal();
            add.StartPosition = FormStartPosition.CenterScreen;
            add.Size = new Size(655, 185);
            add.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateDeals();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form = new DeleteDeal();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonCreditsearch_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                string sel = textCredits.Text;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [ОФОРМЛЕННЫЕ_КРЕДИТЫ] WHERE [НОМЕР_ДОГОВОРА] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.Int).Value = textCredits.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.tableforCreadits.Clear();
                adapter.Fill(MyElements.tableforCreadits);
            }
            catch
            {
                if (MyElements.tableforCreadits.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }

        private void buttonUpcredits_Click(object sender, EventArgs e)
        {
            UpdateCredits();
        }

        private void buttonCancelCredit_Click(object sender, EventArgs e)
        {
            UpdateCredits();
        }

        private void buttonAddcredit_Click(object sender, EventArgs e)
        {
            Form form = new creditAdd();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDelcredit_Click(object sender, EventArgs e)
        {
            Form form = new DeleteCredit();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            UpdateVclads();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UpdateVclads();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [ОФОРМЛЕННЫЕ_ВКЛАДЫ] WHERE [НОМЕР_ДОГОВОРА] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.Int).Value = textBoxVclad.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.tableforVclads.Clear();
                adapter.Fill(MyElements.tableforVclads);
            }
            catch
            {
                if (MyElements.tableforVclads.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }

        private void buttonAddvclad_Click(object sender, EventArgs e)
        {
            Form form = new AddVclad();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDeteteVclad_Click(object sender, EventArgs e)
        {
            Form form = new DeleteVclads();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            try
            {
                adapter.SelectCommand = null;
                string sel = textCredits.Text;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"SELECT * FROM [ОФОРМЛЕННЫЕ_ДЕБЕТОВЫЕ_КАРТЫ] WHERE [НОМЕР_ДОГОВОРА] = @sel";
                sqlCommand.Connection = MyConnection.Connection;
                sqlCommand.Parameters.Add("@sel", SqlDbType.Int).Value = textBoxCards.Text;
                adapter.SelectCommand = sqlCommand;
                MyElements.tableforCards.Clear();
                adapter.Fill(MyElements.tableforCards);
            }
            catch
            {
                if (MyElements.tableforCreadits.Rows.Count < 1)
                {
                    MessageBox.Show("Услуги с таким названием не существует");
                }
            }
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            UpdateCards();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            UpdateCards();
        }

        private void buttonAddCards_Click(object sender, EventArgs e)
        {
            Form form = new AddCards();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonDeleteCards_Click(object sender, EventArgs e)
        {
            Form form = new DeleteCard();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void buttonTcredit_Click(object sender, EventArgs e)
        {
            UpdateDeals();
            select_deals_text.Text = null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateCredits();
            textCredits.Text = null;
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            UpdateVclads();
            textBoxVclad.Text = null;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UpdateCards();
            textBoxCards.Text = null;
        }
    }
}

