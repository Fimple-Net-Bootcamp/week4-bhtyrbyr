using FluentValidation;
using VirtualPaws.Application.DTOs.UserDTOs;

namespace VirtualPaws.Application.Features.Entities.Users.Commands.Create
{
    public class UsersCreateDTOValidator : AbstractValidator<UserCreateDTO>
    {
        public UsersCreateDTOValidator()
        {
            RuleFor(model => model.Name).NotEmpty().MinimumLength(2);
            RuleFor(model => model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(model => model.Username).NotEmpty().MinimumLength(2);
            RuleFor(model => model.Password).NotEmpty().MinimumLength(8);
        }
    }
}
