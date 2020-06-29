using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string webhooksBase = "/v1/webhooks";
        
        /// <summary>
        /// Lists all of your webhooks.
        /// </summary>
        /// <param name="max"></param>
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
        /// <param name="webhookId"></param>
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
        /// <param name="name"></param>
        /// <param name="targetUrl"></param>
        /// <param name="resource"></param>
        /// <param name="sparkEvent"></param>
        /// <param name="secret"></param>
        /// <param name="filter"></param>
        /// <returns>Webhook object.</returns>
        public async Task<Webhook> CreateWebhookAsync(string name, string targetUrl, string resource, string sparkEvent, string secret, string filter = null)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("name", name);
            postBody.Add("targetUrl", targetUrl);
            postBody.Add("resource", resource);
            postBody.Add("event", sparkEvent);
            if (filter != null) { postBody.Add("filter", filter); }
            postBody.Add("secret", secret);
            return await PostItemAsync<Webhook>(webhooksBase, postBody);
        }

        /// <summary>
        /// Deletes a webhook, by ID.
        /// Specify the webhook ID in the webhookId parameter in the URI.
        /// </summary>
        /// <param name="webhookId"></param>
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
        /// <param name="webhookId"></param>
        /// <param name="name"></param>
        /// <param name="targetUrl"></param>
        /// <returns>Webhook object.</returns>
        public async Task<Webhook> UpdateWebhookAsync(string webhookId, string name, string targetUrl)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("name",name);
            putBody.Add("targetUrl", targetUrl);
            var path = $"{webhooksBase}/{webhookId}";
            return await UpdateItemAsync<Webhook>(path, putBody);
        }



    }

        

}