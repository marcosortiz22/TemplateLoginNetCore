using System;
using System.Collections.Generic;

namespace Entities
{
    public class User: EntityBase
    {
        public string CodeUser { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfDeleted { get; set; }

        public List<RolAppUser> RolAppUser { get; set; }
    }
}
