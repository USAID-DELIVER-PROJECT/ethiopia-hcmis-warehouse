using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace HCMIS.Modules.Requisition
{
    public static class CacheSetting
    {
        public static void LoadConfigurationForCaching()
        {
            var builder = new ConfigurationSourceBuilder();

            builder.ConfigureCaching()
                .ForCacheManagerNamed("MyCache")
                .WithOptions
                .UseAsDefaultCache().StoreInMemory();
            var configSource = new DictionaryConfigurationSource();
            builder.UpdateConfigurationWithReplace(configSource);
            EnterpriseLibraryContainer.Current
              = EnterpriseLibraryContainer.CreateDefaultContainer(configSource);
        }
    }
}
