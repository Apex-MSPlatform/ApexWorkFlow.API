using Apex.Core.Abstractions.Messaging;
using Apex.Core.Common;
using Apex.Core.Exceptions;
using AutoMapper;
using Domain.Abstractions;

namespace Application.Features.Workflow.Create
{
    public class CreateWorkflowHandler : ICommandHandler<CreateWorkflowCommand, CreateWorkflowResponse>
    {
        private readonly IWorkflowRepository _repository;

        private readonly IMapper _mapper;

        public CreateWorkflowHandler(IWorkflowRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<CreateWorkflowResponse>> Handle(CreateWorkflowCommand request, CancellationToken cancellationToken)
        {
            var IsExist = await _repository.IsWorkflowExistsAsync(request.ReferenceType, cancellationToken);

            if (IsExist)
                throw new AlreadyExistException([$"Workflow with the following ReferenceType '{request.ReferenceType}' is already exist."]);


            var workflow = _mapper.Map<Domain.Entities.Workflow>(request);

            workflow = await _repository.AddAsync(workflow, cancellationToken);

            var workflowResponse = _mapper.Map<CreateWorkflowResponse>(workflow);

            var result = Result<CreateWorkflowResponse>.Success(workflowResponse,"workflow has b    een created");

            return result;
        }
    }
}
