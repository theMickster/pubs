namespace Pubs.CoreDomain.Settings
{
    public class EntityFrameworkCoreSettings
    {
        public const string SettingsRootName = "EntityFrameworkCoreSettings";

        public string CommandLogLevel { get; set; }

        public int ComamndTimeout { get; set; }

    }
}
