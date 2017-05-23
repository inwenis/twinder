using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twinder.Models;

namespace twinder.Controllers
{
    public class HomeController : Controller
    {
        private static List<Message> ToMessageViewModels(List<Message> messages)
        {
            return messages
                .OrderByDescending(x => x.CreationTimeStamp)
                .Select(x => new Message()
                {
                    Author = x.Author,
                    CreationTimeStamp = x.CreationTimeStamp,
                    Content = x.Content,
                    Id = x.Id,
                    Replies = x.Replies.Take(2).ToList(),
                    TotalRepliesCount = x.Replies.Count,
                    RemainingRepliesCount = x.Replies.Count - 2 < 0 ? 0 : x.Replies.Count - 2
                })
                .ToList();
        }

        public IActionResult Index()
        {
            ViewData["messages"] = ToMessageViewModels(DBContent.Messages);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult AddMessage(Message model)
        {
            model.CreationTimeStamp = DateTimeOffset.UtcNow;
            model.Replies = new List<Reply>();
            model.Id = DBContent.Messages.Max(x => x.Id) + 1;
            model.Author = HttpContext.Session.GetString("username");
            DBContent.Messages.Add(model);
            ViewData["messages"] = ToMessageViewModels(DBContent.Messages);
            return View("Index");
        }

        public IActionResult AddReply(Reply model)
        {
            model.CreationTimeStamp = DateTimeOffset.UtcNow;
            DBContent
                .Messages
                .Single(x => x.Id == model.MessageId)
                .Replies
                .Add(model);
            ViewData["messages"] = ToMessageViewModels(DBContent.Messages);
            return View("Index");
        }

        public IActionResult SetUserName(string username)
        {
            HttpContext.Session.SetString("username", username);
            ViewData["messages"] = ToMessageViewModels(DBContent.Messages);
            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            ViewData["messages"] = ToMessageViewModels(DBContent.Messages);
            return View("Index");
        }
    }
}
