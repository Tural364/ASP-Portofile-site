using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using SiteVisit.Models;

namespace PortfolioMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Skills()
    {
        return View();
    }

    public IActionResult Projects()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contact(ContactViewModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Name) ||
            string.IsNullOrWhiteSpace(model.Email) ||
            string.IsNullOrWhiteSpace(model.Message))
        {
            ViewBag.Error = "Please fill in all fields";
            return View(model);
        }

        SendEmail(
            "alibeylitural212@gmail.com",
            "New message from the site",
            $"Name: {model.Name}\nEmail: {model.Email}\n\n{model.Message}"
        );

        SendEmail(
            model.Email,
            "Thanks for the messaage",
            "I'll answer you later"
        );

        ViewBag.Success = true;
        return View();
    }

    private void SendEmail(string to, string subject, string body)
    {
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.Credentials = new NetworkCredential("alibeylitural212@gmail.com", "");
        smtp.EnableSsl = true;

        MailMessage message = new MailMessage("alibeylitural212@gmail.com", to, subject, body);

        smtp.Send(message);
    }
}
