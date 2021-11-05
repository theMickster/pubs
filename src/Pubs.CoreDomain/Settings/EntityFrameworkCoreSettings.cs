using System.Collections.Generic;

namespace Pubs.CoreDomain.Settings
{
    public class EntityFrameworkCoreSettings
    {
        public const string SettingsRootName = "EntityFrameworkCoreSettings";

        public string CommandLogLevel { get; set; }

        public int ComamndTimeout { get; set; }

        public string CurrentConnectionStringName { get; set; }

        public List<DatabaseConnectionString> DatabaseConnectionStrings { get; set; }
    }
}
