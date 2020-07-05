using System.Collections.Generic;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class PaginationResult<T>
    {
        public List<T> Items { get; set; }
        public Links Links {get; set; }
        
        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}