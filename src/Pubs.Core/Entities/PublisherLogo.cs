using Pubs.SharedKernel.Base;

namespace Pubs.Core.Entities
{
    public class PublisherLogo : BaseEntity
    {
        public string PublisherCode { get; set; }

        public byte[] Logo { get; set; }

        public string PublisherInfo { get; set; }

        public Publisher Publisher { get; set; }

    }
}