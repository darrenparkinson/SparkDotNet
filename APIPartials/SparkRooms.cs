
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string roomsBase = "/v1/rooms";

        /// <summary>
        /// By default, lists rooms to which the authenticated user belongs.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="max"></param>
        /// <param name="type"></param>
        /// <returns>List of Room objects.</returns>
        public async Task<List<Room>> GetRoomsAsync(string teamId = null, int max = 0, string type = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (teamId != null) queryParams.Add("teamId",teamId);
            if (type != null) queryParams.Add("type",type);
            if (max > 0) queryParams.Add("max",max.ToString());

            var path = getURL(roomsBase, queryParams);
            return await GetItemsAsync<Room>(path);
        }

        /// <summary>
        /// Shows details for a room, by ID.
        /// Specify the room ID in the roomId parameter in the URI.
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>Room object.</returns>
        public async Task<Room> GetRoomAsync(string roomId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{roomsBase}/{roomId}", queryParams);
            return await GetItemAsync<Room>(path);
        }

        /// <summary>
        /// Shows Webex meeting details for a room such as the SIP address, meeting URL, toll-free and toll dial-in numbers.
        /// Specify the room ID in the roomId parameter in the URI.
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>MeetingDetails object.</returns>
        public async Task<MeetingDetails> GetRoomMeetingDetailsAsync(string roomId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{roomsBase}/{roomId}/meetingInfo", queryParams);
            return await GetItemAsync<MeetingDetails>(path);
        }

        /// <summary>
        /// Creates a room. The authenticated user is automatically added as a member of the room. See the Memberships API to learn how to add more people to the room.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="teamId"></param>
        /// <returns>Room object.</returns>
        public async Task<Room> CreateRoomAsync(string title, string teamId = null)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("title", title);
            if (teamId != null) { postBody.Add("teamId", teamId); }
            return await PostItemAsync<Room>(roomsBase, postBody);
        }

        /// <summary>
        /// Deletes a room, by ID.
        /// Specify the room ID in the roomId parameter in the URI.
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteRoomAsync(string roomId)
        {
            return await DeleteItemAsync($"{roomsBase}/{roomId}");            
        }

        /// <summary>
        /// Updates details for a room, by ID.
        /// Specify the room ID in the roomId parameter in the URI.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<Room> UpdateRoomAsync(string roomId, string title)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("title",title);
            var path = $"{roomsBase}/{roomId}";
            return await UpdateItemAsync<Room>(path, putBody);
        }
    }

}