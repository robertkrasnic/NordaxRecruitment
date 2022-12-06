using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nordax.Bank.Recruitment.Shared.Models
{
    public class LoanApplicationModel
    {
        public LoanApplicationModel(PersonalInformationModel personalInformation, List<LoanApplicationInformationModel> loanApplications)
        {
            PersonalInformation = personalInformation;
            LoanApplications = loanApplications;
        }

        public PersonalInformationModel PersonalInformation { get; set; }
        public List<LoanApplicationInformationModel>  LoanApplications { get; set; }
    }


    public class LoanApplicationInformationModel 
    {
        public Guid Id { get; set; }

        [Required] public int Amount { get; set; }

        [Required] public int DurationYears { get; set; }

        public LoanType LoanType { get; set; }

        public DateTime ApplicationDate { get; set; }
    }

    public class PersonalInformationModel
    {
        public PersonalInformationModel(string personalNumber, string firstName, string lastName, string email, int phoneNumber)
        {
            PersonalNumber = personalNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public PersonalInformationModel() 
        {
        
        }

        public Guid Id;
        public string PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }

    public class NewLoanApplicationModel
    {
        public NewLoanApplicationModel(int loanAmount, int loanDurationYears, LoanType loanType)
        {
            LoanAmount = loanAmount;
            LoanDurationYears = loanDurationYears;
            LoanType = loanType;
        }

        public int LoanAmount { get; set; }
        public int LoanDurationYears { get; set; }
        public LoanType LoanType { get; set; }

        public Guid PersonalInformationId { get; set; }
    }



    public class EconomyInformationModel
    {
        public int MonthlyIncome { get; set; }
        public string ComapnyName { get; set; }
        public string CompanyType { get; set; }
        public int EmployedSince { get; set; }
    }

}