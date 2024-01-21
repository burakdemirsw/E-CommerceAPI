
using Google.Rpc;
using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    //[Authorize(AuthenticationSchemes ="Admin")]
    public class AddressController : ControllerBase
    {
        private readonly GooleAPIDbContext _context;

        public AddressController(GooleAPIDbContext context)
        {
            _context = context;
        }
        [HttpGet("get-countries/{id}")]
        public async Task<ActionResult> GetCountries(int id)
        {
            if (id == -1)
            {
                List<Country_VM> models = _context.Countries.ToList().Select(p => new Country_VM
                {
                    Id = p.Id,
                    
                    Description = p.Description,
                }).ToList();
                return Ok(models); //return Ok()(models);
            }
            else
            {
                List<Country_VM> models = _context.Countries.Where(p => p.Id == id).Select(p => new Country_VM
                {
                    Id = p.Id,
                    
                    Description = p.Description,
                }).ToList();
                return Ok(models); //return Ok()(models);
            }


        }



        [HttpPost("add-country")]
        public async Task<ActionResult> AddCountry([FromBody] Country_VM country)
        {
            if (ModelState.IsValid)
            {
                var newCountry = new Country
                {
                    Description = country.Description,
                    
                   
                };

                _context.Countries.Add(newCountry);
                await _context.SaveChangesAsync();

                return Ok(true); //return Ok()(models);
            }

            return BadRequest(false);
        }

        [HttpPut("update-country/{id}")]
        public async Task<ActionResult> UpdateCountry(int id, [FromBody] Country_VM country)
        {
            var existingCountry = await _context.Countries.FindAsync(id);

            if (existingCountry == null)
            {
                return NotFound("Country not found.");
            }

            existingCountry.Description = country.Description;
       
            // Update other properties as needed

            _context.Countries.Update(existingCountry);
            await _context.SaveChangesAsync();

            return Ok(true);
        }
        [HttpDelete("delete-country/{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            var existingCountry = await _context.Countries.FindAsync(id);

            if (existingCountry == null)
            {
                return NotFound(false);
            }

            _context.Countries.Remove(existingCountry);
            await _context.SaveChangesAsync();

            return Ok(true);
        }



        [HttpPost("add-province")]
        public async Task<ActionResult> AddProvince([FromBody] Province_VM province)
        {
            if (ModelState.IsValid)
            {
                var newProvince = new Province
                {
                    CountryId = province.CountryId,
                    Description = province.Description,
                };

                _context.Provinces.Add(newProvince);
                await _context.SaveChangesAsync();

               return Ok(true); //return Ok()("Province added successfully.");
            }

            return BadRequest(false);
        }
        [HttpPut("update-province/{id}")]
        public async Task<ActionResult> UpdateProvince(int id, [FromBody] Province_VM province)
        {
            var existingProvince = await _context.Provinces.FindAsync(id);

            if (existingProvince == null)
            {
                return NotFound(false); //return NotFound("Province not found.");
            }

            existingProvince.CountryId = province.CountryId;
            existingProvince.Description = province.Description;

            _context.Provinces.Update(existingProvince);
            await _context.SaveChangesAsync();

           return Ok(true); //return Ok()("Province updated successfully.");
        }

        [HttpDelete("delete-province/{id}")]
        public async Task<ActionResult> DeleteProvince(int id)
        {
            var existingProvince = await _context.Provinces.FindAsync(id);

            if (existingProvince == null)
            {
                return NotFound(false); return NotFound(false); //return NotFound("Province not found.");
            }

            _context.Provinces.Remove(existingProvince);
            await _context.SaveChangesAsync();

           return Ok(true); //return Ok()("Province deleted successfully.");
        }


        [HttpGet("get-provinces/{id}")]
        public async Task<ActionResult> GetProvinces(int id)
        {
            if (id == -1)
            {
                List<Province_VM>  models = _context.Provinces.ToList().Select(p => new Province_VM { 
                    Id = p.Id,
                CountryId = p.CountryId,
                Description = p.Description,
                }).ToList();
               return Ok(models); //return Ok()(models);
            }
            else
            {
                List<Province_VM> models = _context.Provinces.Where(p=>p.Id == id).Select(p => new Province_VM
                {
                    Id = p.Id,
                    CountryId = p.CountryId,
                    Description = p.Description,
                }).ToList();
               return Ok(models); //return Ok()(models);
            }
          

        }

        [HttpPost("add-district")]
        public async Task<ActionResult> AddDistrict([FromBody] District_VM district)
        {
            if (ModelState.IsValid)
            {
                var newDistrict = new District
                {
                    ProvinceId = district.ProvinceId,
                    Description = district.Description,
                };

                _context.Districts.Add(newDistrict);
                await _context.SaveChangesAsync();

               return Ok(true); //return Ok()("District added successfully.");
            }

            return BadRequest("Invalid data provided.");
        }

        [HttpPut("update-district")]
        public async Task<ActionResult> UpdateDistrict( [FromBody] District_VM district)
        {
            var existingDistrict = await _context.Districts.FindAsync(district.Id);

            if (existingDistrict == null)
            {
                return NotFound(false); //return NotFound("District not found.");
            }

            existingDistrict.ProvinceId = district.ProvinceId;
            existingDistrict.Description = district.Description;

            _context.Districts.Update(existingDistrict);
            await _context.SaveChangesAsync();

           return Ok(true); //return Ok()("District updated successfully.");
        }


        [HttpDelete("delete-district/{id}")]
        public async Task<ActionResult> DeleteDistrict(int id)
        {
            var existingDistrict = await _context.Districts.FindAsync(id);

            if (existingDistrict == null)
            {
                return NotFound(false); //return NotFound("District not found.");
            }

            _context.Districts.Remove(existingDistrict);
            await _context.SaveChangesAsync();

           return Ok(true); //return Ok()("District deleted successfully.");
        }



        [HttpGet("get-districts/{id}")]
        public async Task<ActionResult> GetDistricts(int id)
        {
            if (id == -1)
            {
                List<District_VM> models = _context.Districts.ToList().Select(p => new District_VM
                {
                    Id = p.Id,
                    ProvinceId = p.ProvinceId,
                    Description = p.Description,
                }).ToList();
               return Ok(models); //return Ok()(models);
            }
            else
            {
                List<District_VM> models = _context.Districts.Where(p => p.ProvinceId == id).Select(p => new District_VM
                {
                    Id = p.Id,
                    ProvinceId = p.ProvinceId,
                    Description = p.Description,
                }).ToList();
               return Ok(models); //return Ok()(models);
            }

        }
        [HttpPost("add-neighborhood")]
        public async Task<ActionResult> AddNeighborhood([FromBody] Neighborhood_VM neighborhood)
        {
            if (ModelState.IsValid)
            {
                var newNeighborhood = new Neighborhood
                {
                    DistrictId = neighborhood.DistrictId,
                    Description = neighborhood.Description,
                };

                _context.Neighborhoods.Add(newNeighborhood);
                await _context.SaveChangesAsync();

               return Ok(true); //return Ok()("Neighborhood added successfully.");
            }

            return BadRequest("Invalid data provided.");
        }


        [HttpPut("update-neighborhood")]
        public async Task<ActionResult> UpdateNeighborhood( [FromBody] Neighborhood_VM neighborhood)
        {
            var existingNeighborhood = await _context.Neighborhoods.FindAsync(neighborhood.Id);

            if (existingNeighborhood == null)
            {
                return NotFound(false); //return NotFound("Neighborhood not found.");
            }

            existingNeighborhood.DistrictId = neighborhood.DistrictId;
            existingNeighborhood.Description = neighborhood.Description;

            _context.Neighborhoods.Update(existingNeighborhood);
            await _context.SaveChangesAsync();

           return Ok(true); //return Ok()("Neighborhood updated successfully.");
        }


        [HttpDelete("delete-neighborhood/{id}")]
        public async Task<ActionResult> DeleteNeighborhood(int id)
        {
            var existingNeighborhood = await _context.Neighborhoods.FindAsync(id);

            if (existingNeighborhood == null)
            {
                return NotFound(false); //return NotFound("Neighborhood not found.");
            }

            _context.Neighborhoods.Remove(existingNeighborhood);
            await _context.SaveChangesAsync();

           return Ok(true); //return Ok()("Neighborhood deleted successfully.");
        }



        [HttpGet("get-neigborhoods/{id}")]
        public async Task<ActionResult> GetNeighborhoods(int id)
        {
            if (id == -1)
            {
                List<Neighborhood_VM> models = _context.Neighborhoods.ToList().Select(p => new Neighborhood_VM
                {
                    Id = p.Id,
                    DistrictId = p.DistrictId,
                    Description = p.Description,
                }).ToList();
               return Ok(models); //return Ok()(models);
            }
            else
            {
                List<Neighborhood_VM> models = _context.Neighborhoods.Where(p => p.DistrictId == id).Select(p => new Neighborhood_VM
                {
                    Id = p.Id,
                    DistrictId = p.DistrictId,
                    Description = p.Description,
                }).ToList();
               return Ok(models); //return Ok()(models);
            }

        }



    }
}
