using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult Index()
        {
            EmployeeDataContext db = new EmployeeDataContext();
            List<Student> obj = db.GetStudents();
            return View(obj);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Student std)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDataContext context = new EmployeeDataContext();
                    bool check = context.AddStudent(std);
                    if (check == true)
                    {
                        TempData["InsertMassage"] = "Data has been Inserted Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int ID)
        {

            EmployeeDataContext context = new EmployeeDataContext();
            var row = context.GetStudents().Find(model => model.ID == ID);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int ID, Student std)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDataContext context = new EmployeeDataContext();
                    bool check = context.UpdateStudent(std);
                    if (check == true)
                    {
                        TempData["UpdateMassage"] = "Data has been Updated Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int ID)
        {
            EmployeeDataContext context = new EmployeeDataContext();
            var row = context.GetStudents().Find(model => model.ID == ID);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int ID, Student student)
        {
            EmployeeDataContext context = new EmployeeDataContext();
            bool check = context.DeleteStudent(ID);
            if (check == true)
            {
                TempData["DeleteMassage"] = "Data has been Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int ID)
        {
            EmployeeDataContext context = new EmployeeDataContext();
            var row = context.GetStudents().Find(model => model.ID == ID);
            return View(row);
        }
    }
}