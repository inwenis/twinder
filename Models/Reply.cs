using System;

namespace twinder.Models
{
    public class Reply
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTimeOffset CreationTimeStamp { get; set; }
        public int Id { get; set; }
        public int MessageId { get; set; }
    }
}
