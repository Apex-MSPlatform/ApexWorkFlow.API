using FluentValidation;

namespace Application.Features.WorkflowTemplates.Create
{
    public class CreateWorkflowTemplateValidator : AbstractValidator<CreateWorkflowTemplateCommand>
    {
        public CreateWorkflowTemplateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);


            RuleFor(x => x.ReferenceType)
                .NotEmpty();
        }
    }
}
