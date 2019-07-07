using System;
using System.ComponentModel.DataAnnotations;

namespace StudentExercisesMVC.Models
{
    public class NSSPerson
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Slack { get; set; }
        public Cohort Cohort { get; set; }
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}