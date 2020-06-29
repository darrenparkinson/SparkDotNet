using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingTelephonyLink
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public string Method { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}