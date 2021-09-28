using System;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public abstract class BaseConfiguration
    {
        protected readonly string _schema = "dbo";

        public BaseConfiguration(string schema)
        {
            if(!string.IsNullOrWhiteSpace(schema))
            {
                _schema = schema;
            }            
        }

        public BaseConfiguration()
        {
        }
    }
}
