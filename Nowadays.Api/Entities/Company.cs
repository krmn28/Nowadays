using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nowadays.Api.Entities.Common;

namespace Nowadays.Api.Entities
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Project> Projects { get; set; }
    }
}