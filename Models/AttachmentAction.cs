using System;

namespace SparkDotNet
{
    /// <summary>
    /// Users create attachment actions by interacting with message attachments such as clicking on a submit button in a card.
    /// </summary>
    public class AttachmentAction : WebexObject
    {
        /// <summary>
        /// A unique identifier for the action.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The ID of the person who performed the action.
        /// </summary>
        public string personId { get; set; }

        /// <summary>
        /// The ID of the room the action was performed within.
        /// </summary>
        public string roomId { get; set; }

        /// <summary>
        /// The type of action performed. submit
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The parent message the attachment action was performed on.
        /// </summary>
        public string messageId { get; set; }

        /// <summary>
        /// The action's inputs.
        /// </summary>
        public AttachmentActionInput inputs { get; set; }

        /// <summary>
        /// The date and time the action was created.
        /// </summary>
        public DateTime created { get; set; }
    }
}