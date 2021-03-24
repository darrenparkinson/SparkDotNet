using System.Collections.Generic;

namespace SparkDotNet
{
    public class SparkErrorContent
    {
        public string Message { get; set; }
        public List<SparkErrorMessage> Errors { get; set; }
        public string TrackingId { get; set; }
    }
}
