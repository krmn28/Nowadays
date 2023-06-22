using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nowadays.Api.Entities.Common;

namespace Nowadays.Api.Entities
{
    public class Project:BaseEntity
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        
    }
}