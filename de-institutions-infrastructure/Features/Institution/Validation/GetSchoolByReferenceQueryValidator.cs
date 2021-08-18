using de_institutions_infrastructure.Features.Institution.Queries;
using FluentValidation;

namespace de_institutions_infrastructure.Features.Institution.Validation
{
    public class GetSchoolByReferenceQueryValidator : AbstractValidator<GetSchoolByReferenceQuery>
    {
        public GetSchoolByReferenceQueryValidator()
        {
            RuleFor(r => r.InstitutionReference).NotEmpty().WithMessage("School reference is not set");
        }
    }
}