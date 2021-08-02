using AutoMapper;
using de_institutions_infrastructure.Data;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace de_institutions_infrastructure.Features.Common
{
    public abstract class AbstractBaseHandler<T, TR> : IRequestHandler<T, TR> where T : IRequest<TR>
    {
        protected readonly InstituitonContext InstituitonContext;
        protected readonly IValidator<T> Validator;
        protected readonly IMapper Mapper;

        protected AbstractBaseHandler(InstituitonContext instituitonContext, IMapper mapper, IValidator<T> validator)
        {
            Mapper = mapper;
            InstituitonContext = instituitonContext;
            Validator = validator;
        }

        public abstract Task<TR> Handle(T request, CancellationToken cancellationToken);
    }
}