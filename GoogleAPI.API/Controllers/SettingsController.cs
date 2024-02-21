using GoogleAPI.Domain.Entities.All_Settings;
using GoogleAPI.Persistance.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NHibernate.Util;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoogleAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly GooleAPIDbContext _context;

        public SettingsController(GooleAPIDbContext context)
        {
            _context = context;
        }
        [HttpPost("add-company-info")]
        public async Task<IActionResult> AddCompanyInfo( CompanyInfo companyInfo)
        {
            CompanyInfo existingCompanyInfo = _context.CompanyInfos.FirstOrDefault();

            if (existingCompanyInfo != null)
            {

                existingCompanyInfo.Id = existingCompanyInfo.Id;
                existingCompanyInfo.CompanyName = companyInfo.CompanyName;
                existingCompanyInfo.LogoUrl = companyInfo.LogoUrl;
                existingCompanyInfo.ServiceSector = companyInfo.ServiceSector;
                existingCompanyInfo.AuthorizedPerson = companyInfo.AuthorizedPerson;
                existingCompanyInfo.Phone = companyInfo.Phone;
                existingCompanyInfo.Fax = companyInfo.Fax;
                existingCompanyInfo.TaxOffice = companyInfo.TaxOffice;
                existingCompanyInfo.TaxNumber = companyInfo.TaxNumber;
                existingCompanyInfo.TradeRegistryNo = companyInfo.TradeRegistryNo;
                existingCompanyInfo.MersisNo = companyInfo.MersisNo;
                existingCompanyInfo.Email = companyInfo.Email;
                existingCompanyInfo.Address = companyInfo.Address;
                existingCompanyInfo.PostalCode = companyInfo.PostalCode;
                existingCompanyInfo.CompanyCountry = companyInfo.CompanyCountry;
                existingCompanyInfo.CompanyCity = companyInfo.CompanyCity;
                existingCompanyInfo.CompanyDistrict = companyInfo.CompanyDistrict;
                existingCompanyInfo.PasswordResetUrl = companyInfo.PasswordResetUrl;
                existingCompanyInfo.WebSiteUrl = companyInfo.WebSiteUrl;

                // Update the CompanyInfo in the database
                _context.CompanyInfos.Update(existingCompanyInfo);
                _context.SaveChanges();
                
                return Ok(true);
            }
            else
            {
                await _context.CompanyInfos.AddAsync(companyInfo);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
           
        }
        [HttpGet("get-company-info")]
        public async Task<IActionResult> GetCompanyInfo()
        {
            List<CompanyInfo>? CompanyInfos = await _context.CompanyInfos.ToListAsync();
            return Ok(CompanyInfos);
        }
        




    }
}
