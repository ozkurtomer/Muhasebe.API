using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Domain.Roles;

public sealed class RoleList
{
    public static List<AppRole> GetStaticRoles()
    {
        List<AppRole> roles = new List<AppRole>
        {
            #region UniformChartOfAccount
            new AppRole(title: UniformChartOfAccount, code: UniformChartOfAccountCreateCode, name: UniformChartOfAccountCreateName),
            new AppRole(title: UniformChartOfAccount, code: UniformChartOfAccountUpdateCode, name: UniformChartOfAccountUpdateName),
            new AppRole(title: UniformChartOfAccount, code: UniformChartOfAccountDeleteCode, name: UniformChartOfAccountDeleteName),
            #endregion
        };

        return roles;
    }

    #region RoleTitleNames
    public static string UniformChartOfAccount = "Hesap Planı";
    #endregion

    #region RoleCodeandNames
    public static string UniformChartOfAccountCreateCode = "UniformChartOfAccount.Create";
    public static string UniformChartOfAccountUpdateCode = "UniformChartOfAccount.Update";
    public static string UniformChartOfAccountDeleteCode = "UniformChartOfAccount.Delete";
    public static string UniformChartOfAccountCreateName = "Hesap Planı Kayıt Ekleme";
    public static string UniformChartOfAccountUpdateName = "Hesap Planı Kayıt Güncelleme";
    public static string UniformChartOfAccountDeleteName = "Hesap Planı Kayıt Silme";
    #endregion

}
