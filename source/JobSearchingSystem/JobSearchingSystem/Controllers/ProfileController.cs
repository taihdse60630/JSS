using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchingSystem.DAL;
using JobSearchingSystem.Models;

namespace JobSearchingSystem.Controllers
{
    public class ProfileController : Controller
    {
        private ProfileUnitOfWork profileUnitOfWork = new ProfileUnitOfWork();

        //
        // GET: /Profile/
        [Authorize(Roles = "Jobseeker")]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Jobseeker")]
        public ActionResult List(string message)
        {
            ProListViewModel proListViewModel = new ProListViewModel();

            if (!String.IsNullOrEmpty(message))
            {
                ViewBag.message = message;
            }
            proListViewModel.proList = profileUnitOfWork.GetAllProList();

            return View(proListViewModel);
        }

        [Authorize(Roles = "Jobseeker")]
        public ActionResult Update(string profileID)
        {
            ProUpdateViewModel proUpdateViewModel = new ProUpdateViewModel();

            proUpdateViewModel.cities = profileUnitOfWork.CityRepository.Get(filter: d => d.IsDeleted == false).OrderBy(d => d.Name).AsEnumerable();
            proUpdateViewModel.schoolLevels = profileUnitOfWork.SchoolLevelRepository.Get(filter: d => d.IsDeleted == false).OrderByDescending(d => d.LevelNum).AsEnumerable();
            proUpdateViewModel.languages = profileUnitOfWork.LanguageRepository.Get(filter: d => d.IsDeleted == false).OrderBy(d => d.Name).AsEnumerable();
            proUpdateViewModel.levels = profileUnitOfWork.LevelRepository.Get(filter: d => d.IsDeleted == false).OrderByDescending(d => d.LevelNum).AsEnumerable();
            proUpdateViewModel.jobLevels = profileUnitOfWork.JobLevelRepository.Get(filter: d => d.IsDeleted == false).OrderByDescending(d => d.LevelNum).AsEnumerable();
            proUpdateViewModel.categories = profileUnitOfWork.CategoryRepository.Get(filter: d => d.IsDeleted == false).OrderBy(d => d.Name).AsEnumerable();

            proUpdateViewModel.contact = profileUnitOfWork.ContactRepository.GetByID(profileUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault().Id);
            if (proUpdateViewModel.contact == null)
            {
                proUpdateViewModel.contact = new Contact();
                proUpdateViewModel.contact.DateofBirth = DateTime.Now;
            }

            proUpdateViewModel.commonInfoItem = new ProCommonInfoItem();
            if (!String.IsNullOrEmpty(profileID))
            {
                int profileIDNum = 0;
                try
                {
                    profileIDNum = Int32.Parse(profileID);
                }
                catch (Exception)
                {
                    return View(proUpdateViewModel);
                }

                Profile profile = profileUnitOfWork.ProfileRepository.GetByID(profileIDNum);
                if (profile != null)
                {
                    proUpdateViewModel.commonInfoItem.profile = profile;

                    ProfileLanguage profileLanguage = profileUnitOfWork.ProfileLanguageRepository.Get(filter: d => d.ProfileID == profileIDNum && d.IsDeleted == false).FirstOrDefault();
                    if (profileLanguage != null){
                        proUpdateViewModel.commonInfoItem.languageID = profileLanguage.LanguageID;
                        proUpdateViewModel.commonInfoItem.level_ID = profileLanguage.Level_ID;
                    }

                    ExpectedCity expectedCity = profileUnitOfWork.ExpectedCityRepository.Get(filter: d => d.ProfileID == profileIDNum && d.IsDeleted == false).FirstOrDefault();
                    if (expectedCity != null){
                        proUpdateViewModel.commonInfoItem.expectedCity = expectedCity.CityID;
                    }

                    ExpectedCategory expectedCategory = profileUnitOfWork.ExpectedCategoryRepository.Get(filter: d => d.ProfileID == profileIDNum && d.IsDeleted == false).FirstOrDefault();
                    if (expectedCategory != null)
                    {
                        proUpdateViewModel.commonInfoItem.categoryID = expectedCategory.CategoryID;
                    }

                    EmploymentHistory employmentHistory = profileUnitOfWork.EmploymentHistoryRepository.Get(s => s.ProfileID == profileIDNum && s.IsDeleted == false).FirstOrDefault();
                    if (employmentHistory != null)
                    {
                        proUpdateViewModel.employmentHistory = employmentHistory;
                    }
                    else
                    {
                        proUpdateViewModel.employmentHistory = new EmploymentHistory();
                        proUpdateViewModel.employmentHistory.EmploymentHistoryID = -1;
                    }

                    EducationHistory educationHistory = profileUnitOfWork.EducationHistoryRepository.Get(s => s.ProfileID == profileIDNum && s.IsDeleted == false).FirstOrDefault();
                    if (educationHistory != null)
                    {
                        proUpdateViewModel.educationHistory = educationHistory;
                    }
                    else
                    {
                        proUpdateViewModel.educationHistory = new EducationHistory();
                        proUpdateViewModel.educationHistory.EducationHistoryID = -1;
                    }

                    ReferencePerson referencePerson = profileUnitOfWork.ReferencePersonRepository.Get(s => s.ProfileID == profileIDNum && s.IsDeleted == false).FirstOrDefault();
                    if (referencePerson != null)
                    {
                        proUpdateViewModel.referencePerson = referencePerson;
                    }
                    else
                    {
                        proUpdateViewModel.referencePerson = new ReferencePerson();
                        proUpdateViewModel.referencePerson.ReferencePersonID = -1;
                    }
                }
                else
                {
                    proUpdateViewModel.employmentHistory = new EmploymentHistory();
                    proUpdateViewModel.employmentHistory.EmploymentHistoryID = -1;
                    proUpdateViewModel.educationHistory = new EducationHistory();
                    proUpdateViewModel.educationHistory.EducationHistoryID = -1;
                    proUpdateViewModel.referencePerson = new ReferencePerson();
                    proUpdateViewModel.referencePerson.ReferencePersonID = -1;
                }
            }
            else
            {
                proUpdateViewModel.employmentHistory = new EmploymentHistory();
                proUpdateViewModel.employmentHistory.EmploymentHistoryID = -1;
                proUpdateViewModel.educationHistory = new EducationHistory();
                proUpdateViewModel.educationHistory.EducationHistoryID = -1;
                proUpdateViewModel.referencePerson = new ReferencePerson();
                proUpdateViewModel.referencePerson.ReferencePersonID = -1;
            }

            return View(proUpdateViewModel);
        }
	}
}