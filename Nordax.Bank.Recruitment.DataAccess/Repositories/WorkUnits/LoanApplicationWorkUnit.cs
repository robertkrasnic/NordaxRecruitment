using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Nordax.Bank.Recruitment.DataAccess.Factories;
using Nordax.Bank.Recruitment.DataAccess.Repositories;

namespace Nordax.Bank.Recruitment.DataAccess.WorkUnits
{
    public interface ILoanApplicationWorkUnit
    {
        ILoanApplicationRepository LoanApplicationRepository { get; }
        IPersonalInfoRepository PersonalInfoRepository { get; }
        Task CompleteAsync();
    }
    public class LoanApplicationWorkUnit : ILoanApplicationWorkUnit, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public ILoanApplicationRepository LoanApplicationRepository { get; }
        public IPersonalInfoRepository PersonalInfoRepository { get; }
        

        public LoanApplicationWorkUnit(IDbContextFactory dbContextFactory)
        {
            this._context = dbContextFactory.Create();
            this.LoanApplicationRepository = new LoanApplicationRepository(_context);
            this.PersonalInfoRepository = new PersonalInfoRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
