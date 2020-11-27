namespace SparkDotNet {
    /// <summary>
    /// Room Tabs represent an always available tab that is added as a shortcut to a rooms tab row and
    /// configured with a content url. Use this API to list tabs of any room that you are in.
    /// Room Tabs can also be updated to point to a different content url or can be deleted to remove
    /// the tab from the room.
    /// Just like in the Webex Teams app, you must be a member of the room in order to list its Room Tabs.
    /// </summary>
    public class RoomTab : WebexObject
    {
        /// <summary>
        /// A unique identifier for the Room Tab.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A unique identifier for the room.
        /// </summary>
        public string RoomId { get; set; }

        /// <summary>
        /// The room type.
        /// direct: 1:1 room
        /// group: group room
        /// </summary>
        public string RoomType {get; set; }

        /// <summary>
        /// User-friendly name for the room tab.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Content Url of the Room Tab.
        /// </summary>
        public string ContentUrl { get; set; }

        /// <summary>
        /// The person ID of the person who created this Room Tab.
        /// </summary>
        public string CreatorId { get; set; }

        /// <summary>
        /// The date and time when the Room Tab was created.
        /// </summary>
        public System.DateTime Created { get; set; }
    }
}