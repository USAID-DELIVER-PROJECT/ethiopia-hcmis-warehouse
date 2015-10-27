using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("ShortageReasonsCode")]
    public enum ShortageReasons
    {
       [TableCode("DA")] 
        Damaged,
       [TableCode("SL")] 
        ShortLanded,
       [TableCode("NREC")] 
        NotReceived,
       [TableCode("FS")] 
        FMHACASample,
       [TableCode("OTH")] 
        Others,

    }
}
