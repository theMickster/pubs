namespace Pubs.Application.DTOs
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }

        public string AuthorCode { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public bool IsAuthorUnderContract { get; set; }

    }
}
