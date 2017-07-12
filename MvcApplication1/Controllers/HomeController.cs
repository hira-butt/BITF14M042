using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Net.Mail;
using System.Text;



namespace MvcApplication1.Controllers
{


    public class HomeController : Controller
    {

        Database1Entities1 db = new Database1Entities1();



        public ActionResult Index()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View(db.Teachers.ToList());
        }

        public ActionResult About()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = "Your app description page.";

            return View();
        }


        public ActionResult Contact()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ContactFunction(Student s)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            // Student s = new Student();
            // s.Sid = 3;

            string name = s.Name;
            string email = s.Email;
            string pass = s.Password;
            string sub = s.Grade;
            
         //   string pass = s.Password;
            // string result = "Message Sent Successfully..!!";
            string senderID = email;    //"kinza.arshad987@gmail.com";// use sender’s email id here..
            const string senderPassword = "kinzaanu"; // sender password here…
            string toAddress = "hira.butt897@gmail.com";
            string subject = sub;
            string body = "Info is \n Name:" + name + "\nEmail" + email + "\nSubject" + sub + " ";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", // smtp server address here…
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                Timeout = 30000,
            };
            MailMessage message = new MailMessage(senderID, toAddress, subject, body);
            smtp.Send(message);

            return RedirectToAction("Index");
        }

        public ActionResult Services()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = "Your services page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Details()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = "Your details page.";

            return View();
        }

        public ActionResult Staff()
        {
            if (Session["uname"] == null)
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


        public ActionResult Login()
        {
            Session["uname"] = null;

            return View();
        }

        [HttpPost]
        public ActionResult LoginFunction()
        {
            Session["uname"] = null;
            Session["aname"] = null;

            string email = Request["email"];
            string password = Request["password"];
            if (email == "Admin01@gmail.com" && password == "admin")
            {
                Session["aname"] = email;
                return RedirectToAction("Index", "Admin");
            }
            string query = (from t in db.Students
                            where t.Email == email && t.Password == password
                            select t.Name).FirstOrDefault();
            if (query == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                Session["uname"] = email;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUpFunction(Student s)
        {

            // Student  s = new Student();
            s.Sid = 1;
            //string name = Request["Name"];
            //string email = Request["Email"];
            //string password = Request["Password"];
            //string age = Request["Age"];
            //s.Name = name;
            //s.Email = email;
            //s.Password = password;

            if (ModelState.IsValid == true)
            {
                Session["uname"] = s.Email;
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(s);

                ////   s.Sid = 1;
                //   db.Students.Add(s);
                //   db.SaveChanges();
                //   return RedirectToAction("Index");
            }
        }

             public ActionResult searchTeacher()
           {
                if (Session["uname"] == null)
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

        
    }
}
