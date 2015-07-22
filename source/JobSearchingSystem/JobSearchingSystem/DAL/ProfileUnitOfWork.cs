using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobSearchingSystem.Models;
using System.Data;

namespace JobSearchingSystem.DAL
{
    public class ProfileUnitOfWork : UnitOfWork
    {
        public IEnumerable<ProListItem> GetAllProList()
        {
            int no = 0;
            IEnumerable<ProListItem> outList = (from p in this.ProfileRepository.Get()
                                                where p.IsDeleted == false
                                                select new ProListItem {
                                                    ProfileID = p.ProfileID,
                                                    No = ++no,
                                                    ProfileName = p.Name,
                                                    IsActive = p.IsActive,
                                                    ViewedCount = (from pr in this.ViewProfileRepository.Get()
                                                                   where pr.ProfileID == p.ProfileID
                                                                   select pr).Count(),
                                                    UpdatedTime = p.UpdatedTime,
                                                    PerccentStatus = p.PercentStatus,
                                                    IsDeleted = p.IsDeleted
                                                }).AsEnumerable();

            return outList;
        }

        public bool UpdateContact(Contact contact)
        {
            Jobseeker jobseeker = this.JobseekerRepository.GetByID(contact.UserID);
            if (jobseeker == null)
            {
                return false;
            }
            if (jobseeker.IsDeleted == true)
            {
                return false;
            }

            try
            {
                if (this.ContactRepository.GetByID(jobseeker.JobSeekerID) == null)
                {
                    this.ContactRepository.Insert(contact);
                    this.Save();
                }
                else
                {
                    Contact contactToUpdate = this.ContactRepository.GetByID(jobseeker.JobSeekerID);
                    contactToUpdate.FullName = contact.FullName;
                    contactToUpdate.Gender = contact.Gender;
                    contactToUpdate.MaritalStatus = contact.MaritalStatus;
                    contactToUpdate.Nationality = contact.Nationality;
                    contactToUpdate.Address = contact.Address;
                    contactToUpdate.DateofBirth = contact.DateofBirth;
                    contactToUpdate.PhoneNumber = contact.PhoneNumber;
                    contactToUpdate.CityID = contact.CityID;
                    contactToUpdate.District = contact.District;
                    contactToUpdate.IsVisible = contact.IsVisible;
                    this.ContactRepository.Update(contactToUpdate);
                    this.Save();
                }
            }
            catch (DataException)
            {
                return false;
            }

            return true;
        }

