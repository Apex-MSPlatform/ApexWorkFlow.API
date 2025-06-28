using Application.Features.WorkflowTemplates.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class WorkflowTemplateProfile : Profile
    {
        public WorkflowTemplateProfile()
        {
            CreateMap<CreateWorkflowTemplateCommand, WorkflowTemplate>();
            CreateMap<WorkflowTemplate, CreateWorkflowTemplateResponse>();
        }
    }
}
