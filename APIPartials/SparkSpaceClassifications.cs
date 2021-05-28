
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string classificationsBase = "/v1/classifications";

        /// <summary>
        /// List all the space classifications configured in your org.
        /// </summary>
        /// <returns>List of SpaceClassification objects.</returns>
        public async Task<List<SpaceClassification>> GetSpaceClassificationsAsync()
        {
            var queryParams = new Dictionary<string, string>();
            
            var path = getURL(classificationsBase, queryParams);
            return await GetItemsAsync<SpaceClassification>(path);
        }
    }

}