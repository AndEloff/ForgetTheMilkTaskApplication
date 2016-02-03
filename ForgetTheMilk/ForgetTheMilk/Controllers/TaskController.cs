using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForgetTheMilk.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult Index()
        {
            return View(Tasks);
        }

        //setting up a field called tasks that stores a list of strings via the textbox
        public static readonly List<string> Tasks = new List<string>();

        [HttpPost]
        public ActionResult Add(string task)
        {
            Tasks.Add(task);
            return RedirectToAction("Index");
        }
    }
}