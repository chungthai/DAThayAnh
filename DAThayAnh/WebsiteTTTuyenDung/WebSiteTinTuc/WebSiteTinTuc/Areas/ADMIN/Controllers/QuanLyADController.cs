using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteTinTuc.Models;

namespace WebSiteTinTuc.Areas.ADMIN.Controllers
{
    public class QuanLyADController : Controller
    {
        TUYENDUNGITEntities1 td = new TUYENDUNGITEntities1();
        // GET: ADMIN/QuanLyAD
        public ActionResult TrangChuAdmin()
        {
            return View();
        }
        public ActionResult Xemtin(FormCollection f)
        {
            string uutien = f.Get("uutien");
            Session["uutien"] = uutien;
            var tt = td.TinTuc.ToList();
            return View(tt);
        }
        [HttpGet]
 
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int IDTT)
        {
            TinTuc tt = td.TinTuc.SingleOrDefault(n => n.IDTT == IDTT);

            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(tt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TinTuc tt)
        {

            if (ModelState.IsValid)
            {
                //Thực hiện cập nhạp trong Model
                td.Entry(tt).State = System.Data.Entity.EntityState.Modified;
                td.SaveChanges();
            }

            return Redirect("~/ADMIN/QuanLyAD/Xemtin");
        }
        public ActionResult DangTin(int IDTT)
        {
            TinTuc tt = td.TinTuc.SingleOrDefault(n => n.IDTT == IDTT);
            TinTucTuyenDung tttd = new TinTucTuyenDung();
            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            tttd.TenCT = tt.TenCT;
            tttd.Vitri = tt.Vitri;
            tttd.Mucluong = tt.Mucluong;
            tttd.Khuvuc = tt.Khuvuc;
            tttd.Thoihan = tt.Thoihan;
            tttd.Yeucau = tt.Yeucau;
            tttd.Hinhanh = tt.Hinhanh;
            td.TinTucTuyenDung.Add(tttd);
            td.TinTuc.Remove(tt);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/TrangChuAdmin");

        }
        [HttpGet]
        public ActionResult Delete(int IDTT)
        {
            //Lấy Đối tượng sách theo mã
            TinTuc tt = td.TinTuc.SingleOrDefault(n => n.IDTT == IDTT);




            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tt);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult XacNhanXoa(int IDTT)
        {
            TinTuc tt = td.TinTuc.SingleOrDefault(n => n.IDTT == IDTT);
            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            td.TinTuc.Remove(tt);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/Xemtin");

        }

        public ActionResult DangTin(int IDTT, FormCollection f)
        {


            return View();
        }
        [HttpGet]
        public ActionResult Themtintuc()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Themtintuc(TinTuc tt)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Themtindadang()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Themtindadang(TinTucTuyenDung tt)
        {
            return View();
        }
        public ActionResult QuanLyDonNop()
        {
            return View();
        }
        public ActionResult Tindadang()
        {
            var tt = td.TinTucTuyenDung.ToList();
            return View(tt);
        }
        public ActionResult EditTinDaDang(int IDTT)
        {
           

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTinDaDang(TinTucTuyenDung tt)
        {


            return View();
        }
        [HttpGet]
        public ActionResult DeleteTinDaDang(int IDTT)
        {
            //Lấy Đối tượng sách theo mã




            return View();
        }
        [HttpPost, ActionName("DeleteTinDaDang")]
        public ActionResult XacNhanXoaTinDaDang(int IDTT)
        {
            return View();

        }
        public ActionResult QuanLyTaiKhoan()
        {
            return View();
        }
        public ActionResult QuanLyTaiKhoanNguoiDung()
        {
           
            return View();
        }
        public ActionResult QuanLyTaiKhoanCongTy()
        {
            var ttct = td.CONGTY.ToList();
            return View(ttct);
     
        }
        [HttpGet]
        public ActionResult EditTaiKhoanCongTy(int IDCT)
        {
           

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTaiKhoanCongTy(CONGTY ct)
        {

            return View();
        }
        [HttpGet]
        public ActionResult DeleteTaiKhoanCongTy(int IDCT)
        {
            //Lấy Đối tượng sách theo mã
            return View();
        }
        [HttpPost, ActionName("DeleteTaiKhoanCongTy")]
        public ActionResult XacNhanXoaTaiKhoanCongTy(int IDCT)
        {
           
            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanCongTy");

        }
        [HttpGet]
        public ActionResult ThemTaiKhoanCongTy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTaiKhoanCongTy(CONGTY ct)
        {   td.CONGTY.Add(ct);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanCongTy");
        }

        [HttpGet]
        public ActionResult EditTaiKhoanNguoiDung(int IDND)
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTaiKhoanNguoiDung(KHACHHANG kh)
        {

            return View();
        }
        [HttpGet]
        public ActionResult DeleteTaiKhoanNguoiDung(int IDND)
        {
            //Lấy Đối tượng sách theo mã
       
            return View();
        }
        [HttpPost, ActionName("DeleteTaiKhoanNguoiDung")]
        public ActionResult XacNhanXoaTaiKhoanNguoiDung(int IDND)
        {
           
            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanNguoiDung");

        }
        [HttpGet]
        public ActionResult ThemTaiKhoanNguoiDung()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTaiKhoanNguoiDung(KHACHHANG kh)
        {
           
            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanNguoiDung");
        }
        //public ActionResult DanhSachNopDon()
        //{
           
        //    return View(ds);
        //}

        //[HttpGet]
        //public ActionResult EditDonNguoiDung(int IDND)
        //{
         

        //    return View(don);
        //}
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EditDonNguoiDung(NOPDON don)
        //{

            
        //}
    }
}
