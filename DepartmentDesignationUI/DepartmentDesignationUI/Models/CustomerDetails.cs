namespace DepartmentDesignationUI.Models
{
    public class CustomerDetails
    {
        public string CustomerName { get; set; }

        public string Email { get; set; } = string.Empty;

        public int MobileNumber { get; set; }

        public int Country { get; set; }

        public string State {  get; set; } = string.Empty;

        public bool IsPreferredCustomer { get; set; }

        public string CommunicationMode { get; set; } = string.Empty;

        public bool CommunicationPreferences { get; set; }

        public bool IsCreditNeeded { get; set; }

        public string CreditLimit { get; set; } = string.Empty;

        public int CustomerType { get; set; } 

        public string GSTNumber { get; set; } = string.Empty;

        public bool TermsConditions { get; set; }


    }
}
