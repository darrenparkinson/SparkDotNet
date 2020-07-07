using System;

namespace SparkDotNet {
    public class EventData : WebexObject
    {
        public string Id { get; set; }
        public string RoomId { get; set; }
        public string RoomType { get; set; }
        public string Text { get; set; }
        public string PersonId { get; set; }
        public string PersonEmail { get; set; }
        public DateTime Created { get; set; }
    }
}