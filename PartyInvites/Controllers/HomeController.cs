using System;
using System.Web.Helpers;
using System.Web.Mvc;

using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View();
        }

        /// <summary>
        /// Handles RsvpForm's postback event.
        /// </summary>
        /// <param name="guestResponse"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RsvpForm(GuestResponse guestResponse)
        {
            // Check model's validity
            if (ModelState.IsValid)
            {
                try
                {
                    // Sending invitation mail
                    sendingRsvpNotificationMail(guestResponse);
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, "Sorry - we couldn't send the email to confirm your RSVP.");
                    return View();
                }
                return View("Thanks", guestResponse);
            }

            // Model is invalid
            return View();
        }

        private void sendingRsvpNotificationMail(GuestResponse model)
        {
            WebMail.SmtpServer = "localhost";
            WebMail.SmtpPort = 25;
            WebMail.From = "do-not-reply@party-invites.com";
            WebMail.Send(@"saintc0d3r@gmail.com", "RSVP notification", model.Name + " is " + (model.WillAttend.Value ? "" : "not ") + "attending");
        }
    }
}
