
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string telephonyBase = "/v1/telephony";

        #region Calls GET commands
        /// <summary>
        /// Get the list of details for all active calls associated with the user.
        /// </summary>
        /// <returns>List of Call objects.</returns>
        public async Task<List<Call>> GetCallsAsync()
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{telephonyBase}/calls", queryParams);
            return await GetItemsAsync<Call>(path);
        }

        /// <summary>
        /// Get the details of the specified active call for the user.
        /// </summary>
        /// <param name="callId">The call identifier of the call.</param>
        /// <returns>A call object.</returns>
        public async Task<Call> GetCallAsync(string callId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{telephonyBase}/calls/{callId}", queryParams);
            return await GetItemAsync<Call>(path);
        }

        /// <summary>
        /// Get the list of call history records for the user.
        /// A maximum of 20 call history records per type (placed, missed, received) are returned.
        /// </summary>
        /// <param name="type">The type of call history records to retrieve. If not specified, then all call history records are retrieved.</param>
        /// <returns>List of Call History objects.</returns>
        public async Task<List<CallHistoryRecord>> GetCallHistoryAsync(string type = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (type != null) queryParams.Add("direction", type);
            var path = getURL($"{telephonyBase}/calls/history", queryParams);
            return await GetItemsAsync<CallHistoryRecord>(path);
        }
        #endregion Calls GET commands

        #region Calls POST commands
        /// <summary>
        /// Initiate an outbound call to a specified destination.
        /// This is also commonly referred to as Click to Call or Click to Dial.
        /// Alerts on all the devices belonging to the user.
        /// When the user answers on one of these alerting devices, an outbound
        /// call is placed from that device to the destination.
        /// </summary>
        /// <param name="destination">The destination to be dialed. The destination can be digits or a URI. Some examples for destination include: 1234, 2223334444, +12223334444, *73, tel:+12223334444, user@company.domain, sip:user@company.domain</param>
        /// <returns>Dictionary with call information (callId: A unique identifier for the call which is used in all subsequent commands for this call; callSessionId: A unique identifier for the call session the call belongs to. This can be used to correlate multiple calls that are part of the same call session.)</returns>
        public async Task<Dictionary<string, string>> CallDialAync(string destination)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("destination", destination);
            return await PostItemAsync<Dictionary<string, string>>($"(telephonyBase)/calls/dial", postBody);
        }

        /// <summary>
        /// Answer an incoming call on the user's primary device.
        /// </summary>
        /// <param name="callId">The call identifier of the call to be answered.</param>
        /// <returns></returns>
        public async Task<object> CallAnswerAsync(string callId)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("callId", callId);
            return await PostItemAsync<object>($"(telephonyBase)/calls/answer", postBody);
        }

        /// <summary>
        /// Reject an unanswered incoming call.
        /// </summary>
        /// <param name="callId">The call identifier of the call to be rejected.</param>
        /// <returns></returns>
        public async Task<object> CallRejectAsync(string callId)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("callId", callId);
            return await PostItemAsync<object>($"(telephonyBase)/calls/reject", postBody);
        }

        /// <summary>
        /// Hangup a call. If used on an unanswered incoming call, the call is rejected and sent to busy.
        /// </summary>
        /// <param name="callId">The call identifier of the call to be hangup.</param>
        /// <returns></returns>
        public async Task<object> CallHangupAsync(string callId)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("callId", callId);
            return await PostItemAsync<object>($"(telephonyBase)/calls/hangup", postBody);
        }

        /// <summary>
        /// Hold a connected call.
        /// </summary>
        /// <param name="callId">The call identifier of the call to be hold.</param>
        /// <returns></returns>
        public async Task<object> CallHoldAsync(string callId)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("callId", callId);
            return await PostItemAsync<object>($"(telephonyBase)/calls/hold", postBody);
        }

        /// <summary>
        /// Resume a held call.
        /// </summary>
        /// <param name="callId">The call identifier of the call to be resumed.</param>
        /// <returns></returns>
        public async Task<object> CallResumeAsync(string callId)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("callId", callId);
            return await PostItemAsync<object>($"(telephonyBase)/calls/resume", postBody);
        }

        /// <summary>
        /// Divert a call to a destination or a user's voicemail. This is also commonly referred to as Blind Transfer.
        /// </summary>
        /// <param name="callId">The call identifier of the call to divert.</param>
        /// <param name="destination">The destination to divert the call to. If toVoicemail is false, destination is required. The destination can be digits or a URI. Some examples for destination include: 1234, 2223334444, +12223334444, *73, tel:+12223334444, user@company.domain, sip:user@company.domain</param>
        /// <param name="toVoicemail">If set to true, the call is diverted to voicemail. If no destination is specified, the call is diverted to the user's own voicemail. If a destination is specified, the call is diverted to the specified user's voicemail.</param>
        /// <returns></returns>
        public async Task<object> CallDivertAsync(string callId, string destination, bool toVoicemail)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("callId", callId);
            postBody.Add("destination", destination);
            postBody.Add("toVoicemail", toVoicemail);
            return await PostItemAsync<object>($"(telephonyBase)/calls/divert", postBody);
        }

        /// <summary>
        /// Transfer two calls together.
        /// If the user has only two calls, the callId parameters are optional and when not provided
        /// the calls are automatically selected and transferred.
        /// If the user has more than two calls, the callIds are mandatory to specify which calls are being transferred.
        /// Unanswered incoming calls cannot be transferred but can be diverted using the divert command.
        /// This is also commonly referred to as Attended Transfer, Consultative Transfer, or Supervised Transfer.
        /// </summary>
        /// <param name="callId1">The call identifier of the first call to transfer. This parameter is mandatory if callId2 is provided.</param>
        /// <param name="callId2">The call identifier of the second call to transfer. This parameter is mandatory if callId1 is provided.</param>
        /// <returns></returns>
        public async Task<object> CallTransferAsync(string callId1, string callid2)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("callId1", callId1);
            postBody.Add("callId2", callId1);
            return await PostItemAsync<object>($"(telephonyBase)/calls/divert", postBody);
        }

        /// <summary>
        /// Park a connected call.
        /// The number field in the response can be used as the destination for the retrieve command to retrieve the parked call.
        /// </summary>
        /// <param name="callId">The call identifier of the call to park.</param>
        /// <param name="destination">dentifes where the call is to be parked. If not provided, the call is parked against the parking user. The destination can be digits or a URI. Some examples for destination include: 1234, 2223334444, +12223334444, *73, tel:+12223334444, user@company.domain, sip:user@company.domain</param>
        /// <param name="isGroupPark">If set to true, the call is parked against an automatically selected member of the user's call park group and the destination parameter is ignored.</param>
        /// <returns>A Call Park Against object containing the details of where the call has been parked.</returns>
        public async Task<CallParkedAgainst> CallParkAsync(string callId, string destination, bool isGroupPark)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("callId", callId);
            postBody.Add("destination", destination);
            postBody.Add("isGroupPark", isGroupPark);
            return await PostItemAsync<CallParkedAgainst>($"(telephonyBase)/calls/park", postBody);
        }

        /// <summary>
        /// Retrieve a parked call.
        /// A new call is initiated to perform the retrieval in a similar manner to the dial command.
        /// The number field from the park command response can be used as the destination for the retrieve command.
        /// </summary>
        /// <param name="destination">dentifies where the call is parked. The number field from the park command response can be used as the destination for the retrieve command. If not provided, the call parked against the retrieving user is retrieved. The destination can be digits or a URI. Some examples for destination include: 1234, 2223334444, +12223334444, *73, tel:+12223334444, user@company.domain, sip:user@company.domain</param>
        /// <returns>Dictionary with call information (callId: A unique identifier for the call which is used in all subsequent commands for this call; callSessionId: A unique identifier for the call session the call belongs to. This can be used to correlate multiple calls that are part of the same call session.)</returns>
        public async Task<Dictionary<string, string>> CallRetrieveAsync(string destination)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("destination", destination);
            return await PostItemAsync<Dictionary<string, string>>($"(telephonyBase)/calls/retrieve", postBody);
        }
        #endregion Calls POST commands
    }

}