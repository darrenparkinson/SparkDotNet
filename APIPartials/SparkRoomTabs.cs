
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string roomTabsBase = "/v1/room/tabs";

        /// <summary>
        /// Lists all Room Tabs of a room. roomId query parameter is required to retrieve the response.
        /// Use roomId to list Room Tabs for a room, by ID.
        /// </summary>
        /// <param name="roomId">List Room Tabs associated with a room, by ID.</param>
        /// <returns>List of RoomTab objects.</returns>
        public async Task<List<RoomTab>> GetRoomTabsAsync(string roomId)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("roomId", roomId);
      
            var path = getURL($"{roomTabsBase}" , queryParams);
            return await GetItemsAsync<RoomTab>(path);
        }

        /// <summary>
        /// Lists all Room Tabs of a room.
        /// </summary>
        /// <param name="room">List Room Tabs associated with a room.</param>
        /// <returns>List of RoomTab objects.</returns>
        public async Task<List<RoomTab>> GetRoomTabsAsync(Room room)
        {
            return await GetRoomTabsAsync(room.id);
        }

        /// <summary>
        /// Get details for a Room Tab by ID.
        /// Specify the Room Tab ID in the id URI parameter.
        /// </summary>
        /// <param name="roomTabId">The unique identifier for the room tab.</param>
        /// <returns>Room Tab object.</returns>
        public async Task<RoomTab> GetRoomTabAsync(string roomTabId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{roomTabsBase}/{roomTabId}", queryParams);
            return await GetItemAsync<RoomTab>(path);
        }


        /// <summary>
        /// Add a tab with a content url to a room that can be accessed in the room.
        /// </summary>
        /// <param name="roomId">A unique identifier for the room.</param>
        /// <param name="contentUrl">Content Url of the Room Tab. Needs to use the https protocol.</param>
        /// <returns>The newly created Room Tab object.</returns>
        public async Task<RoomTab> CreateRoomTabAsync(string roomId, string contentUrl)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("roomId", roomId);
            postBody.Add("contentUrl", contentUrl);
            
            return await PostItemAsync<RoomTab>(roomTabsBase, postBody);
        }

        /// <summary>
        /// Deletes a Room Tab by ID.
        /// Specify the Room Tab ID in the id URI parameter.
        /// </summary>
        /// <param name="roomTabId">The unique identifier for the room tab.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteRoomTabAsync(string roomTabId)
        {
            return await DeleteItemAsync($"{roomTabsBase}/{roomTabId}");            
        }

        /// <summary>
        /// Deletes a room tab, by object.
        /// </summary>
        /// <param name="roomTab">The room tab object to be deleted.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteRoomTabAsync(RoomTab roomTab)
        {
            return await DeleteRoomTabAsync(roomTab.Id);
        }

        /// <summary>
        /// Updates details for a room tab, by ID.
        /// Specify the room tab ID in the roomTabId parameter in the URI.
        /// </summary>
        /// <param name="roomTabId">The room ID.</param>
        /// <param name="contentUrl">Content Url of the Room Tab. Needs to use the https protocol.</param>
        /// <param name="displayName">User-friendly name for the room tab.</param>
        /// <returns>The updated room tab object</returns>
        public async Task<RoomTab> UpdateRoomTabAsync(string roomTabId, string contentUrl, string displayName)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("contentUrl", contentUrl);
            putBody.Add("displayName", displayName);
            
            var path = $"{roomTabsBase}/{roomTabId}";
            return await UpdateItemAsync<RoomTab>(path, putBody);
        }

        /// <summary>
        /// Updates details for a room tab, by Object.
        /// </summary>
        /// <param name="roomTab">The room tab object to be updated.</param>
        /// <returns>The udated room tab object</returns>
        public async Task<RoomTab> UpdateRoomTabAsync(RoomTab roomTab)
        {
            return await UpdateRoomTabAsync(roomTab.Id, roomTab.ContentUrl, roomTab.DisplayName);
        }
    }

}