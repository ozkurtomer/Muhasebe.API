﻿using Microsoft.AspNetCore.Identity;

namespace OnlineMuhasebe.Domain.AppEntities.Identities;

public sealed class AppRole : IdentityRole<string>
{
    public AppRole()
    {

    }

    public AppRole(string title, string code, string name)
    {
        Id = Guid.NewGuid().ToString();
        Code = code;
        Title = title;
        Name = name;
    }

    public string Code { get; set; }
    public string Title { get; set; }
}
