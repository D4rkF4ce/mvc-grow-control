using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HT.GrowControl.Models;

namespace HT.GrowControl.WebMVC.Models
{
    public class OverViewModel
    {
        public Light_Device Light { get; set; }
        public Fan_Device FanIn { get; set; }

        public Temperature_Device Temperature { get; set; }

        public Humidity_Device Humidity { get; set; }

        public Suction_Device Suction { get; set; }

        public Watering_Device Watering { get; set; }

        public List<FlowerInBloom> FlowersInBloom { get; set; }

        public string Sunrise { get; set; }
        public string SunSet { get; set; }

        public string SunriseDuration { get; set; }
        public string SunSetDuration { get; set; }

        public string TempMinMax { get; set; }
        public string HumidityMinMax { get; set; }

        public OverViewModel()
        {
            FlowersInBloom = new List<FlowerInBloom>();
        }
    }
}