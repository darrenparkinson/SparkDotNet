using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string webhooksBase = "/v1/webhooks";

        /// <summary>
        /// Lists all of your webhooks.
        /// </summary>
        /// <param name="max">Limit the maximum number of webhooks in the response. Default: 100</param>
        /// <returns>List of Webhook objects.</returns>
        public async Task<List<Webhook>> GetWebhooksAsync(int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (max > 0) queryParams.Add("max",max.ToString());
            var path = getURL(webhooksBase, queryParams);
            return await GetItemsAsync<Webhook>(path);
        }

        /// <summary>
        /// Shows details for a webhook, by ID.
        /// Specify the webhook ID in the webhookId parameter in the URI.
        /// </summary>
        /// <param name="webhookId">The unique identifier for the webhook.</param>
        /// <returns>Webhook object.</returns>
        public async Task<Webhook> GetWebhookAsync(string webhookId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{webhooksBase}/{webhookId}", queryParams);
            return await GetItemAsync<Webhook>(path);
        }

        /// <summary>
        /// Creates a webhook.
        /// </summary>
        /// <param name="name">A user-friendly name for the webhook.</param>
        /// <param name="targetUrl">The URL that receives POST requests for each event.</param>
        /// <param name="resource">The resource type for the webhook. Creating a webhook requires 'read' scope on the resource the webhook is for. Possible values: memberships, messages, rooms</param>
        /// <param name="sparkEvent">The event type for the webhook. Possible values: created, updated, deleted</param>
        /// <param name="secret">The secret used to generate payload signature.</param>
        /// <param name="filter">The filter that defines the webhook scope.</param>
        /// <returns>Webhook object.</returns>
        public async Task<Webhook> CreateWebhookAsync(string name, string targetUrl, string resource, string sparkEvent, string secret = null, string filter = null)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("name", name);
            postBody.Add("targetUrl", targetUrl);
            postBody.Add("resource", resource);
            postBody.Add("event", sparkEvent);
            if (filter != null) postBody.Add("filter", filter);
            if (secret != null) postBody.Add("secret", secret);
            return await PostItemAsync<Webhook>(webhooksBase, postBody);
        }

        /// <summary>
        /// Deletes a webhook, by ID.
        /// Specify the webhook ID in the webhookId parameter in the URI.
        /// </summary>
        /// <param name="webhookId">The unique identifier for the webhook.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteWebhookAsync(string webhookId)
        {
            return await DeleteItemAsync($"{webhooksBase}/{webhookId}");            
        }


        /// <summary>
        /// Deletes a webhook, by object.
        /// </summary>
        /// <param name="webhook">The Webhook object to be deleted</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteWebhookAsync(Webhook webhook)
        {
            return await DeleteWebhookAsync(webhook.id);
        }

        /// <summary>
        /// Updates a webhook, by ID.
        /// Specify the webhook ID in the webhookId parameter in the URI.
        /// </summary>
        /// <param name="webhookId">The unique identifier for the webhook.</param>
        /// <param name="name">A user-friendly name for the webhook.</param>
        /// <param name="targetUrl">The URL that receives POST requests for each event.</param>
        /// <param name="secret">The secret used to generate payload signature.</param>
        /// <param name="status">The status of the webhook. Use active to reactivate a disabled webhook. Possible values: active, inactive</param>
        /// <returns>Webhook object.</returns>
        public async Task<Webhook> UpdateWebhookAsync(string webhookId, string name, string targetUrl, string secret = null, string status = null)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("name",name);
            putBody.Add("targetUrl", targetUrl);
            if (secret != null) putBody.Add("secret", secret);
            if (status != null) putBody.Add("status", status);
            var path = $"{webhooksBase}/{webhookId}";
            return await UpdateItemAsync<Webhook>(path, putBody);
        }
    }

}