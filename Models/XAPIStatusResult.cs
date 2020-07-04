using System;
using Newtonsoft.Json;

namespace SparkDotNet
{

    public class XAPIStatusResult
    {
        public XAPIStatusResultAudio Audio { get; set; }

        public override string ToString()
        { 
            return JsonConvert.SerializeObject(this);
        }
    }
}