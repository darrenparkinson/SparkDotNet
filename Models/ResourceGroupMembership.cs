using System;
using Newtonsoft.Json;

namespace SparkDotNet {

    /// <summary>
    /// Resource Group Memberships represent a person's relationship to a Resource Group for a particular Hybrid Services license.
    /// Users assigned a new license will be automatically placed in a "default" Resource Group.
    /// Use this API to list memberships for all people in an organization or update memberships to use a different Resource Group.
    /// Searching and viewing Resource Group Memberships requires an administrator auth token with the spark-admin:resource_group_memberships_read scope.
    /// Updating memberships requires an administrator auth token with the spark-admin:resource_group_memberships_write scope.
    /// To manage Resource Groups, see the Resource Groups API.For more information about Resource Groups, see the Managing Hybrid Services guide.
    /// </summary>
    public class ResourceGroupMembership
    {
        /// <summary>
        /// A unique identifier for the resource group membership.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The resource group ID.
        /// </summary>
        public string ResourceGroupId { get; set; }

        /// <summary>
        /// The license ID.
        /// </summary>
        public string LicenseId { get; set; }

        /// <summary>
        /// The person ID.
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// The organization ID of the person.
        /// </summary>
        public string PersonOrgId { get; set; }

        /// <summary>
        /// The activation status of the resource group membership.
        /// pending:activation pending
        /// activated: activated
        /// error: error present
        /// </summary>
        public string Status { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}