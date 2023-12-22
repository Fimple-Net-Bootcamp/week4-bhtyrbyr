using FluentValidation;
using VirtualPaws.Application.DTOs.PetFoodDTOs;

namespace VirtualPaws.Application.Features.Entities.PetFoods.Commands.Create
{
    public class PetFoodsCreateDTOValidator : AbstractValidator<PetFoodCreateDTO>
    {
        public PetFoodsCreateDTOValidator()
        {
            RuleFor(model => (int)model.NutritionalValue).LessThan(20); 
            RuleFor(model => model.Name).NotEmpty().MinimumLength(2);
        }
    }
}
