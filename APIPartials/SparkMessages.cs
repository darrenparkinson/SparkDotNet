using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string messagesBase = "/v1/messages";

        /// <summary>
        /// Lists all messages in a room with roomType. If present, includes the associated media content attachment for each message. The roomType could be a group or direct(1:1).
        /// The list sorts the messages in descending order by creation date.
        /// </summary>
        /// <param name="roomId">List messages in a room, by ID.</param>
        /// <param name="parentId">List messages with a parent, by ID.</param>
        /// <param name="mentionedPeople">List messages with these people mentioned, by ID. Use me as a shorthand for the current API user. Only me or the person ID of the current user may be specified. Bots must include this parameter to list messages in group rooms (spaces).</param>
        /// <param name="before">List messages sent before a date and time.</param>
        /// <param name="beforeMessage">List messages sent before a message, by ID.</param>
        /// <param name="max">Limit the maximum number of messages in the response. Default: 50</param>
        /// <returns>List of Message objects.</returns>
        public async Task<List<Message>> GetMessagesAsync(string roomId, string parentId = null,
                                                          string mentionedPeople = null, DateTime? before = null,
                                                          string beforeMessage = null, int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            //TODO: Throw Exception if room ID is empty?
            if (roomId != null) queryParams.Add("roomId", roomId);

            if (parentId != null) queryParams.Add("parentId", parentId);

            if (mentionedPeople != null) queryParams.Add("mentionedPeople",mentionedPeople);
            //TODO Parse before as a DateTime and check it's ok before we send the request.
            if (before != null) queryParams.Add("before", ((DateTime)before).ToString("o"));
            if (beforeMessage != null) queryParams.Add("beforeMessage",beforeMessage);
            if (max > 0) queryParams.Add("max",max.ToString());

            var path = getURL(messagesBase, queryParams);
            return await GetItemsAsync<Message>(path);
        }

        /// <summary>
        /// Lists all messages in a 1:1 (direct) room. Use the personId or personEmail query parameter to specify the room.
        /// Each message will include content attachments if present.
        /// The list sorts the messages in descending order by creation date.
        /// </summary>
        /// <param name="parentId">List messages with a parent, by ID.</param>
        /// <param name="personId">List messages in a 1:1 room, by person ID.</param>
        /// <param name="personEmail">List messages in a 1:1 room, by person email.</param>
        /// <returns>List of direct Messages</returns>
        public async Task<List<Message>> GetDirectMessagesAsync(string parentId = null, string personId = null, string personEmail = null)
        {
            var queryParams = new Dictionary<string, string>();

            if (parentId != null) queryParams.Add("parentId", parentId);
            if (personId != null) queryParams.Add("personId", parentId);
            if (personEmail != null) queryParams.Add("personEmail", personEmail);

            var path = getURL($"{messagesBase}/direct", queryParams);
            return await GetItemsAsync<Message>(path);
        }


        /// <summary>
        /// Shows details for a message, by message ID.
        /// Specify the message ID in the messageId parameter in the URI.
        /// </summary>
        /// <param name="messageId">The unique identifier for the message.</param>
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
        /// <param name="roomId">The room ID of the message.</param>
        /// <param name="parentId">The parent message to reply to.</param>
        /// <param name="toPersonId">The person ID of the recipient when sending a private 1:1 message.</param>
        /// <param name="toPersonEmail">The email address of the recipient when sending a private 1:1 message.</param>
        /// <param name="text">The message, in plain text. If markdown is specified this parameter may be optionally used to provide alternate text for UI clients that do not support rich text. The maximum message length is 7439 bytes.</param>
        /// <param name="markdown">The message, in Markdown format. The maximum message length is 7439 bytes.</param>
        /// <param name="files">The public URL to a binary file to be posted into the room. Only one file is allowed per message. Uploaded files are automatically converted into a format that all Webex Teams clients can render. For the supported media types and the behavior of uploads, see the Message Attachments Guide. Possible values: http://www.example.com/images/media.png</param>
        /// <param name="attachments">Content attachments to attach to the message. Only one card per message is supported. See the Cards Guide for more information.</param>
        /// <returns>Message object.</returns>
        public async Task<Message> CreateMessageAsync(string roomId = null, string parentId = null, string toPersonId = null,
                                                      string toPersonEmail = null, string text = null, string markdown = null,
                                                      string[] files = null, string attachments = null)
        {
            var postBody = new Dictionary<string, object>();
            if (roomId != null) postBody.Add("roomId",roomId);
            if (parentId != null) postBody.Add("parentId", parentId);
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
        /// <param name="messageId">The unique identifier for the message.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteMessageAsync(string messageId)
        {
            return await DeleteItemAsync($"{messagesBase}/{messageId}");
        }

        /// <summary>
        /// Deletes a message, by message object.
        /// Specify the message object in the message parameter in the URI.
        /// </summary>
        /// <param name="message">The message object for the message.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeleteMessageAsync(Message message)
        {
            return await DeleteMessageAsync(message.id);
        }

        /// <summary>
        /// Update a message you have posted not more than 10 times.
        /// Specify the messageId of the message you want to edit.
        /// Please note edits of messages containing files or attachments are not currently supported.
        /// If a user attempts to edit a message containing files or attachments a 400 Bad Request will
        /// be returned by the API with a message stating that the feature is currently unsupported.
        /// There is also a maximum number of times a user can edit a message.
        /// The maximum currently supported is 10 edits per message.If a user attempts to edit a message
        /// greater that the maximum times allowed the API will return 400 Bad Request with a message
        /// stating the edit limit has been reached.
        /// While only the roomId and text or markdown attributes are required in the request body,
        /// a common pattern for editing message is to first call GET /messages/{ id} for the message
        /// you wish to edit and to then update the text or markdown attribute accordingly,
        /// passing the updated message object in the request body of the PUT /messages/{id} request.
        /// When this pattern is used on a message that included markdown, the html attribute must be
        /// deleted prior to making the PUT request.
        /// </summary>
        /// <param name="messageId">The unique identifier for the message.</param>
        /// <param name="roomId">The room ID of the message.</param>
        /// <param name="text">The message, in plain text. If markdown is specified this parameter may be optionally used to provide alternate text for UI clients that do not support rich text. The maximum message length is 7439 bytes.</param>
        /// <param name="markdown">The message, in Markdown format. If this attribute is set ensure that the request does NOT contain an html attribute.</param>
        /// <returns>The updated message object</returns>
        public async Task<Message> UpdateMessageAsync(string messageId, string roomId = null, string text = null, string markdown = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("messageId", messageId);

            var postBody = new Dictionary<string, object>();
            if (roomId != null) postBody.Add("roomId", roomId);
            if (text != null) postBody.Add("text", text);
            if (markdown != null) postBody.Add("markdown", markdown);

            var path = getURL($"{messagesBase}/{messageId}", queryParams);

            return await UpdateItemAsync<Message>(path, postBody);
        }

        /// <summary>
        /// Updates a message
        /// </summary>
        /// <param name="message">The message to be updated</param>
        /// <returns>The updated message object</returns>
        public async Task<Message> UpdateMessageAsync(Message message)
        {
            return await UpdateMessageAsync(message.id, message.roomId, message.text, message.markdown);
        }

    }

}