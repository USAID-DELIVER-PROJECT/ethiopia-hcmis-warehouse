using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace HCMIS.Desktop.Helpers
{
    class DatabaseHelper
    {
        public static void RunScriptsOnDatabase()
        {


        
        }

        private static bool ExecuteSqlOnDatabase(SqlConnection connection, string sqlFile)
        {
            string sql = "";

            using (FileStream strm = File.OpenRead(sqlFile))
            {
                StreamReader reader = new StreamReader(strm);
                sql = reader.ReadToEnd();
            }

            Regex regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string[] lines = regex.Split(sql);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlTransaction transaction = connection.BeginTransaction();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;

                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {
                        cmd.CommandText = line;
                        cmd.CommandType = CommandType.Text;

                        try
                        {
                            cmd.ExecuteNonQuery();                            
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }

            transaction.Commit();
            return true;
        }


        /// <summary>
        /// Use this function to fix database inconsistencies.
        /// </summary>
        internal static void FixInconsistencies()
        {
            BLL.Issue.FixInconsistencies();
            //BLL.ReceivePallet.FixInconsistencies();
        }
    }
}
