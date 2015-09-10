using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D3Graphs.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public int Department { get; set; }
        public string Name { get; set; }

        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public float Salary { get; set; }
        public int Category { get; set; }
    }


    public class Result
    {
        public List<EmployeeModel> Employees { get; set; }
        public List<int> Departments { get; set; }
    }
}