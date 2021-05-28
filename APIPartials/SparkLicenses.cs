
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string licensesBase = "/v1/licenses";

        /// <summary>
        /// List all licenses for a given organization. If no orgId is specified, the default is the organization of the authenticated user.
        /// </summary>
        /// <param name="orgId">List licenses for this organization.</param>
        /// <param name="max"></param>
        /// <returns>List of License objects.</returns>
        public async Task<List<License>> GetLicensesAsync(string orgId = null, int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (orgId != null) queryParams.Add("orgId", orgId);
            if (max > 0) queryParams.Add("max",max.ToString());
            var path = getURL(licensesBase, queryParams);
            return await GetItemsAsync<License>(path);
        }

        /// <summary>
        /// Shows details for a license, by ID.
        /// Specify the license ID in the licenseId parameter in the URI.
        /// </summary>
        /// <param name="licenseId">The unique identifier for the license.</param>
        /// <returns>License object.</returns>
        public async Task<License> GetLicenseAsync(string licenseId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{licensesBase}/{licenseId}", queryParams);
            return await GetItemAsync<License>(path);
        }

    }

}