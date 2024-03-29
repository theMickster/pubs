﻿using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities
{
    public class Royalty : BaseEntity
    {
        public int TitleId { get; set; }

        public string TitleCode { get; set; }

        public int LowRange { get; set; }

        public int HighRange { get; set; }

        public int RoyaltyAmount { get; set; }

        public Title Title { get; set; }

    }
}