using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class AttachmentAction
    {
        public string id { get; set; }
        public string type { get; set; }
        public string messageId { get; set; }
        public object inputs { get; set; }
        public string personId { get; set; }
        public string roomId { get; set; }
        public DateTime created { get; set; }

        public override string ToString()
        { 
            return JsonConvert.SerializeObject(this);
        }
    }
}