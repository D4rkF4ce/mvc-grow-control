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
    public class ShellyDataGateway
    {
        private readonly string _connectionString = ConfigurationManager.AppSettings["SQLiteConnectionString"].ToString();

        public ShellyDataGateway()
        {

        }

        public bool SaveShellyData(string temp, string humidity)
        {
            try
            {
                using (var conn = new SQLiteConnection(_connectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "INSERT INTO ShellyData (Date, Temperatur, Humidity) VALUES (@Date, @Temperatur, @Humidity)";
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@Temperatur", temp);
                    cmd.Parameters.AddWithValue("@Humidity", humidity);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        //public List<SystemSetting> GetSystemSettings()
        //{
        //    List<SystemSetting> savedItems = new List<SystemSetting>();
        //    using (var conn = new SQLiteConnection(_connectionString))
        //    using (var cmd = conn.CreateCommand())
        //    {
        //        conn.Open();
        //        cmd.CommandText = "SELECT * FROM SystemSettings";
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                SystemSetting text = new SystemSetting();
        //                text.Id = Convert.ToInt32(reader["ID"].ToString());
        //                text.Name = (string)reader["Name"];
        //                text.Value = (string)reader["Value"];
        //                savedItems.Add(text);
        //            }
        //        }
        //    }
        //    return savedItems;
        //}
    }
}
