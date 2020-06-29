using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingTelephony
    {
        public string AccessCode { get; set; }
        public MeetingTelephonyCallInNumber[] CallInNumbers { get; set; }
        public MeetingTelephonyLink[] Links { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}