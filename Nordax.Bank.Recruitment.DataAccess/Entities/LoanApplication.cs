using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nordax.Bank.Recruitment.Shared.Models;

namespace Nordax.Bank.Recruitment.DataAccess.Entities
{
    public class LoanApplication
    {
        public LoanApplication()
        {
        }

        public LoanApplication(Guid id, int amount, int durationYears, LoanType loanType, Guid personalInfoId)
        {
            this.Id = id;
            this.Amount = amount;
            this.DurationYears = durationYears;
            this.LoanType = loanType;
            this.ApplicationDate = DateTime.Now;
            this.PersonalInfoId = personalInfoId;
        }

        public Guid Id { get; set; }

        [Required] public int Amount { get; set; }

        [Required] public int DurationYears { get; set; }

        public LoanType LoanType { get; set; }
        
        public DateTime ApplicationDate { get; set; }

        [ForeignKey("PersonalInfo")]
        public Guid PersonalInfoId { get; set; }
        public PersonalInfo PersonalInfo { get; set; }

        public LoanApplicationInformationModel ToDomainModel()
        {
            return new LoanApplicationInformationModel
            {
                Id = Id,
                Amount = this.Amount,
                DurationYears = this.DurationYears,
                LoanType = this.LoanType,
                ApplicationDate = this.ApplicationDate,
            };
        }
    }


}