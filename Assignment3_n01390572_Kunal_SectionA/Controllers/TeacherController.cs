using Assignment3_n01390572_Kunal_SectionA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3_n01390572_Kunal_SectionA.Controllers
{
    public class TeacherController : Controller
    {

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/List
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teacher = controller.ListTeachers();
            return View(Teacher);
        }

        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }
    }
}