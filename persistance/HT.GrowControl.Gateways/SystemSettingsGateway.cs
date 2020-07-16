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
    public class SystemSettingsGateway
    {
        private readonly string _connectionString = ConfigurationManager.AppSettings["SQLiteConnectionString"].ToString();

        public SystemSettingsGateway()
        {

        }

        public List<SystemSetting> GetSystemSettings()
        {
            List<SystemSetting> savedItems = new List<SystemSetting>();
            using (var conn = new SQLiteConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM SystemSettings";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SystemSetting text = new SystemSetting();
                        text.Id = Convert.ToInt32(reader["ID"].ToString());
                        text.Name = (string)reader["Name"];
                        text.Value = (string)reader["Value"];
                        savedItems.Add(text);
                    }
                }
            }
            return savedItems;
        }
    }
}
