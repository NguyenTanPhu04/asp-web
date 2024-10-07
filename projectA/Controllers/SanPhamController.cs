using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projectA.Data;
using projectA.Models;

namespace projectA.Controllers
{
    [Area("Administrator")]
    [Authorize (Roles = "Adminnistrator")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            SanPham sanpham = new SanPham();
            IEnumerable<SelectListItem> dstheloai = _db.TheLoai.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            ViewBag.DSTheLoai = dstheloai;
            if (id == 0)
            {
                return View(sanpham);
            }
            else
            {
                sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == id);
                return View(sanpham);
            }
        }
        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                if (sanpham.Id == 0)
                {
                    _db.SanPham.Add(sanpham);
                }
                else
                {
                    _db.SanPham.Update(sanpham);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var sanpham = _db.SanPham.First(sp => sp.Id == id);
                if (sanpham == null)
                {
                    return Json(new { success = false, message = "sản phẩm không tìm thấy: " });
                }
                _db.SanPham.Remove(sanpham);
                _db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new {success = false, message = "xóa thất bại: " + ex.Message});
            }
        }

        [HttpGet]
        public JsonResult Delete2(int id)
        {
            try
            {
                var sanpham = _db.SanPham.First(sp => sp.Id == id);
                if (sanpham == null)
                {
                    return Json(new { success = false, message = "sản phẩm không tìm thấy: " });
                }
                _db.SanPham.Remove(sanpham);
                _db.SaveChanges();
                return Json(new { success = true, message = "Xóa sản phẩm thành công" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "xóa thất bại: " + ex.Message });
            }
        }
    }
}
