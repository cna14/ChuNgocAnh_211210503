using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChuNgocAnh_211210503.Models;

namespace ChuNgocAnh_211210503.Models
{
	public partial class HangHoa
	{
		public int MaHang { get; set; }
		public int MaLoai { get; set; }

		[Required(ErrorMessage = "Tên hàng không được để trống.")]
		public string TenHang { get; set; }

		[Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000.")]
		public decimal? Gia { get; set; }

		[RegularExpression(@"\.(jpg|png|gif|tiff)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg, .png, .gif, .tiff")]
		public string Anh { get; set; }

		public virtual LoaiHang MaLoaiNavigation { get; set; }
	}
}
