using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentExercisesMVC.Models
{
    public class Exercise
    {
       /* public Exercise(string name, string language, int id)
        {
            ExerciseName = name;
            ExerciseLanguage = language;
            Id = id;
        }
        */
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Exercise Name")]
        public string ExerciseName {get; set;}
        [Required]
        [Display(Name = "Exercise Language")]
        public string ExerciseLanguage {get; set;}
        public List<Student> ListOfStudents {get; set;} = new List<Student>();

        public void ListStudentsOnExercise(List<Student> students)
        {
            
            Console.WriteLine($"Students working on {this.ExerciseName}: ");

            foreach(Student student in students)
            {
                foreach(Exercise exercise in student.ExerciseList)
                {
                    if(exercise.Equals(this))
                    {
                        ListOfStudents.Add(student);
                        Console.WriteLine(student.GetFullName());
                    }
                }
                
            }
        }
    }
}
