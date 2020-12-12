
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Tomtom.Application.Core;
using Tomtom.Application.Exceptions;
using Tomtom.Application.Value;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tomtom.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ISender _mediator => HttpContext.RequestServices.GetRequiredService<ISender>();

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            return _mediator.Send(new ValueQuery { Id = id}, HttpContext.RequestAborted).ContinueWith(receiver => !receiver.Result.IsSuccess ?  receiver.Result.Error is NotFoundException ? NotFound() : (IActionResult)StatusCode(500, receiver.Result.Error) : Ok(receiver.Result.GetValue()));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Task<IActionResult> Post([FromBody] AddValueCommand command)
        {
            return _mediator.Send(command, HttpContext.RequestAborted).ContinueWith(receiver => receiver.Result.IsSuccess ? Ok() : (IActionResult)StatusCode(500, receiver.Result.Error) );
        }
    }
}
