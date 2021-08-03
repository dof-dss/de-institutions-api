using de_institutions_infrastructure.Features.Institution.Queries;
using FluentValidation;

namespace de_institutions_infrastructure.Features.Institution.Validation
{
    public class GetInstitutionByNameQueryValidator : AbstractValidator<GetInstitutionByNameQuery>
    {
        public GetInstitutionByNameQueryValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name is not set");
        }
    }
}