namespace Pubs.CoreDomain.Constants
{
    /// <summary>
    /// Contains constant strings to represent the security roles within the application.
    /// </summary>
    /// <remarks>
    /// These constants are useful in the code to ensure consistency wherever the role names are referenced.
    /// Another example of how to rid the application of the magic strings code smell.
    /// </remarks>
    public static class ApplicationRoleNames
    {
        /// <summary>
        /// String constant for the 'Administrator' user role.
        /// </summary>
        public const string Administrator = "Administrator";

        /// <summary>
        /// String constant for the 'User' user role.
        /// </summary>
        public const string User = "User";


        /// <summary>
        /// String constant for the 'ReadOnlyUser' user role.
        /// </summary>
        public const string ReadOnlyUser = "ReadOnlyUser";


        /// <summary>
        /// String constant for the 'PowerUser' user role.
        /// </summary>
        public const string PowerUser = "PowerUser";

    }
}
