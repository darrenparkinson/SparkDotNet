namespace SparkDotNet {
    /// <summary>
    /// Resource Groups are collections of on-premise clusters which provide Hybrid Services to a particular subset of people in an organization.
    /// If a person has a Hybrid Services license associated with their account, they will be associated with a resource group to use specific
    /// on-premise clusters for that service.
    /// Searching and viewing Resource Groups requires an administrator auth token with a scope of spark-admin:resource_groups_read.
    /// To manage the people associated with Resource Groups, see the Resource Group Memberships API.
    /// For more information about Resource Groups, see the Managing Hybrid Services guide.
    /// </summary>
    public class ResourceGroup : WebexObject
    {
        /// <summary>
        /// A unique identifier for the resource group.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A user-friendly name for the resource group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the organization to which this resource group belongs.
        /// </summary>
        public string OrgId { get; set; }
    }
}