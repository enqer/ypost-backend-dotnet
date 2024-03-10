using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ypost_backend_dotnet.Common;

namespace ypost_backend_dotnet.Models.Validators
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentDtoValidator(AppDbContext dbContext)
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty()
                .Custom((value, context) =>
                {
                    var usernameUsed = dbContext.Users.Any(u => u.Id == value);
                    if (!usernameUsed)
                    {
                        context.AddFailure("AuthorId", "Author with this id doesn't exist");
                    }
                });
            RuleFor(x => x.Content)
                .NotEmpty()
                .MaximumLength(160);
            RuleFor(x => x.EntryId)
                .NotEmpty()
                .Custom((value, context) =>
                {
                     var usernameUsed = dbContext.Posts.Any(u => u.Id == value);
                     if (!usernameUsed)
                     {
                         context.AddFailure("EntryId", "Entry with this id doesn't exist");
                     }
                });
        }
    }
}
