using MySql.Data.MySqlClient;
using Mysqlx.Notice;
using System.Data;
namespace ArchiveFund
{
    internal class Sql
    {
        /*public static object[,]? Query(string request, MySqlConnection mySqlConnection, out MySqlDataReader? reader, MySqlParameter[]? parameters = null)
        {
            try
            {
                var mySqlCommand = new MySqlCommand(request, mySqlConnection);
                if (parameters is not null) mySqlCommand.Parameters.AddRange(parameters);
                reader = mySqlCommand.ExecuteReader();
                return Query(new object[0, reader.FieldCount], ref reader, mySqlConnection, false);
            }
            catch (Exception ex)
            {
                SqlRequestErrors(ex);
                reader = null;
                return null;
            }
        }
        public static object[,] Query(object[,] output, ref MySqlDataReader reader, MySqlConnection mySqlConnection, bool auto)
        {
            if (!reader.Read() || reader is null)
            {
                if (auto)
                    mySqlConnection.Close();
                return output;
            }
            object[,] result = new object[output.GetLength(0) + 1, reader.FieldCount];
            for (int i = 0; i < output.GetLength(0); i++)
                for (int i1 = 0; i1 < output.GetLength(1); i1++)
                    result[i, i1] = output[i, i1];
            for (int i = 0; i < output.GetLength(1); i++)
                result[result.GetLength(0) - 1, i] = reader[i];
            return Query(result, ref reader, mySqlConnection, auto);
        }
        public static object[,]? Query(string request, MySqlParameter[]? parameters = null)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionStringBuilding.ConnectionString);
            try
            {
                mySqlConnection.Open();
                return Query(request, mySqlConnection, out var reader, parameters);
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
        }*/
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
        public static object[,] SqlRequestErrors(Exception ex)
        {
            object[,] ErrorResult = new object[,] { { "Message: " + ex.Message,
                "StackTrace: " + (ex.StackTrace is not null ? ex.StackTrace : "NULL"),
                "HelpLink: " + (ex.HelpLink is not null ? ex.HelpLink : "NULL"),
                "HResult: " + (ex.HResult),
                "Source: " + (ex.Source is not null ? ex.Source : "NULL"),
                "TargetSite.Name: " + (ex.TargetSite is not null ? ex.TargetSite.Name : "NULL") } };
#if DEBUG
            if (MessageBox.Show(ErrorResult[0, 0].ToString() +
                ErrorResult[0, 1].ToString() + ErrorResult[0, 2].ToString() +
                ErrorResult[0, 3].ToString() + ErrorResult[0, 4].ToString() +
                ErrorResult[0, 5].ToString(), "!SqlRequest! -> exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Environment.Exit(0);
#endif
            return ErrorResult;
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
