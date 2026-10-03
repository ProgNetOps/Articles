using Articles.Abstractions;
using Articles.Abstractions.Enums;
using FluentValidation;
using MediatR;

namespace Submission.Application.Features.CreateArticle;
//Records are immutable and in theory, we shouldn't change our commands
public record CreateArticleCommand(int JournalId, string Title,
    string Scope, ArticleType ArticleType):IRequest<IdResponse>
{

}

public class CreateCommandValidator:AbstractValidator<CreateArticleCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty");
        RuleFor(x => x.Scope)
            .NotEmpty().WithMessage("Scope cannot be empty");
        RuleFor(x => x.JournalId)
            .NotEmpty().WithMessage("Invalid journal Id");
    }
}