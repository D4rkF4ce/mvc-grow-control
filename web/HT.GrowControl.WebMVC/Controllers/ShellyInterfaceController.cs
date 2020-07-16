using HT.GrowControl.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace HT.GrowControl.WebMVC.Controllers
{
    public class ShellyInterfaceController : Controller
    {
        ShellyDataGateway _gateway = new ShellyDataGateway();

        public string UpdateShellyData(string temp,string hum)
        {
            if (!string.IsNullOrEmpty(temp) && !string.IsNullOrEmpty(hum))
            {
                var result = _gateway.SaveShellyData(temp, hum);
                return "200";
            }
            return "403";
        }
    }
}
