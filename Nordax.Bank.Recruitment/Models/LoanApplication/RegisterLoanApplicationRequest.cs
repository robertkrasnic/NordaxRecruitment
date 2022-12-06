using System.ComponentModel.DataAnnotations;

namespace Nordax.Bank.Recruitment.Models.LoanApplication
{
	public class RegisterLoanApplicationRequest
	{
        public int LoanAmount { get; set; }
        public int LoanDurationYears { get; set; }
        public int MonthlyIncome { get; set; }
        public string CompanyName { get; set; }
        public string EmploymentType { get; set; }
        public int EmployedSince { get; set; }
        public string PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }


}
