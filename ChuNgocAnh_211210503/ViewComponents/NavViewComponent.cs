using Microsoft.AspNetCore.Mvc;
using ChuNgocAnh_211210503.Models;

namespace ChuNgocAnh_211210503.ViewComponents
{
	public class NavViewComponent : ViewComponent
	{
		QLHangHoaContext db;
		List<LoaiHang> majors;
		public NavViewComponent(QLHangHoaContext _context)
		{
			db = _context;
			majors = db.LoaiHangs.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderNav", majors);
		}
	}
}
