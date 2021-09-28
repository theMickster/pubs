using Pubs.Application.Interfaces.DbContexts;
using System;

namespace Pubs.Application.Common.Helpers
{
    public class DbContextSchemaHelper : IDbContextSchema
    {
        public string DefaultSchema { get; }

        public DbContextSchemaHelper(string schema)
        {
            DefaultSchema = schema ?? throw new ArgumentNullException(nameof(schema));
        }
    }
}
