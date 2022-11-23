using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistentAutograded.Models;
using TechJobsPersistentAutograded.ViewModels;
using TechJobsPersistentAutograded.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistentAutograded.Controllers
{

    public class HomeController : Controller

    {
        private JobRepository _repo;
       

        public HomeController(JobRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()

        {
            IEnumerable<Job> jobs = _repo.GetAllJobs();

            return View(jobs);
        }

        //In AddJob() pass an instance of AddJobViewModel to the view.
        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            //List<Employer> employers = _repo.Employers.ToList();
            //List<Skill> skills = _repo.Skills.ToList();
            //AddJobViewModel addJobViewModel = new AddJobViewModel(employers, skills);

            //i need to to add this in part3
            AddJobViewModel addJobViewModel = new AddJobViewModel(_repo.GetAllEmployers(). ToList(), _repo.GetAllSkills().ToList());
            //AddJobViewModel addJobViewModel = new AddJobViewModel(_repo.GetAllEmployers().ToList);
            return View(addJobViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
           
            if (ModelState.IsValid)
            {
                //Employer newEmployer = _repo.FindEmployerById(addJobViewModel.EmployerId);
                //Employer theEmployer = new Employers._repo.Find(addJobViewModel.EmployerId);
                //Creat new Job object
                Job newJob = new Job()
                {

                    Name = addJobViewModel.Name,
                    EmployerId = addJobViewModel.EmployerId,
                    Employer = _repo.FindEmployerById(addJobViewModel.EmployerId)

                };
                //................


                _repo.GetAllJobsEmployer().Add(newJob);
                // _repo.Jobs.Add(newJob);
                //return Redirect("Index");
                _repo.SaveChanges();
                return Redirect("/Employer");
            }

            return View("Add",addJobViewModel);
        }


        public IActionResult Detail(int id)
        {
            Job theJob = _repo.FindJobById(id);

            List<JobSkill> jobSkills = _repo.FindSkillsForJob(id).ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }

    }

}


