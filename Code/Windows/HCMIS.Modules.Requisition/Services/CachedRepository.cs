

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace HCMIS.Modules.Requisition.Services
{
    public abstract class CachedRepository<T,TIdentifier> where T:class, new()
    {
       
        
        protected CachedRepository ()
	    {
                 
	    }
        
        public ICollection<T> FindAll()
        {
            var cacheManager = EnterpriseLibraryContainer.Current.GetInstance<ICacheManager>();
            var tKey = typeof(T).ToString();
            ICollection<T> entities;
            if (!cacheManager.Contains(tKey) || cacheManager[tKey] == null)
            {
                entities = GetData();
                cacheManager.Add(tKey, entities, CacheItemPriority.Low, null, new NeverExpired());// new SlidingTime(TimeSpan.FromSeconds(10)));
            }

            var cachedEntities = cacheManager.GetData(tKey);
            entities = cachedEntities as ICollection<T>;
            return entities;
        }

        public abstract T FindSingle(TIdentifier id);
        
        protected abstract ICollection<T> GetData();

    }
}
