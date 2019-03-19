using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tirdea_Denis_Alexandru_3133A
{
    class DataBaseConnection
    {
        string Command;
        private static string CONNECTION_STRING = "DATA SOURCE=localhost:1521/xe;User Id=MyDB;Password=system";

        public DataBaseConnection(string Command)
        {
            this.Command = Command;
            ReadTables();
        }

        public DataTable ReadTables()
        {
            SQLMenuOracle form = new SQLMenuOracle();
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection();
            try
            {
                using (conn = new OracleConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    using (OracleDataAdapter oda = new OracleDataAdapter(Command, conn))
                    {
                        oda.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Dispose();
            }
            return dt;
        }

        public static void InsertIntoDataBase(string Command)
        {
            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = Command;

                int rezult = cmd.ExecuteNonQuery();
                if (rezult > 0)
                {

                }
                else
                {
                    MessageBox.Show("Eroare");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }

        }
    }
}
