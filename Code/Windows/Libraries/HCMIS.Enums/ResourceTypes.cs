using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("ResourceTypeCode")]
    public enum ResourceTypes
    {
       [TableCode("WIN")] 
        Windows,
       [TableCode("WM")] 
        UserManagement,
       [TableCode("DASH")] 
        Dashboard,
       [TableCode("MHD")] 
        MultihubDashboard,
       [TableCode("DS")] 
        DirectoryServices,
       [TableCode("GL")] 
        GeneralLookup,

    }
}