        public bool UpdateCommonInfo(Profile profile, int languageID, int level_ID, int expectedCityNum, int categoryID)
        {
            Jobseeker jobseeker = this.JobseekerRepository.GetByID(profile.JobSeekerID);
            if (jobseeker == null)
            {
                return false;
            }
            if (jobseeker.IsDeleted == true)
            {
                return false;
            }

            try
            {
                if (this.ProfileRepository.Get(filter: d => d.Name == profile.Name).FirstOrDefault() == null)
                {
                    // Add new
                    this.ProfileRepository.Insert(profile);
                    this.Save();

                    Profile insertedProfile = this.ProfileRepository.Get(filter: d => d.Name == profile.Name).LastOrDefault();
                    if (insertedProfile == null)
                    {
                        return false;
                    }

                    Language language = this.LanguageRepository.GetByID(languageID);
                    Level level = this.LevelRepository.GetByID(level_ID);
                    if (language != null && level != null)
                    {
                        ProfileLanguage profileLanguage = new ProfileLanguage();
                        profileLanguage.LanguageID = language.LanguageID;
                        profileLanguage.Language = language;
                        profileLanguage.ProfileID = insertedProfile.ProfileID;
                        profileLanguage.Profile = insertedProfile;
                        profileLanguage.Level_ID = level.Level_ID;
                        profileLanguage.Level = level;
                        profileLanguage.IsDeleted = false;

                        this.ProfileLanguageRepository.Insert(profileLanguage);
                    }

                    City city = this.CityRepository.GetByID(expectedCityNum);
                    if (city != null)
                    {
                        ExpectedCity expectedCity = new ExpectedCity();
                        expectedCity.ProfileID = insertedProfile.ProfileID;
                        expectedCity.Profile = insertedProfile;
                        expectedCity.CityID = city.CityID;
                        expectedCity.City = city;
                        expectedCity.IsDeleted = false;

                        this.ExpectedCityRepository.Insert(expectedCity);
                    }

                    Category category = this.CategoryRepository.GetByID(categoryID);
                    if (category != null)
                    {
                        ExpectedCategory expectedCategory = new ExpectedCategory();
                        expectedCategory.ProfileID = insertedProfile.ProfileID;
                        expectedCategory.Profile = insertedProfile;
                        expectedCategory.CategoryID = category.CategoryID;
                        expectedCategory.Category = category;
                        expectedCategory.IsDeleted = false;

                        this.ExpectedCategoryRepository.Insert(expectedCategory);
                    }

                    this.Save();
                }
                else
                {
                    // Update
                    Profile profileToUpdate = this.ProfileRepository.Get(filter: d => d.Name == profile.Name).FirstOrDefault();
                    profileToUpdate.YearOfExperience = profile.YearOfExperience;
                    profileToUpdate.HighestSchoolLevel_ID = profile.HighestSchoolLevel_ID;
                    profileToUpdate.MostRecentCompany = profile.MostRecentCompany;
                    profileToUpdate.MostRecentPosition = profile.MostRecentPosition;
                    profileToUpdate.CurrentJobLevel_ID = profile.CurrentJobLevel_ID;
                    profileToUpdate.ExpectedPosition = profile.ExpectedPosition;
                    profileToUpdate.ExpectedJobLevel_ID = profile.ExpectedJobLevel_ID;
                    profileToUpdate.ExpectedSalary = profile.ExpectedSalary;
                    profileToUpdate.UpdatedTime = DateTime.Now;
                    profileToUpdate.Objectives = profile.Objectives;

                    this.ProfileRepository.Update(profileToUpdate);

                    IEnumerable<ProfileLanguage> oldProfileLanguages = this.ProfileLanguageRepository.Get(filter: d => d.ProfileID == profileToUpdate.ProfileID).AsEnumerable();
                    foreach (ProfileLanguage item in oldProfileLanguages)
                    {
                        if (item.IsDeleted == false)
                        {
                            item.IsDeleted = true;
                            this.ProfileLanguageRepository.Update(item);
                        }
                    }
                    ProfileLanguage profileLanguage = this.ProfileLanguageRepository.Get(s => s.ProfileID == profileToUpdate.ProfileID && s.LanguageID == languageID).FirstOrDefault();
                    if (profileLanguage != null)
                    {
                        profileLanguage.IsDeleted = false;
                        this.ProfileLanguageRepository.Update(profileLanguage);
                    }
                    else
                    {
                        Language language = this.LanguageRepository.GetByID(languageID);
                        Level level = this.LevelRepository.GetByID(level_ID);
                        if (language != null && level != null)
                        {
                            ProfileLanguage newProfileLanguage = new ProfileLanguage();
                            newProfileLanguage.LanguageID = language.LanguageID;
                            newProfileLanguage.Language = language;
                            newProfileLanguage.ProfileID = profileToUpdate.ProfileID;
                            newProfileLanguage.Profile = profileToUpdate;
                            newProfileLanguage.Level_ID = level.Level_ID;
                            newProfileLanguage.Level = level;
                            newProfileLanguage.IsDeleted = false;

                            this.ProfileLanguageRepository.Insert(newProfileLanguage);
                        }
                    }
                    
                    IEnumerable<ExpectedCity> oldExpectedCities = this.ExpectedCityRepository.Get(filter: d => d.ProfileID == profileToUpdate.ProfileID).AsEnumerable();
                    foreach (ExpectedCity item in oldExpectedCities)
                    {
                        if (item.IsDeleted == false)
                        {
                            item.IsDeleted = true;
                            this.ExpectedCityRepository.Update(item);
                        }
                    }
                    ExpectedCity expectedCity = this.ExpectedCityRepository.Get(s => s.ProfileID == profileToUpdate.ProfileID && s.CityID == expectedCityNum).FirstOrDefault();
                    if (expectedCity != null)
                    {
                        expectedCity.IsDeleted = false;
                        this.ExpectedCityRepository.Update(expectedCity);
                    }
                    else
                    {
                        City city = this.CityRepository.GetByID(expectedCityNum);
                        if (city != null)
                        {
                            ExpectedCity newExpectedCity = new ExpectedCity();
                            newExpectedCity.ProfileID = profileToUpdate.ProfileID;
                            newExpectedCity.Profile = profileToUpdate;
                            newExpectedCity.CityID = city.CityID;
                            newExpectedCity.City = city;
                            newExpectedCity.IsDeleted = false;

                            this.ExpectedCityRepository.Insert(newExpectedCity);
                        }
                    }

                    IEnumerable<ExpectedCategory> oldExpectedCategories = this.ExpectedCategoryRepository.Get(filter: d => d.ProfileID == profileToUpdate.ProfileID).AsEnumerable();
                    foreach (ExpectedCategory item in oldExpectedCategories)
                    {
                        if (item.IsDeleted == false)
                        {
                            item.IsDeleted = true;
                            this.ExpectedCategoryRepository.Update(item);
                        }
                    }
                    ExpectedCategory expectedCategory = this.ExpectedCategoryRepository.Get(s => s.ProfileID == profileToUpdate.ProfileID && s.CategoryID == categoryID).FirstOrDefault();
                    if (expectedCategory != null)
                    {
                        expectedCategory.IsDeleted = false;
                        this.ExpectedCategoryRepository.Update(expectedCategory);
                    }
                    else
                    {
                        Category category = this.CategoryRepository.GetByID(categoryID);
                        if (category != null)
                        {
                            ExpectedCategory newExpectedCategory = new ExpectedCategory();
                            newExpectedCategory.ProfileID = profileToUpdate.ProfileID;
                            newExpectedCategory.Profile = profileToUpdate;
                            newExpectedCategory.CategoryID = category.CategoryID;
                            newExpectedCategory.Category = category;
                            newExpectedCategory.IsDeleted = false;

                            this.ExpectedCategoryRepository.Insert(newExpectedCategory);
                        }
                    }

                    this.Save();
                }
            }
            catch (DataException)
            {
                return false;
            }

            return true;
        }
    }
}