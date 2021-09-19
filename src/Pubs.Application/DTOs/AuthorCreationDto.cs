namespace Pubs.Application.DTOs
{
    public class AuthorCreationDto
    {
        public string AuthorCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public const bool Contract = false;
    }
}
