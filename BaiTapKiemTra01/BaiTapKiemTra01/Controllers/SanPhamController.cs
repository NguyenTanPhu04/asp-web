using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BaiTap02()
        {
            var sanpham = new SanPhamViewModel()
            {
                TenSanPham = "Điện thoại iPhone 14",
                GiaBan = 19990000, 
                AnhMoTa = "/images/MQ9V3.jpg" 
            };

            return View(sanpham);
        }
    }
}
