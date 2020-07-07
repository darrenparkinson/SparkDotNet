namespace SparkDotNet
{
    public class MeetingTelephony : WebexObject
    {

        /// <summary>
        /// Code for authenticating a user to join teleconference.
        /// Users join the teleconference using the call-in number or the global call-in number, followed by the value of the accessCode.
        /// </summary>
        public string AccessCode { get; set; }

        /// <summary>
        /// Array of call-in numbers for joining teleconference from a phone.
        /// </summary>
        public MeetingTelephonyCallInNumber[] CallInNumbers { get; set; }

        /// <summary>
        /// HATEOAS information of global call-in numbers for joining teleconference from a phone.
        /// </summary>
        public MeetingTelephonyLink[] Links { get; set; }
    }


}