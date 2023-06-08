using Location.Application.Queries.Countries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTest.Application.Commands;
using TechTest.Application.DTOs;
using TechTest.Application.Queries;
using TechTest.Core.Entities;
using TechTest.Infrastructure.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TechTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly TechTestContext _context;
        private readonly IMediator _mediator;

        public PackagesController(TechTestContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/Packages
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PackageDTO>>> GetPackages()
        {
            var response = await _mediator.Send(new GetAllPackageQuery());
            return response;
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
            var response = await _mediator.Send(new GetPackageByIdQuery(id));
            if (response == null)
            {
                return NotFound("Country information not found");
            }
            return Ok(response);
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> PutPackage(int id, [FromBody] EditPackageCommand command)
        {

            try
            {
                if (command.Id == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<Package>> PostPackage([FromBody] CreatePackageCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE: api/Packages/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeletePackageCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }

        private bool PackageExists(int id)
        {
            return (_context.Packages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
