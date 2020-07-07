using System;

namespace SparkDotNet
{
    /// <summary>
    /// Rooms are virtual meeting places where people post messages and collaborate to get work done.
    /// This API is used to manage the rooms themselves. Rooms are created and deleted with this API.
    /// You can also update a room to change its title, for example.
    /// To create a team room, specify the a teamId in the POST payload.
    /// Note that once a room is added to a team, it cannot be moved.To learn more about managing teams, see the Teams API.
    /// To manage people in a room see the Memberships API.
    /// To post content see the Messages API.
    /// </summary>
    public class Room : WebexObject
    {
        /// <summary>
        /// A unique identifier for the room.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A user-friendly name for the room.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// The room type.
        /// direct: 1:1 room
        /// group: group room
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Whether the room is moderated (locked) or not.
        /// </summary>
        public bool isLocked { get; set; }

        /// <summary>
        /// The ID for the team with which this room is associated.
        /// </summary>
        public string teamId { get; set; }

        /// <summary>
        /// The date and time of the room's last activity.
        /// </summary>
        public DateTime lastActivity { get; set; }

        /// <summary>
        /// The ID of the person who created this room.
        /// </summary>
        public string creatorId { get; set; }

        /// <summary>
        /// The date and time the room was created.
        /// </summary>
        public DateTime created { get; set; }

        /// <summary>
        /// The ID of the organization which owns this room. See Webex Teams Data in the Compliance Guide for more information.
        /// </summary>
        public string OwnerId { get; set; }
    }
}