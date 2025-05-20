using System;

namespace RestApi.Models
{
    public class Product
    {
        public string? id { get; set; }
        public string name { get; set; }

        public Dictionary<string, object> data { get; set; }
    }
}
