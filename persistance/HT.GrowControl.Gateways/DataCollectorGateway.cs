using HT.GrowControl.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.GrowControl.Gateways
{
    public class DataCollectorGateway
    {
        private string _connectionString = ConfigurationManager.AppSettings["DataCollectorConnectionString"].ToString();

        public DataCollectorGateway()
        {

        }

        public DataCollectorGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<DataCollectorModel> GetCollectedData()
        {
            List<DataCollectorModel> savedItems = new List<DataCollectorModel>();
            using (var conn = new SQLiteConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM History order by TimeStamp desc";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DataCollectorModel text = new DataCollectorModel();
                        text.Id = Convert.ToInt32(reader["ID"].ToString());
                        text.DeviceId = Convert.ToInt32(reader["DeviceId"].ToString());
                        text.Name = (string)reader["Name"];
                        text.Value = (string)reader["Value"];
                        text.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                        savedItems.Add(text);
                    }
                }
            }
            return savedItems;
        }

        public bool AddData(int deviceId, string Name, string Value, string TimeStamp)
        {
            bool isOk = false;

            try
            {
                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        var insertCommand = conn.CreateCommand();
                        insertCommand.Transaction = transaction;
                        insertCommand.CommandText = "INSERT INTO History (DeviceId, Name, Value, TimeStamp) VALUES ($DeviceId, $Name, $Value, $TimeStamp)";
                        insertCommand.Parameters.AddWithValue("$DeviceId", deviceId);
                        insertCommand.Parameters.AddWithValue("$Name", Name);
                        insertCommand.Parameters.AddWithValue("$Value", Value);
                        insertCommand.Parameters.AddWithValue("$TimeStamp", TimeStamp);
                        insertCommand.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }

                isOk = true;
            }
            catch (Exception ex)
            {

            }

            return isOk;
        }
    }
}
