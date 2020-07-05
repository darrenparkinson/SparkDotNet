using System;

namespace SparkDotNet
{
    /// <summary>
    /// Devices represent cloud-registered Webex RoomOS devices, as well as actively-connected Webex soft clients on mobile or desktop.
    /// Devices may be associated with Places.
    /// Searching and viewing details for your devices requires an auth token with the spark:devices_read scope.Updating
    /// or deleting your devices requires an auth token with the spark:devices_write scope. Viewing the list of all devices
    /// in an organization requires an administrator auth token with the spark-admin:devices_read scope. Adding, updating,
    /// or deleting all devices in an organization requires an administrator auth token with the spark-admin:devices_write scope.
    /// </summary>
    public class Device : WebexObject
    {
        /// <summary>
        /// A unique identifier for the device.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A friendly name for the device.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The place associated with the device.
        /// </summary>
        public string PlaceId { get; set; }

        /// <summary>
        /// The person associated with the device.
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// The organization associated with the device.
        /// </summary>
        public string OrgId { get; set; }

        /// <summary>
        /// The capabilities of the device.
        /// </summary>
        public string[] Capabilities { get; set; }

        /// <summary>
        /// The permissions the user has for this device. For example, xapi means this user is entitled to using the xapi against this device.
        /// </summary>
        public string[] Permissions { get; set; }

        /// <summary>
        /// The connection status of the device.
        /// </summary>
        public string ConnectionStatus { get; set; }

        /// <summary>
        /// The product name.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Tags assigned to the device.
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// The current IP address of the device.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// The current network connectivty for the device.
        /// </summary>
        public string ActiveInterface { get; set; }

        /// <summary>
        /// The unique address for the network adapter.
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// The primary SIP address to dial this device.
        /// </summary>
        public string PrimarySipUrl { get; set; }

        /// <summary>
        /// All SIP addresses to dial this device.
        /// </summary>
        public string[] SipUrls { get; set; }

        /// <summary>
        /// Serial number for the device.
        /// </summary>
        public string Serial { get; set; }

        /// <summary>
        /// The operating system name data and version tag.
        /// </summary>
        public string Software { get; set; }

        /// <summary>
        /// The upgrade channel the device is assigned to.
        /// </summary>
        public string UpgradeChannel { get; set; }

        /// <summary>
        /// The date and time that the device was registered, in ISO8601 format.
        /// </summary>
        public DateTime Created { get; set; }
    }
}