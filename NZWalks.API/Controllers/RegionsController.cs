using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    // https://localhost:portNumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWaksDbContext dbContext;

        public RegionsController(NZWaksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET ALL REGIONS
        // GET: https://localhost:portNumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            // Get data from Databse - Domain Models
            var regionsDomain = dbContext.Regions.ToList();

            // Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            // Return DTOs
            return Ok(regionsDto);
        }

        // GET SINGLE REGION (Get Region by ID)
        // GET: https://localhost:portNumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            // Get Region Domain Model from Database
            var regionDomain = dbContext.Regions.Find(id);
            //var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map/Convert Region Domain Model to Region DTO
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            // Return DTO back to client
            return Ok(regionDto);
        }
    }
}
