
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string organizationsBase = "/v1/organizations";

        /// <summary>
        /// List all organizations visible by your account.
        /// </summary>
        /// <param name="max"></param>
        /// <returns>List of Organization objects.</returns>
        public async Task<List<Organization>> GetOrganizationsAsync(int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (max > 0) queryParams.Add("max",max.ToString());
            var path = getURL(organizationsBase, queryParams);
            return await GetItemsAsync<Organization>(path);
        }

        /// <summary>
        /// List all organizations visible by your account.
        /// </summary>
        /// <param name="max"></param>
        /// <param name="callingData">Include XSI Endpoint values in the response (if applicable) for the organization.</param>
        /// <returns>List of Organization objects.</returns>
        public async Task<List<Organization>> GetOrganizationsAsync(int max = 0, bool callingData = false)
        {
            var queryParams = new Dictionary<string, string>();
            if (max > 0) queryParams.Add("max", max.ToString());
            queryParams.Add("callingData", callingData.ToString());
            var path = getURL(organizationsBase, queryParams);
            return await GetItemsAsync<Organization>(path);
        }

        /// <summary>
        /// Shows details for an organization, by ID.
        /// Specify the org ID in the orgId parameter in the URI.
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns>Organization object.</returns>
        public async Task<Organization> GetOrganizationAsync(string orgId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{organizationsBase}/{orgId}", queryParams);
            return await GetItemAsync<Organization>(path);
        }

        /// <summary>
        /// Shows details for an organization, by ID.
        /// Specify the org ID in the orgId parameter in the URI.
        /// </summary>
        /// <param name="orgId">The unique identifier for the organization.</param>
        /// <param name="callingData">Include XSI Endpoint values in the response (if applicable) for the organization.</param>
        /// <returns>Organization object.</returns>
        public async Task<Organization> GetOrganizationAsync(string orgId, bool callingData)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("callingData", callingData.ToString());
            var path = getURL($"{organizationsBase}/{orgId}", queryParams);
            return await GetItemAsync<Organization>(path);
        }

    }

}