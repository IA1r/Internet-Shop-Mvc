using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Internet_Shop.Controllers
{
    public class CategoriesController : Controller
    {

        /// <summary>
        /// Games category page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Games()
        {
            return View();
        }

        /// <summary>
        /// Tables category page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Tables()
        {
            return View();
        }

        /// <summary>
        /// Shirts category page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Shirts()
        {
            return View();
        }

        /// <summary>
        /// Sports the food category page.
        /// </summary>
        /// <returns></returns>
        public ActionResult SportFood()
        {
            return View();
        }

        /// <summary>
        /// Exercises the machine category page.
        /// </summary>
        /// <returns></returns>
        public ActionResult ExerciseMachine()
        {
            return View();
        }


    }
}
