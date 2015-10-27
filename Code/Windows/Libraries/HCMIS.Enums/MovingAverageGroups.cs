using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("MovingAverageGroupCode")]
    public enum MovingAverageGroups
    {
       [TableCode("MOH")] 
        MOH,
       [TableCode("SCMS")] 
        SCMS,
       [TableCode("RDF")] 
        RDF,
       [TableCode("GFCO")] 
        GFConsignment,
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
       [TableCode("MIC")] 
        Miscellaneous,

    }
}
