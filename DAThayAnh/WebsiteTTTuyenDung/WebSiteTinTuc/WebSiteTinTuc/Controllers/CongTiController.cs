using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteTinTuc.Models;

namespace WebSiteTinTuc.Controllers
{
    public class CongTiController : Controller
    {
        // GET: CongTi
        TUYENDUNGITEntities1 td = new TUYENDUNGITEntities1();
        // GET: CongTy
        public ActionResult TrangChuCongTy()
        {
            return View();
        }
        [HttpGet]

        public ActionResult Tintuc()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Tintuc(TinTuc tt, FormCollection f)
        {
            foreach (string fileUpload in Request.Files)
            {
                HttpPostedFileBase fileupload = Request.Files["fileUpload"];
                if (fileUpload == null)
                {
                    ViewBag.ThongBao = "Chọn hình ảnh";
                    return View();
                }
                // Thêm vào csdl 
                if (ModelState.IsValid)
                {
                    var FileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/"), FileName);
                    //Kiem tra Hinh Anh da ton tai chưa
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình Ảnh Đã Tồn Tại";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }

                }
            }
            tt.TenCT = f["tenct"];
            tt.Khuvuc = f["khuvuc"];
            tt.Mucluong = f["mucluong"];
            tt.Thoihan = DateTime.Parse(f["thoihan"]);
            tt.Vitri = f["vitri"];
            tt.NgayGui = DateTime.Now;
            tt.Hinhanh = f["fileUpload"];
            tt.Yeucau = f["yeucau"];
            td.TinTuc.Add(tt);
            td.SaveChanges();

            return RedirectToAction("TrangChuCongTy", "CongTy");
        }
        public ActionResult DanhSachNguoiNop()
        {
            return View();
        }


    }
}