using DepartmentDesignationUI.Models;
using Microsoft.AspNetCore.Components;


namespace DepartmentDesignationUI.Components.Pages
{
    public partial class DesignationForm: ComponentBase
    {
        public Employee employeeModel = new();

        public List<Department> departments = new List<Department>();

        public List<Designation> designations = new List<Designation>();

        public List<Designation> filteredDesignations = new List<Designation>();

        protected override void OnInitialized()
        {
            employeeModel.DepartmentId = 0;
            employeeModel.DesignationId = 0;

            departments = new List<Department>
            {
                new Department { DepartmentId = 1, DepartmentName = "Human Resources" },
                new Department { DepartmentId = 2, DepartmentName = "Finance" },
                new Department { DepartmentId = 3, DepartmentName = "IT" },
                new Department { DepartmentId = 4, DepartmentName = "Sales" },
                new Department { DepartmentId = 5, DepartmentName = "Marketing" }
            };

            designations = new List<Designation>
            {
                new Designation { DesignationId = 1, DesignationName = "Software Engineer", DepartmentId = 3 },
                new Designation { DesignationId = 2, DesignationName = "Senior Software Engineer", DepartmentId = 3 },
                new Designation { DesignationId = 3, DesignationName = "HR Manager", DepartmentId = 1 },
                new Designation { DesignationId = 4, DesignationName = "Finance Analyst", DepartmentId = 2 },
                new Designation { DesignationId = 5, DesignationName = "Sales Executive", DepartmentId = 4 },
                new Designation { DesignationId = 6, DesignationName = "Marketing Specialist", DepartmentId = 5 }
            };

            
        }

        public async Task SaveEmployeeForm()
        {
            //
        }

        public void OnDepartmentBasis(int departmentId)
        {
            employeeModel.DepartmentId = departmentId;

            filteredDesignations = designations
                .Where(d => d.DepartmentId == departmentId)
                .ToList();

        }



    }
}
