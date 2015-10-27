using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("AccountCode")]
    public enum Accounts
    {
       [TableCode("MOH")] 
        MOH,
       [TableCode("RDFR")] 
        RDFRegular,
       [TableCode("RDFP")] 
        RDFPBS,
       [TableCode("RDFM")] 
        RDFMDG,
       [TableCode("GFCO")] 
        GFConsignment,
       [TableCode("SCMS")] 
        SCMS,
       [TableCode("HPCO")] 
        HAPCO,
       [TableCode("OTHR")] 
        Others,
       [TableCode("CONS")] 
        Consignment,
       [TableCode("BNUN")] 
        BedNetUNICEFHeadOffice,
       [TableCode("LAB")] 
        Labs,
       [TableCode("MISC")] 
        Miscellaneous,

    }
}
