using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using D3Graphs.Models;

namespace D3Graphs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployees(int? count)
        {
            if (count == null) count = 40000;
            if (count > 50000) count = 50000;

            IList<EmployeeModel> _comments = new List<EmployeeModel>();
            Random r = new Random();
            int rInt = r.Next(0, 100); //for ints
            for (int i = 1; i <= count; i++)
            {
                _comments.Add(new EmployeeModel
                {
                    Id = i,
                    Name = "John Doe Number " + i,
                    Department = r.Next(1, 11)
                });
            }

            return new JsonResult()
            {
                Data = _comments,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
    }
}