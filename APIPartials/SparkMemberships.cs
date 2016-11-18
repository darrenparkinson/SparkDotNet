using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string membershipsBase = "/v1/memberships";
        
        /// <summary>
        /// Lists all room memberships. By default, lists memberships for rooms to which the authenticated user belongs.
        /// - Use query parameters to filter the response.
        /// - Use roomId to list memberships for a room, by ID.
        /// - Use either personId or personEmail to filter the results.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="personId"></param>
        /// <param name="personEmail"></param>
        /// <param name="max"></param>
        /// <returns>A List of Membership objects.</returns>
        public async Task<List<Membership>> GetMembershipsAsync(string roomId = null, string personId = null, string personEmail = null, int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (roomId != null) queryParams.Add("roomId",roomId);
            if (personId != null) queryParams.Add("personId",personId);
            if (personEmail != null) queryParams.Add("personEmail",personEmail);
            if (max > 0) queryParams.Add("max",max.ToString());

            var path = getURL(membershipsBase, queryParams);
            return await GetItemsAsync<Membership>(path);
        }

        /// <summary>
        /// Get details for a membership by ID.
        /// Specify the membership ID in the membershipId URI parameter.
        /// </summary>
        /// <param name="membershipId"></param>
        /// <returns>Membership object.</returns>
        public async Task<Membership> GetMembershipAsync(string membershipId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{membershipsBase}/{membershipId}", queryParams);
            return await GetItemAsync<Membership>(path);
        }

        /// <summary>
        /// Add someone to a room by Person ID or email address; optionally making them a moderator.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="personId"></param>
        /// <param name="personEmail"></param>
        /// <param name="isModerator"></param>
        /// <returns>Membership object.</returns>
        public async Task<Membership> CreateMembershipAsync(string roomId, string personId = null, string personEmail = null, bool isModerator = false)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("roomId", roomId);
            if (personId != null) { postBody.Add("personId", personId); }
            if (personEmail != null) { postBody.Add("personEmail", personEmail); }
            postBody.Add("isModerator", isModerator);
            return await PostItemAsync<Membership>(membershipsBase, postBody);
        }

        /// <summary>
        /// Deletes a membership by ID.
        /// Specify the membership ID in the membershipId URI parameter.
        /// </summary>
        /// <param name="membershipId"></param>
        /// <returns>Boolean representing the success of the operation.</returns>
        public async Task<bool> DeleteMembershipAsync(string membershipId)
        {
            return await DeleteItemAsync($"{membershipsBase}/{membershipId}");            
        }

        /// <summary>
        /// Updates properties for a membership by ID.
        /// Specify the membership ID in the membershipId URI parameter.
        /// </summary>
        /// <param name="membershipId"></param>
        /// <param name="isModerator"></param>
        /// <returns>Membership object.</returns>
        public async Task<Membership> UpdateMembershipAsync(string membershipId, bool isModerator)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("isModerator",isModerator);
            var path = $"{membershipsBase}/{membershipId}";
            return await UpdateItemAsync<Membership>(path, putBody);
        }
    }
}