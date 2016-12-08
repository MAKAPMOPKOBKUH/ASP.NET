using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Departments;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            department Model = new department();
            department dep0 = new department();
            department dep1 = new department();
            department dep00 = new department();
            dep00.departments = new List<department>();

            department dep11 = new department();
            dep11.departments = new List<department>();

            dep0.departments = new List<department>();
            dep0.departments.Add(dep00);

            dep1.departments = new List<department>();
            dep1.departments.Add(dep11);

            Model.departments = new List<department>();

            Model.departments.Add(dep0);
            Model.departments.Add(dep1);

            return View(Model);
        }

        
    }
}