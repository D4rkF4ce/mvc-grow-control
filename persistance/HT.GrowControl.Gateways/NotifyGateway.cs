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
    public class NotifyGateway
    {
        private string _connectionString = ConfigurationManager.AppSettings["NotifyConnectionString"].ToString();

        public NotifyGateway()
        {

        }

        public NotifyGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<DeviceNotification> GetDeviceNotification()
        {
            List<DeviceNotification> savedItems = new List<DeviceNotification>();
            using (var conn = new SQLiteConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM DeviceNotifications order by TimeStamp desc";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DeviceNotification text = new DeviceNotification();
                        text.Id = Convert.ToInt32(reader["ID"].ToString());
                        text.DeviceId = Convert.ToInt32(reader["DeviceId"].ToString());
                        text.InfoMsg = (string)reader["InfoMsg"];
                        text.Status = (string)reader["Status"];
                        text.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                        savedItems.Add(text);
                    }
                }
            }
            return savedItems;
        }

        public bool AddDeviceNotification(int deviceId, string infoMsg, string status, string TimeStamp)
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
                        insertCommand.CommandText = "INSERT INTO DeviceNotifications (DeviceId, InfoMsg, Status, TimeStamp) VALUES ($DeviceId, $InfoMsg, $Status, $TimeStamp)";
                        insertCommand.Parameters.AddWithValue("$DeviceId", deviceId);
                        insertCommand.Parameters.AddWithValue("$InfoMsg", infoMsg);
                        insertCommand.Parameters.AddWithValue("$Status", status);
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

        public bool CleanUpDeviceNotification()
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
                        insertCommand.CommandText = "DELETE FROM DeviceNotifications";
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

        public bool CleanUpDeviceNotification_withoutWateringNoty(int excludedId)
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
                        insertCommand.CommandText = "DELETE FROM DeviceNotifications WHERE DeviceId != $ExcludedId";
                        insertCommand.Parameters.AddWithValue("$ExcludedId", excludedId);
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
