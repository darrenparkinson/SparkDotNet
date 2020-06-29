using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class Meeting
    {
        public string Id { get; set; }
        public string MeetingSeriesId { get; set; }
        public string ScheduledMeetingId { get; set; }
        public string MeetingNumber { get; set; }
        public string Title { get; set; }
        public string Agenda { get; set; }
        public string Password { get; set; }
        public string MeetingType { get; set; }
        public string State { get; set; }
        public bool IsModified { get; set; }
        public TimeZoneInfo Timezone { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Recurrence { get; set; }
        public string HostUserId { get; set; }
        public string HostDisplayName { get; set; }
        public string HostEmail { get; set; }
        public string HostKey { get; set; }
        public string WebLink { get; set; }
        public string SipAddress { get; set; }
        public string DialInIpAddress { get; set; }
        public bool EnabledAutoRecordMeeting { get; set; }
        public bool AllowAnyUserToBeCoHost { get; set; }
        public MeetingTelephony Telephony { get; set; }




        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}