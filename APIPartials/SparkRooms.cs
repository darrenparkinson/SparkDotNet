
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string roomsBase = "/v1/rooms";

        /// <summary>
        /// By default, lists rooms to which the authenticated user belongs.
        /// </summary>
        /// <param name="teamId">List rooms associated with a team, by ID.</param>
        /// <param name="max">Limit the maximum number of rooms in the response. Default: 100</param>
        /// <param name="type">List rooms by type. Possible values: direct, group</param>
        /// <param name="sortBy">Sort results. Possible values: id, lastactivity, created</param>
        /// <returns>List of Room objects.</returns>
        public async Task<List<Room>> GetRoomsAsync(string teamId = null, int max = 0, string type = null, string sortBy = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (teamId != null) queryParams.Add("teamId",teamId);
            if (type != null) queryParams.Add("type",type);
            if (max > 0) queryParams.Add("max", System.Math.Max(max, 1000).ToString());
            if (sortBy != null) queryParams.Add("sortBy", sortBy);

            var path = getURL(roomsBase, queryParams);
            return await GetItemsAsync<Room>(path);
        }

        /// <summary>
        /// Shows details for a room, by ID.
        /// Specify the room ID in the roomId parameter in the URI.
        /// </summary>
        /// <param name="roomId">The unique identifier for the room.</param>
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
        /// <param name="roomId">The unique identifier for the room.</param>
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
        /// <param name="title">A user-friendly name for the room.</param>
        /// <param name="teamId">The ID for the team with which this room is associated.</param>
        /// <param name="classificationId">Space classification id represents the space's current classification. It can be attached during space creation time, and can be modified at the request of an authorized user.</param>
        /// <returns>Room object.</returns>
        public async Task<Room> CreateRoomAsync(string title, string teamId = null, string classificationId = null)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("title", title);
            if (teamId != null) { postBody.Add("teamId", teamId); }
            if (classificationId != null) { postBody.Add("classificationId", classificationId); }
            return await PostItemAsync<Room>(roomsBase, postBody);
        }

        /// <summary>
        /// Deletes a room, by ID. Deleted rooms cannot be recovered.
        /// Deleting a room that is part of a team will archive the room instead.
        /// Specify the room ID in the roomId parameter in the URI.
        /// </summary>
        /// <param name="roomId">The unique identifier for the room.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteRoomAsync(string roomId)
        {
            return await DeleteItemAsync($"{roomsBase}/{roomId}");            
        }

        /// <summary>
        /// Deletes a room, by object. Deleted rooms cannot be recovered.
        /// Deleting a room that is part of a team will archive the room instead.
        /// </summary>
        /// <param name="room">The room object to be deleted.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteRoomAsync(Room room)
        {
            return await DeleteRoomAsync(room.id);
        }

        /// <summary>
        /// Updates details for a room, by ID.
        /// Specify the room ID in the roomId parameter in the URI.
        /// </summary>
        /// <param name="roomId">The unique identifier for the room.</param>
        /// <param name="title">A user-friendly name for the room.</param>
        /// <returns>The updated room object</returns>
        public async Task<Room> UpdateRoomAsync(string roomId, string title, string classificationId = null)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("title",title);
            if (classificationId != null) putBody.Add("classificationId", classificationId);
            var path = $"{roomsBase}/{roomId}";
            return await UpdateItemAsync<Room>(path, putBody);
        }

        /// <summary>
        /// Updates details for a room, by Object.
        /// </summary>
        /// <param name="room">The room object to be updated.</param>
        /// <returns>The udated room object</returns>
        public async Task<Room> UpdateRoomAsync(Room room)
        {
            return await UpdateRoomAsync(room.id, room.title, room.ClassificationId);
        }
    }

}