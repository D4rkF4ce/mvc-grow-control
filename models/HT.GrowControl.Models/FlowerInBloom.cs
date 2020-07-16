using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.GrowControl.Models
{
    public class FlowerInBloom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int DaysInBloom { get; set; }


        // View:
        public string TimeToHarvest { get; set; }
        public DateTime EndDate { get; set; }
    }
}
