using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Pkcs;

namespace CoreDemo.Controllers
{
	readonly CommentManager cm = new CommentManager(new EfCommentRepository());
	public class CommentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView();
		}
	}
}
