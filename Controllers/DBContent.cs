using System;
using System.Collections.Generic;
using System.Linq;
using twinder.Models;

namespace twinder.Controllers
{
    public class DBContent
    {
        public static IEnumerable<Reply> GetSomeReplies(int repliesCount)
        {
            foreach (var _ in Enumerable.Repeat(0, repliesCount))
            {
                yield return new Reply
                {
                    Author = "Dillinger",
                    Content = "This is not True",
                    CreationTimeStamp = DateTimeOffset.Now,
                };
            }
        }

        public static readonly List<Message> Messages = new List<Message>
        {
            new Message
            {
                Content =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                Author = "John Doe",
                CreationTimeStamp = new DateTimeOffset(2017, 01, 12, 12, 49, 41, TimeSpan.Zero),
                Id = 1,
                Replies = GetSomeReplies(4).ToList()
            },
            new Message
            {
                Content =
                    "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.",
                Author = "Gal Anonim",
                CreationTimeStamp = new DateTimeOffset(2017, 01, 01, 15, 49, 41, TimeSpan.Zero),
                Id = 2,
                Replies = GetSomeReplies(3).ToList()
            },
            new Message
            {
                Content =
                    "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga.",
                Author = "Johny Cash",
                CreationTimeStamp = new DateTimeOffset(2016, 10, 17, 12, 49, 41, TimeSpan.Zero),
                Id = 3,
                Replies = GetSomeReplies(2).ToList()
            },
            new Message
            {
                Content =
                    "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga.",
                Author = "Johny Cash",
                CreationTimeStamp = new DateTimeOffset(2016, 10, 17, 12, 49, 41, TimeSpan.Zero),
                Id = 4,
                Replies = GetSomeReplies(1).ToList()
            },
            new Message
            {
                Content =
                    "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga.",
                Author = "Johny Cash",
                CreationTimeStamp = new DateTimeOffset(2016, 10, 17, 12, 49, 41, TimeSpan.Zero),
                Id = 5,
                Replies = GetSomeReplies(0).ToList()
            }
        };
    }
}
