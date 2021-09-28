namespace Pubs.CoreDomain.Constants
{
    /// <summary>
    /// Contains constant strings to represent the user statuses within the application.
    /// </summary>
    /// <remarks>
    /// These constants are useful in the code to ensure consistency wherever the role names are referenced.
    /// Another example of how to rid the application of the magic strings code smell.
    /// </remarks>
    public static class ApplicationUserStatusNames
    {
        /// <summary>
        /// String constant for the 'Active' user role.
        /// </summary>
        public const string Active = "Active";

        /// <summary>
        /// String constant for the 'Inactive' user role.
        /// </summary>
        public const string Inactive = "Inactive";

        /// <summary>
        /// String constant for the 'Locked' user role.
        /// </summary>
        public const string Locked = "Locked";

    }
}
