using MyswoleMateMvcApp.Models;
using MyswoleMateMvcApp.MySwoleMateDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyswoleMateMvcApp.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult TraineeList()
        {
            var traineeList = new TraineeDAL();
            var trainees = traineeList.GetAllTrainees();

            foreach (var item in trainees)
            {
                //for each item take the Height and CellNbr values,
                //use the HeightDisplay and PhoneDisplay methods
                //and store the returned values from the methods
                //into the HeightDisplay and PhoneDisplay properties of the item.
                //The DisplayHeight is done for you.
                // item.DisplayHeight = HeightDisplay(item.Height);
                //item.DisplayCellNbr = PhoneDisplay(item.CellNbr);

            }
            return View(trainees);
        }
        public ActionResult WorkOutPlans()
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