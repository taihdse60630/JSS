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

        [HttpPost]
        [Authorize(Roles = "Jobseeker")]
        public ActionResult Update([Bind(Include = "FullName, Gender, MaritalStatus, Nationality, Address, DateofBirth, PhoneNumber, CityID, District, IsVisible")] 
                                        Contact contact,
                                   [Bind(Include = "Name, YearOfExperience, HighestSchoolLevel_ID, MostRecentCompany, MostRecentPosition, CurrentJobLevel_ID, ExpectedPosition, ExpectedJobLevel_ID, ExpectedSalary, Objectives")]
                                            Profile profile, string languageID, string level_ID, string expectedCity, string categoryID,
                                   [Bind(Include = "EmploymentHistoryID, Position, Company, WorkingTime, Description")]EmploymentHistory employmentHistory,
                                   [Bind(Include = "EducationHistoryID, Subject, School, SchoolLevel_ID, Achievement")]EducationHistory educationHistory,
                                   [Bind(Include = "ReferencePersonID, ReferencePersonName, ReferencePersonPosition, ReferencePersonCompany, EmailAddress, ReferencePersonPhoneNumber")]ReferencePerson referencePerson)
        {

        }

        [HttpPost]
        [Authorize(Roles = "Jobseeker")]
        public ActionResult UpdateContact([Bind(Include = "FullName, Gender, MaritalStatus, Nationality, Address, DateofBirth, PhoneNumber, CityID, District, IsVisible")] 
                                        Contact contact)
        {
            if (!String.IsNullOrEmpty(contact.FullName)
                && !String.IsNullOrEmpty(contact.PhoneNumber))
            {
                contact.UserID = profileUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault().Id;

                bool result = this.profileUnitOfWork.UpdateContact(contact);

                if (result)
                {
                    return RedirectToAction("List", new { message = "Cập nhật thông tin cá nhân thành công." });
                }
            }

            return RedirectToAction("List", new { message = "Cập nhật thông tin cá nhân thất bại." });
        }

        [HttpPost]
        [Authorize(Roles = "Jobseeker")]
        public ActionResult UpdateCommonInfo([Bind(Include = "Name, YearOfExperience, HighestSchoolLevel_ID, MostRecentCompany, MostRecentPosition, CurrentJobLevel_ID, ExpectedPosition, ExpectedJobLevel_ID, ExpectedSalary, Objectives")]
                                            Profile profile, string languageID, string level_ID, string expectedCity, string categoryID)
        {
            if (!String.IsNullOrEmpty(profile.Name)
                && !String.IsNullOrEmpty(profile.ExpectedPosition)
                && !String.IsNullOrEmpty(profile.Objectives)
                && !String.IsNullOrEmpty(languageID)
                && !String.IsNullOrEmpty(level_ID)
                && !String.IsNullOrEmpty(expectedCity)
                && !String.IsNullOrEmpty(categoryID))
            {
                int languageIDNum = 0;
                int level_IDNum = 0;
                int expectedCityNum = 0;
                int categoryIDNum = 0;

                try
                {
                    languageIDNum = Int32.Parse(languageID);
                    level_IDNum = Int32.Parse(level_ID);
                    expectedCityNum = Int32.Parse(expectedCity);
                    categoryIDNum = Int32.Parse(categoryID);
                }
                catch (Exception)
                {
                    return RedirectToAction("List", new { message = "Cập nhật thông tin chung thất bại." });
                }

                if (profile.CurrentJobLevel_ID == -1)
                {
                    profile.CurrentJobLevel_ID = null;
                }
                profile.CreatedTime = DateTime.Now;
                profile.UpdatedTime = profile.CreatedTime;
                profile.PercentStatus = 25;
                string userId = profileUnitOfWork.AspNetUserRepository.Get(filter: d => d.UserName == User.Identity.Name).FirstOrDefault().Id;
                profile.JobSeekerID = userId;
                profile.IsActive = false;
                profile.IsDeleted = false;

                bool result = this.profileUnitOfWork.UpdateCommonInfo(profile, languageIDNum, level_IDNum, expectedCityNum, categoryIDNum);

                if (result)
                {
                    return RedirectToAction("List", new { message = "Cập nhật thông tin chung thành công." });
                }
            }

            return RedirectToAction("List", new { message = "Cập nhật thông tin chung thất bại." });
        }

        [HttpPost]
        [Authorize(Roles = "Jobseeker")]
        public ActionResult UpdateEmploymentHistory([Bind(Include = "EmploymentHistoryID, Position, Company, YearOfExperience, Description")]EmploymentHistory employmentHistory, string profileID)
        {
            if (!String.IsNullOrEmpty(employmentHistory.Position)
                && !String.IsNullOrEmpty(employmentHistory.Company)
                && !String.IsNullOrEmpty(profileID))
            {
                int profileIDNum = 0;
                try
                {
                    profileIDNum = Int32.Parse(profileID);
                }
                catch (Exception)
                {
                    RedirectToAction("List", new { message = "Cập nhật kinh nghiệm làm việc thất bại." });
                }

                if (employmentHistory.EmploymentHistoryID == -1)
                {
                    // Add new
                    employmentHistory.ProfileID = profileIDNum;
                    employmentHistory.IsDeleted = false;
                    profileUnitOfWork.EmploymentHistoryRepository.Insert(employmentHistory);
                    profileUnitOfWork.Save();
                }
                else
                {
                    // Update
                    employmentHistory.ProfileID = profileIDNum;
                    employmentHistory.IsDeleted = false;
                    profileUnitOfWork.EmploymentHistoryRepository.Update(employmentHistory);
                    profileUnitOfWork.Save();
                }

                return RedirectToAction("List", new { message = "Cập nhật kinh nghiệm làm việc thành công." });
            }

            return RedirectToAction("List", new { message = "Cập nhật kinh nghiệm làm việc thất bại." });
        }

        [HttpPost]
        [Authorize(Roles = "Jobseeker")]
        public ActionResult UpdateEducationHistory([Bind(Include = "EducationHistoryID, Subject, School, SchoolLevel_ID, Achievement")]EducationHistory educationHistory, string profileID)
        {
            if (!String.IsNullOrEmpty(educationHistory.Subject)
                && !String.IsNullOrEmpty(educationHistory.School)
                && !String.IsNullOrEmpty(profileID))
            {
                int profileIDNum = 0;
                try
                {
                    profileIDNum = Int32.Parse(profileID);
                }
                catch (Exception)
                {
                    RedirectToAction("List", new { message = "Cập nhật học vấn thất bại." });
                }

                if (educationHistory.EducationHistoryID == -1)
                {
                    // Add new
                    educationHistory.ProfileID = profileIDNum;
                    educationHistory.IsDeleted = false;
                    profileUnitOfWork.EducationHistoryRepository.Insert(educationHistory);
                    profileUnitOfWork.Save();
                }
                else
                {
                    // Update
                    educationHistory.ProfileID = profileIDNum;
                    educationHistory.IsDeleted = false;
                    profileUnitOfWork.EducationHistoryRepository.Update(educationHistory);
                    profileUnitOfWork.Save();
                }

                return RedirectToAction("List", new { message = "Cập nhật học vấn thành công." });
            }

            return RedirectToAction("List", new { message = "Cập nhật học vấn thất bại." });
        }

        [HttpPost]
        [Authorize(Roles = "Jobseeker")]
        public ActionResult UpdateReferencePerson([Bind(Include = "ReferencePersonID, FullName, Position, Company, EmailAddress, PhoneNumber")]ReferencePerson referencePerson, string profileID)
        {
            if (!String.IsNullOrEmpty(referencePerson.FullName)
                && !String.IsNullOrEmpty(referencePerson.Position)
                && !String.IsNullOrEmpty(referencePerson.Company)
                && !String.IsNullOrEmpty(referencePerson.EmailAddress)
                && !String.IsNullOrEmpty(profileID))
            {
                int profileIDNum = 0;
                try
                {
                    profileIDNum = Int32.Parse(profileID);
                }
                catch (Exception)
                {
                    RedirectToAction("List", new { message = "Cập nhật thông tin tham khảo thất bại." });
                }

                if (referencePerson.ReferencePersonID == -1)
                {
                    // Add new
                    referencePerson.ProfileID = profileIDNum;
                    referencePerson.IsDeleted = false;
                    profileUnitOfWork.ReferencePersonRepository.Insert(referencePerson);
                    profileUnitOfWork.Save();
                }
                else
                {
                    // Update
                    referencePerson.ProfileID = profileIDNum;
                    referencePerson.IsDeleted = false;
                    profileUnitOfWork.ReferencePersonRepository.Update(referencePerson);
                    profileUnitOfWork.Save();
                }

                return RedirectToAction("List", new { message = "Cập nhật thông tin tham khảo thành công." });
            }

            return RedirectToAction("List", new { message = "Cập nhật thông tin tham khảo thất bại." });
        }

        [HttpPost]
        [Authorize(Roles = "Jobseeker")]
        public ActionResult Delete(string profileID)
        {
            if (!String.IsNullOrEmpty(profileID))
            {
                int profileIDNum;

                try
                {
                    profileIDNum = Int32.Parse(profileID);
                }
                catch (Exception)
                {
                    return RedirectToAction("List");
                }

                Profile profile = profileUnitOfWork.ProfileRepository.GetByID(profileIDNum);

                if (profile != null)
                {
                    profile.IsActive = false;
                    profile.IsDeleted = true;
                    profileUnitOfWork.ProfileRepository.Update(profile);

                    IEnumerable<ProfileLanguage> profileLanguages = profileUnitOfWork.ProfileLanguageRepository.Get(s => s.ProfileID == profile.ProfileID).AsEnumerable();
                    if (profileLanguages != null)
                    {
                        foreach (ProfileLanguage item in profileLanguages)
                        {
                            item.IsDeleted = true;
                            profileUnitOfWork.ProfileLanguageRepository.Update(item);
                        }
                    }

                    IEnumerable<ExpectedCity> expectedCities = profileUnitOfWork.ExpectedCityRepository.Get(s => s.ProfileID == profile.ProfileID).AsEnumerable();
                    if (expectedCities != null)
                    {
                        foreach (ExpectedCity item in expectedCities)
                        {
                            item.IsDeleted = true;
                            profileUnitOfWork.ExpectedCityRepository.Update(item);
                        }
                    }

                    IEnumerable<ExpectedCategory> expectedCategories = profileUnitOfWork.ExpectedCategoryRepository.Get(s => s.ProfileID == profile.ProfileID).AsEnumerable();
                    if (expectedCategories != null)
                    {
                        foreach (ExpectedCategory item in expectedCategories)
                        {
                            item.IsDeleted = false;
                            profileUnitOfWork.ExpectedCategoryRepository.Update(item);
                        }
                    }

                    profileUnitOfWork.Save();
                    return RedirectToAction("List", new { message = "Xóa hồ sơ " + profile.Name + " thành công." });
                }

                return RedirectToAction("List", new { message = "Xóa hồ sơ " + profile.Name + " thất bại." });
            }

            return RedirectToAction("List", new { message = "Xóa hồ sơ thất bại." });
        }
	}
}