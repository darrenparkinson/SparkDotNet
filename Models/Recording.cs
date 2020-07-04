using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class Recording
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public DateTime CreateTime { get; set; }
        public string DownloadUrl { get; set; }
        public string PlaybackUrl { get; set; }
        public string Password { get; set; }
        public string Format { get; set; }
        public int DurationSeconds { get; set; }
        public int SizeBytes { get; set; }
        public bool ShareToMe { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}