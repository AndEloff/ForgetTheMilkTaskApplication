using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions; //this is for using the Regex
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
        public static readonly List<Task> Tasks = new List<Task>();

        [HttpPost]
        public ActionResult Add(string task)
        {
            var taskItem = new Task { Description = task };
            //parsing out due date if user submits one via Regular Expression rule that I set up
            var dueDatePattern = new Regex(@"may\s(\d)");
            //Creating a boolean varaible to determine if the task has an due date associated with it
            var hasDueDate = dueDatePattern.IsMatch(task);
            if (hasDueDate)
            {
                var dueDate = dueDatePattern.Match(task);
                var day = Convert.ToInt32(dueDate.Groups[1].Value);
                taskItem.DueDate = new DateTime(DateTime.Today.Year, 5, day); //hardcoded the month to May will update it to parse out the curent month
            }
            //new instance of the task class created below, with the descrpt set to whatever the user entered task is
            Tasks.Add(taskItem);
            return RedirectToAction("Index");
        }
    }

    public class Task
    {
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}