using HT.GrowControl.Converter;
using HT.GrowControl.DataProvider;
using HT.GrowControl.Gateways;
using HT.GrowControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HT.GrowControl.DataCollector
{
    class Program
    {
        static DataCollectorGateway _gateway = new DataCollectorGateway();
        static Watering_Device Watering = null;
        static Light_Device Light = null;
        static Fan_Device FanIn = null;
        static Suction_Device Suction = null;
        static Temperature_Device Temperature = null;
        static Humidity_Device Humidity = null;
        static NotifyGateway _notifyGateway = new NotifyGateway();

        static void Main(string[] args)
        {
            Console.WriteLine("HT.GrowControl.DataCollector.Main");

            CollectData();            

            if (Watering != null)
            {
                Check_Watering_Stats(Watering);
            }

            if (Temperature != null && Humidity != null)
            {
                Check_Temp_Hygro_Stats();
            }

            //Console.WriteLine("FINISH!");
        }

        private static void CollectData()
        {
            Console.WriteLine("CollectData...");
            bool collected = false;

            try
            {
                MyStromConnector licht = new MyStromConnector("192.168.1.206");
                MyStromConnector umLuft = new MyStromConnector("192.168.1.108");
                MyStromConnector abLuft = new MyStromConnector("192.168.1.241");
                MyStromConnector watering = new MyStromConnector("192.168.1.109");
                ShellyConnector tempHygro = new ShellyConnector("192.168.1.187");

                Watering = DataConverter.ConvertToWateringDevice(watering.Get());
                Light = DataConverter.ConvertToLightDevice(licht.Get());
                FanIn = DataConverter.ConvertToFanDevice(umLuft.Get());
                Suction = DataConverter.ConvertToSuctionDevice(abLuft.Get());

                var tempHygroValue = tempHygro.Get();
                Temperature = DataConverter.ConvertToTemperatureDevice(tempHygroValue);
                Humidity = DataConverter.ConvertToHumidityDevice(tempHygroValue);

                collected = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DATACOLLECTOR FAILED");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            if (collected)
            {
                _gateway.AddData(5, Watering.Name, Watering.PowerValue.ToString(), DateTime.Now.ToString());
                _gateway.AddData(1, Light.Name, Light.PowerValue.ToString(), DateTime.Now.ToString());
                _gateway.AddData(3, FanIn.Name, FanIn.PowerValue.ToString(), DateTime.Now.ToString());
                _gateway.AddData(4, Suction.Name, Suction.PowerValue.ToString(), DateTime.Now.ToString());
                _gateway.AddData(2, Temperature.Name, Temperature.CelsiusValue.ToString(), DateTime.Now.ToString());
                _gateway.AddData(6, Humidity.Name, Humidity.HumidityValue.ToString(), DateTime.Now.ToString());

                Console.WriteLine("Collected & Insered!");
            }
            else
            {
                Console.WriteLine("Not collected & not insered!");
            }
        }
        private static void Check_Temp_Hygro_Stats()
        {
            Console.WriteLine("Check Temperatur & Humidity...");

            try
            {
                // Default Values <> Settings:
                SystemSettingsGateway gateway = new SystemSettingsGateway();
                List<SystemSetting> settings = gateway.GetSystemSettings();
                

                // ZUM TESTEN:
                DeviceNotification tempDevice = new DeviceNotification();
                tempDevice.DeviceId = Temperature.Id;
                tempDevice.TimeStamp = DateTime.Now;
                double minTemp = Convert.ToDouble(settings.First(x => x.Name == "MinTemp").Value.Replace('.', ','));
                double maxTemp = Convert.ToDouble(settings.First(x => x.Name == "MaxTemp").Value.Replace('.', ','));
                double diff = Convert.ToDouble((maxTemp - minTemp) / 2);
                Console.WriteLine(Temperature.CelsiusValue);

                if (Temperature.CelsiusValue < minTemp)
                {
                    tempDevice.Status = "danger";
                    tempDevice.InfoMsg = "Temperatur ist gut";
                }

                if (IsBetween(Temperature.CelsiusValue, minTemp, (minTemp + diff)))
                {
                    tempDevice.Status = "success";
                    tempDevice.InfoMsg = "Temperatur zu nieder";
                }
                else if (IsBetween(Temperature.CelsiusValue, (minTemp + diff), maxTemp))
                {
                    tempDevice.Status = "warning";
                    tempDevice.InfoMsg = "Erhöhte Temperatur";
                }
                else
                {
                    tempDevice.Status = "danger";
                    tempDevice.InfoMsg = "Temperatur zu hoch";
                }

                


                // ZUM TESTEN:
                DeviceNotification humDevice = new DeviceNotification();
                humDevice.DeviceId = Humidity.Id;
                humDevice.TimeStamp = DateTime.Now;
                double minHumidity = Convert.ToDouble(settings.First(x => x.Name == "MinHumidity").Value.Replace('.', ','));
                double maxHumidity = Convert.ToDouble(settings.First(x => x.Name == "MaxHumidity").Value.Replace('.', ','));
                double diffHum = Convert.ToDouble((maxHumidity - minHumidity) / 2);
                Console.WriteLine(Humidity.HumidityValue);
                if (Humidity.HumidityValue < minHumidity)
                {
                    humDevice.Status = "danger";
                    humDevice.InfoMsg = "Wert zu nieder";
                }
                
                if (IsBetween(Humidity.HumidityValue, minHumidity, (minHumidity + diffHum)))
                {
                    humDevice.Status = "success";
                    humDevice.InfoMsg = "Wert ist gut";
                }
                else if (IsBetween(Humidity.HumidityValue, (minHumidity + diffHum), (maxHumidity - 2)))
                {
                    humDevice.Status = "warning";
                    humDevice.InfoMsg = "Wert ist erhöht";
                }
                else
                {
                    humDevice.Status = "danger";
                    humDevice.InfoMsg = "Wert zu hoch";
                }


                // Save values:
                _notifyGateway.CleanUpDeviceNotification_withoutWateringNoty(5); // 5 = ID from Watering Device see above
                _notifyGateway.AddDeviceNotification(tempDevice.DeviceId, tempDevice.InfoMsg, tempDevice.Status, tempDevice.TimeStamp.ToString());
                _notifyGateway.AddDeviceNotification(humDevice.DeviceId, humDevice.InfoMsg, humDevice.Status, humDevice.TimeStamp.ToString());


                Console.WriteLine("Check Temperatur & Humidity finish.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Check Temperatur & Humidity finish with errors:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void Check_Watering_Stats(Watering_Device watering)
        {
            Console.WriteLine("Check Watering...");

            try
            {
                if (watering.DeviceIsInUse == "Ja")
                {
                    //Console.WriteLine("Watering is active");
                    _notifyGateway.CleanUpDeviceNotification();
                    _notifyGateway.AddDeviceNotification(5, DateTime.Now.ToString(), "success", DateTime.Now.ToString());

                }
                else
                {
                    //Console.WriteLine("Watering is not active");
                    //_notifyGateway.AddDeviceNotification(5, DateTime.Now.ToString(), "success", DateTime.Now.ToString());
                }

                Console.WriteLine("Check Watering finish.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Check Watering finish with errors:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static bool IsBetween(double testValue, double bound1, double bound2)
        {
            return (testValue >= Math.Min(bound1, bound2) && testValue <= Math.Max(bound1, bound2));
        }
    }
}
