using System.Collections.Generic;

namespace Models.DTOs
{
    public class Lookup
    {
        public object Id { get; set; }
        public string Text { get; set; }
        public Lookup[] Children { get; set; }
        public LookupAdditional Additional { get; set; }
    }

    public class LookupAdditional
    {
        public string Description { get; set; }
        public int? ImageId { get; set; }
        public string ImageUrl { get; set; }
        public byte[] Image { get; set; }
        public List<Lookup> Ancestors { get; set; }
        public object Data { get; set; }
    }
}
