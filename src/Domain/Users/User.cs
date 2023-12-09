﻿using Domain.Users.ValueObjects;

namespace Domain.Users;

public class User
{
    public UserId Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; }
}

