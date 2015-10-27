namespace HCMIS.Modules.Requisition.Domain
{
    public class Client
    {
        public  int ClientID { get; set; }
        public string ClientName { get; set; }
        public string Woreda { get; set; }
        public string Zone { get; set; }
        public string Region { get; set; }
        public string InstitutionType { get; set; }
        
    }
}