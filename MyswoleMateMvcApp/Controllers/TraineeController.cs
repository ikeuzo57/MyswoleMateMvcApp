using MyswoleMateMvcApp.Models;
using MyswoleMateMvcApp.MySwoleMateDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyswoleMateMvcApp.Controllers
{
    public class TraineeController : Controller
    {

        TraineeDAL trainee = new TraineeDAL();
        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult CreateNewTrainee()
        {
            return View();
        }

        public ActionResult CreateNewTraineeInfo(Trainee traineeObj)
        {
            trainee.AddTraineeInfo(traineeObj);
           return RedirectToAction("TraineeList");

        }
        public ActionResult TraineeList()
        {
            
            var trainees = trainee.GetAllTrainees();

            foreach (var item in trainees)
            {
                //for each item take the Height and CellNbr values,
                //use the HeightDisplay and PhoneDisplay methods
                //and store the returned values from the methods
                //into the HeightDisplay and PhoneDisplay properties of the item.
                //The DisplayHeight is done for you.
                 item.DisplayHeight = HeightDisplay(item.Height);
                 item.DisplayCellNbr = PhoneDisplay(item.CellNbr);

            }
            return View(trainees);
        }


        /// <summary>
        /// Return phone number in split phone number display
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private string PhoneDisplay(string phoneNumber)
        {
            return string.Format("{0}-{1}-{2}", phoneNumber.Substring(0, 3), phoneNumber.Substring(3, 3), phoneNumber.Substring(6, (phoneNumber.Length - 6)));
        }

        //You can create the private methods for HeightDisplay and PhoneDisplay below.
        //The HeightDisplay method signature has been given to you.
        private string HeightDisplay(int height)
        {
            //store the displayed height
            string heightDisplay = "";
            int ft = 0;
            int inch = 0;

            try
            {
                //perform the calculations to separate feet and height (hint: this is a great 
                //time to use the % (modulus) operator
                ft = height / 12;
                inch = height % 12;

                if (inch > 0)
                {
                    heightDisplay = string.Format("{0}ft.{1}in.", ft, inch);
                }
                else
                {
                    heightDisplay = string.Format("{0}ft.", ft);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return heightDisplay;
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