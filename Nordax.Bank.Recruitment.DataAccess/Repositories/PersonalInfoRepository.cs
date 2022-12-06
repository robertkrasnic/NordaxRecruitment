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
using System.Linq;

namespace Nordax.Bank.Recruitment.DataAccess.Repositories
{
    public interface IPersonalInfoRepository
    {
        Task<Guid> AddPersonalInfoAsync(PersonalInformationModel loanApplication);
        Task<PersonalInformationModel> GetPersonalInfoByPersonalNumberAsync(string personalNumber);
    }

    public class PersonalInfoRepository : BaseRepository<PersonalInfo>, IPersonalInfoRepository
    {
        public PersonalInfoRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<IEnumerable<PersonalInfo>> GetAll()
        {
            try
            {
                return await this
                    ._entities
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                
                return new List<PersonalInfo>();
            }
        }

        public async Task<Guid> AddPersonalInfoAsync(PersonalInformationModel personalInfoModel)
        {
            var newPersonalInfo = await this
                ._entities
                .AddAsync( new PersonalInfo( 
                    id: new Guid(),
                    personalNumber: personalInfoModel.PersonalNumber,
                    firstName: personalInfoModel.FirstName,
                    email: personalInfoModel.Email,
                    lastName: personalInfoModel.LastName,
                    phoneNumber: personalInfoModel.PhoneNumber)
                );

            return newPersonalInfo.Entity.Id;
        }


        public async Task<PersonalInformationModel> GetPersonalInfoByPersonalNumberAsync(string personalNumber)
        {
            var latesPersonalInfo = await this
                ._entities
                .SingleOrDefaultAsync(pi => pi.PersonalNumber == personalNumber);

            return latesPersonalInfo?.ToDomainModel();   
        }


        // TODO: Delete 
    }



}