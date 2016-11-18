using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class Message
    {
        public string id { get; set; }
        public string roomId { get; set; }
        public string roomType { get; set; }
        public string toPersonId { get; set; }
        public string toPersonEmail { get; set; }
        public string text { get; set; }
        public string markdown { get; set; }
        public string[] files { get; set; }
        public string personId { get; set; }
        public string personEmail { get; set; }
        public string html { get; set; }
        public DateTime created { get; set; }
        public string[] mentionedPeople { get; set; }


        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }

 
}