using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingInvitee
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public bool CoHost { get; set; }
        public string MeetingId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}