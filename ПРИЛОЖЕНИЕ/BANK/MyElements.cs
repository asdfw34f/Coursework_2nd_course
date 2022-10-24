using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BANK
{
    static public class MyElements
    {
        static public DataTable tablefordeals = new DataTable();
        static public DataTable tableforCreadits = new DataTable();
        static public DataTable tableforVclads = new DataTable();
        static public DataTable tableforCards = new DataTable();
        static public DataTable TypeCards = new DataTable();
        static public DataTable TypeCreadits = new DataTable();
        static public DataTable TypeVclads = new DataTable();
        static public DataTable tableWorks = new DataTable();
        static public DataTable tableUser = new DataTable();
        static public DataTable tableClients = new DataTable();
        static public DataTable tableChet = new DataTable();
        static public DataTable tableHistoryOper = new DataTable();
        static public DataTable tableDogovotClients = new DataTable();


        static public bool LOCK = false;
    }
}
