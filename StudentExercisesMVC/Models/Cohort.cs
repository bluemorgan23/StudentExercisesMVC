using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentExercisesMVC.Models
{
    public class Cohort
    {
        /*
        public Cohort(string name, int id) {
            Name = name;
            Id = id;
        }
        */
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cohort Name")]
        public string CohortName {get; set;}
        public List<Student> ListOfStudents {get; set;} = new List<Student>();
        public List<Instructor> ListOfInstructors {get; set;} = new List<Instructor>();
    }
}