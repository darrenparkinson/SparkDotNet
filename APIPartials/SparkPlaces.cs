
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string placesBase = "/v1/places";

        /// <summary>
        /// List places. Use query parameters to filter the response.
        /// </summary>
        /// <param name="displayName">(optional) List places by display name.</param>
        /// <param name="orgId"> (optional) List places in this organization. Only admin users of another organization (such as partners) may use this parameter.</param>
        /// <param name="max">(optional) Limit the maximum number of places in the response.</param>
        /// <returns>A list of Place objects matching the query</returns>
        public async Task<List<Place>> GetPlacesAsync(string displayName = null, string orgId = null, int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (max > 0) queryParams.Add("max",max.ToString());
            if (displayName != null) queryParams.Add("displayName", displayName);
            if (orgId != null) queryParams.Add("orgId", orgId);
            var path = getURL(placesBase, queryParams);
            return await GetItemsAsync<Place>(path);
        }

        /// <summary>
        /// Shows details for a place, by ID.
        /// Specify the place ID in the placeId parameter in the URI.
        /// </summary>
        /// <param name="placeId">A unique identifier for the place.</param>
        /// <returns>A Place object</returns>
        public async Task<Place> GetPlaceAsync(string placeId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{placesBase}/{placeId}", queryParams);
            return await GetItemAsync<Place>(path);
        }

        /// <summary>
        /// Create a place.
        /// </summary>
        /// <param name="displayName">A friendly name for the place.</param>
        /// <returns>A Place object.</returns>
        public async Task<Place> CreatePlaceAsync(string displayName)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("displayName", displayName);
            return await PostItemAsync<Place>(placesBase, postBody);
        }

        /// <summary>
        /// Deletes a place, by ID. Will also delete all devices associated with the place.
        /// Specify the place ID in the placeId parameter in the URI.
        /// </summary>
        /// <param name="placeId">A unique identifier for the place.</param>
        /// <returns>true if the Place was deleted, false otherwise</returns>
        public async Task<bool> DeletePlaceAsync(string placeId)
        {
            return await DeleteItemAsync($"{placesBase}/{placeId}");
        }

        /// <summary>
        /// Deletes a place, by Place object. Will also delete all devices associated with the place.
        /// </summary>
        /// <param name="place">A Place object.</param>
        /// <returns>true if the Place was deleted, false otherwise</returns>
        public async Task<bool> DeletePlaceAsync(Place place)
        {
            return await DeletePlaceAsync(place.Id);
        }

        /// <summary>
        /// Updates details for a place, by ID.
        /// Specify the place ID in the placeId parameter in the URI.
        /// </summary>
        /// <param name="placeId">A unique identifier for the place.</param>
        /// <param name="displayName">A friendly name for the place.</param>
        /// <returns>A Place object of the update place</returns>
        public async Task<Place> UpdatePlaceAsync(string placeId, string displayName)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("displayName", displayName);
            var path = $"{placesBase}/{placeId}";
            return await UpdateItemAsync<Place>(path, putBody);
        }

        /// <summary>
        /// Updates details for a place, by Place object.
        /// </summary>
        /// <param name="place">A place object wich should be updated</param>
        /// <returns>A Place object of the update place</returns>
        public async Task<Place> UpdatePlaceAsync(Place place)
        {
            return await UpdatePlaceAsync(place.Id, place.DisplayName);
        }

   }

}