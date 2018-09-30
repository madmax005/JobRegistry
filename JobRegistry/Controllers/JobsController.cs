using JobRegistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobRegistry.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Joblist()
        {
            using (JobRegistryDBContext dbmodel = new JobRegistryDBContext())
                return View(dbmodel.JobDetails.ToList());
        }

        public ActionResult AddJobs()
        {
            return View();
        }

        // Add Jobs list Details

        [HttpPost]
        public ActionResult AddJobs(JobDetail JobId)
        {
            try
            {
                // Create Jobseeker Details

                using (JobRegistryDBContext dbmodel = new JobRegistryDBContext())
                {
                    dbmodel.JobDetails.Add(JobId);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("AddJobs");
            }
            catch
            {
                return View();
            }
        }

    }
}