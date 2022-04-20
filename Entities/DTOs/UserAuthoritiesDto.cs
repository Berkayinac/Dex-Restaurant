using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserAuthoritiesDto : IDto
    {
        public User User { get; set; }
        public List<AuthorityDto> Authorities { get; set; }
    }
}
