using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twinder.Models;

namespace twinder.Controllers.Api
{
    public class MessageController : Controller
    {
        [HttpGet("api/messages")]
        public JsonResult Get()
        {
            return Json(DBContent.Messages);
        }

        [HttpPost("api/messages")]
        public IActionResult Add([FromBody]Message model)
        {
            model.Replies = new List<Reply>();
            model.CreationTimeStamp = DateTimeOffset.Now;
            model.Author = HttpContext.Session.GetString("username");
            DBContent.Messages.Add(model);
            return Created($"api/messages/{model.Content}", model);
        }

        [HttpGet("api/isLoggedIn")]
        public IActionResult IsLoggedIn()
        {
            if (HttpContext.Session.GetString("username") != null) // empty string?
            {
                return Content(HttpContext.Session.GetString("username"));
            }
            else
            {
                return Content("");
            }
        }

        [HttpPost("api/messages/{id}/addReply")]
        public IActionResult AddReply(int id, [FromBody]Reply model)
        {
            if (HttpContext.Session.GetString("username") != null) // empty string?
            {
                model.Author = HttpContext.Session.GetString("username");
                model.CreationTimeStamp = DateTimeOffset.Now;
                var message = DBContent.Messages.SingleOrDefault(x => x.Id == id);
                if (message != null)
                {
                    message.Replies.Add(model);
                    return Created($"api/messages/{id}/addReply", model);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
