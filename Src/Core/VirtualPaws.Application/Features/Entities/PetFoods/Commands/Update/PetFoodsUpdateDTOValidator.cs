using FluentValidation;
using VirtualPaws.Application.DTOs.PetFoodDTOs;

namespace VirtualPaws.Application.Features.Entities.PetFoods.Commands.Update
{
    public class PetFoodsUpdateDTOValidator : AbstractValidator<PetFoodUpdateDTO>
    {
        public PetFoodsUpdateDTOValidator()
        {
            RuleFor(model => (int)model.NewNutritionalValue).LessThan(20);
            RuleFor(model => model.NewName).NotEmpty().MinimumLength(2);
        }
    }
}
