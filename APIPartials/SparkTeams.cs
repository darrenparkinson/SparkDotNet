
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string teamsBase = "/v1/teams";

        /// <summary>
        /// Lists teams to which the authenticated user belongs.
        /// </summary>
        /// <param name="max"></param>
        /// <returns>List of Team objects.</returns>
        public async Task<List<Team>> GetTeamsAsync(int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (max > 0) queryParams.Add("max",max.ToString());
            var path = getURL(teamsBase, queryParams);
            return await GetItemsAsync<Team>(path);
        }

        /// <summary>
        /// Shows details for a team, by ID.
        /// Specify the room ID in the teamId parameter in the URI.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns>Team object.</returns>
        public async Task<Team> GetTeamAsync(string teamId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{teamsBase}/{teamId}", queryParams);
            return await GetItemAsync<Team>(path);
        }

        /// <summary>
        /// Creates a team. The authenticated user is automatically added as a member of the team. See the Team Memberships API to learn how to add more people to the team.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Team object.</returns>
        public async Task<Team> CreateTeamAsync(string name)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("name", name);
            return await PostItemAsync<Team>(teamsBase, postBody);
        }

        /// <summary>
        /// Deletes a team, by ID.
        /// Specify the team ID in the teamId parameter in the URI.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteTeamAsync(string teamId)
        {
            return await DeleteItemAsync($"{teamsBase}/{teamId}");            
        }

        /// <summary>
        /// Updates details for a team, by ID.
        /// Specify the team ID in the teamId parameter in the URI.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="name"></param>
        /// <returns>Team object.</returns>
        public async Task<Team> UpdateTeamAsync(string teamId, string name)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("name",name);
            var path = $"{teamsBase}/{teamId}";
            return await UpdateItemAsync<Team>(path, putBody);
        }
    }

}