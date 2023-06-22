using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nowadays.Api.Entities.Common;

namespace Nowadays.Api.Entities
{
    public class Duty:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}