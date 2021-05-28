
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{
    public partial class Spark
    {

        private readonly string organizationsBase = "/v1/organizations";

        /// <summary>
        /// List all organizations visible by your account.
        /// </summary>
        /// <param name="max">The maxmimum number of  objects to be returned.</param>
        /// <param name="callingData">Include XSI Endpoint values in the response (if applicable) for the organization. Requires special permissions</param>
        /// <returns>List of Organization objects.</returns>
        public async Task<List<Organization>> GetOrganizationsAsync(int max = 0, bool? callingData = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (max > 0) queryParams.Add("max", max.ToString());
            if (callingData != null) queryParams.Add("callingData", callingData.ToString());
            var path = getURL(organizationsBase, queryParams);
            return await GetItemsAsync<Organization>(path);
        }

        /// <summary>
        /// Shows details for an organization, by ID.
        /// Specify the org ID in the orgId parameter in the URI.
        /// </summary>
        /// <param name="orgId">The unique identifier for the organization.</param>
        /// <param name="callingData">Include XSI Endpoint values in the response (if applicable) for the organization. Requires special permissions.</param>
        /// <returns>Organization object.</returns>
        public async Task<Organization> GetOrganizationAsync(string orgId, bool? callingData = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (callingData != null) queryParams.Add("callingData", callingData.ToString());
            var path = getURL($"{organizationsBase}/{orgId}", queryParams);
            return await GetItemAsync<Organization>(path);
        }

        /// <summary>
        /// Deletes an organization, by ID. It may take up to 10 minutes for the organization to be deleted
        /// after the response is returned.
        /// Specify the org ID in the orgId parameter in the URI.
        /// Deleting your organization permanently deletes all of the information associated with your
        /// organization and is irreversible.
        /// Deleting an Organization may fail with a HTTP 409 Conflict response and encounter one or more
        /// of the errors described below. Resolve these conditions to allow the delete to succeed.
        /// * Org cannot be deleted as it has Linked sites.
        /// * Org cannot be deleted as it has active subscriptions or licenses.
        /// * Org cannot be deleted as Directory Synchronization is enabled.
        /// * Org cannot be deleted as it has more than 1 user.
        /// * Org cannot be deleted as it has more than 1 managed by relationship.
        /// * Org cannot be deleted as it has managed orgs.
        /// When deleting a Webex for BroadWorks organization with BroadWorks Directory Synchronization enabled,
        /// a prerequisite is to remove all the BroadWorks Directory Synchronization users beforehand.
        /// Refer to the Organization Deletion section of the Webex for BroadWorks guide for more information.
        /// </summary>
        /// <param name="orgId">The id of the organization to be deleted</param>
        /// <returns>True if the deletion succeeded, false otherwise</returns>
        public async Task<bool> DeleteOrganizationAsync(string orgId)
        {
            return await DeleteItemAsync($"{organizationsBase}/{orgId}");
        }

        /// <summary>
        /// Deletes an organization, by ID. It may take up to 10 minutes for the organization to be deleted
        /// after the response is returned.
        /// Specify the org ID in the orgId parameter in the URI.
        /// Deleting your organization permanently deletes all of the information associated with your
        /// organization and is irreversible.
        /// Deleting an Organization may fail with a HTTP 409 Conflict response and encounter one or more
        /// of the errors described below. Resolve these conditions to allow the delete to succeed.
        /// * Org cannot be deleted as it has Linked sites.
        /// * Org cannot be deleted as it has active subscriptions or licenses.
        /// * Org cannot be deleted as Directory Synchronization is enabled.
        /// * Org cannot be deleted as it has more than 1 user.
        /// * Org cannot be deleted as it has more than 1 managed by relationship.
        /// * Org cannot be deleted as it has managed orgs.
        /// When deleting a Webex for BroadWorks organization with BroadWorks Directory Synchronization enabled,
        /// a prerequisite is to remove all the BroadWorks Directory Synchronization users beforehand.
        /// Refer to the Organization Deletion section of the Webex for BroadWorks guide for more information.
        /// </summary>
        /// <param name="organization">The organization to be deleted</param>
        /// <returns>True if the deletion succeeded, false otherwise</returns>
        public async Task<bool> DeleteOrganizationAsync(Organization organization)
        {
            return await DeleteOrganizationAsync(organization.id);
        }

    }

}