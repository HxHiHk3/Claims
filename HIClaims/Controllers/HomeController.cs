using HIClaims.BL;
using HIClaims.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HIClaims.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ModalPopup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClaims(Claim claim)
        {
            if(ModelState.IsValid)
            {
                CustomerClaim cusomerclaim = new CustomerClaim();
                if (claim.ClaimedDate > DateTime.Now.Date)
                {
                    ViewData["Error"] = "Claim cannot be in future date";
                    return View("ModalPopup");
                } 
                cusomerclaim.SaveClaims(claim);
                return RedirectToAction("List", "Home");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You have a bunch of errors:");

                foreach (ModelState modelState in ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        sb.Append(error + "\n");
                    }
                }
                ViewData["Error"] = sb.ToString();
                return RedirectToAction("List", "Home");
            }
        }

        public ActionResult List()
        {
            CustomerClaim claim = new CustomerClaim();
            var result = claim.GetClaims();
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}