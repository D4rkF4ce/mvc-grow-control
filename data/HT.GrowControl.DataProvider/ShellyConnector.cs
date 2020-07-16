using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HT.GrowControl.DataProvider
{
    public class ShellyConnector
    {
        public string IPEndpoint { get; set; }

        public ShellyConnector(string endpoint)
        {
            IPEndpoint = endpoint;
        }

        public ShellyCloudResponse Get()
        {
            try
            {
                string test = "NaN";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://shelly-5-eu.shelly.cloud/device/status?auth_key=MmNlZjV1aWQ7DF8F8F97ADB52C0B0BF70FD4AB053CC996CA01E7234B1329B7344C075BAAABA4A30E26639A09189&id=f059b8");
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    test = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }

                return JsonConvert.DeserializeObject<ShellyCloudResponse>(test);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
