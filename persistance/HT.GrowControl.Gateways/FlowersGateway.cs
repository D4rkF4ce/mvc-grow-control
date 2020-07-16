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
    public class FlowersGateway
    {
        private readonly string _connectionString = ConfigurationManager.AppSettings["SQLiteConnectionString"].ToString();

        public FlowersGateway()
        {

        }

        public List<FlowerInBloom> GetFlowersInBloom()
        {
            List<FlowerInBloom> savedItems = new List<FlowerInBloom>();
            using (var conn = new SQLiteConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM FlowersInBloom";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FlowerInBloom text = new FlowerInBloom();
                        text.Id = Convert.ToInt32(reader["ID"].ToString());
                        text.Name = (string)reader["Name"];
                        text.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        text.DaysInBloom = Convert.ToInt32(reader["DaysInBloom"].ToString());
                        text.EndDate = text.StartDate.AddDays(text.DaysInBloom);
                        int daysDone = (DateTime.Now - text.StartDate).Days;
                        int daysToGo = (text.EndDate - text.StartDate).Days;
                        text.TimeToHarvest = daysDone + " / " + daysToGo;

                        savedItems.Add(text);
                    }
                }
            }
            return savedItems;
        }
    }
}
