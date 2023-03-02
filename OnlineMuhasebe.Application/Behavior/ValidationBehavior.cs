﻿using MediatR;
using FluentValidation;
using FluentValidation.Results;
using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Behavior;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> Validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        Validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!Validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errorDictionary = Validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(x => x.PropertyName, x => x.ErrorMessage, (propertyName, errorMessage) => new
            {
                Key = propertyName,
                Values = errorMessage.Distinct().ToArray()
            }).ToDictionary(x => x.Key, x => x.Values[0]);

        if (errorDictionary.Any())
        {
            var errors = errorDictionary.Select(x => new ValidationFailure
            {
                PropertyName = x.Value,
                ErrorCode = x.Key
            });
            throw new ValidationException(errors);
        }
        return await next();
    }
}
