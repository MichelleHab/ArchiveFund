using MySql.Data.MySqlClient;
using Mysqlx.Notice;
using System.Data;
namespace ArchiveFund
{
    internal class Sql
    {        
        public static DataTable? Query(string request, MySqlParameter[]? parameters = null)
        {
            MySqlConnection mySqlConnection = new(ConnectionStringBuilding.ConnectionString);
            try
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new(request, mySqlConnection);
                if (parameters is not null)
                    mySqlCommand.Parameters.AddRange(parameters);
                DataTable dt = new();
                new MySqlDataAdapter(mySqlCommand).Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                SqlRequestErrors(ex);
                return null;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        public static object? QueryOneReturn(string request, MySqlParameter[]? parameters = null)
        {
            MySqlConnection mySqlConnection = new(ConnectionStringBuilding.ConnectionString);
            try
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new(request, mySqlConnection);
                if (parameters is not null)
                    mySqlCommand.Parameters.AddRange(parameters);
                var rdr = mySqlCommand.ExecuteReader();
                if (rdr.Read())
                    return rdr[0];
                else return null;
            }
            catch (Exception ex)
            {
                SqlRequestErrors(ex);
                return null;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        public static bool QueryNonReturns(string request, MySqlParameter[]? parameters = null)
        {
            MySqlConnection mySqlConnection = new(ConnectionStringBuilding.ConnectionString);
            try
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new(request, mySqlConnection);
                if (parameters is not null)
                    mySqlCommand.Parameters.AddRange(parameters);
                mySqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                SqlRequestErrors(ex);
                return false;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        public static bool ExportToFile(string filePath)
        {
            var conn = new MySqlConnection(ConnectionStringBuilding.ConnectionString);
            try
            {
                var mySqlBackup = new MySqlBackup(conn.CreateCommand());
                conn.Open();
                mySqlBackup.ExportToFile(filePath);
                return true;
            }
            catch { return false; }
            finally
            {
                conn.Close();
            }
        }
        public static string SqlRequestErrors(Exception ex)
        {
            var result = "Message: " + ex.Message;
#if DEBUG
            if (MessageBox.Show(result, "!SqlRequest! -> exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Environment.Exit(0);
#endif
            return result;
        }
        public static MySqlConnectionStringBuilder ConnectionStringBuilding = new()
        {
            Server = "localhost",
            Port = 3306,
            UserID = "root",
            Password = "",
            Database = "mysql",
            ConnectionTimeout = 5
        };
    }
}
