using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastApp.Models;
using System.IO;

namespace WeatherForecastApp.Converter.Impl
{
    public class JsonConverter : IJsonConverter
    {
        public Root Convert(string json)
        {

            Root root = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(json);
            return root;

        }
    }
}
