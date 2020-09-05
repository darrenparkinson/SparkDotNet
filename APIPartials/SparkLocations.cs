using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {
        private string locationsBase = "/v1/locations";

        /// <summary>
        /// List locations for an organization.
        /// Use query parameters to filter the response.
        /// Long result sets will be split into pages.
        /// </summary>
        /// <param name="name">List locations whose name contains this string (case-insensitive).</param>
        /// <param name="id">List locations by ID.</param>
        /// <param name="orgId">List locations in this organization. Only admin users of another organization (such as partners) may use this parameter.</param>
        /// <param name="max">Limit the maximum number of location in the response. Default: 100</param>
        /// <returns>A list of matching Location objects</returns>
        public async Task<List<Location>> GetLocationsAsync(string name = null, string id = null, string orgId = null, int max = 0)
        {
            var queryParams = new Dictionary<string, string>();

            if (name != null) queryParams.Add("name", name);
            if (id != null) queryParams.Add("id", id);
            if (orgId != null) queryParams.Add("orgId", orgId);
            if (max > 0) queryParams.Add("max", max.ToString());

            var path = getURL(locationsBase, queryParams);
            return await GetItemsAsync<Location>(path);
        }

        /// <summary>
        /// Shows details for a location, by ID.
        /// Specify the location ID in the locationId parameter in the URI.
        /// Partner administrators should use the List Locations endpoint to retrieve information about locations.
        /// </summary>
        /// <param name="locationId">A unique identifier for the location.</param>
        /// <returns>A location object</returns>
        public async Task<Location> GetLocationAsync(string locationId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{locationsBase}/{locationId}", queryParams);
            return await GetItemAsync<Location>(path);
        }
    }

}