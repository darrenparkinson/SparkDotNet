
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string rolesBase = "/v1/roles";

        /// <summary>
        /// List all roles.
        /// </summary>
        /// <param name="max">The maximum number of objects to be returned</param>
        /// <returns>List of Role objects.</returns>
        public async Task<List<Role>> GetRolesAsync(int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (max > 0) queryParams.Add("max",max.ToString());
            var path = getURL(rolesBase, queryParams);
            return await GetItemsAsync<Role>(path);
        }

        /// <summary>
        /// Shows details for a role, by ID.
        // Specify the role ID in the roleId parameter in the URI.
        /// </summary>
        /// <param name="roleId">The unique identifier for the role.</param>
        /// <returns>Role object.</returns>
        public async Task<Role> GetRoleAsync(string roleId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{rolesBase}/{roleId}", queryParams);
            return await GetItemAsync<Role>(path);
        }

    }

}