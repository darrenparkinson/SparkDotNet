using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class AttachmentActionInput
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }

        public override string ToString()
        { 
            return JsonConvert.SerializeObject(this);
        }
    }
}