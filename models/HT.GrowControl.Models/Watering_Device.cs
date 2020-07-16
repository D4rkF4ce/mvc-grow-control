using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.GrowControl.Models
{
    public class Watering_Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public string Relay { get; set; }
        public string RainInMin { get; set; }
        public string Icon { get; set; }
        public string DeviceIsInUse { get; set; }


        public double PowerValue { get; set; }

        public DeviceNotification Info { get; set; }

        public Watering_Device()
        {
            Info = new DeviceNotification();
        }
    }
}
