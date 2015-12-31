using eManager.Domain;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        IDepartmentDataSource _db;

        public EmployeeController(IDepartmentDataSource db)
        {
            _db = db;
        }

        [HttpGet]        
        public ActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeViewModel();
            model.DepartmentId = departmentId;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployeeViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var dept = _db.Departments.Single(d => d.Id == viewmodel.DepartmentId);
                Employee emp = new Employee();
                emp.Name = viewmodel.Name;
                emp.HireDate = viewmodel.HireDate;
                dept.Employees.Add(emp);
                _db.Save();
                return RedirectToAction("detail", "department", new { id = viewmodel.DepartmentId });
            }
            return View(viewmodel);
        }

    }
}
