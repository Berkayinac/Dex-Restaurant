using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserAuthority : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AuthorityId { get; set; }
    }
}
