using System;

namespace SparkDotNet
{
    /// <summary>
    /// Each org has its own Space Classification object containing exactly 5 space classifications.
    /// </summary>
    public class SpaceClassification : WebexObject
    {
        /// <summary>
        /// Unique identifier for the org's Space Classification
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Represents the rank of the classification.
        /// A number from 0 to 4, in which 0 usually refers to "public",
        /// and is the default whenever a rank cannot be determined.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Represents the classification title to be displayed in classified spaces for org users.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Space Classification enabled state
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// classification's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The date and time of the Space Classification changes
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// A unique identifier for the organization
        /// </summary>
        public string OrgId { get; set; }
    }
}