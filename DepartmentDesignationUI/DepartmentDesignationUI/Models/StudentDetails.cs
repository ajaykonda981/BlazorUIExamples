using System.ComponentModel.DataAnnotations;


namespace DepartmentDesignationUI.Models
{
    public class StudentDetails
    {
        public string StudentName { get; set; } = string.Empty;

        public DateOnly DOB { get; set; }

        public string Gender { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string PhoneNumber { get ; set; }

        public string Address { get; set; } = string.Empty;

        public int Country { get; set; }

        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        //public Dictionary<string, bool> LanguagesKnown { get; set; } = new();
        public string LanguagesKnown { get; set; } = string.Empty;

        public string Course {  get; set; } = string.Empty;

        public string Subjects { get ; set; } = string.Empty;

        public string Hobbies { get; set; } = string.Empty;

        public string Sports { get; set; } = string.Empty;

        public DateOnly RegistrationDate {  get; set; }

        public bool TermsConditions { get; set; }


    }
}
