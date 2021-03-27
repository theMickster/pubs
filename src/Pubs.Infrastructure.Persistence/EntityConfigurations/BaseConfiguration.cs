using System;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public abstract class BaseConfiguration
    {
        protected readonly string _schema;

        public BaseConfiguration(string schema)
        {
            _schema = schema;
        }
    }
}
