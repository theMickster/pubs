using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities
{
    public class Book : BaseEntity
    {
        public int TitleId { get; set; }

        public string TitleCode { get; set; }

        public int AuthorId { get; set; }

        public string AuthorCode { get; set; }

        public int AuthorOrder { get; set; }

        public int Royalty { get; set; }

        public Author Author { get; set; }

        public Publisher Publisher { get; set; }

    }
}