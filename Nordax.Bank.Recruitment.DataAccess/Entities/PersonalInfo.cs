using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nordax.Bank.Recruitment.Shared.Models;

namespace Nordax.Bank.Recruitment.DataAccess.Entities
{
    public class PersonalInfo
    {
        public PersonalInfo()
        {
        }

        public PersonalInfo(Guid id, string personalNumber, string firstName, string lastName, string email, int phoneNumber)
        {
            Id = id;
            PersonalNumber = personalNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; set; }
        public string PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<LoanApplication> LoanApplications { get; set; }

        public PersonalInformationModel ToDomainModel()
        {
            return new PersonalInformationModel()
            {
                Id = this.Id,
                PersonalNumber = this.PersonalNumber,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                PhoneNumber =this.PhoneNumber
             
            };
        }
    }


}