
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string meetingsPreferencesBase = "/v1/meetingPreferences";

        /// <summary>
        /// Retrieves the list of Webex sites that the authenticated user is set up to use.
        /// </summary>
        /// <returns>Array of sites for the user. Users can have one site or multiple sites. This concept is specific to Webex Meetings. Any siteUrl in the site list can be assigned as user's default site by Update Default Site of Meeting Preference API.</returns>
        public async Task<List<MeetingSite>> GetMeetingSitesAsync()
        {
            return await GetItemsAsync<MeetingSite>($"{meetingsPreferencesBase}/sites", "sites");
        }

        /// <summary>
        /// Updates the default site for the authenticated user.
        /// </summary>
        /// <param name="defaultSite">Whether or not to change user's default site. Note: defaultSite must be true.</param>
        /// <param name="siteUrl">Access URL for the site.</param>
        /// <returns>The updated MeetingSite object</returns>
        public async Task<MeetingSite> UpdateDefaultMeetingSite(bool defaultSite, string siteUrl)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("defaultSite", defaultSite.ToString());
            var path = getURL($"{meetingsPreferencesBase}/sites", queryParams);

            var postBody = new Dictionary<string, object>();
            postBody.Add("siteUrl", siteUrl);

            return await PostItemAsync<MeetingSite>(path, postBody);
        }

        /// <summary>
        /// Retrieves scheduling options for the authenticated user.
        /// </summary>
        /// <returns>Meeting Scheduling Options object for the user.</returns>
        public async Task<MeetingSchedulingOptions> GetMeetingSchedulingOptionsAsync()
        {
            return await GetItemAsync<MeetingSchedulingOptions>($"{meetingsPreferencesBase}/schedulingOptions");
        }

        /// <summary>
        /// Updates scheduling options for the authenticated user.
        /// </summary>
        /// <param name="enabledJoinBeforeHost">Flag to enable/disable Join Before Host. The period during which invitees can join before the start time is defined by autoLockMinutes. This attribute can be modified by Update Scheduling Options API. Note: This feature is only effective if the site supports the Join Before Host feature. This attribute can be modified by Update Scheduling Options API.</param>
        /// <param name="joinBeforeHostMinutes">Number of minutes before the start time that an invitee can join a meeting if enabledJoinBeforeHost is true. Valid options are 0, 5, 10 and 15. This attribute can be modified by Update Scheduling Options API.</param>
        /// <param name="enabledAutoShareRecording">Flag to enable/disable the automatic sharing of the meeting recording with invitees when it is available. This attribute can be modified by Update Scheduling Options API.</param>
        /// <returns>The updated Meeting Scheduling Options</returns>
        public async Task<MeetingSchedulingOptions> UpdateMeetingSchedulingOptionsAsync(bool enabledJoinBeforeHost, int joinBeforeHostMinutes, bool enabledAutoShareRecording)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("enabledJoinBeforeHost", enabledJoinBeforeHost);
            postBody.Add("joinBeforeHostMinutes", joinBeforeHostMinutes);
            postBody.Add("enabledAutoShareRecording", enabledAutoShareRecording);

            return await UpdateItemAsync<MeetingSchedulingOptions>($"{meetingsPreferencesBase}/schedulingOptions", postBody);
        }

        /// <summary>
        /// Updates scheduling options for the authenticated user.
        /// </summary>
        /// <param name="meetingSchedulingOptions">The new scheduling options</param>
        /// <returns>The updated Meeting Scheduling Options</returns>
        public async Task<MeetingSchedulingOptions> UpdateMeetingSchedulingOptionsAsync(MeetingSchedulingOptions meetingSchedulingOptions)
        {
            return await UpdateMeetingSchedulingOptionsAsync(meetingSchedulingOptions.EnabledJoinBeforeHost, meetingSchedulingOptions.JoinBeforeHostMinutes, meetingSchedulingOptions.EnabledAutoShareRecording);
        }

        /// <summary>
        /// Retrieves video options for the authenticated user.
        /// </summary>
        /// <returns>List of possible Video Device Objects</returns>
        public async Task<List<MeetingVideoDevice>> GetMeetingVideoDevicesAsync()
        {
            return await GetItemsAsync<MeetingVideoDevice>($"{meetingsPreferencesBase}/video", "videoDevices");
        }

        /// <summary>
        /// Updates video options for the authenticated user.
        /// </summary>
        /// <param name="meetingVideoDevices">Array of video devices. If the array is not empty, one device and no more than one devices must be set as default device.</param>
        /// <returns>List of Video Devices</returns>
        public async Task<List<MeetingVideoDevice>> UpdateMeetingVideoDevicesAsync(List<MeetingVideoDevice> meetingVideoDevices)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("meetingVideoDevices", meetingVideoDevices);

            // @flag @todo
            // This will not work as it returns an array instead of a single element
            return await UpdateItemAsync<List<MeetingVideoDevice>>($"{meetingsPreferencesBase}/video", postBody);
        }
    }
}