using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public IActionResult Index(Writer p)
		{
			Context c = new Context();
			var datavalue = c.Writers.FirstOrDefault(x=>x.Mail==p.Mail
			&& x.Password == p.Password);
			if (datavalue != null)
			{
				HttpContext.Session.SetString("ssername", p.Mail);
				return RedirectToAction("Index", "Writer");
			}
			else 
			{ 
				return View(); 
			}
		}
	}
}
