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

    //Referenced from BLOG-PROJECT 2 
    //Name: Christine Bittle
    //FROM WHERE: GitHub Repository
    //Date: November 12, 2020
    //Used for: Read functionality for Teachers and Students 

    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDBContext school = new SchoolDBContext();

        //This Controller Will access the teachers table of our school database.
        /// <summary>
        /// Returns a list of Teacher in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of teachers (first names and last names)
        /// </returns>
        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection Conn = school.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teacher
            List<Teacher> teachers = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string employeenumber = ResultSet["employeenumber"].ToString();
                DateTime hiredate = (DateTime) ResultSet["hiredate"];
                decimal TeacherSalary = (Decimal)ResultSet["salary"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.employeenumber = employeenumber;
                NewTeacher.hiredate = hiredate;
                NewTeacher.TeacherSalary = TeacherSalary;

                //Add the Teacher Name to the List
                teachers.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Teacher names
            return teachers;
        }

        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = school.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers where teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString(); 
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string employeenumber = ResultSet["employeenumber"].ToString();
                DateTime hiredate = (DateTime)ResultSet["hiredate"];
                decimal TeacherSalary = (Decimal)ResultSet["salary"];

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.employeenumber = employeenumber;
                NewTeacher.hiredate = hiredate;
                NewTeacher.TeacherSalary = TeacherSalary;

            }


            return NewTeacher;
        }

    }
}
