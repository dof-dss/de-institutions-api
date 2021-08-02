using de_institutions_infrastructure.Features.Institution.Queries;
using FluentValidation;

namespace de_institutions_infrastructure.Features.Institution.Validation
{
    public class GetAllInstitutionsQueryValidator : AbstractValidator<GetAllInstitutionsQuery>
    {
        public GetAllInstitutionsQueryValidator()
        {

        }
    }
}