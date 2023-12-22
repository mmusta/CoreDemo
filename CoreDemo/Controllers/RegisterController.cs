using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{

		WriterManager wm = new WriterManager(new EfWriterRepository());

		[HttpGet]
		public IActionResult Index()
		{
			
			return View();
			
		}
		[HttpPost]
		public IActionResult Index(Writer p)
		{
			p.Status = true;
			p.About = "Deneme Test";
			wm.WriteAdd(p);
			return RedirectToAction("Index","Blog");
		}
	}
}
