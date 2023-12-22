using FluentValidation;
using VirtualPaws.Application.DTOs.TrainingDTOs;

namespace VirtualPaws.Application.Features.Entities.Trainings.Commands.Update
{
    public class TrainingsUpdateDTOValidator : AbstractValidator<TrainingUpdateDTO>
    {
        public TrainingsUpdateDTOValidator()
        {
            RuleFor(model => (int)model.NewXP).LessThan(20);
            RuleFor(model => model.NewName).NotEmpty().MinimumLength(2);
        }
    }
}
