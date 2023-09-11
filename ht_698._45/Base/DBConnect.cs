using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace ht_698._45
{
    internal class DBConnect
    {
        private static bool IsOpen = false;
        private static OleDbConnection sqlCon = new OleDbConnection();
        private static OleDbDataAdapter sqlda;
        private static DataSet sqlds = new DataSet();

        public static int Count(string strsql)
        {
            try
            {
                if (ConnectionState.Open == sqlCon.State)
                {
                    DataTable dataTable = new DataTable();
                    sqlda = new OleDbDataAdapter(strsql, sqlCon);
                    sqlda.Fill(dataTable);
                    return dataTable.Rows.Count;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return -1;
        }

        public static OleDbDataReader DataReader(string strsql)
        {
            try
            {
                if (ConnectionState.Open == sqlCon.State)
                {
                    OleDbCommand command = new OleDbCommand(strsql, sqlCon);
                    return command.ExecuteReader();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return null;
        }

        public static void DBClose()
        {
            if (IsOpen)
            {
                sqlCon.Close();
                sqlCon.Dispose();
                IsOpen = false;
            }
        }

        public static bool DBOpen()
        {
            if (IsOpen)
            {
                return true;
            }
            string str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + @"\Database\MeterMS.698.45.mdb;Persist Security Info=False;Jet OLEDB:Database Password=ht654321";
            Version version = Environment.OSVersion.Version;
            if ((version.Major == 5) && (version.Minor == 1))
            {
                str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + @"\Database\MeterMS.698.45.mdb;Persist Security Info=False;Jet OLEDB:Database Password=ht654321";
            }
            else if ((version.Major == 6) && (version.Minor == 0))
            {
                str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + @"\Database\MeterMS.698.45.mdb;Persist Security Info=False;Jet OLEDB:Database Password=ht654321";
            }
            else if ((version.Major == 6) && (version.Minor == 1))
            {
                str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + @"\Database\MeterMS.698.45.mdb;Persist Security Info=False;Jet OLEDB:Database Password=ht654321";
            }
            else if ((version.Major == 5) && (version.Minor == 0))
            {
                str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + @"\Database\MeterMS.698.45.mdb;Persist Security Info=False;Jet OLEDB:Database Password=ht654321";
            }
            else
            {
                str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + @"\Database\MeterMS.698.45.mdb;Persist Security Info=False;Jet OLEDB:Database Password=ht654321";
            }
            sqlCon.ConnectionString = str;
            try
            {
                if (ConnectionState.Open != sqlCon.State)
                {
                    sqlCon.Open();
                    IsOpen = true;
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IsOpen = false;
                return false;
            }
        }

        public static int ExecuteNonQuery(string strsql)
        {
            try
            {
                if (ConnectionState.Open == sqlCon.State)
                {
                    OleDbCommand command = new OleDbCommand(strsql, sqlCon);
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return -1;
        }

        public static ConnectionState GetConnectionState() 
        {
            return sqlCon.State;
        }

        public static OleDbConnection GetSysSqlConnection()
        {
            if (ConnectionState.Open == sqlCon.State)
            {
                return sqlCon;
            }
            return null;
        }

        public static DataTable Result(string sqlstr, string tablename)
        {
            if (tablename == null)
            {
                tablename = "TempData";
            }
            try
            {
                if (ConnectionState.Open == sqlCon.State)
                {
                    DataTable dataTable = new DataTable(tablename);
                    sqlda = new OleDbDataAdapter(sqlstr, sqlCon);
                    sqlda.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return null;
        }
    }
}

