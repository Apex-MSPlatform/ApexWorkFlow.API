using Apex.Core.Abstractions.Messaging;
using Apex.Core.Common;
using AutoMapper;
using Domain.Abstractions;

using FluentValidation;

namespace Application.Features.WorkflowTemplates.ReadAll
{
    public class ReadAllWorkflowTemplateHandler : IQueryHandler<ReadAllWorkflowTemplateQuery, ReadAllWorkflowTemplateResponse>
    {
        private readonly IWorkflowTemplateRepository _repository;
        private readonly IMapper _mapper;

        public ReadAllWorkflowTemplateHandler(IWorkflowTemplateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ReadAllWorkflowTemplateResponse>> Handle(ReadAllWorkflowTemplateQuery query, CancellationToken cancellationToken)
        {
            var response = new ReadAllWorkflowTemplateResponse
            {
                Templates = await _repository.GetQueryableList(
                query.QueryParameters,
                cancellationToken,
                searchFunc: (query, searchTerm) =>
                {
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        return query.Where(r => r.Name!.Contains(searchTerm));
                    }
                    return query;
                })
            };

            var result = Result<ReadAllWorkflowTemplateResponse>.Success(response, "All workflow templates");

            return result;
        }

    }
}
