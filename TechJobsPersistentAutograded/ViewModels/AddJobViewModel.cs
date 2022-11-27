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
        public List<SelectListItem> Employer { get; set; }
        //skills will be added in part3
        public List<SelectListItem> JobSkills { get; set; }
        public object SkillId { get; set; }

        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {

            Employer = new List<SelectListItem>();

            foreach (Employer employerItem in employers)
            {
                Employer.Add(new SelectListItem
                {
                    Value = employerItem.Id.ToString(),
                    Text = employerItem.Name

                });
            }

            //Set the List<Skill> property equal to the parameter you have just passed in

            JobSkills = new List<SelectListItem>();
            foreach(Skill skillItem in skills)
            {
                JobSkills.Add(new SelectListItem
                {
                    Value = skillItem.Id.ToString(),
                    Text= skillItem.Name

                });
            }


      
        }

            public AddJobViewModel(){ }

        
    }
}
