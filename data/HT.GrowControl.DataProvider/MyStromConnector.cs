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
    public class MyStromConnector
    {
        public string IPEndpoint { get; set; }

        public MyStromConnector(string endpoint)
        {
            IPEndpoint = endpoint;
        }



        public MyStromResponse Get()
        {           
            try
            {
                string test = "NaN";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://"+ IPEndpoint + "/report");
                request.Method = "GET";
                
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    test = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }

                return JsonConvert.DeserializeObject<MyStromResponse>(test);
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }
    }
}
