using System;
using Pubs.SharedKernel.Base;

namespace Pubs.Core.Entities
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