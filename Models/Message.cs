using System;

namespace SparkDotNet
{
    /// <summary>
    /// Messages are how we communicate in a room.In Webex Teams, each message is displayed on its own line along with a timestamp and sender information.
    /// Use this API to list, create, and delete messages.
    /// Message can contain plain text, rich text, and a file attachment.
    /// Just like in the Webex Teams app, you must be a member of the room in order to target it with this API.
    /// </summary>
    public class Message : WebexObject
    {
        /// <summary>
        /// The unique identifier for the message.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The unique identifier for the parent message.
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// The room ID of the message.
        /// </summary>
        public string roomId { get; set; }

        /// <summary>
        /// The type of room.
        /// direct: 1:1 room
        /// group: group room
        /// </summary>
        public string roomType { get; set; }

        /// <summary>
        /// The person ID of the recipient when sending a private 1:1 message.
        /// </summary>
        public string toPersonId { get; set; }

        /// <summary>
        /// The email address of the recipient when sending a private 1:1 message.
        /// </summary>
        public string toPersonEmail { get; set; }

        /// <summary>
        /// The message, in plain text.
        /// If markdown is specified this parameter may be optionally used to provide alternate text for UI clients that do not support rich text.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// The message, in Markdown format.
        /// </summary>
        public string markdown { get; set; }

        /// <summary>
        /// The text content of the message, in HTML format. This read-only property is used by the Webex Teams clients.
        /// </summary>
        public string html { get; set; }

        /// <summary>
        /// Public URLs for files attached to the message.
        /// For the supported media types and the behavior of file uploads, see Message Attachments.
        /// </summary>
        public string[] files { get; set; }

        /// <summary>
        /// The person ID of the message author.
        /// </summary>
        public string personId { get; set; }

        /// <summary>
        /// The email address of the message author.
        /// </summary>
        public string personEmail { get; set; }

        /// <summary>
        /// People IDs for anyone mentioned in the message.
        /// </summary>
        public string[] mentionedPeople { get; set; }

        /// <summary>
        /// Group names for the groups mentioned in the message.
        /// </summary>
        public string[] mentionedGroups { get; set; }

        /// <summary>
        /// Message content attachments attached to the message. See the Cards Guide for more information.
        /// </summary>
        public object[] attachments { get; set; }

        /// <summary>
        /// The date and time the message was created.
        /// </summary>
        public DateTime created { get; set; }

        /// <summary>
        /// The date and time that the message was last edited by the author. This field is only present when the message contents have changed.
        /// </summary>
        public DateTime updated { get; set; }
    }


}