using System;

namespace Client.Models
{
    public abstract class Entity
    {
        public virtual Guid Identifier { get; set; }
        public abstract string DocType { get; }
    }
}