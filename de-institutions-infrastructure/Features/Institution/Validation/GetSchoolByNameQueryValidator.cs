using de_institutions_infrastructure.Features.Institution.Queries;
using FluentValidation;

namespace de_institutions_infrastructure.Features.Institution.Validation
{
    public class GetSchoolByNameQueryValidator : AbstractValidator<GetSchoolByNameQuery>
    {
        public GetSchoolByNameQueryValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name is not set");
        }
    }
}