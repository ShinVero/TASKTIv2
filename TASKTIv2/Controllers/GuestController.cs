using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TASKTIv2.DAL;
using TASKTIv2.Models;

namespace TASKTIv2.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        public ActionResult Index()
        {
            using (GuestDAL service = new GuestDAL())
            {
                var model = service.GetData().ToList();
                if (TempData["Pesan"] != null)
                {
                    ViewBag.Pesan = TempData["Pesan"].ToString();
                }
                return View(model);
            }
        }

        public ActionResult IndexGuest()
        {
            string Id = Session["IdGuest"].ToString();
            using (GuestDAL service = new GuestDAL())
            {
                return View(service.GetDataByUsername(Id).ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DataGuest guest)
        {
            using (GuestDAL service = new GuestDAL())
            {
                try
                {
                    service.Add(guest);
                    TempData["Pesan"] = Helpers.KotakPesan.GetPesan("Sukses !",
                        "success", "Data Guest " + guest.NamaGuest + " berhasil ditambah");
                }
                catch (Exception ex)
                {
                    TempData["Pesan"] = Helpers.KotakPesan.GetPesan("Error !",
                                          "danger", ex.Message);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (GuestDAL services = new GuestDAL())
            {
                var result = services.GetDataById(id);
                return View(result);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DataGuest guest)
        {
            using (GuestDAL services = new GuestDAL())
            {
                try
                {
                    services.Edit(guest);
                    TempData["Pesan"] = Helpers.KotakPesan.GetPesan("Sukses !",
                        "success", "Data Author " + guest.NamaGuest + " berhasil diedit");
                }
                catch (Exception ex)
                {
                    TempData["Pesan"] = Helpers.KotakPesan.GetPesan("Error !",
                                         "danger", ex.Message);
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            using (GuestDAL service = new GuestDAL())
            {
                try
                {
                    service.Delete(id);
                    TempData["Pesan"] = Helpers.KotakPesan.GetPesan("Sukses !",
                        "success", "Data Author berhasil didelete !");
                }
                catch (Exception ex)
                {
                    TempData["Pesan"] = Helpers.KotakPesan.GetPesan("Error !",
                                         "danger", ex.Message);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Search(string txtSearch)
        {
            using (GuestDAL svCat = new GuestDAL())
            {
                var results = svCat.Search(txtSearch).ToList();
                return View("Index", results);
            }
        }
    }
}
