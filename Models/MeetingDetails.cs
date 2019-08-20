using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingDetails
    {
        public string roomId { get; set; }
        public string meetingLink { get; set; }
        public string sipAddress { get; set; }
        public string meetingNumber { get; set; }
        public string callInTollFreeNumber { get; set; }
        public string callInTollNumber { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
