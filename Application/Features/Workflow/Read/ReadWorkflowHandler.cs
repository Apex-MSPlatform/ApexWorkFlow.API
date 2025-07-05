using Application.Abstractions.Messaging;
using AutoMapper;
using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Shared;

namespace Application.Features.Workflow.Read
{
    public class ReadWorkflowHandler : IQueryHandler<ReadWorkflowQurey, ReadWorkflowResponse>
    {
        private readonly IWorkflowRepository _repository;

        private readonly IMapper _mapper;

        public ReadWorkflowHandler(IWorkflowRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<ReadWorkflowResponse>> Handle(ReadWorkflowQurey request, CancellationToken cancellationToken)
        {
            var workflow = await _repository.GetByIdAsync(request.Id);

            if (workflow == null)
            {
                throw new NotFoundException($"Workflow with ID {request.Id} not found.");
            }

            var output = _mapper.Map<ReadWorkflowResponse>(workflow);

            var result = Result<ReadWorkflowResponse>.Success(output,"");

            return result;
        }
    }
}
