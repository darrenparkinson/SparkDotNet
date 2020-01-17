using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{
    public partial class Spark
    {
        private string attachmentActionBase = "/v1/attachment/actions";        

        /// <summary>
        /// Shows details for an attachment action, by attachment action ID.
        /// Specify the attachment action ID in the attachmentActionId parameter in the URI.
        /// </summary>
        /// <param name="attachmentActionId"></param>
        /// <returns>AttachmentAction object.</returns>
        public async Task<AttachmentAction> GetAttachmentActionAsync(string attachmentActionId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{attachmentActionBase}/{attachmentActionId}", queryParams);
            return await GetItemAsync<AttachmentAction>(path);
        }
    }
}