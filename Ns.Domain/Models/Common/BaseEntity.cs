using System;
using System.Collections.Generic;
using System.Text;

namespace Ns.Domain.Models.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
