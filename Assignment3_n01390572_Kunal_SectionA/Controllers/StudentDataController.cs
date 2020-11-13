using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment3_n01390572_Kunal_SectionA.Models;
using MySql.Data.MySqlClient;

namespace Assignment3_n01390572_Kunal_SectionA.Controllers
{
    public class StudentDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDBContext school = new SchoolDBContext();

        //This Controller Will access the students table of our school database.
        /// <summary>
        /// Returns a list of Student in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListStudent</example>
        /// <returns>
        /// A list of teachers (first names and last names)
        /// </returns>
        [HttpGet]
        public IEnumerable<Student> ListStudents()
        {
            //Create an instance of a connection
            MySqlConnection Conn = school.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from students";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Student
            List<Student> students = new List<Student> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = (int)ResultSet["studentid"];
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                DateTime Enroll = (DateTime)ResultSet["enroldate"];

                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.Enroll = Enroll;

                //Add the Student Name to the List
                students.Add(NewStudent);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of student names
            return students;
        }
    }
}
