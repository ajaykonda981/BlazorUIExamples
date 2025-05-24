namespace DepartmentDesignationUI.Models
{
    public class EmployeeDetails
    {
        public string EmployeeName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public int EmployeeType { get; set; }

        public bool IsWFHAllowed { get; set; }

        public string ContractDuration { get; set; }

        public string Country { get; set; }

        public string State {  get; set; }

        public DateOnly DateOfJoining { get; set; }

        public bool IsCompanyLaptopOrNot {  get; set; }

        public string LaptopSerialNumber { get; set; }

        public string Gender { get; set; }

        public bool IsNightShift { get; set; }
    }
}
