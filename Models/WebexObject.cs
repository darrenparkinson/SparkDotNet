using Newtonsoft.Json;

namespace SparkDotNet
{
    /// <summary>
    /// This is a common superclass for all Webex API objects.
    /// It will bundle their common behavior
    /// </summary>
    public abstract class WebexObject
    {

        /// <summary>
        /// Returns the JSON representation of the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
