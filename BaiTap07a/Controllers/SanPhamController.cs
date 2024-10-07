using BaiTap07a.Data;
using BaiTap07a.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiTap07a.Controllers
{
    [Area("Admin")]

    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPhams.Include("TheLoai").ToList();

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
                sanpham = _db.SanPhams.Include("TheLoai").FirstOrDefault(sp => sp.Id == id);
                return View(sanpham);
            }
        }
        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if(ModelState.IsValid)
            {
                if(sanpham.Id == 0)
                {
                    _db.SanPhams.Add(sanpham);
                }
                else
                {
                    _db.SanPhams.Update(sanpham);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sanpham = _db.SanPhams.FirstOrDefault(sp => sp.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.SanPhams.Remove(sanpham);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
