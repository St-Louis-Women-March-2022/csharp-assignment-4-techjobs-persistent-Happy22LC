using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddJobViewModel
    {
        private Func<List<Employer>> toList;

        //need properties for the job’s name, the selected employer’s ID,
        //and a list of all employers as SelectListItem.

        [Required(ErrorMessage = "Job name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Employer is required")]
        public int EmployerId { get; set; }
        public List<SelectListItem> Employers { get; set; }
        //skills will be added in part3
        public List<Skill> Skills { get; set; }

        // public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {

            Employers = new List<SelectListItem>();

            foreach (Employer employerItem in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employerItem.Id.ToString(),
                    Text = employerItem.Name

                });
            }
            Skills = skills;
        }

        public AddJobViewModel(Func<List<Employer>> toList)
        {
            this.toList = toList;
        }

        //public AddJobViewModel(){ }
        //public AddJobViewModel(List<Employer> employers,List<SelectListItem> employer, List<Skill> skills)
    }
}
