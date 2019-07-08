using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExercisesMVC.Models;
using StudentExercisesMVC.Models.ViewModels;

namespace StudentExercisesMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IConfiguration _config;

        public StudentsController(IConfiguration config)
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
        // GET: Students
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    

                    cmd.CommandText = @"
                                    SELECT s.Id,
                                        s.FirstName,
                                        s.LastName,
                                        s.Slack,
                                        s.CohortId
                                        FROM Student s";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Slack = reader.GetString(reader.GetOrdinal("Slack")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };

                        students.Add(student);
                    }

                    reader.Close();

                    return View(students);
                }
            }
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            
            try
            {
                Student student = GetStudentById(id);

                return View(student);
            }
            catch
            {
                return NotFound();
            }
                  
            
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            StudentCreateViewModel studentCreateViewModel = new StudentCreateViewModel(_config.GetConnectionString("DefaultConnection"));

            return View(studentCreateViewModel);
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentCreateViewModel model)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Student
                ( FirstName, LastName, Slack, CohortId )
                VALUES
                ( @firstName, @lastName, @slack, @cohortId )";
                    cmd.Parameters.Add(new SqlParameter("@firstName", model.student.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", model.student.LastName));
                    cmd.Parameters.Add(new SqlParameter("@slack", model.student.Slack));
                    cmd.Parameters.Add(new SqlParameter("@cohortId", model.student.CohortId));
                    await cmd.ExecuteNonQueryAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {

            List<Cohort> cohorts = GetAllCohorts();

            Student student = GetStudentById(id);

            StudentEditViewModel StudentEditViewModel = new StudentEditViewModel(_config.GetConnectionString("DefaultConnection"));

            StudentEditViewModel.Student = GetStudentById(id);
            

            return View(StudentEditViewModel);
        }

        private List<Cohort> GetAllCohorts()
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, CohortName FROM Cohort";

                    List<Cohort> cohorts = new List<Cohort>();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cohort cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                        };

                        cohorts.Add(cohort);
                    }

                    reader.Close();

                    return cohorts;
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StudentEditViewModel viewModel)
        {
            Student student = GetStudentById(id);

            viewModel.Student = student;
           
            
                // TODO: Add update logic here

                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                            UPDATE Student
                            SET FirstName = @FirstName,
                                LastName = @LastName,
                                CohortId = @CohortId,
                                Slack = @Slack
                            WHERE Id = @id;
                        ";

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@FirstName", student.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                        cmd.Parameters.Add(new SqlParameter("@CohortId", student.CohortId));
                        cmd.Parameters.Add(new SqlParameter("@Slack", student.Slack));

                        await cmd.ExecuteNonQueryAsync();

                        if (viewModel.SelectedValues.Count > 0)
                        {
                            viewModel.SelectedValues.ForEach(i =>
                            {
                                cmd.CommandText = $" INSERT INTO StudentExercise (ExerciseId, StudentId) VALUES (@ExerciseId{i}, @StudentId{id});";
                                cmd.Parameters.Add(new SqlParameter($"@ExerciseId{i}", i));
                                if(!cmd.Parameters.Contains($"@StudentId{id}"))
                                {
                                    cmd.Parameters.Add(new SqlParameter($"@StudentId{id}", id));

                                }

                               cmd.ExecuteNonQuery();
                            });
                                
                        }

                        return RedirectToAction(nameof(Index));
                    }

                }

            
                          
           
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {

            Student student = GetStudentById(id);

            return View(student);

        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here

                using(SqlConnection conn = Connection)
                {
                    conn.Open();

                    using(SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM StudentExercise WHERE StudentId = @id;
                                            DELETE FROM Student WHERE Id = @id";

                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        cmd.ExecuteNonQuery();

                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        private bool StudentExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // More string interpolation
                    cmd.CommandText = "SELECT Id FROM Student WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();

                    return reader.Read();
                }
            }
        }

        private Student GetStudentById(int id)
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                    SELECT s.Id,
                                        s.FirstName,
                                        s.LastName,
                                        s.Slack,
                                        s.CohortId
                                        FROM Student s
                                        WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();



                    Student student = null;

                    if (reader.Read())
                    {
                        student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Slack = reader.GetString(reader.GetOrdinal("Slack")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };

                        reader.Close();

                        return student;
                    }
                   else
                    {
                        return student;
                    }
                }
            }

        }
    }
}