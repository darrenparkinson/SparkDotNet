using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string teamMembershipsBase = "/v1/team/memberships";

        /// <summary>
        /// Lists all team memberships. By default, lists memberships for teams to which the authenticated user belongs.
        /// Use query parameters to filter the response.
        /// Use teamId to list memberships for a team, by ID.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="max"></param>
        /// <returns>List of TeamMembership objects.</returns>
        public async Task<List<TeamMembership>> GetTeamMembershipsAsync(string teamId, int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (teamId != null) queryParams.Add("teamId",teamId);
            if (max > 0) queryParams.Add("max",max.ToString());
            var path = getURL(teamMembershipsBase, queryParams);
            return await GetItemsAsync<TeamMembership>(path);
        }

        /// <summary>
        /// Get details for a membership by ID.
        /// Specify the membership ID in the membershipId URI parameter.
        /// </summary>
        /// <param name="membershipId"></param>
        /// <returns>TeamMembership object.</returns>
        public async Task<TeamMembership> GetTeamMembershipAsync(string membershipId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{teamMembershipsBase}/{membershipId}", queryParams);
            return await GetItemAsync<TeamMembership>(path);
        }

        /// <summary>
        /// Add someone to a team by Person ID or email address; optionally making them a moderator.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="personId"></param>
        /// <param name="personEmail"></param>
        /// <param name="isModerator"></param>
        /// <returns>TeamMembership object.</returns>
        public async Task<TeamMembership> CreateTeamMembershipAsync(string teamId, string personId = null, string personEmail = null, bool isModerator = false)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("teamId", teamId);
            if (personId != null) { postBody.Add("personId", personId); }
            if (personEmail != null) { postBody.Add("personEmail", personEmail); }
            postBody.Add("isModerator", isModerator);
            return await PostItemAsync<TeamMembership>(teamMembershipsBase, postBody);
        }

        /// <summary>
        /// Deletes a membership by ID.
        /// Specify the membership ID in the membershipId URI parameter.
        /// </summary>
        /// <param name="membershipId"></param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteTeamMembershipAsync(string membershipId)
        {
            return await DeleteItemAsync($"{teamMembershipsBase}/{membershipId}");            
        }

        /// <summary>
        /// Updates properties for a membership by ID.
        /// Specify the membership ID in the membershipId URI parameter.
        /// </summary>
        /// <param name="membershipId"></param>
        /// <param name="isModerator"></param>
        /// <returns>TeamMembership object.</returns>
        public async Task<TeamMembership> UpdateTeamMembershipAsync(string membershipId, bool isModerator)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("isModerator",isModerator);
            var path = $"{teamMembershipsBase}/{membershipId}";
            return await UpdateItemAsync<TeamMembership>(path, putBody);
        }
    }
}