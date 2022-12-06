using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nordax.Bank.Recruitment.DataAccess.WorkUnits;
using Nordax.Bank.Recruitment.Shared.Models;

namespace Nordax.Bank.Recruitment.Domain.Services
{
    public interface ILoanApplicationService
    {
        Task<Guid> RegisterLoanApplicationAsync(NewLoanApplicationModel loanApplication, PersonalInformationModel personalInfo);
        Task<LoanApplicationModel> GetAllLoanApplicationsByPersonalNumberAsync(string personalNumber);
    }

    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly ILoanApplicationWorkUnit _loanApplicationWorkUnit;


        public LoanApplicationService(ILoanApplicationWorkUnit loanApplicationWorkUnit)
        {
            this._loanApplicationWorkUnit = loanApplicationWorkUnit;
        }

        public async Task<Guid> RegisterLoanApplicationAsync(NewLoanApplicationModel loanApplication, PersonalInformationModel personalInfo)
        {

            var personalInformation = await this
                ._loanApplicationWorkUnit
                .PersonalInfoRepository
                .GetPersonalInfoByPersonalNumberAsync(personalInfo.PersonalNumber);

            if (personalInformation == null)
            {
                loanApplication.PersonalInformationId = await this
                    ._loanApplicationWorkUnit
                    .PersonalInfoRepository
                    .AddPersonalInfoAsync(personalInfo);
            }
            else
            {
                loanApplication.PersonalInformationId = personalInformation.Id;
            }
            
            
            var newLoanApplicationId = await this
                ._loanApplicationWorkUnit
                .LoanApplicationRepository
                .RegisterLoanApplicationAsync(loanApplication);

            await this._loanApplicationWorkUnit.CompleteAsync();
            return newLoanApplicationId;
        }

        public async Task<LoanApplicationModel> GetAllLoanApplicationsByPersonalNumberAsync(string personalNumber)
        {
            var personalInformation = await this
                ._loanApplicationWorkUnit
                .PersonalInfoRepository
                .GetPersonalInfoByPersonalNumberAsync(personalNumber);

            var loanApplications = await this
                ._loanApplicationWorkUnit
                .LoanApplicationRepository
                .WhereAsync(a => a.PersonalInfoId == personalInformation.Id);
                
            var loanApplicationModels = loanApplications.Select(a => a.ToDomainModel()).ToList();

            return new LoanApplicationModel(personalInformation, loanApplicationModels);
        }
    }
}