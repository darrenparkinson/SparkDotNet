using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string hybridBase = "/v1/hybrid";

        #region HybridConnector
        /// <summary>
        /// List hybrid connectors for an organization. If no orgId is specified, the default is the organization of the authenticated user.
        /// Only an admin auth token with the spark-admin:hybrid_connectors_read scope can list connectors.
        /// </summary>
        /// <param name="orgId">List hybrid connectors in this organization. If an organization is not specified, the organization of the caller will be used.</param>
        /// <returns>A list of HybridConnectors</returns>
        public async Task<List<HybridConnector>> GetHybridConnectorsAsync(string orgId = null)
        {
            var queryParams = new Dictionary<string, string>();

            if (orgId != null) queryParams.Add("orgId", orgId);
            
            var path = getURL($"{hybridBase}/connectors", queryParams);
            return await GetItemsAsync<HybridConnector>(path);
        }

        /// <summary>
        /// Shows details for a hybrid connector, by ID.
        /// Only an admin auth token with the spark-admin:hybrid_connectors_read scope can see connector details.
        /// </summary>
        /// <param name="connectorId">The ID of the connector.</param>
        /// <returns>A hybrid Connector Object</returns>
        public async Task<HybridConnector> GetHybridConnectorAsync(string connectorId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{hybridBase}/connectors/{connectorId}", queryParams);
            return await GetItemAsync<HybridConnector>(path);
        }
        #endregion HybridConnector

        #region HybridCluster
        /// <summary>
        /// List hybrid clusters for an organization. If no orgId is specified, the default is the organization of the authenticated user.
        /// Only an admin auth token with the spark-admin:hybrid_clusters_read scope can list clusters.
        /// </summary>
        /// <param name="orgId">List hybrid clusters in this organization. If an organization is not specified, the organization of the caller will be used.</param>
        /// <returns>A list of HybridClusters</returns>
        public async Task<List<HybridCluster>> GetHybridClustersAsync(string orgId = null)
        {
            var queryParams = new Dictionary<string, string>();

            if (orgId != null) queryParams.Add("orgId", orgId);

            var path = getURL($"{hybridBase}/clsuters", queryParams);
            return await GetItemsAsync<HybridCluster>(path);
        }

        /// <summary>
        /// Shows details for a hybrid cluster, by ID.
        /// Only an admin auth token with the spark-admin:hybrid_clusters_read scope can see cluster details.
        /// </summary>
        /// <param name="hybridClusterId">The ID of the clsuter.</param>
        /// <returns>A hybrid Clsuter Object</returns>
        public async Task<HybridCluster> GetHybridClusterAsync(string hybridClusterId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{hybridBase}/clsuters/{hybridClusterId}", queryParams);
            return await GetItemAsync<HybridCluster>(path);
        }
        #endregion HybridCluster



    }

}