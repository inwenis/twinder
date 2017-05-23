using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace twinder.Controllers
{
    public class Messages : Controller
    {
        public IActionResult ViewThread(int id)
        {
            var message = DBContent.Messages.SingleOrDefault(x => x.Id == id);
            if(message != null)
            {
                return View(message);
            }
            else
            {
                return View(); //TODO no such message
            }
        }
    }
}
