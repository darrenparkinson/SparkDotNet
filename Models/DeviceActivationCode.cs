using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class DeviceActivationCode
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string PlaceId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}