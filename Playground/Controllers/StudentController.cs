using Newtonsoft.Json;
using Playground.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Playground.Controllers
{
    //http://www.tutorialsteacher.com/mvc/asp.net-mvc-tutorials
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //Function gets a list of students from a "database call" and creates the inputs necessary to build a Bootstrap Table on the front end
        [HttpPost]
        public JsonResult GetStudents(string flagString)
        {
            int flag = int.Parse(flagString);
            
            //Simulate DB Call
            DataTable table = SelectAllSudents(flag);

            List<Student> studentsList = new List<Student>();
            foreach (DataRow dr in table.Rows)
            {
                Student student = new Student();

                student.ID = int.Parse(dr["ID"].ToString());
                student.FirstName = dr["FirstName"].ToString();
                student.LastName = dr["LastName"].ToString();
                student.Year = dr["Year"].ToString();

                studentsList.Add(student);
            }

            object columns = new
            {
                ID = "ID",
                FirstName = "First Name",
                LastName = "Last Name",
                Year = "Year"
            };

            //Object returned as 'retData' to the Client
            object obj = new { cols = columns, data = studentsList };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //This function simulates a DB Call
        public DataTable SelectAllSudents(int flag)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string)); table.Columns.Add("FirstName", typeof(string)); table.Columns.Add("LastName", typeof(string)); table.Columns.Add("Year", typeof(string));

            List<Student> list = new List<Student>();

            Student student = new Student(); student.ID = 1; student.FirstName = "Tony"; student.LastName = "Stark"; student.Year = "2008"; list.Add(student);
            student = new Student(); student.ID = 6; student.FirstName = "Steve"; student.LastName = "Rogers"; student.Year = "2011"; list.Add(student);
            student = new Student(); student.ID = 2; student.FirstName = "Bruce"; student.LastName = "Banner"; student.Year = "2008"; list.Add(student);
            student = new Student(); student.ID = 4; student.FirstName = "Thor"; student.LastName = "Odinson"; student.Year = "2011"; list.Add(student);
            student = new Student(); student.ID = 3; student.FirstName = "Natasha"; student.LastName = "Romanoff"; student.Year = "2010"; list.Add(student);
            student = new Student(); student.ID = 5; student.FirstName = "Clint"; student.LastName = "Barton"; student.Year = "2011"; list.Add(student);

            student = new Student(); student.ID = 9; student.FirstName = "Peter"; student.LastName = "Parker"; student.Year = "2016"; list.Add(student);
            student = new Student(); student.ID = 7; student.FirstName = "Peter"; student.LastName = "Quill"; student.Year = "2014"; list.Add(student);
            student = new Student(); student.ID = 8; student.FirstName = "Scott"; student.LastName = "Lang"; student.Year = "2015"; list.Add(student);
            student = new Student(); student.ID = 10; student.FirstName = "T'Challa"; student.LastName = "Wakanda"; student.Year = "2016"; list.Add(student);
            student = new Student(); student.ID = 11; student.FirstName = "Stephen"; student.LastName = "Strange"; student.Year = "2016"; list.Add(student);
            student = new Student(); student.ID = 12; student.FirstName = "Carol"; student.LastName = "Danvers"; student.Year = "2019"; list.Add(student);

            for (int i = 0; i < list.Count; i++)
            {
                //Original
                if (flag == 1)
                {
                    if(list[i].ID <= 6)
                    {
                        table.Rows.Add(new object[] { list[i].ID, list[i].FirstName, list[i].LastName, list[i].Year });
                    }
                }
                //New
                else if (flag == 2)
                {
                    if (list[i].ID > 6)
                    {
                        table.Rows.Add(new object[] { list[i].ID, list[i].FirstName, list[i].LastName, list[i].Year });
                    }
                }
                //All
                else
                {
                    table.Rows.Add(new object[] { list[i].ID, list[i].FirstName, list[i].LastName, list[i].Year });
                }
            }
            
            return table;
        }
    }
}