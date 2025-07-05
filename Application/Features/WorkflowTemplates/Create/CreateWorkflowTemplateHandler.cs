using Application.Abstractions.Messaging;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Shared;
using FluentValidation;

namespace Application.Features.WorkflowTemplates.Create
{
    public class CreateWorkflowTemplateHandler : ICommandHandler<CreateWorkflowTemplateCommand, CreateWorkflowTemplateResponse>
    {
        private readonly IWorkflowTemplateRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateWorkflowTemplateCommand> _validator;

        public CreateWorkflowTemplateHandler(IWorkflowTemplateRepository repository, IMapper mapper, IValidator<CreateWorkflowTemplateCommand> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Result<CreateWorkflowTemplateResponse>> Handle(CreateWorkflowTemplateCommand request, CancellationToken cancellationToken)
        {
            var ValidationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!ValidationResult.IsValid)
            {
                var errors = ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new DataValidationException(errors);
            }


            var existing = await _repository.IsNameExistsAsync(request.Name, cancellationToken);
            if (existing)
            {
                List<string> list = ["A workflow template with the same name already exists."];

                throw new AlreadyExistException(list);
            }                      

            var template = _mapper.Map<WorkflowTemplate>(request);

            await _repository.AddAsync(template, cancellationToken);

            var response = _mapper.Map<CreateWorkflowTemplateResponse>(template);

            var result = Result<CreateWorkflowTemplateResponse>.Success(response, "has been created.");

            return result;
        }

    }
}
