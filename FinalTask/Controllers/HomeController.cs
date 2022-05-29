using BuisinessLayer;
using BuisinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using FinalTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTask.Controllers
{
    public class HomeController : Controller
    {
        //private EFDBContext _context;
        //private readonly ILogger<HomeController> _logger;

        private DataManager _dataManager;
        public HomeController(EFDBContext context, DataManager dataManager)
        {
            //_context = context;
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            //List<Lec> _lec = _context.Lecs.ToList();
            List<Lec> _lec = _dataManager.LecsRep.GetAllLecs().ToList();
            return View(_lec);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*************************************************************Students****************************************************************************/
        public IActionResult Students()
        {
            var _stud = _dataManager.StudentsRep.GetAllStudents();
            return View(_stud);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student stud)
        {
            if (ModelState.IsValid)
            {
                _dataManager.StudentsRep.CreateStudent(stud);
                return RedirectToAction("~/Home/Students");
            }
            return View(stud);
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            Student st = new Student();
            return View("EditStudent", st);
        }

        [HttpGet]
        public IActionResult EditStudent(int Id)
        {
            var stud = _dataManager.StudentsRep.EditStudentGet(Id);
            return View(stud);
        }

        [HttpPost]
        public IActionResult EditStudent(Student stud)
        {
            if (ModelState.IsValid)
            {
                _dataManager.StudentsRep.EditStudentPost(stud);
                return RedirectToAction("Students");
            }
            return View();
        }

        public IActionResult DeleteStudent(Student stud)
        {
            _dataManager.StudentsRep.DeleteStudent(stud);
            return RedirectToAction("Students");
        }

        /*************************************************************Lecs****************************************************************************/


        [HttpPost]
        public IActionResult CreateLec(Lec lec)
        {
            if (ModelState.IsValid)
            {
                _dataManager.LecsRep.CreateLec(lec);
                return RedirectToAction("Index");
            }
            return View(lec);
        }
        [HttpGet]
        public IActionResult CreateLec()
        {
            ViewBag.Lectors = new SelectList(_dataManager.LectorsRep.GetAllLectors(), "Id", "Name");
            Lec lec = new Lec();
            return View("EditLec", lec);
        }

        [HttpGet]
        public IActionResult EditLec(int Id)
        {
            ViewBag.Lectors = new SelectList(_dataManager.LectorsRep.GetAllLectors(), "Id", "Name");
            var lec = _dataManager.LecsRep.EditLecGet(Id);
            return View(lec);
        }

        [HttpPost]
        public IActionResult EditLec(Lec lec)
        {
            if (ModelState.IsValid)
            {
                _dataManager.LecsRep.EditLecPost(lec);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteLec(Lec lec)
        {
            _dataManager.LecsRep.DeleteLec(lec);
            return RedirectToAction("Index");
        }

        /*************************************************************Lectors****************************************************************************/
        public IActionResult Lectors()
        {
            List<Lector> _lect = _dataManager.LectorsRep.GetAllLectors().ToList();
            return View(_lect);
        }

        [HttpPost]
        public IActionResult CreateLector(Lector lect)
        {
            if (ModelState.IsValid)
            {
                _dataManager.LectorsRep.CreateLector(lect);
                return RedirectToAction("Lectors");
            }
            return View(lect);
        }
        [HttpGet]
        public IActionResult CreateLector()
        {
            Lector lect = new Lector();
            return View("EditLector", lect);
        }

        [HttpGet]
        public IActionResult EditLector(int Id)
        {
            var lect = _dataManager.LectorsRep.EditLectorGet(Id);
            return View(lect);
        }

        [HttpPost]
        public IActionResult EditLector(Lector lect)
        {
            if (ModelState.IsValid)
            {
                _dataManager.LectorsRep.EditLectorPost(lect);
                return RedirectToAction("Lectors");
            }
            return View();
        }

        public IActionResult DeleteLector(Lector lect)
        {
            _dataManager.LectorsRep.DeleteLector(lect);
            return RedirectToAction("Lectors");
        }

        /*************************************************************Attendances****************************************************************************/
        [HttpGet]
        public IActionResult Attendances(Lec lect)
        {
            
            var att = _dataManager.AttendancesRep.GetAllAttendancesGet(lect).ToList();
            return View(att);
        }
        [HttpPost]
        public async Task<IActionResult> Attendances(string roleId, IEnumerable<Attendance> atts)
        {

            foreach (var att in atts)
            {
                _dataManager.AttendancesRep.GetAllAttendancesPost(att);
            }


            return RedirectToAction("Attendances");
        }
        [HttpGet]
        public IActionResult EditAttendance(int Id)
        {
            var att = _dataManager.AttendancesRep.EditAttendanceGet(Id);
            ViewBag.Lec = new SelectList(_dataManager.LecsRep.GetAllLecs(), "Id", "Subject", "Date");
            ViewBag.Stud = new SelectList(_dataManager.StudentsRep.GetStudents(), "Id", "Name");
            return View(att);
        }

        [HttpPost]
        public IActionResult EditAttendance(Attendance att)
        {
            if (ModelState.IsValid)
            {
                //_dataManager.AttendancesRep.EditAttendancePost(att);
                return RedirectToAction("Attendances");
            }
            return View();
        }
        public IActionResult SaveXML(Lec lec)
        {
            _dataManager.LecsRep.SaveXML(lec);
            return RedirectToAction("Index");
        }
        public IActionResult SaveJSON(Lec lec)
        {
            _dataManager.LecsRep.SaveJSON(lec);
            return RedirectToAction("Index");
        }

    }
}
