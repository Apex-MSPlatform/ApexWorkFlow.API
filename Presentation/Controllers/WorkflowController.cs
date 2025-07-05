using Application.Features.Workflow.Create;
using Application.Features.Workflow.Read;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class WorkflowController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkflowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [MapToApiVersion(1)]
        [HttpGet("{WorkflowId}")]
        public async Task<IActionResult> Read(Guid WorkflowId)
        {
            var query = new ReadWorkflowQurey
            {
                Id = WorkflowId
            };

            var result = await _mediator.Send(query);

            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }

        [MapToApiVersion(1)]
        [HttpPost()]
        public async Task<IActionResult> Create(CreateWorkflowCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }




    }
}
