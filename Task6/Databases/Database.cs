using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Databases
{
    /// <summary>
    /// Main datebase.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Database.
        /// </summary>
        private static Database _database;

        public static Database GetDatabase()
        {
            return _database;
        }

        /// <summary>
        /// Create new way to database.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        /// <returns>Datebase.</returns>
        public static Database GetDatabase(string connectionString)
        {
            if (_database == null)
            {
                _database = new Database(connectionString);
            }
            return _database;
        }

        /// <summary>
        /// Connection string.
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// Connection.
        /// </summary>
        public SqlConnection Connection { get; }

        /// <summary>
        /// CMD.
        /// </summary>
        private IDbCommand CMD { get; set; }

        /// <summary>
        /// Create new datebase.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        private Database(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.Connection = new SqlConnection(connectionString);
            this.CMD = Connection.CreateCommand();
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="name">Name column.</param>
        /// <param name="value">Value for add.</param>
        /// <returns>New datebase.</returns>
        public Database AddParameter<T>(string name, T value)
        {
            SqlParameter param = new SqlParameter();

            param.ParameterName = name;
            param.Value = value;
            CMD.Parameters.Add(param);

            return this;
        }


        /// <summary>
        /// Do query.
        /// </summary>
        /// <param name="query">Query.</param>
        public void ExecuteNonQuery(string query)
        {
            using (Connection)
            {
                CMD.CommandText = query;
                Connection.Open();
                CMD.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Get information from data base.
        /// </summary>
        /// <typeparam name="T">IUniversity.</typeparam>
        /// <param name="query">Query.</param>
        /// <returns></returns>
        public List<T> ExecuteQuery<T>(string query)
        {
            List<T> list = new List<T>();
            Type type = typeof(T);

            using (var connection = new SqlConnection(ConnectionString))
            {
                IDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                CMD.CommandText = query;
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    T obj = (T)Activator.CreateInstance(type);
                    type.GetProperties().ToList()
                        .ForEach(p => { p.SetValue(obj, reader[p.Name]); });
                    reader.GetValue(0);
                    list.Add(obj);
                }
            }


            return list;
        }
    }
}
