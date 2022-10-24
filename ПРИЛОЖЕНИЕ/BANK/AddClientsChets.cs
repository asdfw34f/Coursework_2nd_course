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
    public partial class AddClientsChets : Form
    {
        SqlDataAdapter sqlData = new SqlDataAdapter();
        SqlCommand command = new SqlCommand(@"Insert into [СЧЕТА]([НОМЕР_СЧЁТА], [НОМЕР_КЛИЕНТА]) VALUES(@CHET, @CLIENT)", MyConnection.GetConnection());

        public AddClientsChets()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //@CHET, @CLIENT
                command.Parameters.Add("@CHET", SqlDbType.VarChar).Value = НомерСчёта.Text;
                command.Parameters.Add("@CLIENT", SqlDbType.Int).Value = Convert.ToInt32(НомерСчёта.Text);
                MyConnection.OpenConnection();
                command.ExecuteNonQuery();
                MyConnection.CloseConnection();
                MessageBox.Show("Запись добавлена !", "Выполнение добавления записи");
                НомерСчёта.Text = null;
                НомерКлиента.Text = null;
            }
            catch
            {
                MessageBox.Show("Не удалось добавить запись!", "Ошибка добавления");
            }
        }

    }
}
