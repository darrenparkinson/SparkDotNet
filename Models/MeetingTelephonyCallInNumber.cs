using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingTelephonyCallInNumber
    {
        public string Label { get; set; }
        public string CallInNumber { get; set; }
        public string TollType { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}