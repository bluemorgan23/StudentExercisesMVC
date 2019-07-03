using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC.Models.ViewModels
{
    public class StudentEditViewModel
    {
        public Student Student { get; set; }
        public List<Cohort> AvailableCohorts { get; set; }

        public List<Exercise> AvailableExercises { get; set; }

        public int[] SelectedExercisesIds { get; set; }

        public List<SelectListItem> AvailableExercisesSelectList
        {
            get
            {
                if(AvailableExercises == null)
                {
                    return null;
                }

                return AvailableExercises
                        .Select(e => new SelectListItem(e.ExerciseName, e.Id.ToString()))
                        .ToList();
            }
        }

        public List<SelectListItem> AvailableCohortsSelectList
        {
            get
            {
                if(AvailableCohorts == null)
                {
                    return null;
                }


                return AvailableCohorts
                        .Select(c => new SelectListItem(c.CohortName, c.Id.ToString()))
                        .ToList();
            }
        }
    }
}
