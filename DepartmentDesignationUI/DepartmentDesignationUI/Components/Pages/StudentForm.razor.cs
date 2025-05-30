using DepartmentDesignationUI.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;

namespace DepartmentDesignationUI.Components.Pages
{
    public partial class StudentForm
    {
        public StudentDetails studentDetails = new();

        public bool IsDOBEnabled = false;

        public List<string> genders = new List<string>() { "Male", "Female", "Others" };

        public bool IsGenderVisible = false;

        public bool IsEmailEnabed = false;

        public bool IsPwdVisible = false;

        public bool IsPhoneNumberVisible = false;

        public bool IsPhoneNumberEnabled = false;

        public bool IsAddressVisible = false;

        public bool IsCountryEnable = false;

        public bool IsStateVisible = false;

        public bool IsCityEnabled = false;

        public bool IsLanguageEnabled = false;

        public bool IsCourseEnabled = false;

        public bool IsSubjectEnabled = false;

        public bool IsSubjectVisible = false;

        public bool IsHobbyEnabled = false;

        public bool IsSportsVisible = false;

        public bool IsRegistrationDateEnabled = false;

        public bool IsSubmitBtnEnabled = false;

        public List<Country> countries = new List<Country>();

        public List<State> states = new List<State>();

        public List<CityOfStudent> cities = new List<CityOfStudent>();

        public List<Course> courses = new List<Course>();

        public List<LanguageOption> languages = new List<LanguageOption>();

        public List<Subject> subjects = new List<Subject>();

        public List<Hobby> hobbies = new List<Hobby>();

        public List<Sport> sports = new List<Sport>();

       

        protected override void OnInitialized()
        {

            countries = new List<Country>
            {
                new Country { CountryId = 1, CountryName ="India"},
                new Country { CountryId = 2, CountryName ="USA"},
                new Country { CountryId = 3, CountryName ="UK"},

            };

            states = new List<State>
            {
                // States for India (CountryId = 1)
                new State { StateId = 1, StateName = "Maharashtra"},
                new State { StateId = 2, StateName = "Karnataka"},
                new State { StateId = 3, StateName = "Telangana"},

                // States for USA (CountryId = 2)
                new State { StateId = 4, StateName = "California"},
                new State { StateId = 5, StateName = "Texas"},
                new State { StateId = 6, StateName = "New York"},

                // States for UK (CountryId = 3)
                new State { StateId = 7, StateName = "England" },
                new State { StateId = 8, StateName = "Scotland"},
                new State { StateId = 9, StateName = "Wales" }
            };

            cities = new List<CityOfStudent>
            {
                new CityOfStudent { CityId = 1, CityName = "New York" },
                new CityOfStudent { CityId = 2, CityName = "Los Angeles" },
                new CityOfStudent { CityId = 3, CityName = "Chennai" },
                new CityOfStudent { CityId = 4, CityName = "Hyderabad" },
                new CityOfStudent { CityId = 5, CityName = "Miami" },
                new CityOfStudent { CityId = 6, CityName = "San Francisco" },
                new CityOfStudent { CityId = 7, CityName = "Seattle" },
            };

            languages = new List<LanguageOption>
            {
                new LanguageOption { Name = "English", IsSelected = false },
                new LanguageOption { Name = "Spanish", IsSelected = false },
                new LanguageOption { Name = "French", IsSelected = false },
                new LanguageOption { Name = "German", IsSelected = false },
                new LanguageOption { Name = "Hindi", IsSelected = false }
            };


            courses = new List<Course>
            {
                new Course { CourseId = 1, CourseName = "Computer Science" },
                new Course { CourseId = 2, CourseName = "Mathematics" },
                new Course { CourseId = 3, CourseName = "Physics" },
                new Course { CourseId = 4, CourseName = "Chemistry" },
                new Course { CourseId = 5, CourseName = "Biology" },
                new Course { CourseId = 6, CourseName = "English Literature" },
                new Course { CourseId = 7, CourseName = "Economics" }
            };

            subjects = new List<Subject>
            {
                new Subject { SubjectName = "Mathematics", IsSubjectSelected = false },
                new Subject { SubjectName = "Physics", IsSubjectSelected = false  },
                new Subject { SubjectName = "Chemistry", IsSubjectSelected = false  },
                new Subject { SubjectName = "Biology", IsSubjectSelected = false  },
                new Subject { SubjectName = "Computer Science", IsSubjectSelected = false  },
                new Subject { SubjectName = "History" , IsSubjectSelected = false },
                new Subject { SubjectName = "Geography", IsSubjectSelected = false  }
            };

            hobbies = new List<Hobby>
            {
                new Hobby { HobbyId = 1, HobbyName ="Gardening", IsHobbySelected = false},
                new Hobby { HobbyId = 2, HobbyName ="Dancing", IsHobbySelected = false},
                new Hobby { HobbyId = 3, HobbyName ="Sports", IsHobbySelected = false},

            };

            sports = new List<Sport>
            {
                new Sport { SportId = 1, SportName ="Cricket"},
                new Sport { SportId = 2, SportName="Tennis"},
                new Sport { SportId = 3, SportName="Basketball"},

            };


        }
        public async Task OnStudentNameChanged(ChangeEventArgs e)
        {
            if (e?.Value is string newValue)
            {
                studentDetails.StudentName = newValue;

                // Enable/disable DOB based on whether the name is not empty or null
                IsDOBEnabled = !string.IsNullOrWhiteSpace(newValue);
            }
            else
            {
                IsDOBEnabled = false;
            }

            await Task.CompletedTask;
        }


