using FluentValidation;
using VirtualPaws.Application.DTOs.PetDTOs;

namespace VirtualPaws.Application.Features.Entities.Pets.Commands.Create
{
    public class PetsUpdateDTOValidator : AbstractValidator<PetUpdateDTO>
    {
        public PetsUpdateDTOValidator()
        {
            RuleFor(model => model.NewType).NotEmpty().MinimumLength(2); 
            RuleFor(model => model.NewName).NotEmpty().MinimumLength(2);
        }
    }
}
