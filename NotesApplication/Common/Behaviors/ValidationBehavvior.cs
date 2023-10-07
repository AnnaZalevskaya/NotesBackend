using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;

namespace NotesApplication.Common.Behaviors
{
    public class ValidationBehavvior<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<IRequest>> _validators;

        public ValidationBehavvior(IEnumerable<IValidator<IRequest>> validators)
        {
            _validators = validators;   
        }

        public Task<TResponse> Handle (TRequest request, RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(res => res.Errors)
                .Where(failure => failure != null)
                .ToList();
            if(failures.Count() != 0)
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
