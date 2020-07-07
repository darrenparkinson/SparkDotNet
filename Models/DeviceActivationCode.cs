using System;

namespace SparkDotNet
{
    public class DeviceActivationCode : WebexObject
    {
        /// <summary>
        /// A unique identifier for the activation code.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The activation code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The placeId of the place where the device will be activated.
        /// </summary>
        public string PlaceId { get; set; }

        /// <summary>
        /// The date and time the activation code was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The date and time the activation code expires.
        /// </summary>
        public DateTime Expires { get; set; }
    }


}