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
    public class InstructorsController : Controller
    {
        public IActionResult Privacy()
        {
            return View();
        }
        private readonly IConfiguration _config;

        public InstructorsController(IConfiguration config)
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
        // GET: Instructors
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {



                    cmd.CommandText = @"
                                    SELECT i.Id,
                                        i.FirstName,
                                        i.LastName,
                                        i.Slack,
                                        i.CohortId
                                        FROM Instructor i";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();
                    while (reader.Read())
                    {
                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Slack = reader.GetString(reader.GetOrdinal("Slack")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };

                        instructors.Add(instructor);
                    }

                    reader.Close();

                    return View(instructors);
                }
            }
        }

        // GET: Instructors/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Instructor instructor = GetInstructorById(id);

                return View(instructor);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {

            InstructorCreateViewModel instructorCreateViewModel = new InstructorCreateViewModel(_config.GetConnectionString("DefaultConnection"));

            return View(instructorCreateViewModel);
           
        }

        // POST: Instructors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InstructorCreateViewModel model)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Instructor
                ( FirstName, LastName, Slack, CohortId )
                VALUES
                ( @FirstName, @LastName, @Slack,  @CohortId )";
                    cmd.Parameters.Add(new SqlParameter("@FirstName", model.Instructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", model.Instructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Slack", model.Instructor.Slack));
                    cmd.Parameters.Add(new SqlParameter("@CohortId", model.Instructor.CohortId));
                    //cmd.Parameters.Add(new SqlParameter("@Specialty", model.Instructor.Specialty));
                    await cmd.ExecuteNonQueryAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
        }

        // GET: Instructors/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            string sql = $@"
                            SELECT
                                i.Id,
                                i.FirstName,
                                i.LastName,
                                i.Slack,
                                i.CohortId
                            FROM Instructor i
                            WHERE i.Id = @id
                            ";

            Instructor instructor = null;

            /*
                Run the query above and create an instance of Instructor
                populated with the data it returns
             */

            using(SqlConnection conn = Connection)
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;

                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    if(reader.Read())
                    {
                        instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Slack = reader.GetString(reader.GetOrdinal("Slack")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };
                    }
                    else
                    {
                        reader.Close();
                        return NotFound();
                    }
                    /*
                        Create an instance of your InstructorEditViewModel
                    */

                    InstructorEditViewModel instructorEditView = new InstructorEditViewModel(_config.GetConnectionString("DefaultConnection"));

                    /*
                        Assign the instructor you created to the .Instructor
                        property of your view model
                    */

                    instructorEditView.Instructor = instructor;

                    reader.Close();
                    return View(instructorEditView);

                    
                }
            }

        }

        // POST: Instructors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InstructorEditViewModel viewModel)
        {
            Instructor instructor = viewModel.Instructor;
            try
            {
                // TODO: Add update logic here

                using(SqlConnection conn = Connection)
                {
                    conn.Open();

                    using(SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Instructor SET FirstName = @FirstName, LastName = @LastName, Slack = @Slack, CohortId = @CohortId WHERE Id = @id";

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@FirstName", instructor.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", instructor.LastName));
                        cmd.Parameters.Add(new SqlParameter("@Slack", instructor.Slack));
                        cmd.Parameters.Add(new SqlParameter("@CohortId", instructor.CohortId));

                        cmd.ExecuteNonQuery();

                       
                    }

                    conn.Close();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Instructors/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Instructor instructor = GetInstructorById(id);

                return View(instructor);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here

                using (SqlConnection conn = Connection)
                {
                    conn.Open();

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM Instructor WHERE Id = @id";

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

        private Instructor GetInstructorById(int id)
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                    SELECT i.Id,
                                        i.FirstName,
                                        i.LastName,
                                        i.Slack,
                                        i.CohortId
                                        FROM Instructor i
                                        WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();



                    Instructor instructor = null;

                    if (reader.Read())
                    {
                        instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Slack = reader.GetString(reader.GetOrdinal("Slack")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };

                        reader.Close();

                        return instructor;
                    }
                    else
                    {
                        reader.Close();

                        return instructor;
                    }
                }
            }

        }
    }
}