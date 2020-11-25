
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string workspacesBase = "/v1/workspaces";

        /// <summary>
        /// List workspaces.
        /// Use query parameters to filter the response.The orgId parameter can only be used by
        /// admin users of another organization(such as partners).
        /// The capacity and type fields will only be present for workspaces that have a value set for them.
        /// The special values notSet (for filtering on category) and -1 (for filtering on capacity)
        /// can be used to filter for workspaces without a type and/or capacity.
        /// </summary>
        /// <param name="displayName">List workspaces by display name.</param>
        /// <param name="capacity">List workspaces with the given capacity. Must be -1 or higher. A value of -1 lists workspaces with no capacity set.</param>
        /// <param name="type">List workspaces by type. Possible values: notSet, focus, huddle, meetingRoom, open, desk, other</param>
        /// <param name="orgId">List workspaces in this organization. Only admin users of another organization (such as partners) may use this parameter.</param>
        /// <param name="start">Offset. Default is 0.</param>
        /// <param name="max">Limit the maximum number of workspaces in the response.</param>
        /// <returns>List of Workspace objects.</returns>
        public async Task<List<Workspace>> GetWorkspacesAsync(string displayName = null, int? capacity = null, string type = null, string orgId = null, int start = 0, int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (displayName != null) queryParams.Add("displayName", displayName);
            if (capacity != null) queryParams.Add("capacity", capacity.ToString());
            if (type != null) queryParams.Add("type", type);
            if (orgId != null) queryParams.Add("orgId", orgId);
            if (start > 0) queryParams.Add("start", start.ToString());
            if (max > 0) queryParams.Add("max", max.ToString());

            var path = getURL(workspacesBase, queryParams);
            return await GetItemsAsync<Workspace>(path);
        }

        /// <summary>
        /// Shows details for a workspace, by ID. The capacity and type fields will only be present if they have been set for the workspace.
        /// Specify the workspace ID in the workspaceId parameter in the URI.
        /// </summary>
        /// <param name="workspaceId">A unique identifier for the workspace.</param>
        /// <returns>The Workspace object.</returns>
        public async Task<Workspace> GetWorkspaceAsync(string workspaceId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{workspacesBase}/{workspaceId}", queryParams);
            return await GetItemAsync<Workspace>(path);
        }

        /// <summary>
        /// Create a workspace. The capacity and type parameters are optional, and omitting them will result in the creation of a workspace without a capacity and/or type set.
        /// The orgId parameter can only be used by admin users of another organization(such as partners).
        /// </summary>
        /// <param name="displayName">A friendly name for the workspace.</param>
        /// <param name="orgId">OrgId associated with the workspace. Only admin users of another organization (such as partners) may use this parameter.</param>
        /// <param name="capacity">How many people the workspace is suitable for. If set, must be 0 or higher.</param>
        /// <param name="type">The type that best describes the workspace.</param>
        /// <returns>The newly created Workspace object.</returns>
        public async Task<Workspace> CreateWorkspaceAsync(string displayName, string orgId = null, int? capacity = null, string type = null)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("displayName", displayName);
            if (orgId != null) postBody.Add("orgId", orgId);
            if (capacity != null) postBody.Add("capacity", System.Math.Max((int)capacity, 0));
            if (type != null) postBody.Add("type", type);
            
            return await PostItemAsync<Workspace>(workspacesBase, postBody);
        }

        /// <summary>
        /// Deletes a workspace, by ID. Will also delete all devices associated with the workspace. Any deleted devices will need to be reactivated.
        /// Specify the workspace ID in the workspaceId parameter in the URI.
        /// </summary>
        /// <param name="workspaceId">A unique identifier for the workspace.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteWorkspaceAsync(string workspaceId)
        {
            return await DeleteItemAsync($"{workspacesBase}/{workspaceId}");            
        }

        /// <summary>
        /// Deletes a workspace, by object.
        /// </summary>
        /// <param name="workspace">The workspace object to be deleted.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteWorkspaceAsync(Workspace workspace)
        {
            return await DeleteWorkspaceAsync(workspace.Id);
        }

        /// <summary>
        /// Updates details for a workspace, by ID.
        /// Specify the workspace ID in the workspaceId parameter in the URI.
        /// Include all details for the workspace that are present in a GET request for the workspace details.Not including an optional field (that is, the capacity or the type field) will result in the field no longer being defined for the workspace.
        /// </summary>
        /// <param name="workspaceId">A unique identifier for the workspace.</param>
        /// <param name="displayName">A friendly name for the workspace.</param>
        /// <param name="capacity">How many people the workspace is suitable for. If set, must be 0 or higher.</param>
        /// <param name="type">The type that best describes the workspace.</param>
        /// <returns>The updated workspace object</returns>
        public async Task<Workspace> UpdateWorkspaceAsync(string workspaceId, string displayName, int? capacity = null, string type = null)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("displayName", displayName);
            if (capacity != null) putBody.Add("capacity", System.Math.Max((int)capacity, 0));
            if (type != null) putBody.Add("type", type);
            var path = $"{workspacesBase}/{workspaceId}";
            return await UpdateItemAsync<Workspace>(path, putBody);
        }

        /// <summary>
        /// Updates details for a workspace, by Object.
        /// </summary>
        /// <param name="workspace">The workspace object to be updated.</param>
        /// <returns>The udated workspace object</returns>
        public async Task<Workspace> UpdateWorkspacesync(Workspace workspace)
        {
            return await UpdateWorkspaceAsync(workspace.Id, workspace.DisplayName, workspace.Capacity, workspace.Type);
        }
    }

}