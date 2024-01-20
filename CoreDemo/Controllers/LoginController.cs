using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		public HttpContext GetHttpContext()
		{
			return HttpContext;
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(Writer p)
		{
			Context c = new Context();
			var datavalue = c.Writers.FirstOrDefault(x => x.Mail== p.Mail && x.Password == p.Password);
			if(datavalue != null)
			{
				var claims=new List<Claim>
				{
					new Claim(ClaimTypes.Name,p.Mail) 
				};
				var useridentity=new ClaimsIdentity(claims,"a");
				ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index","Writer");
			}
			else
			{
				return View();
			}
		}
	}
}
//Context c = new Context();
//var datavalue = c.Writers.FirstOrDefault(x => x.Mail == p.Mail
//&& x.Password == p.Password);
//if (datavalue != null)
//{
//	HttpContext.Session.SetString("ssername", p.Mail);
//	return RedirectToAction("Index", "Writer");
//}
//else
//{
//	return View();
//}