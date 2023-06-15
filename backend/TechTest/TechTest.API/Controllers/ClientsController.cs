using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechTest.Application.Commands;
using TechTest.Application.Queries;
using TechTest.Application.Queries.Countries;
using TechTest.Core.Entities;

namespace TechTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        //private readonly TechTestContext _context;

        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
           // _context = context;
        }

        // GET: api/Clients
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Client>> GetClients()
        {
            var response = await  _mediator.Send(new GetAllClientQuery());
            return response;
        }

        //GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {

            var response = await _mediator.Send(new GetClientByIdQuery(id));
            if (response == null)
            {
                return NotFound("Country information not found");
            }
            return Ok(response);
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> PutClient(int id, [FromBody] EditClientCommand command)
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<Client>> PostClient([FromBody] CreateClientCommand command)
        {

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE: api/Clients/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteClientCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        //private bool ClientExists(int id)
        //{
        //    return (_context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
