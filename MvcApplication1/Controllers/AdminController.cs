using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;


namespace MvcApplication1.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/


        Database1Entities1 db = new Database1Entities1();

        public ActionResult Index()
        {
            if (Session["aname"] == null && Session["uname"] != null )
            {
                return RedirectToAction("Login" , "Home");
            }

            return View();
        }
        public ActionResult About()
        {
             if (Session["aname"] == null)
            {
                return RedirectToAction("Login" , "Home");
            }
        
            return View();
        }

        public ActionResult Add()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddFunction(Teacher t)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                t.Tid = 1;
                db.Teachers.Add(t);
                db.SaveChanges();
                return RedirectToAction("Mstaff");
            }
            else
            {
                return View(t);
            }
        }

        public ActionResult Addstudent()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student s)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                s.Sid = 1;
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Mstudent");
            }
            else
            {
                return View(s);
            }
        }

        public ActionResult Contact()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        public ActionResult Details()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult Services()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult MStaff()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = "Your staff page.";
            var teacherList = db.Teachers.ToList();
            if (teacherList == null)
            {
                teacherList = new List<Teacher>();
            }
            return View(teacherList);
        }


        public ActionResult Mstudent()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = "Your student page.";
            var studentList = db.Students.ToList();
            if (studentList == null)
            {
                studentList = new List<Student>();
            }
            return View(studentList);
        }

        public ActionResult Update(int id)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            Teacher t = db.Teachers.Find(id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateConfirm(int id)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {

                Teacher t = db.Teachers.Find(id);
                string name = Request["name"];
                string phone = Request["phone"];
                string desc = Request["description"];
                string img = Request["img"];
                string em = Request["email"];
                string pw = Request["pass"];
                t.Name = name;
                t.PhoneNo = Convert.ToInt32(phone);
              //  t.PhoneNo = phone;
                t.Description = desc;
                t.Image = img;
                t.Email = em;
                t.Password = pw;
                db.SaveChanges();

                return RedirectToAction("MStaff");
            }
            else
            {
                return RedirectToAction("Update");
            }
        }


        public ActionResult Updatestudent(int id)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            Student t = db.Students.Find(id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateStudent(int id)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                Student s = db.Students.Find(id);
                string name = Request["name"];
                string em = Request["email"];
                string pw = Request["pass"];
                string g = Request["grade"];
                s.Name = name;
                s.Email = em;
                s.Password = pw;
                s.Grade = g;
                db.SaveChanges();

                return RedirectToAction("Mstudent");
            }
            else
            {
                return RedirectToAction("UpdateStudent");
            }
        }

        public ActionResult Delete(int id)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            Teacher t = db.Teachers.Find(id);
            db.Teachers.Remove(t);
            db.SaveChanges();
            return RedirectToAction("MStaff");
        }

        public ActionResult DeleteS(int id)
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            Student s = db.Students.Find(id);
            db.Students.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Mstudent");
        }

        public ActionResult searchTeacher()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        [HttpPost]
        public JsonResult searchTeacherFunction(string term)
        {
            Database1Entities1 db = new Database1Entities1();
            List<Teacher> d = db.Teachers
                        .Where(s => s.Name.StartsWith(term)).ToList();

            return Json(d, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult SearchPeople(string keyword)
        {
            // System.Threading.Thread.Sleep(2000);
            Database1Entities1 db = new Database1Entities1();

            var data = db.Teachers.Where(f => f.Name.Contains(keyword)).ToList();
            return PartialView(data);
        }

        public ActionResult searchStudent()
        {
            if (Session["aname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        [HttpPost]
        public JsonResult searchStudentFunction(string term)
        {
            Database1Entities1 db = new Database1Entities1();
            List<Student> d = db.Students
                        .Where(s => s.Name.StartsWith(term)).ToList();

            return Json(d, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult SearchPeopleS(string keyword)
        {
            // System.Threading.Thread.Sleep(2000);
            Database1Entities1 db = new Database1Entities1();

            var data = db.Students.Where(f => f.Name.Contains(keyword)).ToList();
            return PartialView(data);
        }


    }
}
