using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using HT.GrowControl.Gateways;
using HT.GrowControl.Models;
using HT.GrowControl.WebMVC.Models;

namespace HT.GrowControl.WebMVC.Controllers
{
    public class HistoryController : Controller
    {
        DataCollectorGateway _gateway = new DataCollectorGateway();
        NotifyGateway _notyGateway = new NotifyGateway();

        public JsonResult Data()
        {
            return Json(_gateway.GetCollectedData(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            HistoryViewModel model = new HistoryViewModel();
            model.CollectedData = _gateway.GetCollectedData();
            return View(model);
        }

        public JsonResult Status()
        {
            return Json(_notyGateway.GetDeviceNotification(), JsonRequestBehavior.AllowGet);
        }
    }
}