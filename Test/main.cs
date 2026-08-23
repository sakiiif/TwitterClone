using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace Test
{
    public class main
    {
        public void run()
        {
            var notifications = new List<Notification>() // upcasting
            {
                new LikeNotification(Guid.NewGuid(), Guid.NewGuid()),
                new CommentNotification(Guid.NewGuid(), Guid.NewGuid()),
                new FriendRequestNotification(Guid.NewGuid(), Guid.NewGuid()),
                new MentionNotification(Guid.NewGuid(), Guid.NewGuid()),
                new SystemNotification(Guid.NewGuid())
            };

            foreach (var notification in notifications)
            {
                string s = notification.GetMessage();
                Console.WriteLine(s);
            }

            var likeable = new List<ILikeable>() // upcasting
            {
                new Tweet("first tweet", Guid.NewGuid() ),
                new Tweet("", Guid.NewGuid() ),
                new Comment(Guid.NewGuid(), Guid.NewGuid(), "1 cmnt"),
                new Comment(Guid.NewGuid(), Guid.NewGuid(), "  ")
            };

            foreach(var x in likeable)
            {
                Console.WriteLine(x.CanBeLiked());
            }


            //notifications[0] = new LikeNotification(Guid.NewGuid(), Guid.NewGuid());
        }

    }
}
