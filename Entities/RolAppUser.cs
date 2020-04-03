using System.Collections.Generic;

namespace Entities
{
    public class RolAppUser: EntityBase
    {
        public int IdUser { get; set; }

        public int IdRolApp { get; set; }

        public User User { get; set; }

        public RolApp RolApp { get; set; }
    }
}
