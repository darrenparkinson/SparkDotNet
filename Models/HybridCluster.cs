namespace SparkDotNet {

    /// <summary>
    /// Hybrid Clusters are groups of hosts, and the connectors these hosts contain, that are managed as a unit. All the connectors of a single type in a cluster share the same configuration.
    /// Listing and viewing Hybrid Clusters requires an administrator auth token with the spark-admin:hybrid_clusters_read scope.
    /// Hybrid Clusters are associated with Resource Groups. See the Resource Groups API for more information.
    /// </summary>
    public class HybridCluster : WebexObject
    {
        /// <summary>
        /// A unique identifier for the cluster.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The ID of the organization to which this hybrid cluster belongs.
        /// </summary>
        public string OrgId { get; set; }

        /// <summary>
        /// The name of the cluster.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the resource group this cluster belongs to.
        /// </summary>
        public string ResourceGroupId { get; set; }
    }
}