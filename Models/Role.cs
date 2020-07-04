using System;
using Newtonsoft.Json;

namespace SparkDotNet {

    /// <summary>
    /// A persona for an authenticated user, corresponding to a set of privileges within an organization.
    /// This roles resource can be accessed only by an admin.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// A unique identifier for the role.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The name of the role.
        /// </summary>
        public string name { get; set; }
        
        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}