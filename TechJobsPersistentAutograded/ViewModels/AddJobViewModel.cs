using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddJobViewModel
    {

        //need properties for the job’s name, the selected employer’s ID,
        //and a list of all employers as SelectListItem.

        [Required(ErrorMessage = "Job name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Employer is required")]
        public int EmployerId { get; set; }
        //public int Id { get; set; }
        public List<SelectListItem> Employer { get; set; }
        //skills will be added in part3
        //public List<SelectListItem> JobSkills { get; set; }
        public List<Skill> JobSkills { get; set; }
        public List<int> SkillId { get; set; }

        //

        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {

            Employer = new List<SelectListItem>();

            foreach (Employer employerItem in employers)
            {
                Employer.Add(new SelectListItem
                {
                    Value = employerItem.Id.ToString(),//value is the actual form value that will submited 
                    Text = employerItem.Name //display

                });
            }
            //property equal to the parameter you have just passed in
            JobSkills = skills;

        }

            public AddJobViewModel(){ }

        
    }
}
