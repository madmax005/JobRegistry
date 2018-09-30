using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobRegistry.Models;

namespace JobRegistry.Controllers
{
    public class JobSeekerController : Controller
    {
        // GET: JobSeeker
        public ActionResult JobRegistration()
        {
            using (JobRegistryDBContext dbmodel = new JobRegistryDBContext())
                return View(dbmodel.JobSeekers.ToList());
        }

        // GET: JobSeeker/Details/5
        public ActionResult Details(int id)
        {
            using (JobRegistryDBContext dbmodel = new JobRegistryDBContext())
            {
                return View(dbmodel.JobSeekers.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // GET: JobSeeker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobSeeker/Create
        [HttpPost]
        public ActionResult Create(JobSeeker jobSeeker)
        {
            try
            {
                // Create Jobseeker Details

                using (JobRegistryDBContext dbmodel = new JobRegistryDBContext())
                {
                    dbmodel.JobSeekers.Add(jobSeeker);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("JobRegistration");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobSeeker/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobSeeker/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}
