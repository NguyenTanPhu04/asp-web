using Microsoft.AspNetCore.Mvc;

namespace BaiTapVN0609.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Nguyễn Tấn Phú";
            ViewBag.MSSV = "1822040870";
            ViewData["Nam"] = "Năm 2024";
            return View();
        }
        public ActionResult MayTinh(int a, int b, string pheptinh)
        {
            double ketQua = 0;
            switch (pheptinh)
            {
                case "cong":
                    ketQua = a + b;
                    break;
                case "tru":
                    ketQua = a - b;
                    break;
                case "nhan":
                    ketQua = a * b;
                    break;
                case "chia":
                    if (b != 0)
                        ketQua = (double)a / b;
                    else
                        ViewBag.ThongBao = "Không thể chia cho 0!";
                    break;
                default:
                    ViewBag.ThongBao = "Phép tính không hợp lệ!";
                    break;
            }

            ViewBag.KetQua = ketQua;
            return View();
        }



        public ActionResult Profile()
        {
            return View();
        }
    }
}
