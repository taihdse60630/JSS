using JobSearchingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using JobSearchingSystem.DAL;

namespace JobSearchingSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnitOfWork unitOfWork = new UnitOfWork();

            AreaRegistration.RegisterAllAreas();

            var context = new ApplicationDbContext();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!context.Users.Any(user => user.UserName == "admin"))
            {   
                var applicationUser = new ApplicationUser() { UserName = "admin" };
                userManager.Create(applicationUser, "123456");

                if (!context.Roles.Any(role => role.Name == "Admin"))
                {
                    roleManager.Create(new IdentityRole("Admin"));
                }
                userManager.AddToRole(applicationUser.Id, "Admin");

                Administrator admin = unitOfWork.AdministratorRepository.GetByID(applicationUser.Id);
                if (admin == null)
                {
                    admin = new Administrator();
                    admin.AdministratorID = applicationUser.Id;
                    admin.IsDeleted = false;
                    unitOfWork.AdministratorRepository.Insert(admin);
                    unitOfWork.Save();
                }
            }

            if (!context.Users.Any(user => user.UserName == "manager"))
            {
                var applicationUser = new ApplicationUser() { UserName = "manager" };
                userManager.Create(applicationUser, "123456");
                context.SaveChanges();

                if (!context.Roles.Any(role => role.Name == "Manager"))
                {
                    roleManager.Create(new IdentityRole("Manager"));
                }
                userManager.AddToRole(applicationUser.Id, "Manager");

                Manager manager = unitOfWork.ManagerRepository.GetByID(applicationUser.Id);
                if (manager == null)
                {
                    manager = new Manager();
                    manager.ManagerID = applicationUser.Id;
                    manager.IsDeleted = false;
                    unitOfWork.ManagerRepository.Insert(manager);
                    unitOfWork.Save();
                }
            }

            if (!context.Users.Any(user => user.UserName == "staff"))
            {
                var applicationUser = new ApplicationUser() { UserName = "staff" };
                userManager.Create(applicationUser, "123456");
                context.SaveChanges();

                if (!context.Roles.Any(role => role.Name == "Staff"))
                {
                    roleManager.Create(new IdentityRole("Staff"));
                }
                userManager.AddToRole(applicationUser.Id, "Staff");

                Staff staff = unitOfWork.StaffRepository.GetByID(applicationUser.Id);
                if (staff == null)
                {
                    staff = new Staff();
                    staff.StaffID = applicationUser.Id;
                    staff.IsDeleted = false;
                    unitOfWork.StaffRepository.Insert(staff);
                    unitOfWork.Save();
                }
            }

            if (!context.Users.Any(user => user.UserName == "recruiter"))
            {
                var applicationUser = new ApplicationUser() { UserName = "recruiter" };
                userManager.Create(applicationUser, "123456");
                context.SaveChanges();

                if (!context.Roles.Any(role => role.Name == "Recruiter"))
                {
                    roleManager.Create(new IdentityRole("Recruiter"));
                }
                userManager.AddToRole(applicationUser.Id, "Recruiter");

                Recruiter recruiter = new Recruiter();
                recruiter.RecruiterID = applicationUser.Id;
                recruiter.Email = "taihdse60630@fpt.edu.vn";
                recruiter.IsDeleted = false;
                unitOfWork.RecruiterRepository.Insert(recruiter);
                unitOfWork.Save();
            }

            if (!context.Users.Any(user => user.UserName == "jobseeker"))
            {
                var applicationUser = new ApplicationUser() { UserName = "jobseeker" };
                userManager.Create(applicationUser, "123456");
                context.SaveChanges();

                if (!context.Roles.Any(role => role.Name == "Jobseeker"))
                {
                    roleManager.Create(new IdentityRole("Jobseeker"));
                }
                userManager.AddToRole(applicationUser.Id, "Jobseeker");

                Jobseeker jobseeker = new Jobseeker();
                jobseeker.JobSeekerID = applicationUser.Id;
                jobseeker.Email = "taihdse60630@fpt.edu.vn";
                jobseeker.IsDeleted = false;
                unitOfWork.JobseekerRepository.Insert(jobseeker);
                unitOfWork.Save();
            }

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
