using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nordax.Bank.Recruitment.Domain.Services;
using Nordax.Bank.Recruitment.Models.LoanApplication;
using Nordax.Bank.Recruitment.Shared.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Nordax.Bank.Recruitment.Controllers
{
    [ApiController]
    [Route("api/loan-application")]
    public class LoanApplicationController : ControllerBase
    {        
        private readonly ILoanApplicationService _loanApplicationService;


        public LoanApplicationController(ILoanApplicationService loanApplicationService)
        {
            this._loanApplicationService = loanApplicationService;
        }

        [HttpGet("attachment")]
        [SwaggerResponse(StatusCodes.Status200OK, "File uploaded successfully", typeof(FileResponse))]
        [ProducesResponseType(typeof(FileResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            //TODO: Store file
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Loan Application registered successfully")]
        public async Task<IActionResult> RegisterLoanApplication([FromBody] RegisterLoanApplicationRequest request)
        {
            var loanApp = new NewLoanApplicationModel(request.LoanAmount, request.LoanDurationYears, LoanType.PrivateLoan);
            var personalInfo = new PersonalInformationModel(request.PersonalNumber, request.FirstName, request.LastName, request.Email, request.PhoneNumber);
            //var employmetInfo = new EconomyInformationModel { ComapnyName = request.CompanyName, EmployedSince = request.EmployedSince, MonthlyIncome = request.MonthlyIncome };
            
            var newLoanApplicationId = await this._loanApplicationService.RegisterLoanApplicationAsync(loanApp, personalInfo);
            
            return Ok(personalInfo.PersonalNumber);
        }

        [HttpGet("{personalNumber}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Loan Application fetched successfully", typeof(LoanApplicationResponse))]
        [ProducesResponseType(typeof(LoanApplicationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLoanApplications(string personalNumber)
        {
            var loanApplications = await this._loanApplicationService.GetAllLoanApplicationsByPersonalNumberAsync(personalNumber);
                
            return Ok(new LoanApplicationResponse(loanApplications));
        }
	}
}