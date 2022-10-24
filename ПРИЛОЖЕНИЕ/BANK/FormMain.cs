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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                if (MyElements.LOCK)
                {
                    MessageBox.Show("Вы вошли как Администратор!", "Вход выполнен");
                }
                else
                    MessageBox.Show("Авторизация прошла успешно!", "Вход выполнен");
            }
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                                "Вы действительно хотите выйти?",
                                "Выход из приложения",
                                MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button1
                               );
            switch (result)
            {
                case DialogResult.Yes:
                    Cursor.Current = Cursors.WaitCursor;
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void закрытьВсеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                do
                {
                    MdiChildren[0].Close();

                } while (MdiChildren.Count() > 0);
            }
            catch  {

                MessageBox.Show("Все окна закрыты");
            }
        }

        private void свернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void плавующаяОбластьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }else
            this.WindowState = FormWindowState.Normal;
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

        private void договорыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new tablesdealsform();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void отделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new tablesTypesdeals();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new tablesWorks();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new tablesClients();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
    }
}
