using DepartmentDesignationUI.Models;
using Microsoft.AspNetCore.Components;

namespace DepartmentDesignationUI.Components.Pages
{
    public partial class CustomerForm
    {
        public CustomerDetails customerDetails = new();

        public List<Country> countries = new List<Country>();

        public List<State> states = new List<State>();

        public List<State> filteredStates = new List<State>();

        public List<CustomerType> customers = new List<CustomerType>();

        public List<string> communicationModes = new List<string>() { "Call", "SMS", "Email", "Whatsapp" };

        public bool IsStateVisible = false;

        public bool IsCommunicationModeActive = false;

        public bool IsCreditLimit = false;

        public bool IsGSTVisible = false;

        public bool IsSubmitBtnEnabled = false;

        public bool IsCommunicationPreferenceEnabled = false;

        protected override void OnInitialized()
        {
            customerDetails.Country = 0;


            countries = new List<Country>
            {
                new Country { CountryId = 1, CountryName ="India"},
                new Country { CountryId = 2, CountryName ="USA"},
                new Country { CountryId = 3, CountryName ="UK"},

            };

            states = new List<State>
            {
                // States for India (CountryId = 1)
                new State { StateId = 1, StateName = "Maharashtra", CountryId = 1 },
                new State { StateId = 2, StateName = "Karnataka", CountryId = 1 },
                new State { StateId = 3, StateName = "Telangana", CountryId = 1 },

                // States for USA (CountryId = 2)
                new State { StateId = 4, StateName = "California", CountryId = 2 },
                new State { StateId = 5, StateName = "Texas", CountryId = 2 },
                new State { StateId = 6, StateName = "New York", CountryId = 2 },

                // States for UK (CountryId = 3)
                new State { StateId = 7, StateName = "England", CountryId = 3 },
                new State { StateId = 8, StateName = "Scotland", CountryId = 3 },
                new State { StateId = 9, StateName = "Wales", CountryId = 3 }
            };

            customers = new List<CustomerType>
            {
                new CustomerType { CustTypeId = 1, CustTypeName = "Regular"},
                new CustomerType { CustTypeId = 2, CustTypeName = "VIP"},
                new CustomerType { CustTypeId = 3, CustTypeName = "Corporate"},

            };
        }

        public void OnCountryChanged(int countryId)
        {
            customerDetails.Country = countryId;

            if (countryId != 0)
            {
                IsStateVisible = true;

                filteredStates = states
                .Where(x => x.CountryId == countryId)
                .ToList();
            }
            else
            {
                customerDetails.State = string.Empty;
                IsStateVisible = false;
            }

        }

        public void OnCustomerChanged(ChangeEventArgs e)
        {
            bool isChecked = e?.Value is bool value && value;

            if (isChecked == true)
            {
                IsCommunicationModeActive = true;
            }
            else
            {
                customerDetails.CommunicationMode = string.Empty;
                IsCommunicationModeActive = false;
                //customerDetails.CommunicationMode = string.Empty;
            }
        }
        public void OnCommunicationModeChanged(string selectedValue)
        {

            if (!string.IsNullOrEmpty(selectedValue))
            {
                customerDetails.CommunicationMode = selectedValue;

                if (selectedValue == "SMS" || selectedValue == "Email")
                {
                    IsCommunicationPreferenceEnabled = true;
                }
                else
                {
                    IsCommunicationPreferenceEnabled = false;
                    customerDetails.CommunicationPreferences = false; // Uncheck if disabled
                }
            }
            else
            {
                customerDetails.CommunicationMode = string.Empty;
                IsCommunicationPreferenceEnabled = false;
                customerDetails.CommunicationPreferences = false;
            }
        }

        //private string selectedCommunicationMode;

        //private void OnCommunicationModeChanged(ChangeEventArgs e)
        //{
        //    selectedCommunicationMode = e.Value.ToString();

        //}

        public void OnCreditChanged(ChangeEventArgs e)
        {
            bool isChecked = e?.Value is bool value && value;

            if (isChecked == true)
            {
                IsCreditLimit = true;
            }
            else
            {
                customerDetails.CreditLimit = string.Empty;
                IsCreditLimit = false;
                
            }

        }

        public void OnCustomerChanged(int custTypeId)
        {
            customerDetails.CustomerType = custTypeId;

            if (custTypeId != 0)
            {
                IsGSTVisible = true;
            }

            else
            {
                customerDetails.GSTNumber = string.Empty;
                IsGSTVisible = false;
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
