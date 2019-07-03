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
    public class ExercisesController : Controller
    {

       
        private readonly IConfiguration _config;

        public ExercisesController(IConfiguration config)
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
            // GET: Exercises
        public ActionResult Index()
        {

            using(SqlConnection conn = Connection)
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "SELECT e.Id AS ExerciseId, e.ExerciseName, e.ExerciseLanguage FROM Exercise e";

                    List<Exercise> exercises = new List<Exercise>();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ExerciseId")),
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            ExerciseLanguage = reader.GetString(reader.GetOrdinal("ExerciseLanguage"))
                        };

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return View(exercises);

                }
            }
            
        }

        // GET: Exercises/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Exercise exercise = GetExerciseById(id);

                return View(exercise);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exercises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Exercise exercise)
        {
            
                // TODO: Add insert logic here

                using(SqlConnection conn = Connection)
                {
                    conn.Open();

                    using(SqlCommand cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = "INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES (@ExerciseName, @ExerciseLanguage)";

                        cmd.Parameters.Add(new SqlParameter("@ExerciseName", exercise.ExerciseName));
                        cmd.Parameters.Add(new SqlParameter("@ExerciseLanguage", exercise.ExerciseLanguage));

                        await cmd.ExecuteNonQueryAsync();

                        return RedirectToAction(nameof(Index));

                    }
                }

            
            
        }

        // GET: Exercises/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Exercise exercise = GetExerciseById(id);

                return View(exercise);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Exercises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Exercise exercise)
        {
            try
            {
                // TODO: Add update logic here

                using(SqlConnection conn = Connection)
                {
                    conn.Open();

                    using(SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Exercise SET ExerciseName = @ExerciseName, ExerciseLanguage = @ExerciseLanguage WHERE Id = @id";
                        cmd.Parameters.Add(new SqlParameter("@ExerciseName", exercise.ExerciseName));
                        cmd.Parameters.Add(new SqlParameter("@ExerciseLanguage", exercise.ExerciseLanguage));
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

        // GET: Exercises/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Exercise exercise = GetExerciseById(id);

                return View(exercise);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Exercises/Delete/5
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

                        cmd.CommandText = "DELETE FROM Exercise WHERE Id = @id";

                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        cmd.ExecuteNonQuery();

                        conn.Close();

                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        private Exercise GetExerciseById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "SELECT e.Id AS ExerciseId, e.ExerciseName, e.ExerciseLanguage FROM Exercise e WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    Exercise exercise = null;

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ExerciseId")),
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            ExerciseLanguage = reader.GetString(reader.GetOrdinal("ExerciseLanguage"))
                        };

                        
                    }

                    reader.Close();

                    return exercise;

                }
            }
        }
    }
}