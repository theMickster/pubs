namespace Pubs.Application.DTOs
{
    public class AuthorTitleDto
    {
        public int AuthorTitleId { get; set; }

        public int AuthorId { get; set; }

        public int TitleId { get; set; }

        public string TitleCode { get; set; }

        public string TitleName { get; set; }

        public string TitleType { get; set; }

        public byte AuthorOrder { get; set; }
    }
}
