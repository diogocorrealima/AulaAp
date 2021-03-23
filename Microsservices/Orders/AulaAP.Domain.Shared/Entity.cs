using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Domain.Shared
{
    public abstract class Entity<TID>
    {
        public TID Id { get; set; }
        public abstract bool IsValid();
    }
}
