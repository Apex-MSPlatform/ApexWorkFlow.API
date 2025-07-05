using Application.Features.Workflow.Create;
using Application.Features.Workflow.Read;
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

            CreateMap<Workflow, ReadWorkflowResponse>();


            CreateMap<CreateWorkflowCommand, Workflow>();
            CreateMap<Workflow, CreateWorkflowResponse>();

        }
    }
}
