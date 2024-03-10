using FluentValidation;

namespace ypost_backend_dotnet.Models.Validators
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentDtoValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty();
            RuleFor(x => x.Content)
                .NotEmpty()
                .MaximumLength(160);
            RuleFor(x => x.EntryId)
                .NotEmpty();
        }
    }
}
