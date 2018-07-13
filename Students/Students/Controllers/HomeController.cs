using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.Models;

namespace Students.Controllers
{
    public class HomeController : Controller
    {
        private StudentsContext db = new StudentsContext();
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        public ActionResult Edit(int id = 0)
        {
            Student student = db.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            ViewBag.Courses = db.Courses.ToList();
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student, int[] selectedCourses)
        {
            Student newStudent = db.Students.Find(student.Id);
            newStudent.Name = student.Name;
            newStudent.Surname = student.Surname;

            newStudent.Courses.Clear();
            if (selectedCourses != null)
            {
                //Получаем выбранные курсы
                foreach (var c in db.Courses.Where(co=>selectedCourses.Contains(co.Id)))
                {
                    newStudent.Courses.Add(c);
                }
            }
            db.Entry(newStudent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}