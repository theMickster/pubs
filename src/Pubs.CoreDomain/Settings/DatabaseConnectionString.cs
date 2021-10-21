using System;

namespace Pubs.CoreDomain.Settings
{
    public class DatabaseConnectionString
    {
        private string _connectionString = "Server=(local); Database=HelloWorld; Application Name=TestTestTest;";

        public string ConnectionStringName { get; set; }

        public string ConnectionString
        {
            get => _connectionString;
            set
            {
                if( string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The connection string cannot be null or empty");
                }

                if(!value.ToLower().Contains("server"))
                {
                    throw new Exception("The connection string must contain a 'Server' attribute.");
                }

                if (!value.ToLower().Contains("database") && !value.ToLower().Contains("initial catalog"))
                {
                    throw new Exception("The connection string must contain a 'database' or 'initial catalog' attribute.");
                }

                if(!value.ToLower().Contains("application name"))
                {
                    throw new Exception("The connection string must contain a 'application name' attribute to distinguish it from other database connections.");
                }

                _connectionString = value;

            }
        }
    }
}
