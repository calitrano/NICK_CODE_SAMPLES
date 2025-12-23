using System;
using Oracle.ManagedDataAccess.Client;

namespace ORACLE_EXTRACT_DESKTOP_AUG_21
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var oracleHelper = new OraHelper())
                {
                    oracleHelper.Connect();

                    using (var cmd = new OracleCommand("SELECT * FROM EVENTS", oracleHelper.Connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("Rows returned from Oracle:");

                            while (reader.Read())
                            {
                                Console.WriteLine(
                                    $"{reader["type"]} {reader["event_date"]} {reader["description"]}"
                                );
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found in EVENTS table.");
                        }
                    }
                }

                Console.WriteLine("Program completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled error in Main:");
                Console.WriteLine(ex.Message);
            }
        }
    }

    class OraHelper : IDisposable
    {
        public OracleConnection Connection { get; private set; }

        public void Connect()
        {
            try
            {
                // Connection string intentionally redacted.
                // Expected format:
                // User Id=<username>;Password=<password>;Data Source=<host>:<port>/<service_name>;

                Connection = new OracleConnection(
                    "User Id=<USER>;Password=<PASSWORD>;Data Source=localhost:1521/XEPDB1"
                );

                Connection.Open();
                Console.WriteLine($"Connected to Oracle. Server version: {Connection.ServerVersion}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect to Oracle:");
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}
