using Application.Features.WorkflowTemplates.Create;
using Asp.Versioning;
using Domain.Shared.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class WorkflowTemplatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkflowTemplatesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /*
        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> ReadAll([FromQuery] QueryParameters parameters)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }*/

        [MapToApiVersion(1)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkflowTemplateCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }


    }
}
