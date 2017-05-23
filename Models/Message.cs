using System;
using System.Collections.Generic;

namespace twinder.Models
{
    public class Message
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTimeOffset CreationTimeStamp { get; set; }
        public int Id { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public int TotalRepliesCount { get; set; }
        public bool MoreThanTwoReplies { get; set; }
        public int RemainingRepliesCount { get; set; }
    }
}
