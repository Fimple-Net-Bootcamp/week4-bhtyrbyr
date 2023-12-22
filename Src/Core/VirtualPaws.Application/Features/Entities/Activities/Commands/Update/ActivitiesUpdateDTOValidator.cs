using FluentValidation;
using VirtualPaws.Application.DTOs.ActivityDTOs;

namespace VirtualPaws.Application.Features.Entities.Activities.Commands.Update
{
    public class ActivitiesUpdateDTOValidator : AbstractValidator<ActivityUpdateDTO>
    {
        public ActivitiesUpdateDTOValidator()
        {
            RuleFor(model => (int)model.NewNutritionalValue).LessThan(20);
            RuleFor(model => model.NewName).NotEmpty().MinimumLength(2);
        }
    }
}
