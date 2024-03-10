using FluentValidation;

namespace ypost_backend_dotnet.Models.Validators
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostDtoValidator() 
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty();
            RuleFor(x => x.Content)
                .NotEmpty()
                .MaximumLength(160);
        }
    }
}
