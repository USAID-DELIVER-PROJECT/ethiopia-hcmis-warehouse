using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BLL;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace HCMIS.Modules.Requisition.Services
{
    public class ItemRepository:CachedRepository<Domain.Item,int>
    {
        public override Domain.Item FindSingle(int id)
        {
            var items = FindAll();
            var item = items.SingleOrDefault(i => i.ItemID == id);
            return item;
        }

        protected override ICollection<Domain.Item> GetData()
        {
            ICollection<Domain.Item> items = new Collection<Domain.Item>();
            var dbItems = new Item();
            dbItems.LoadAll();
            while (!dbItems.EOF)
            {
                items.Add(new Domain.Item
                {
                    StockCode = dbItems.StockCode,
                    ItemID = dbItems.ID,
                    ItemName = dbItems.FullItemName
                });
                dbItems.MoveNext();
            }
            return items;
        }
    }
}
