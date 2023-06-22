using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nowadays.Api.Entities.Common;

namespace Nowadays.Api.Entities
{
    public class Employee:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NationalyId { get; set; }
    }
}