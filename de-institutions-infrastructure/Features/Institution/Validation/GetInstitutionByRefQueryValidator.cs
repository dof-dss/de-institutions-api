using de_institutions_infrastructure.Features.Institution.Queries;
using FluentValidation;

namespace de_institutions_infrastructure.Features.Institution.Validation
{
    public class GetInstitutionByRefQueryValidator : AbstractValidator<GetInstitutionByRefQuery>
    {
        public GetInstitutionByRefQueryValidator()
        {
            RuleFor(r => r.InstitutionReference).NotEmpty().WithMessage("Institution reference is not set");
        }
    }
}