using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Domain.Shared
{
    public abstract class Entity<TID>
    {
        public Entity()
        {
            validationResult = new ValidationResult();
        }
        public TID Id { get; set; }
        public ValidationResult validationResult { get; protected set; }
        public abstract bool IsValid();
    }
}
