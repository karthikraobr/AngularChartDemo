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

            var result = new Result();
            Random r = new Random();
            int rInt = r.Next(0, 100); //for ints
            var employees = new List<EmployeeModel>();
            for (int i = 1; i <= count; i++)
            {
                employees.Add(new EmployeeModel
                {
                    Id = i,
                    Name = "John Doe Number " + i,
                    Department = r.Next(1, 11),
                    DOB = new DateTime(2011,1,1),
                    Address = "Address"+i,
                    Category = r.Next(1, 10),
                    Salary=i,
                });
            }
            result.Employees = employees;
            var groupedEmployees = employees.GroupBy(p => p.Department).ToList();
            result.Departments = groupedEmployees.Select(x => x.Key).ToList();
            result.Departments.Sort();
            return new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
    }
}