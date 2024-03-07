using FluentValidation;
using ypost_backend_dotnet.Common;

namespace ypost_backend_dotnet.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(AppDbContext dbContext) 
        {
   
            RuleFor(x => x.Password)
                .MinimumLength(8);
            RuleFor(x => x.UserName)
                .MinimumLength(5)
                .Custom((value, context) =>
                {
                    var usernameUsed = dbContext.Users.Any(u => u.UserName ==  value);
                    if (usernameUsed)
                    {
                        context.AddFailure("UserName", "The UserName is taken");
                    }
                });
            RuleFor(x => x.FirstName)
                .MinimumLength(5);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Custom((value, context) =>
                {
                    var emailUsed = dbContext.Users.Any(u => u.Email == value);
                    if (emailUsed)
                    {
                        context.AddFailure("Email", "The email is taken");
                    }
                });

        }
    }
}
