using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ht_698._45
{
    public static class AccessHelper
    {
        private static string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", Application.StartupPath + @"\DB.MDB");

        private static OleDbConnection connection = null;

        /// <summary>
        /// 创建一个OleDbCommand对象实例
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="connection">数据库连接对象实例OleDbConnection</param>
        /// <param name="oleDbParameters">可选参数</param>
        /// <returns></returns>
        private static OleDbCommand CreateCommand(string commandText, OleDbConnection connection, params System.Data.OleDb.OleDbParameter[] oleDbParameters)
        {
            if (connection == null)
                connection = new OleDbConnection(connectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();                                        

            OleDbCommand comm = new OleDbCommand(commandText, connection);
            if (oleDbParameters != null)
            {
                foreach (OleDbParameter parm in oleDbParameters)
                {
                    comm.Parameters.Add(parm);
                }
            }
            return comm;
        }

        /// <summary>
        /// 创建一个OleDbParameter参数对象实例
        /// </summary>
        /// <param name="parmname">参数名称</param>
        /// <param name="parmvalue">参数值</param>
        /// <returns></returns>
        public static OleDbParameter MakeParm(string parmname, object parmvalue)
        {
            return new OleDbParameter(parmname, parmvalue);
        }

        /// <summary>
        /// 执行 SQL INSERT、DELETE、UPDATE 和 SET 语句等命令。
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="oleDbParameters">可选参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string commandText, params System.Data.OleDb.OleDbParameter[] oleDbParameters)
        {
            int value=0;

            if (connection == null)
                connection = new OleDbConnection(connectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            OleDbCommand comm = new OleDbCommand(commandText, connection);
            if (oleDbParameters != null)
            {
                foreach (OleDbParameter parm in oleDbParameters)
                {
                    comm.Parameters.Add(parm);
                }
            }
            value = comm.ExecuteNonQuery();
            connection.Close();
            comm.Dispose();
            return value;
        }

        /// <summary>
        /// 从数据库中检索单个值(例如一个聚合值)。
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="oleDbParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string commandText, params System.Data.OleDb.OleDbParameter[] oleDbParameters)
        {
            OleDbCommand comm = CreateCommand(commandText, connection, oleDbParameters);
            return comm.ExecuteScalar();
        }

        /// <summary>
        /// 提供读取数据行的方法。
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="oleDbParameters">可选参数</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader ExecuteDataReader(string commandText, params System.Data.OleDb.OleDbParameter[] oleDbParameters)
        {
            OleDbCommand comm = CreateCommand(commandText, connection, oleDbParameters);
            return comm.ExecuteReader();
        }

        /// <summary>
        /// 表示一组数据命令和一个数据库连接，它们用于填充 DataSet 和更新数据源。
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="oleDbParameters">可选参数</param>
        /// <returns></returns>
        public static OleDbDataAdapter ExecuteDataAdapter(string commandText, params System.Data.OleDb.OleDbParameter[] oleDbParameters)
        {
            OleDbCommand comm = CreateCommand(commandText, connection, oleDbParameters);
            OleDbDataAdapter da = new OleDbDataAdapter(comm);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            return da;
        }

        /// <summary>
        /// 返回一个DataSet数据集。
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="oleDbParameters">可选参数</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string commandText, params OleDbParameter[] oleDbParameters)
        {
            DataSet ds = new DataSet();
            OleDbCommand comm = CreateCommand(commandText, connection, oleDbParameters);
            OleDbDataAdapter da = new OleDbDataAdapter(comm);
            da.Fill(ds);
            return ds;
        }
    }
}