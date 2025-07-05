using FluentValidation;

namespace Application.Features.Workflow.Create
{
    public class CreateWorkflowCommandValidator : AbstractValidator<CreateWorkflowCommand>
    {
        public CreateWorkflowCommandValidator()
        {
            RuleFor(x => x.ReferenceType)
                .NotEmpty().WithMessage("Reference type is required.")
                .MaximumLength(100).WithMessage("Reference type must not exceed 100 characters.");

            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage("Display name is required.")
                .MaximumLength(150).WithMessage("Display name must not exceed 150 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}
