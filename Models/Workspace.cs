using System;

namespace SparkDotNet
{
    /// <summary>
    /// Workspaces represent where people work, such as conference rooms, meeting spaces, lobbies,
    /// and lunch rooms. Devices may be associated with workspaces.
    /// Viewing the list of workspaces in an organization requires an administrator
    /// auth token with the spark-admin:workspaces_read scope.Adding, updating, or
    /// deleting workspaces in an organization requires an administrator auth token
    /// with the spark-admin:workspaces_write scope.
    /// The Workspaces API can also be used by partner administrators acting as administrators
    /// of a different organization than their own. In those cases an orgId value must be supplied,
    /// as indicated in the reference documentation for the relevant endpoints.
    /// </summary>
    public class Workspace : WebexObject
    {
        /// <summary>
        /// Unique identifier for the Workspace.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A friendly name for the workspace.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// How many people the workspace is suitable for.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The workspace type. One of
        /// notSet: No workspace type set.
        /// focus: High concentration.
        /// huddle: Brainstorm/collaboration.
        /// meetingRoom: Dedicated meeting space.
        /// open: Unstructured agile.
        /// desk: Individual.
        /// other: Unspecified.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// OrgId associate with the workspace
        /// </summary>
        public string OrgId { get; set; }

        /// <summary>
        /// SipUrl to call all the devices associated with the workspace.
        /// </summary>
        public string SipAddress { get; set; }

        /// <summary>
        /// The date and time that the workspace was registered, in ISO8601 format.
        /// </summary>
        public DateTime Created { get; set; }
    }
}