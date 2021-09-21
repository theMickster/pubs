namespace Pubs.Application.DTOs
{
    public class AuthorCreateDto
    {
        public string AuthorCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public const bool Contract = false;
    }
}
