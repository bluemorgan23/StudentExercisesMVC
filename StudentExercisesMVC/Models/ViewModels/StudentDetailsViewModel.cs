using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC.Models.ViewModels
{
    public class StudentDetailsViewModel
    {

        private string _connectionString;

        private SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public Student Student { get; set; }

        public List<Exercise> Exercises { get; set; }

        public StudentDetailsViewModel() { }

        public StudentDetailsViewModel(int id, string config)
        {
            _connectionString = config;

            Exercises = AssignedExercises(id);
        }

        private List<Exercise> AssignedExercises(int id)
        {
            List<Exercise> exercises = new List<Exercise>();
            using(SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT se.Id, se.ExerciseId, se.StudentId, e.Id AS exerciseId, e.ExerciseName, e.ExerciseLanguage FROM StudentExercise se JOIN Exercise e ON e.Id = se.ExerciseId  WHERE StudentId = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            ExerciseLanguage = reader.GetString(reader.GetOrdinal("ExerciseLanguage"))
                        };

                        exercises.Add(exercise);

                    }

                    reader.Close();

                    return exercises;
                }
            }
        }
    }
}
