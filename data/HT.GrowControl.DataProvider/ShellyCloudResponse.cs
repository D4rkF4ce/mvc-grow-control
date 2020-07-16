using System.Collections.Generic;

namespace HT.GrowControl.DataProvider
{
    public class ShellyCloudResponse
    {
        public bool isok { get; set; }
        public Data data { get; set; }
    }

    public class Cloud
    {
        public bool enabled { get; set; }
        public bool connected { get; set; }

    }

    public class Tmp
    {
        public double value { get; set; }
        public string units { get; set; }
        public double tC { get; set; }
        public double tF { get; set; }
        public bool is_valid { get; set; }

    }

    public class Update
    {
        public string status { get; set; }
        public bool has_update { get; set; }
        public string new_version { get; set; }
        public string old_version { get; set; }

    }

    public class TzInfo
    {
        public string device { get; set; }
        public string fw { get; set; }

    }

    public class FwInfo
    {
        public string device { get; set; }
        public string fw { get; set; }

    }

    public class Getinfo
    {
        public TzInfo tz_info { get; set; }
        public FwInfo fw_info { get; set; }

    }

    public class Mqtt
    {
        public bool connected { get; set; }

    }

    public class Hum
    {
        public double value { get; set; }
        public bool is_valid { get; set; }

    }

    public class Bat
    {
        public int value { get; set; }
        public double voltage { get; set; }

    }

    public class WifiSta
    {
        public bool connected { get; set; }
        public string ssid { get; set; }
        public string ip { get; set; }
        public int rssi { get; set; }

    }

    public class DeviceStatus
    {
        public int serial { get; set; }
        public bool is_valid { get; set; }
        public int ram_lwm { get; set; }
        public int unixtime { get; set; }
        public int ram_total { get; set; }
        public int fs_free { get; set; }
        public Cloud cloud { get; set; }
        public Tmp tmp { get; set; }
        public int fs_size { get; set; }
        public Update update { get; set; }
        public Getinfo getinfo { get; set; }
        public int ram_free { get; set; }
        public string time { get; set; }
        public string mac { get; set; }
        public bool has_update { get; set; }
        public string _updated { get; set; }
        public int connect_retries { get; set; }
        public Mqtt mqtt { get; set; }
        public Hum hum { get; set; }
        public Bat bat { get; set; }
        public List<string> act_reasons { get; set; }
        public WifiSta wifi_sta { get; set; }
        public int uptime { get; set; }
        public bool _sleeping { get; set; }

    }

    public class Data
    {
        public bool online { get; set; }
        public DeviceStatus device_status { get; set; }

    }
}