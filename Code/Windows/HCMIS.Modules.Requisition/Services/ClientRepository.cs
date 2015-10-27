using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using HCMIS.Modules.Requisition.Domain;
using Client = HCMIS.Modules.Requisition.Domain.Client;

namespace HCMIS.Modules.Requisition.Services
{
    public class ClientRepository:CachedRepository<Domain.Client,int>
    {

        protected override ICollection<Domain.Client> GetData()
        {

            ICollection<Domain.Client> clients = new Collection<Domain.Client>();
            var dbClients = new BLL.Institution();
            dbClients.LoadAll();
            while (!dbClients.EOF)
            {
                clients.Add(new Domain.Client { ClientID = dbClients.ID, ClientName = dbClients.Name,Woreda = dbClients.WoredaName,Zone = dbClients.ZoneName,Region = dbClients.RegionName,InstitutionType = dbClients.InstitutionTypeName});
                dbClients.MoveNext();
            }
            return clients;
        }

        public override Client FindSingle(int id)
        {
            return FindAll().SingleOrDefault(i => i.ClientID == id);
        }
    }
}
