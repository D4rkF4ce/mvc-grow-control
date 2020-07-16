using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.GrowControl.Models
{
    public class Temperature_Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TempInCelsius { get; set; }
        public string Icon { get; set; }
        public double CelsiusValue { get; set; }

        public DeviceNotification Info { get; set; }

        public Temperature_Device()
        {
            Info = new DeviceNotification();
        }
    }
}
