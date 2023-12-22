using FluentValidation;
using VirtualPaws.Application.DTOs.TrainingDTOs;

namespace VirtualPaws.Application.Features.Entities.Trainings.Commands.Create
{
    public class TrainingsCreateDTOValidator : AbstractValidator<TrainingCreateDTO>
    {
        public TrainingsCreateDTOValidator()
        {
            RuleFor(model => (int)model.XP).LessThan(20); 
            RuleFor(model => model.Name).NotEmpty().MinimumLength(2);
        }
    }
}
