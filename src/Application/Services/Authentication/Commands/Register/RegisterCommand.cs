﻿using Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Services.Authentication.Commands.Register;
public record TRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;

