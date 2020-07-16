using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.GrowControl.Models
{
    public class Humidity_Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HumidityInPercent { get; set; }
        public string Icon { get; set; }
        public double HumidityValue { get; set; }

        public DeviceNotification Info { get; set; }

        public Humidity_Device()
        {
            Info = new DeviceNotification();
        }
    }
}
