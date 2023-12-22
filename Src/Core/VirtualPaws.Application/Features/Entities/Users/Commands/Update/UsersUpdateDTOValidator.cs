using FluentValidation;
using VirtualPaws.Application.DTOs.ActivityDTOs;
using VirtualPaws.Application.DTOs.UserDTOs;

namespace VirtualPaws.Application.Features.Entities.Activities.Commands.Update
{
    public class UsersUpdateDTOValidator : AbstractValidator<UserUpdateDTO>
    {
        public UsersUpdateDTOValidator()
        {
            RuleFor(model => model.NewName).NotEmpty().MinimumLength(2);
            RuleFor(model => model.NewSurname).NotEmpty().MinimumLength(2);
            RuleFor(model => model.NewPassword).NotEmpty().MinimumLength(8);
        }
    }
}
