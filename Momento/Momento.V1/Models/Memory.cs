using System.Collections.Generic;

namespace Momento.V1.Models
{
    public class Memory
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
    }
}