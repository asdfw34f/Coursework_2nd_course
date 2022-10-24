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
    public partial class AddClientsDogovors : Form
    {
        SqlDataAdapter sqlData = new SqlDataAdapter();
        SqlCommand command = new SqlCommand(@"Insert into [ДОГОВОРЫ_КЛИЕНТОВ]([НОМЕР_ДОГОВОРА], [НОМЕР_КЛИЕНТА], [ДАТА_ЗАКЛЮЧЕНИЯ], [ДАТА_ОКОНЧАНИЯ], [НОМЕР_СЧЁТА], [НОМЕР_СОТРУДНИКА]) VALUES(@NUMDOG, @CLIENT, @DATESTART, @DATEFIFNISH, @NUMCHET, @NUMWORKER)", MyConnection.GetConnection());

        public AddClientsDogovors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numdog = textNumdogovorclient.Text;
            Convert.ToInt32(numdog);
            string numcl = textNumclient.Text;
            Convert.ToInt32(numcl);
            string sdate = datastart.Text;
            string fdate = datefinish.Text;
            string numch = numchet.Text;
            string numw = textnumworkers.Text;
            Convert.ToInt32(numw);

            //@NUMDOG, @CLIENT, @DATESTART, @DATEFIFNISH, @NUMCHET, @NUMWORKER
            try
            {
                command.Parameters.Add("@NUMDOG", SqlDbType.Int).Value = numdog;
                command.Parameters.Add("@CLIENT", SqlDbType.Int).Value = numcl;
                command.Parameters.Add("@DATESTART", SqlDbType.Date).Value = sdate;
                command.Parameters.Add("@DATEFIFNISH", SqlDbType.Date).Value = fdate;
                command.Parameters.Add("@NUMCHET", SqlDbType.VarChar).Value = numch;
                command.Parameters.Add("@NUMWORKER", SqlDbType.Int).Value = numw;
                MyConnection.OpenConnection();
                command.ExecuteNonQuery();
                MyConnection.CloseConnection();
                MessageBox.Show("Запись добавлена !", "Выполнение добавления записи");
                textNumdogovorclient.Text = null;
                textNumclient.Text = null;
                datastart.Text = null;
                datefinish.Text = null;
                numchet.Text = null;
                textnumworkers.Text = null;
            }
            catch
            {
                MessageBox.Show("Не удалось добавить запись!", "Ошибка добавления");
            }
        }
    }
}
