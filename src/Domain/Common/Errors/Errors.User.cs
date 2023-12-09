﻿using ErrorOr;

namespace Domain.Common.Errors;
public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "User already exists with given email.");
    }
}
