using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
namespace ht_698._45
{
    //数据库类操作
    class DbConnectClass
    {
        OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|test.mdb");
        OleDbCommand Comd;

        /// <summary>
        /// 数据库连接的打开与关闭
        /// </summary>
        /// <param name="IsOpen">结果</param>
        public void ConnectionMange(bool IsOpen)
        {
            try
            {
                if (IsOpen)
                {
                    if (Conn.State != ConnectionState.Open)
                        Conn.Open();
                }
                else
                {
                    if (Conn.State != ConnectionState.Closed)
                        Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 删除所有数据
        /// </summary>
        /// <param name="SqlString">语句</param>
        /// <returns>int</returns>
        public int ReMoveAll(string SqlString)
        {
            try
            {
                ConnectionMange(true);
                Comd = new OleDbCommand(SqlString, Conn);
                int enCount = Comd.ExecuteNonQuery();
                return enCount;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Comd.Dispose();
                ConnectionMange(false);
            }
        }

        /// <summary>
        ///更新数据
        /// </summary>
        /// <param name="SqlString">语句</param>
        /// <returns>int</returns>
        public int UpdataAll(string SqlString)
        {
            try
            {
                ConnectionMange(true);
                Comd = new OleDbCommand(SqlString, Conn);
                int enCount = Comd.ExecuteNonQuery();
                return enCount;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Comd.Dispose();
                ConnectionMange(false);
            }
        }

        /// <summary>
        ///查询，返回所有数据
        /// </summary>
        /// <param name="SqlString">语句</param>
        /// <returns>SqlDataReader</returns>
        public OleDbDataReader ReadAll(string SqlString)
        {
            try
            {
                ConnectionMange(true);
                Comd = new OleDbCommand(SqlString, Conn);
                return Comd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Comd.Dispose();
                //ConnectionMange(false);             
            }
        }

        /// <summary>
        ///增加数据
        /// </summary>
        /// <param name="SqlString">语句</param>
        /// <returns>int</returns>
        public int AddData(string SqlString)
        {
            try
            {
                ConnectionMange(true);
                Comd = new OleDbCommand(SqlString, Conn);
                int enCount = Comd.ExecuteNonQuery();
                return enCount;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Comd.Dispose();
                ConnectionMange(false);
            }
        }
    }
}