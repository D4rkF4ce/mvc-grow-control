using HT.GrowControl.DataProvider;
using HT.GrowControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.GrowControl.Converter
{
    public static class DataConverter
    {
        /// <summary>
        /// Treshold Value (normal plug is also using power while offline)
        /// </summary>
        private static double _tresholdValue = 5.0;

        public static Suction_Device ConvertToSuctionDevice(MyStromResponse objectToConvert)
        {
            Suction_Device suction = new Suction_Device
            {
                Id = 4,
                Name = "AbLuft",
                Icon = "~/content/images/blowout.png",
                Power = objectToConvert.power.ToString("0.00") + " Watt",
                Relay = objectToConvert.relay.ToString(),
                DeviceIsInUse = "Nein",
                PowerValue = objectToConvert.power
            };

            if (objectToConvert.relay && objectToConvert.power > _tresholdValue) 
            {
                suction.DeviceIsInUse = "Ja";
            }

            return suction;
        }

        public static Fan_Device ConvertToFanDevice(MyStromResponse objectToConvert)
        {
            Fan_Device fanIn = new Fan_Device
            {
                Id = 3,
                Name = "UmLuft",
                Icon = "~/content/images/fan.png",
                Power = objectToConvert.power.ToString("0.00") + " Watt",
                Relay = objectToConvert.relay.ToString(),
                DeviceIsInUse = "Nein",
                PowerValue = objectToConvert.power
            };

            if (objectToConvert.relay && objectToConvert.power > _tresholdValue)
            {
                fanIn.DeviceIsInUse = "Ja";
            }

            return fanIn;
        }

        public static Light_Device ConvertToLightDevice(MyStromResponse objectToConvert)
        {
            Light_Device light = new Light_Device
            {
                Id = 1,
                Name = "SanLight Q5W",
                Power = objectToConvert.power.ToString("0.00") + " Watt",
                Relay = objectToConvert.relay.ToString(),
                Temp = objectToConvert.temperature.ToString("0.00") + " °C",
                Icon = "~/content/images/light-off.png",
                DeviceIsInUse = "Nein",
                PowerValue = objectToConvert.power
            };

            if (objectToConvert.relay && objectToConvert.power > _tresholdValue)
            {
                light.Icon = "~/content/images/light-on.png";
                light.DeviceIsInUse = "Ja";
            }

            return light;
        }

        public static Watering_Device ConvertToWateringDevice(MyStromResponse objectToConvert)
        {
            Watering_Device light = new Watering_Device
            {
                Id = 5,
                Name = "Bewässerung",
                Power = objectToConvert.power.ToString("0.00") + " Watt",
                Relay = objectToConvert.relay.ToString(),
                RainInMin = "1 Minute / 75 ml",
                Icon = "~/content/images/no-rain.png",
                DeviceIsInUse = "Nein",
                PowerValue = objectToConvert.power
            };

            if (objectToConvert.relay && objectToConvert.power > _tresholdValue)
            {
                light.Icon = "~/content/images/rain.png";
                light.DeviceIsInUse = "Ja";
            }

            return light;
        }

        public static Temperature_Device ConvertToTemperatureDevice(ShellyCloudResponse objectToConvert)
        {
            Temperature_Device tempHygro = new Temperature_Device
            {
                Id = 2,
                Name = "Temperatur",
                Icon = "~/content/images/thermo.png",
                TempInCelsius = objectToConvert.data.device_status.tmp.value + "°C",
                CelsiusValue = objectToConvert.data.device_status.tmp.value
            };

            return tempHygro;
        }

        public static Humidity_Device ConvertToHumidityDevice(ShellyCloudResponse objectToConvert)
        {
            Humidity_Device tempHygro = new Humidity_Device
            {
                Id = 6,
                Name = "Luftfeuchtigkeit",
                Icon = "~/content/images/humidity.png",
                HumidityInPercent = objectToConvert.data.device_status.hum.value + "%",               
                HumidityValue = objectToConvert.data.device_status.hum.value
            };

            return tempHygro;
        }
    }
}
