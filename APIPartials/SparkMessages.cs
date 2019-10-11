using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string messagesBase = "/v1/messages";

        /// <summary>
        /// Lists all messages in a room with roomType. If present, includes the associated media content attachment for each message. The roomType could be a group or direct(1:1).
        /// The list sorts the messages in descending order by creation date.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="mentionedPeople"></param>
        /// <param name="before"></param>
        /// <param name="beforeMessage"></param>
        /// <param name="max"></param>
        /// <returns>List of Message objects.</returns>
        public async Task<List<Message>> GetMessagesAsync(string roomId, string mentionedPeople = null, string before = null, string beforeMessage = null, int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            //TODO: Throw Exception if room ID is empty?
            if (roomId != null) queryParams.Add("roomId",roomId);

            if (mentionedPeople != null) queryParams.Add("mentionedPeople",mentionedPeople);
            //TODO Parse before as a DateTime and check it's ok before we send the request.
            if (before != null) queryParams.Add("before",before);
            if (beforeMessage != null) queryParams.Add("beforeMessage",beforeMessage);
            if (max > 0) queryParams.Add("max",max.ToString());

            var path = getURL(messagesBase, queryParams);
            return await GetItemsAsync<Message>(path);
        }

        /// <summary>
        /// Shows details for a message, by message ID.
        /// Specify the message ID in the messageId parameter in the URI.
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns>Message object.</returns>
        public async Task<Message> GetMessageAsync(string messageId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{messagesBase}/{messageId}", queryParams);
            return await GetItemAsync<Message>(path);
        }

        /// <summary>
        /// Posts a plain text message, and optionally, a media content attachment, to a room.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="toPersonId"></param>
        /// <param name="toPersonEmail"></param>
        /// <param name="text"></param>
        /// <param name="markdown"></param>
        /// <param name="files"></param>
        /// <param name="attachments"></param>
        /// <returns>Message object.</returns>
        public async Task<Message> CreateMessageAsync(string roomId = null, string toPersonId = null, string toPersonEmail = null, string text = null, string markdown = null, string[] files = null, string attachments = null)
        {
            var postBody = new Dictionary<string, object>();
            if (roomId != null) postBody.Add("roomId",roomId);
            if (toPersonId != null) postBody.Add("toPersonId",toPersonId);
            if (toPersonEmail != null) postBody.Add("toPersonEmail",toPersonEmail);
            if (text != null) postBody.Add("text",text);
            if (markdown != null) postBody.Add("markdown",markdown);
            if (files != null) postBody.Add("files",files);
            if (attachments != null) postBody.Add("attachments", attachments);
            return await PostItemAsync<Message>(messagesBase,postBody);
        }

        /// <summary>
        /// Deletes a message, by message ID.
        /// Specify the message ID in the messageId parameter in the URI.
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteMessageAsync(string messageId)
        {
            return await DeleteItemAsync($"{messagesBase}/{messageId}");
        }

    }

}