        public void OnDOBChanged(DateOnly selectedValue)
        {


            studentDetails.DOB = selectedValue;
            if (selectedValue != null)
            {
                IsGenderVisible = true;
            }
            else
            {
                IsGenderVisible = false;
            }
        }

        public void OnGenderChanged(string selectedValue)
        {
            studentDetails.Gender = selectedValue;

            if (selectedValue != null)
            {
                IsEmailEnabed = true;
            }

            else
            {
                IsEmailEnabed = false;
            }

        }

        public void OnEmailChanged(ChangeEventArgs e)
        {
            if (e?.Value is string newValue)
            {
                studentDetails.Email = newValue;
                IsPwdVisible = true;

                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                bool IsEmailValid = Regex.IsMatch(newValue, emailPattern);

                IsPhoneNumberEnabled = IsEmailValid;

            }

            else
            {
                IsPwdVisible = false;
                IsPhoneNumberEnabled = false;
            }

        }

        

        public void OnPhoneNumberChanged(string phoneNumber)
        {
            studentDetails.PhoneNumber = phoneNumber;
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                IsAddressVisible = false;
            }
            else
            {
                string phonePattern = @"^\+?[\d\s\-]{7,15}$";
                var isMatched = Regex.IsMatch(phoneNumber, phonePattern);

                if (isMatched)
                {
                    IsAddressVisible = true;
                }
                else
                {
                    IsAddressVisible = false;
                }
            }

            //StateHasChanged();
        }

        public void OnAddressChanged(string selectedValue)
        {
            studentDetails.Address = selectedValue;

            if(selectedValue != null) 
            {
                IsCountryEnable = true;
            }
            else
            {
                //studentDetails.Address = string.Empty;
                IsCountryEnable = false;
            }

        }

        public void OnCountryChanged(int selectedValue)
        {
            studentDetails.Country = selectedValue;
            if (selectedValue > 0)
            {
                IsStateVisible = true;

                if(selectedValue == 1)
                {
                    IsLanguageEnabled = true;
                }
                else
                {
                    IsLanguageEnabled = false;
                }

            }
            else
            {
                IsStateVisible = false;
            }

            
            

        }

        public void OnStateChanged(string selectedValue)
        {
            studentDetails.State = selectedValue;

            if (!string.IsNullOrWhiteSpace(selectedValue))
            {
                IsCityEnabled = true;
            }
            else
            {
                studentDetails.City = string.Empty;
                IsCityEnabled = false;
            }

        }

        public void OnLanguageChanged(LanguageOption language, bool isChecked)
        {
            language.IsSelected = isChecked;

            IsCourseEnabled = languages.Any(l => l.IsSelected);


        }


        public void OnCourseChanged(string selectedValue) 
        {
            studentDetails.Course = selectedValue;

            if(!string.IsNullOrWhiteSpace(selectedValue))
            {
                IsSubjectVisible = true;
            }
            else
            {
                IsSubjectVisible = false;
            }
        }
        public void OnSubjectChanged(Subject subject, bool isChecked)
        {
            subject.IsSubjectSelected = isChecked;

            IsHobbyEnabled = subjects.Count(s => s.IsSubjectSelected) >= 2;

        }

        

        public void OnHobbyChanged(Hobby hobby, bool isChecked)
        {
            hobby.IsHobbySelected = isChecked;
            
            IsSportsVisible = hobbies.Any(h => h.HobbyName == "Sports" && h.IsHobbySelected);
        }

        public void OnSportsChanged(string  selectedValue) 
        {
            studentDetails.Sports = selectedValue;

            if(!string.IsNullOrWhiteSpace(selectedValue))
            {
                IsRegistrationDateEnabled = true;
            }
            else
            {
                IsRegistrationDateEnabled = false;
            }
        }

        public void OnTermsChanged(ChangeEventArgs e)
        {
            bool isChecked = e?.Value is bool value && value;

            if (isChecked == true)
            {
                IsSubmitBtnEnabled = true;
            }
            else
            {

                IsSubmitBtnEnabled = false;

            }

        }

    }
}

