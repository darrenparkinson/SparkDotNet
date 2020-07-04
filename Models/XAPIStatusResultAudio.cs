using System;
using Newtonsoft.Json;

namespace SparkDotNet
{

    public class XAPIStatusResultAudio
    {
        public int Volume { get; set; }

        public override string ToString()
        { 
            return JsonConvert.SerializeObject(this);
        }
    }
}