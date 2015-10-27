using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("CommodityTypeCode")]
    public enum CommodityTypes
    {
       [TableCode("PHAR")] 
        Pharmaceuticals,
       [TableCode("MEDS")] 
        MedicalSupplies,
       [TableCode("MEDE")] 
        MedicalEquipments,
       [TableCode("CHEM")] 
        ChemicalsandReagents,

    }
}
