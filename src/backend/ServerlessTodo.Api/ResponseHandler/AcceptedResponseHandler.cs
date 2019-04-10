﻿using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Abstractions.Http;
using FunctionMonkey.Commanding.Abstractions.Validation;
using Microsoft.AspNetCore.Mvc;

namespace ServerlessTodo.Api.ResponseHandler
{
    public class AcceptedResponseHandler : IHttpResponseHandler
    {
        public Task<IActionResult> CreateResponse<TCommand, TResult>(TCommand command, TResult result) where TCommand : ICommand<TResult>
        {
            if (result is bool value)
            {
                if (value)
                {
                    return Task.FromResult((IActionResult)new AcceptedResult());
                }
                else
                {
                    return Task.FromResult((IActionResult)new BadRequestResult());
                }
            }

            return null;
        }

        public Task<IActionResult> CreateResponse<TCommand>(TCommand command)
        {
            return null;
        }

        public Task<IActionResult> CreateResponseFromException<TCommand>(TCommand command, Exception ex) where TCommand : ICommand
        {
            return null;
        }

        public Task<IActionResult> CreateValidationFailureResponse<TCommand>(TCommand command, ValidationResult validationResult) where TCommand : ICommand
        {
            return null;
        }
    }
}