using System;
using Newtonsoft.Json;

namespace SparkDotNet
{

    public class Membership
    {
        public string id { get; set; }
        public string roomId { get; set; }
        public string personId { get; set; }
        public string personEmail { get; set; }
        public string personDisplayName { get; set; }
        public string personOrgId { get; set; }
        public bool isModerator { get; set; }
        public DateTime created { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}