using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities
{
    public class AuthorTitle : BaseEntity
    {
        public int AuthorId { get; set; }

        public int TitleId { get; set; }

        public string TitleCode { get; set; }

        public string AuthorCode { get; set; }

        public byte AuthorOrder { get; set; }
        
        public int Royalty { get; set; }

        public Author Author { get; set; }

        public Title Title { get; set; }

    }
}
