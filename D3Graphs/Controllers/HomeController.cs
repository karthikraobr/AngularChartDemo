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

        public ActionResult GetEmployees(int? id)
        {
            if (id == null) id = 40000;
            if (id > 50000) id = 50000;

            var result = new Result();
            Random r = new Random();
            int rInt = r.Next(0, 100); //for ints
            var employees = new List<EmployeeModel>();
            for (int i = 1; i <= id; i++)
            {
                employees.Add(new EmployeeModel
                {
                    Id = i,
                    Name = "John Doe Number " + i,
                    Department = r.Next(1, 11),
                    DOB = RandomDay().ToShortDateString(),
                    Address = "Address "+i,
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

        DateTime RandomDay()
        {
            DateTime start = new DateTime(1950, 1, 1);
            Random gen = new Random();
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}