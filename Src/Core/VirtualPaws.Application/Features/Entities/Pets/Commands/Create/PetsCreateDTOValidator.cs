using FluentValidation;
using VirtualPaws.Application.DTOs.PetDTOs;

namespace VirtualPaws.Application.Features.Entities.Pets.Commands.Create
{
    public class PetsCreateDTOValidator : AbstractValidator<PetCreateDTO>
    {
        public PetsCreateDTOValidator()
        {
            RuleFor(model => model.Type).NotEmpty().MinimumLength(2); 
            RuleFor(model => model.Name).NotEmpty().MinimumLength(2);
        }
    }
}
