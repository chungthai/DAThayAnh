using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteTinTuc.Models;

namespace WebSiteTinTuc.Controllers
{
    public class HomeController : Controller
    {

         TUYENDUNGITEntities1 td = new TUYENDUNGITEntities1();
      

        public ActionResult TrangChu() {
            var tt = td.TinTucTuyenDung.ToList();
            ViewBag.CanhBao = "Bạn phải đăng nhập mới có thể nộp đơn";
            return View(tt);
        }
        [HttpGet]
        public ActionResult TrangNopDon(int IDTT)
        {
            var tttd = td.TinTucTuyenDung.SingleOrDefault(n => n.IDTT == IDTT);
            Session["IDTD"] = IDTT;

            return View(tttd);
        }

        [HttpPost]
        public ActionResult TrangNopDon(TinTucTuyenDung tttd, FormCollection f)
        {
            string sNguoiNop = f.Get("name").ToString();
            string sEmail = f.Get("email").ToString();
            string sSDT = f.Get("sdt").ToString();
            string sGT = f.Get("message").ToString();

            Session["sNguoiNop"] = sNguoiNop;
            Session["sEmail"] = sEmail;
            Session["sSDT"] = sSDT;
            Session["sGT"] = sGT;
            int id = int.Parse(Session["IDTD"].ToString());
            tttd = td.TinTucTuyenDung.SingleOrDefault(n => n.IDTT == id);
            var nd = new NOPDON();

            nd.IDTT = tttd.IDTT;
            nd.CongTy = tttd.TenCT;
            nd.NgayNop = DateTime.Now;
            nd.NguoiNop = Session["sNguoiNop"].ToString();
            nd.Hanchot = tttd.Thoihan;
            nd.Yeucau = tttd.Yeucau;
            nd.Vitri = tttd.Vitri;
            nd.Email = Session["sEmail"].ToString();
            nd.SDT = Session["sSDT"].ToString();
            nd.Gioithieubanthan = sGT;
            td.NOPDON.Add(nd);
            td.SaveChanges();

            return RedirectToAction("TrangChu", "Home");
        }
        public ActionResult DonNguoiDung()
        {
            return View();
        }
        public ActionResult KetQuaTimKiem(FormCollection f)
        {

            return View();
        }
        public ActionResult XoaDonNguoiDung(int IDTT)
        {
            return View();

        }
        [HttpPost, ActionName("XoaDonNguoiDung")]
        public ActionResult XacNhanXoa(int IDTT)
        {

            return View();
        }

    }
}