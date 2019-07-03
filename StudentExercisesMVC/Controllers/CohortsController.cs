using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExercisesMVC.Models;

namespace StudentExercisesMVC.Controllers
{
    public class CohortsController : Controller
    {

        private readonly IConfiguration _config;

        public CohortsController(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        // GET: api/Cohort
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT 
                                        c.Id AS CohortId,
                                        c.CohortName
                                        
                                        FROM Cohort c";
                                        

                    //s.Id AS StudentId,
                    //                    s.FirstName AS SFirst,
                    //                    s.LastName AS SLast,
                    //                    i.Id AS InstructorId,
                    //                    i.FirstName AS IFirst,
                    //                    i.LastName AS ILast

                    //                    LEFT JOIN Student s ON s.CohortId = c.Id
                    //                    LEFT JOIN Instructor i ON i.CohortId = c.Id";

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    //List<Instructor> instructors = new List<Instructor>();

                    //List<Student> students = new List<Student>();

                    List<Cohort> cohorts = new List<Cohort>();

                    while (reader.Read())
                    {
                        //Student student = new Student
                        //{
                        //    Id = reader.GetInt32(reader.GetOrdinal("StudentId")),
                        //    FirstName = reader.GetString(reader.GetOrdinal("SFirst")),
                        //    LastName = reader.GetString(reader.GetOrdinal("SLast")),
                        //    CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        //};


                        //students.Add(student);




                        //Instructor instructor = new Instructor
                        //{
                        //    Id = reader.GetInt32(reader.GetOrdinal("InstructorId")),
                        //    FirstName = reader.GetString(reader.GetOrdinal("IFirst")),
                        //    LastName = reader.GetString(reader.GetOrdinal("ILast")),
                        //    CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        //};

                        //instructors.Add(instructor);


                        Cohort cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("CohortId")),
                            CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                            //ListOfStudents = students.Where(s => s.CohortId == reader.GetInt32(reader.GetOrdinal("CohortId"))).ToList(),
                            //ListOfInstructors = instructors.Where(i => i.CohortId == reader.GetInt32(reader.GetOrdinal("CohortId"))).ToList()
                        };

                        cohorts.Add(cohort);

                        //if (cohorts.Any(c => c.Id == cohort.Id))
                        //{
                        //    cohort.ListOfInstructors.Add(instructor);

                        //    cohort.ListOfStudents.Add(student);

                        //    Cohort cohortToUpdate = cohorts.Find(c => c.Id == cohort.Id);
                        //    if (!cohortToUpdate.ListOfInstructors.Any(i => i.Id == instructor.Id))
                        //    {
                        //        cohortToUpdate.ListOfInstructors.Add(instructor);
                        //    }

                        //    if (!cohortToUpdate.ListOfStudents.Any(s => s.Id == student.Id))
                        //    {
                        //        cohortToUpdate.ListOfStudents.Add(student);
                        //    }

                        //}
                        //else
                        //{
                        //    cohorts.Add(cohort);
                        //}

                    }

                    reader.Close();

                    return View(cohorts);
                }
            }


        }

        // GET: Cohorts/Details/5
        
        public  IActionResult Details(int Id)
        {
            try
            {
                Cohort cohort =  GetCohortById(Id);

                return View(cohort);
            }
            catch
            {
                return NotFound();
            }


        }

        // GET: Cohorts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cohorts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cohort cohort)
        {
            try
            {
                // TODO: Add insert logic here

                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO Cohort
                ( CohortName )
                VALUES
                ( @CohortName )";
                        cmd.Parameters.Add(new SqlParameter("@CohortName", cohort.CohortName));
                        
                        await cmd.ExecuteNonQueryAsync();

                        return RedirectToAction(nameof(Index));
                    }
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Cohorts/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Cohort cohort = GetCohortById(id);

                return View(cohort);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Cohorts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cohort cohort)
        {
            try
            {
                // TODO: Add update logic here

                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                            UPDATE Cohort
                            SET CohortName = @CohortName
                            WHERE Id = @id
                        ";
                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@CohortName", cohort.CohortName));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return RedirectToAction(nameof(Index));
                    }

                }

            }

            catch
            {
                return View();
            }
        }

        // GET: Cohorts/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Cohort cohort = GetCohortById(id);

                return View(cohort);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Cohorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Cohort GetCohortById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT 
                                        c.Id AS CohortId,
                                        c.CohortName
                                        FROM Cohort c
                                        WHERE c.Id = @Id";

                    //s.Id AS StudentId,
                    //                    s.FirstName AS SFirst,
                    //                    s.LastName AS SLast,
                    //                    i.Id AS InstructorId,
                    //                    i.FirstName AS IFirst,
                    //                    i.LastName AS ILast
                    //                    FROM Cohort c
                    //                    LEFT JOIN Student s ON s.CohortId = c.Id
                    //                    LEFT JOIN Instructor i ON i.CohortId = c.Id

                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    SqlDataReader reader = cmd.ExecuteReader();

                    //List<Instructor> instructors = new List<Instructor>();

                    //List<Student> students = new List<Student>();

                    Cohort cohort = null;

                    if (reader.Read())
                    {
                        //Student student = new Student
                        //{
                        //    Id = reader.GetInt32(reader.GetOrdinal("StudentId")),
                        //    FirstName = reader.GetString(reader.GetOrdinal("SFirst")),
                        //    LastName = reader.GetString(reader.GetOrdinal("SLast")),
                        //    CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        //};


                        //students.Add(student);




                        //Instructor instructor = new Instructor
                        //{
                        //    Id = reader.GetInt32(reader.GetOrdinal("InstructorId")),
                        //    FirstName = reader.GetString(reader.GetOrdinal("IFirst")),
                        //    LastName = reader.GetString(reader.GetOrdinal("ILast")),
                        //    CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        //};

                        //instructors.Add(instructor);


                        cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("CohortId")),
                            CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                            //ListOfStudents = students.Where(s => s.CohortId == reader.GetInt32(reader.GetOrdinal("CohortId"))).ToList(),
                            //ListOfInstructors = instructors.Where(i => i.CohortId == reader.GetInt32(reader.GetOrdinal("CohortId"))).ToList()
                        };


                        //if (!cohort.ListOfInstructors.Any(i => i.Id == instructor.Id))
                        //{
                        //    cohort.ListOfInstructors.Add(instructor);
                        //}

                        //if (!cohort.ListOfStudents.Any(s => s.Id == student.Id))
                        //{
                        //    cohort.ListOfStudents.Add(student);
                        //}                   

                    }

                    reader.Close();

                    return cohort;
                }
            }
        }
    }
}