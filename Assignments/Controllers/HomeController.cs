using Assignments.Iservices;
using Assignments.Models;
using Assignments.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignments.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISanPhamServices iSanPhamServices;
        private readonly IHoaDonServices ihoaDonServices;
        private readonly IHoaDonChiTietServices ihoaDonChiTietServices;
        ShoppingDBConText dBConText;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            iSanPhamServices = new SanPhamServices();
            ihoaDonServices = new HoaDonServices();
            ihoaDonChiTietServices = new HoaDonChiTietServices();
            dBConText = new ShoppingDBConText();
        }

        public IActionResult Index()
        {
            var Sanpham = iSanPhamServices.GetAllSanPham().Where(c => c.SoLuongBanDau > 0).ToList();
            return View("Index", Sanpham); // Trả về một View cụ thể đi kèm với Model
        }
        public IActionResult SanPham()
        {
            //var sanpham = new List<SanPham>()
            //{
            //    new SanPham{SanPhamID = Guid.NewGuid(), Ten = "Sản phẩm 1", Gia = 10000, SoLuongBanDau = 44, NhaCungCap = "KhanhPG", GhiChu = "Còn", TrangThai = 1},
            //};
            //return View("SanPham", sanpham);
            List<SanPham> sanPhams = iSanPhamServices.GetAllSanPham();
            return View("SanPham", sanPhams);
        }
        public IActionResult CreateSanPham()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSanPham(SanPham sanPham, IFormFile imageFile) // Thực hiện chức năng thêm
        {
            var x = imageFile.FileName;
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                // Trỏ tới thư muc j wwwroot để lát nữa thực hiện việc copy sang
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                sanPham.Anh = x;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }
                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được copy
                sanPham.Anh = imageFile.FileName;
            }
            if (iSanPhamServices.CreateSanPham(sanPham))
            {
                return RedirectToAction("SanPham");
            }
            return View();
        }
        public IActionResult EditSanPham(SanPham sanPham, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                // Trỏ tới thư muc j wwwroot để lát nữa thực hiện việc copy sang
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }
                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được copy
                sanPham.Anh = imageFile.FileName;
            }
            if (iSanPhamServices.UpdateSanPham(sanPham))
            {
                return RedirectToAction("SanPham");
            }
            return View(sanPham);
        }
        [HttpGet]
        public IActionResult EditSanPham(Guid id)
        {
            SanPham sanPham = iSanPhamServices.GetSanPhamById(id);
            return View(sanPham);
        }

        public IActionResult DeleteSanPham(Guid id)
        {
            if (iSanPhamServices.DeleteSanPham(id))
            {
                return RedirectToAction("SanPham");
            }
            else
            {
                return View("Index");
            }
        }
        //public IActionResult ThemGioHang(Guid id)
        //{
        //    // Từ id lấy được từ sản phẩm lấy ra sản phẩm đó
        //    var sanpham = iSanPhamServices.GetSanPhamById(id);
        //    int soluong = 1;
        //    // Đọc dữ liệu từ Sesson xrm trong Cart có gì chua?
        //    var sanphams = SessionServices.GetObjFromSession(HttpContext.Session, "ThemGioHang");
        //    if(sanpham.TrangThai == 0)
        //    {
        //        return Content("Sản phẩm đã hết");
        //    }
        //    if (sanphams.Count == 0)
        //    {
        //        sanphams.Add(sanpham); // Nếu cart rỗng thì thêm sản phẩm vào luôn
                
        //        // Đưa dữ liệu về lại Sesson
        //        SessionServices.SetObjToJson(HttpContext.Session, "ThemGioHang", sanphams);
        //    }
        //    else
        //    {
        //        if (!SessionServices.CheckProductInCart(id, sanphams)) //Nếu sản phẩm chưa nằm trong giỏ hàng
        //        {
        //            sanphams.Add(sanpham); // Nếu cart chưa chứa sản phẩm vào luôn
        //            // Đưa dữ liệu về lại Sesson
        //            SessionServices.SetObjToJson(HttpContext.Session, "ThemGioHang", sanphams);
        //        }
        //        else
        //        {
        //            soluong++;
        //        }
        //        SessionServices.SetObjToJson(HttpContext.Session, "THemGioHang", sanphams); 
        //    }
        //    // Lấy từ Sesson

        //    return RedirectToAction("GioHang");

        //}
        //public int TongSoLuong(Guid id)
        //{
        //    int iTongSoLuong = 0;
        //    var sanpham = iSanPhamServices.GetSanPhamById(id);
        //    List<SessionServices> lstSession = SessionServices.SetObjToJson(HttpContext.Session, "ThemGioHang", sanphams) as List<SessionServices>;
        //}
        public IActionResult GioHang()
        {
            var sanphams = SessionServices.GetObjFromSession(HttpContext.Session, "ThemGioHang");
            return View(sanphams);
        }
        public IActionResult DetailsSanPham(Guid id)
        {
            SanPham sanPham = iSanPhamServices.GetSanPhamById(id);
            return View(sanPham);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Carts()
        {
            var sanphams = SessionServices.GetObjFromSession(HttpContext.Session, "AddToCarts");
            return View(sanphams);
        }
        public IActionResult AddToCarts(Guid id)
        {
            // Từ id lấy được từ sản phẩm lấy ra sản phẩm đó
            var sanpham = iSanPhamServices.GetSanPhamById(id);
            // Đọc dữ liệu từ Sesson xrm trong Cart có gì chua?
            var Carts = SessionServices.GetObjFromSession(HttpContext.Session, "AddToCarts");
            if(sanpham.TrangThai == 0)
            {
                return Content("Sản phẩm đã hết");
            }
            if (Carts.Count == 0)
            {
                /*sanphams.Add(sanpham);*/ // Nếu cart rỗng thì thêm sản phẩm vào luôn
                var giohangitem = new GioHangChiTiet()
                {
                    UserID = new Guid(),
                    SanPhamID = sanpham.SanPhamID,
                    SoLuong = 1
                };
                Carts.Add(giohangitem);
                // Đưa dữ liệu về lại Sesson
                SessionServices.SetObjToJson(HttpContext.Session, "AddToCarts", Carts);
            }
            else
            {
                if (!SessionServices.CheckProductInCart(id, Carts)) //Nếu sản phẩm chưa nằm trong giỏ hàng
                {
                    var giohangitem = new GioHangChiTiet()
                    {
                        UserID = new Guid(),
                        SanPhamID = sanpham.SanPhamID,
                        SoLuong = 1
                    };
                    Carts.Add(giohangitem);
                    // Đưa dữ liệu về lại Sesson
                    SessionServices.SetObjToJson(HttpContext.Session, "AddToCarts", Carts);
                }
                else
                {
                    var giohangitem = Carts.Where(c=>c.SanPhamID == id).FirstOrDefault();
                    giohangitem.SoLuong++;
                }
                SessionServices.SetObjToJson(HttpContext.Session, "AddToCarts", Carts);
            }
            // Lấy từ Sesson
            return RedirectToAction("Carts");
        }
        public IActionResult CapnhatSoluong(IFormCollection f)
        {
            var countsp = iSanPhamServices.GetSanPhamById(Guid.Parse(f["ID_product"].ToString())).SoLuongBanDau; // Lấy Số lượng sản phẩm còn trong DB
            Guid id = Guid.Parse(f["ID_product"].ToString()); // Lấy id sp bị chỉnh sửa trong giỏ
            
                var products = SessionServices.GetObjFromSession(HttpContext.Session, "AddToCarts"); // Lấy cart trong session
                if (int.Parse(f["Quantity"].ToString()) == 0)
                {
                    var x = products.Where(c => c.SanPhamID == id).FirstOrDefault();
                    products.Remove(x);
                }
                else if (int.Parse(f["Quantity"].ToString()) > countsp)
                {
                    TempData["OverQuantity"] = "Vượt quá số lượng sản phẩm trong kho!";
                    return RedirectToAction("Carts");
                }
                else
                {
                    var x = products.Where(c => c.SanPhamID == id).FirstOrDefault();
                    x.SoLuong = int.Parse(f["Quantity"].ToString());
                }
                SessionServices.SetObjToJson(HttpContext.Session, "AddToCarts", products);
                return RedirectToAction("Carts");
        }
        public IActionResult HoaDon(Guid id, IFormCollection f)
        {
            var sanpham = iSanPhamServices.GetSanPhamById(id);
            var Carts = SessionServices.GetObjFromSession(HttpContext.Session, "AddToCarts");
            HoaDon hd = new HoaDon()
            {
                HoaDonID = new Guid(),
                UserID = Guid.Parse("ad8ee5ab-e806-42d4-b408-10586d3f26c4"),
                NgayTao = DateTime.Now,
                TrangThai = 1
            };
            dBConText.hoaDons.Add(hd);
            dBConText.SaveChanges();
            for (int i = 0; i < Carts.Count(); i++)
            {
                sanpham = iSanPhamServices.GetAllSanPham().Where(c => c.SanPhamID == Carts[i].SanPhamID).FirstOrDefault();
                HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                {
                    HoaDonChiTietID = new Guid(),
                    HoaDonID = hd.HoaDonID,
                    SanPhamID = Carts[i].SanPhamID,
                    SoLuong = Carts[i].SoLuong,
                    Gia = sanpham.Gia,
                };
                if (ihoaDonChiTietServices.CreateHoaDonChiTiet(hoaDonChiTiet))//Kiểm tra lưu thành công
                {
                    // Trừ số lượng sản phẩm trong kho
                    sanpham.SoLuongBanDau -= Carts[i].SoLuong;
                    iSanPhamServices.UpdateSanPham(sanpham);
                }
            }
            Carts.Clear();
            SessionServices.SetObjToJson(HttpContext.Session, "AddToCarts", Carts);
            return RedirectToAction("Carts");
        }
        public IActionResult TinTuc()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}