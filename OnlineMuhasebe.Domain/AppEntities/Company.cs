using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.AppEntities;

public sealed class Company : Entity
{
    public string CompanyName { get; set; }

    public string CompanyAddress { get; set; }

    public string CompanyTaxNo { get; set; }

    public string CompanyTaxDepartment { get; set; }

    public string CompanyPhone { get; set; }

    public string CompanyEmail { get; set; }

    public string CompanyServerName { get; set; }

    public string CompanyDatabaseName { get; set; }

    public string CompanyServerId { get; set; }

    public string CompanyServerPassword { get; set; }

}
