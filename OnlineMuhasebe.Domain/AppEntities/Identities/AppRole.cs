﻿using Microsoft.AspNetCore.Identity;

namespace OnlineMuhasebe.Domain.AppEntities.Identities;

public sealed class AppRole : IdentityRole<string>
{
    public string Code { get; set; }
}
