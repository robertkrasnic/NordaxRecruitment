using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nordax.Bank.Recruitment.DataAccess.Entities;
using Nordax.Bank.Recruitment.DataAccess.Exceptions;
using Nordax.Bank.Recruitment.DataAccess.Factories;
using Nordax.Bank.Recruitment.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Nordax.Bank.Recruitment.DataAccess.Repositories
{

    public interface ILoanApplicationRepository : IBaseRepository<LoanApplication>
    {
        Task<Guid> RegisterLoanApplicationAsync(NewLoanApplicationModel loanApplication);
        Task<LoanApplicationInformationModel> GetLoanApplicationAsync(Guid loanApplicationId);
    }

    public class LoanApplicationRepository : BaseRepository<LoanApplication>, ILoanApplicationRepository
    {
        public LoanApplicationRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<IEnumerable<LoanApplication>> GetAll()
        {
            try
            {
                return await this._entities.ToListAsync();
            }
            catch (Exception ex)
            {
                
                return new List<LoanApplication>();
            }
        }

        public async Task<Guid> RegisterLoanApplicationAsync(NewLoanApplicationModel loanApplication)
        {
            var newSubscription = await this.
                _entities
                .AddAsync( new LoanApplication(
                    new Guid(), 
                    loanApplication.LoanAmount, 
                    loanApplication.LoanDurationYears, 
                    loanApplication.LoanType,
                    loanApplication.PersonalInformationId = loanApplication.PersonalInformationId)
                );

            return newSubscription.Entity.Id;
        }

        public async Task<LoanApplicationInformationModel> GetLoanApplicationAsync(Guid loanApplicationId)
        {
            var loanApplication = await this._entities.FirstOrDefaultAsync(s => s.Id == loanApplicationId);
            
            if (loanApplication == null)
                throw new LoanApplicationNotFoundException();

            return loanApplication.ToDomainModel();
        }

        //public async Task DeleteLoanApplication(Guid loanApplicationId)
        //{
        
        //}

        //public async Task SoftDeleteLoanApplication(Guid loanApplicationId)
        //{
        
        //}


    }
 


}