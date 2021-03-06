using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("InstitutionTypeCode")]
    public enum InstitutionTypes
    {
       [TableCode("RGN")] 
        Region,
       [TableCode("ZN")] 
        Zone,
       [TableCode("WR")] 
        Woreda,
       [TableCode("HB")] 
        Hub,
       [TableCode("CLN")] 
        Clinic,
       [TableCode("HS")] 
        Hospital,
       [TableCode("HC")] 
        HealthCenter,
       [TableCode("PH")] 
        Pharmacy,
       [TableCode("RDS")] 
        RuralDrugStore,
       [TableCode("DS")] 
        DrugStore,
       [TableCode("CN")] 
        Center,
       [TableCode("SU")] 
        Supplier,
       [TableCode("RS")] 
        ResearchCenter,
       [TableCode("IN")] 
        Individuals,
       [TableCode("ES")] 
        Escrow,
       [TableCode("IMW")] 
        Importandwholesale,
       [TableCode("RL")] 
        RegionalLab,
       [TableCode("MN")] 
        Machine,
       [TableCode("OTH")] 
        Others,
       [TableCode("DL")] 
        DiagnosticLaboratory,

    }
}
