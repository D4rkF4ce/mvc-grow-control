using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.GrowControl.Models
{
    public class DeviceNotification
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string InfoMsg { get; set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
