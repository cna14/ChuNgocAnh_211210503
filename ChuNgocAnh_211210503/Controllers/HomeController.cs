using ChuNgocAnh_211210503.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChuNgocAnh_211210503.Controllers
{
	public class HomeController : Controller
	{
		private QLHangHoaContext db;
		public HomeController(QLHangHoaContext context)
		{
			db = context;
		}

		public IActionResult Index()
		{
			IEnumerable<HangHoa> list_hh = db.HangHoas.Where(hh => hh.Gia > 100).ToList();
			return View("ChuNgocAnh_mainContent", list_hh);
		}


		public IActionResult MatHangByLoaiHangID(int mid)
		{
			var lh = db.HangHoas.Where(l => l.MaLoai == mid).ToList();
			return PartialView("TableHangHoa", lh);
		}

		public IActionResult AddToCart()
		{
			ViewBag.CategoryId = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai");
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddToCart(HangHoa hh)
		{
			if (!ModelState.IsValid)
			{
				db.HangHoas.Add(hh);
				db.SaveChanges();

				return RedirectToAction("Index");
			}

			return View("AddToCart");
		}

	}
}
