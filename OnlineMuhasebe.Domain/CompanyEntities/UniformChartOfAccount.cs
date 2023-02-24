﻿using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.CompanyEntities;

public sealed class UniformChartOfAccount : Entity
{
    public string Code { get; set; }

    public string Name { get; set; }

    public char Type { get; set; }
}
