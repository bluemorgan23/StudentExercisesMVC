using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC.Models.ViewModels
{
    public class InstructorEditViewModel
    {
        private string _connectionString;

        private SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public List<SelectListItem> Cohorts { get; set; }
        public Instructor Instructor { get; set; }

        public InstructorEditViewModel() { }

        public InstructorEditViewModel(string config)
        {

            _connectionString = config;

            /*
                Query the database to get all cohorts
            */

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, CohortName FROM Cohort";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cohort> cohorts = new List<Cohort>();
                    while (reader.Read())
                    {
                        cohorts.Add(new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            CohortName = reader.GetString(reader.GetOrdinal("CohortName")),
                        });
                    }

                    

                    Cohorts = cohorts.Select(c => new SelectListItem
                    {
                        Text = c.CohortName,
                        Value = c.Id.ToString()
                    })
                .ToList();

                    Cohorts
                        .Insert(0, new SelectListItem
                        {
                            Text = "Choose cohort...",
                            Value = "0"
                        });

                reader.Close();
                }
            }



            /*
                Use the LINQ .Select() method to convert
                the list of Cohort into a list of SelectListItem
                objects
            */
        }

        
    }
}
