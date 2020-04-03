using System.Collections.Generic;

namespace Entities
{
    public class RolApp: EntityBase
    {
        public List<RolAppUser> RolAppUser { get; set; }
    }
}
