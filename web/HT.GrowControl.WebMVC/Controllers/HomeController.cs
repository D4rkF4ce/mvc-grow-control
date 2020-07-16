using HT.GrowControl.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using HT.GrowControl.Models;
using HT.GrowControl.WebMVC.Models;
using HT.GrowControl.Converter;
using HT.GrowControl.Gateways;
using System.Web.ModelBinding;

namespace HT.GrowControl.WebMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        DataCollectorGateway _gateway = new DataCollectorGateway();
        NotifyGateway _notyGateway = new NotifyGateway();

        public ActionResult Index()
        {
            OverViewModel model = new OverViewModel();

            MyStromConnector licht = new MyStromConnector("192.168.1.206");
            MyStromConnector umLuft = new MyStromConnector("192.168.1.108");
            MyStromConnector abLuft = new MyStromConnector("192.168.1.241");
            ShellyConnector tempHygro = new ShellyConnector("192.168.1.187");
            MyStromConnector watering = new MyStromConnector("192.168.1.109");


            model.Watering = DataConverter.ConvertToWateringDevice(watering.Get());
            model.Light = DataConverter.ConvertToLightDevice(licht.Get());            
            model.FanIn = DataConverter.ConvertToFanDevice(umLuft.Get());
            model.Suction = DataConverter.ConvertToSuctionDevice(abLuft.Get());

            var tempResp = tempHygro.Get();

            model.Temperature = DataConverter.ConvertToTemperatureDevice(tempResp);
            model.Humidity = DataConverter.ConvertToHumidityDevice(tempResp);


            FlowersGateway flowers = new FlowersGateway();
            model.FlowersInBloom = flowers.GetFlowersInBloom();


            SystemSettingsGateway gateway = new SystemSettingsGateway();
            List<SystemSetting> settings = gateway.GetSystemSettings();

            model.Sunrise = settings.First(x => x.Name == "Sunrise").Value;
            model.SunSet = settings.First(x => x.Name == "Sunset").Value;           

            model.TempMinMax = "Temp: "+ settings.First(x => x.Name == "MinTemp").Value + "°C - "+ settings.First(x => x.Name == "MaxTemp").Value + "°C";
            model.HumidityMinMax = "RLF: "+ settings.First(x => x.Name == "MinHumidity").Value + "% - "+ settings.First(x => x.Name == "MaxHumidity").Value + "%";


            //var x = _gateway.GetCollectedData();
            var notifications = _notyGateway.GetDeviceNotification();

            model.Temperature.Info = notifications.First(x => x.DeviceId == model.Temperature.Id);
            model.Humidity.Info = notifications.First(x => x.DeviceId == model.Humidity.Id);
            model.Watering.Info = notifications.First(x => x.DeviceId == model.Watering.Id);

            return View(model);
        }
    }
}