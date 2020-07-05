namespace SparkDotNet
{
    public class MeetingInvitee : WebexObject
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public bool CoHost { get; set; }
        public string MeetingId { get; set; }
    }


}