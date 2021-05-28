using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{
    public partial class Spark
    {
        private readonly string attachmentActionBase = "/v1/attachment/actions";

        /// <summary>
        /// Shows details for an attachment action, by attachment action ID.
        /// Specify the attachment action ID in the attachmentActionId parameter in the URI.
        /// </summary>
        /// <param name="attachmentActionId">A unique identifier for the attachment action.</param>
        /// <returns>AttachmentAction object.</returns>
        public async Task<AttachmentAction> GetAttachmentActionAsync(string attachmentActionId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{attachmentActionBase}/{attachmentActionId}", queryParams);
            return await GetItemAsync<AttachmentAction>(path);
        }

        /// <summary>
        /// Create a new attachment action.
        /// </summary>
        /// <param name="type">The type of action to perform. submit.</param>
        /// <param name="messageId">The ID of the message which contains the attachment.</param>
        /// <param name="inputs">The attachment action's inputs.</param>
        /// <returns>The newly created Attachment Action object</returns>
        public async Task<AttachmentAction> CreateAttachmentActionAsync(string type, string messageId, AttachmentActionInput inputs)
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("type", type);
            putBody.Add("messageId", messageId);
            putBody.Add("inputs", inputs);
            return await PostItemAsync<AttachmentAction>(attachmentActionBase, putBody);
        }

        /// <summary>
        /// Create a new attachment action.
        /// </summary>
        /// <param name="attachment">The Attachment Action object to be created</param>
        /// <returns>The newly created Attachment Action object</returns>
        public async Task<AttachmentAction> CreateAttachmentActionAsync(AttachmentAction attachment)
        {
            return await CreateAttachmentActionAsync(attachment.type, attachment.messageId, attachment.inputs);
        }
    }
}