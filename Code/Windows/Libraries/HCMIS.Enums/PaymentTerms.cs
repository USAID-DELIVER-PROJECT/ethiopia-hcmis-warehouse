using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("PaymentTermCode")]
    public enum PaymentTerms
    {
       [TableCode("LC")] 
        LC,
       [TableCode("PIA")] 
        PIA,
       [TableCode("CA")] 
        CA,
       [TableCode("NET30")] 
        Net30,
       [TableCode("NET60")] 
        Net60,
       [TableCode("Contr")] 
        Contra,

    }
}
