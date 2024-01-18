using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Pkcs;
using EntityLayer.Concrete;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		readonly CommentManager cm = new(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult PartialAddComment(Comment p)
		{
			p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.Status = true;
			p.BlogID = 2;
			cm.CommentAdd(p);
			return PartialView();
		}
		public PartialViewResult CommentListByBlog(int id)
		{
			_ = cm.GetList(id);
			return PartialView();
		}
	}
}
