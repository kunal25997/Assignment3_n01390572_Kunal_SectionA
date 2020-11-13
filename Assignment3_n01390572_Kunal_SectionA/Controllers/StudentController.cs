using Assignment3_n01390572_Kunal_SectionA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3_n01390572_Kunal_SectionA.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/List
        public ActionResult List()
        {
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> Student = controller.ListStudents();
            return View(Student);
        }
    }
}