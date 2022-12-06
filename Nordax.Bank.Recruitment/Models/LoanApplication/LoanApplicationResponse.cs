using Nordax.Bank.Recruitment.DataAccess.Entities;
using Nordax.Bank.Recruitment.Shared.Models;
using System.Collections.Generic;

namespace Nordax.Bank.Recruitment.Models.LoanApplication
{
	public class LoanApplicationResponse
	{
        public List<LoanApplicationInformationModel> LoanApplications { get; set; }
        public PersonalInformationModel PersonalInformation { get; set; }
        

        public LoanApplicationResponse(List<LoanApplicationInformationModel> loanApplications, PersonalInformationModel personalInformation)
        {
            this.LoanApplications = loanApplications;
            this.PersonalInformation = personalInformation;
        }
        
        public LoanApplicationResponse(LoanApplicationModel loanApplicationModel)
        {
            this.LoanApplications = loanApplicationModel.LoanApplications;
            this.PersonalInformation = loanApplicationModel.PersonalInformation;
        }
    }

    
}
