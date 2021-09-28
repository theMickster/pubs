namespace Pubs.CoreDomain.Constants
{
    /// <summary>
    /// Contains constant strings to represent the user status abbreviations within the application.
    /// </summary>
    /// <remarks>
    /// These constants are useful in the code to ensure consistency wherever the role names are referenced.
    /// Another example of how to rid the application of the magic strings code smell.
    /// </remarks>
    public class ApplicationUserStatusAbbreviations
    {
        /// <summary>
        /// String constant for the 'Active' user role.
        /// </summary>
        public const string A = "A";

        /// <summary>
        /// String constant for the 'Inactive' user role.
        /// </summary>
        public const string I = "I";

        /// <summary>
        /// String constant for the 'Locked' user role.
        /// </summary>
        public const string L = "L";
    }
}
