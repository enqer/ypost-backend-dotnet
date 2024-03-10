using FluentValidation;
using ypost_backend_dotnet.Common;

namespace ypost_backend_dotnet.Models.Validators
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostDtoValidator(AppDbContext dbContext) 
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty()
                .Custom((value, context) =>
                {
                    var usernameUsed = dbContext.Users.Any(u => u.Id == value);
                    if (!usernameUsed)
                    {
                        context.AddFailure("AuthorID", "Author with this id is not exist");
                    }
                });
            RuleFor(x => x.Content)
                .NotEmpty()
                .MaximumLength(160);
        }
    }
}
