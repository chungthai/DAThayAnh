using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebSiteTinTuc.Models;

namespace WebSiteTinTuc.Controllers
{
  
    public class AccountController : Controller
    {
        TUYENDUNGITEntities1 td = new TUYENDUNGITEntities1();
        //Sign up
        public ActionResult DangKy()
        {
            return View();
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DangKy(KHACHHANG kh, FormCollection f)
        {


            kh.Email = f["email"];
            kh.Password = f["matkhau"];
            kh.Repeat_Password = f["nhaplai"];
            kh.HoTen = f["hoten"];
            kh.DiaChi = f["diachi"];
            kh.SDT = f["sdt"];
            td.KHACHHANG.Add(kh);
            td.SaveChanges();
            return RedirectToAction("TrangChu", "Home");
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f, string id)
        {
            string sTaiKhoan = f.Get("username").ToString();
            string sMatKhau = f.Get("password").ToString();
            id = sTaiKhoan;
            var nd = td.KHACHHANG.SingleOrDefault(x => x.Email == id);
            var ad = td.ADMIN.SingleOrDefault(x => x.Tendangnhap == id);
            var ct = td.CONGTY.SingleOrDefault(x => x.Tendangnhap == id);

            if (nd != null)
            {
                if (nd.Email == id && nd.Password == sMatKhau && id == sTaiKhoan)
                {

                    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công";
                    Session["TaiKhoan"] = sTaiKhoan;
                    Session["Tenkhachhang"] = nd.HoTen;
                    Session["Emailnd"] = nd.Email;
                    Session["SDT"] = nd.SDT;

                    return RedirectToAction("TrangChu", "Home");
                }

                if (nd.Email != id || nd.Password != sMatKhau || id != sTaiKhoan)
                {
                    ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";

                }
            }

            if (nd == null)
            {
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";

            }
            if (ct != null)
            {
                if (ct.Tendangnhap == id && ct.Matkhau == sMatKhau && id == sTaiKhoan)
                {

                    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công";
                    Session["Tenct"] = ct.Tencongty;

                    return RedirectToAction("TrangChuCongTy", "CongTy");
                }

                if (ct.Tendangnhap != id || ct.Matkhau != sMatKhau || id != sTaiKhoan)
                {
                    ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";

                }
            }
            if (ct == null)
            {
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";

            }
            if (ad != null)
            {
                if (ad.Tendangnhap == id && ad.Matkhau == sMatKhau && id == sTaiKhoan)
                {
                    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công";


                    return Redirect("~/ADMIN/QuanLyAD/TrangChuAdmin");
                }

                if (ad.Tendangnhap != id || ad.Matkhau != sMatKhau || id != sTaiKhoan)
                {
                    ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";

                }
            }
            if (ad == null)
            {
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";

            }

            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("TrangChu", "Home");
        }
       
    }
}