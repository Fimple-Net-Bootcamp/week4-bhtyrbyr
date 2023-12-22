using FluentValidation;
using VirtualPaws.Application.DTOs.ActivityDTOs;

namespace VirtualPaws.Application.Features.Entities.Activities.Commands.Create
{
    public class ActivityCreateDTOValdaitor : AbstractValidator<ActivityCreateDTO>
    {
        public ActivityCreateDTOValdaitor()
        {
            RuleFor(model => (int)model.NutritionalValue).LessThan(20); 
            RuleFor(model => model.Name).NotEmpty().MinimumLength(2);
        }
    }
}
