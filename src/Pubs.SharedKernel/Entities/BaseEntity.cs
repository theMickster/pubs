using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pubs.SharedKernel.Entities
{
    public abstract class BaseEntity : IValidatableObject
    {
        public int Id { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
