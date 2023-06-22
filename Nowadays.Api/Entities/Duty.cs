using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nowadays.Api.Entities.Common;

namespace Nowadays.Api.Entities
{
    public class Duty:BaseEntity
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
    }
}