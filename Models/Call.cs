using System;

namespace SparkDotNet {

    public class Call : WebexObject
    {
        /// <summary>
        /// The call identifier of the call.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The call session identifier of the call session the call belongs to. This can be used to correlate multiple calls that are part of the same call session.
        /// </summary>
        public string CallSessionId { get; set; }

        /// <summary>
        /// The personality of the call.
        /// </summary>
        public string Personality { get; set; }

        /// <summary>
        /// The current state of the call.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The remote party's details. For example, if user A calls user B then B is the remote party in A's outgoing call details and A is the remote party in B's incoming call details.
        /// </summary>
        public object RemoteParty { get; set; }

        /// <summary>
        /// The appearance value for the call. The appearance value can be used to display the user's calls in an order consistent with the user's devices. Only present when the call has an appearance value assigned.
        /// </summary>
        public string Appearance { get; set; }

        /// <summary>
        /// The date and time the call was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The date and time the call was answered. Only present when the call has been answered.
        /// </summary>
        public DateTime Answered { get; set; }

        /// <summary>
        /// The list of details for previous redirections of the incoming call ordered from most recent to least recent.
        /// For example, if user B forwards an incoming call to user C, then a redirection entry is present for B's
        /// forwarding in C's incoming call details. Only present when there were previous redirections and the incoming
        /// call's state is alerting.
        /// </summary>
        public object[] Redirections { get; set; }

        /// <summary>
        /// The reason the incoming call was redirected.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// The details of a party who redirected the incoming call.
        /// </summary>
        public string RedirectingParty { get; set; }

        /// <summary>
        /// The recall details for the incoming call. Only present when the incoming call is for a recall.
        /// </summary>
        public string Recall { get; set; }

        /// <summary>
        /// The call's current recording state. Only present when the user's call recording has been invoked during the life of the call.
        /// </summary>
        public string RecordingState { get; set; }
    }
}