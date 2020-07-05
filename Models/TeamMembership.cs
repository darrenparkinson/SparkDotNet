using System;

namespace SparkDotNet
{
    /// <summary>
    /// eam Memberships represent a person's relationship to a team. Use this API to list members of any team that you're in
    /// or create memberships to invite someone to a team. Team memberships can also be updated to make someone a moderator
    /// or deleted to remove them from the team.
    /// Just like in the Webex Teams app, you must be a member of the team in order to list its memberships or invite people.
    /// </summary>
    public class TeamMembership : WebexObject
    {
        /// <summary>
        /// A unique identifier for the team membership.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The team ID.
        /// </summary>
        public string teamId { get; set; }

        /// <summary>
        /// The person ID.
        /// </summary>
        public string personId { get; set; }

        /// <summary>
        /// The email address of the person.
        /// </summary>
        public string personEmail { get; set; }

        /// <summary>
        /// The display name of the person.
        /// </summary>
        public string personDisplayName { get; set; }

        /// <summary>
        /// The organization ID of the person.
        /// </summary>
        public string personOrgId { get; set; }

        /// <summary>
        /// Whether or not the participant is a team moderator.
        /// </summary>
        public bool isModerator { get; set; }

        /// <summary>
        /// The date and time when the team membership was created.
        /// </summary>
        public DateTime created { get; set; }
    }
}