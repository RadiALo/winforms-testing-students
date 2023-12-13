using System.Data.Odbc;
using System.Data;

namespace Testing_students
{
    public static class Connector
    {
        static string ConnectionString = @"Dsn=Testing Students Server;uid=root;pwd=12345;server=localhost;database=testing_students;port=3306";

        public static DataTable ExecuteSelectQuery(string Query)
        {
            OdbcConnection conn = new OdbcConnection(ConnectionString);
            conn.Open();
            OdbcDataAdapter oda = new OdbcDataAdapter(Query, conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            conn.Close();
            return dt;
        }

        public static void ExecuteQuery(string Query)
        {
            OdbcConnection conn = new OdbcConnection(ConnectionString);
            conn.Open();
            OdbcCommand oda = new OdbcCommand(Query, conn);
            oda.ExecuteNonQuery();
            conn.Close();
        }
    }
}
