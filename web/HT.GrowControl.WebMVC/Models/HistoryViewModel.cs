using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HT.GrowControl.Models;

namespace HT.GrowControl.WebMVC.Models
{
    public class HistoryViewModel
    {
        public List<DataCollectorModel> CollectedData { get; set; }

        public HistoryViewModel()
        {
            CollectedData = new List<DataCollectorModel>();
        }
    }
}