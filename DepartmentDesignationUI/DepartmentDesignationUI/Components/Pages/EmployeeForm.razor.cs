using DepartmentDesignationUI.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace DepartmentDesignationUI.Components.Pages
{
    public partial class EmployeeForm
    {
        public EmployeeDetails employeeDetails = new();

        public List<EmployeeType> employeeTypes = new List<EmployeeType>();

        public bool IsWFHEnabled = false;

        public bool IsDisplayContract = false;

        public bool IsLaptopSerial = false;
        protected override void OnInitialized()
        {
            employeeDetails.EmployeeType = 0;


            employeeTypes = new List<EmployeeType>
            {
                new EmployeeType { EmployeeTypeId = 1, EmployeeTypeName = "Permanent"},
                new EmployeeType { EmployeeTypeId = 2, EmployeeTypeName = "Temporary"}

            };
        }

        public void OnEmployeeTypeChanged(int employeeTypeId)
        {
            employeeDetails.EmployeeType = employeeTypeId;


            if(employeeTypeId == 1) 
            {
                IsWFHEnabled = true;
                IsDisplayContract = false;
                employeeDetails.ContractDuration = string.Empty;
            }
            else
            {
                employeeDetails.IsWFHAllowed = false;

                IsWFHEnabled = false;

                IsDisplayContract = true;


            }
        }
        public void OnCompanyLaptopChanged(ChangeEventArgs e)
        {
            bool isChecked = e?.Value is bool value && value;

            if (isChecked == true)
            {
                IsLaptopSerial = true;
            }
            else
            {
                IsLaptopSerial = false;
                employeeDetails.LaptopSerialNumber = string.Empty;
            }
        }

    }

}

