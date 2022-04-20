using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AuthorityDto : IDto
    {
        public int AuthorityId { get; set; }
        public string AuthorityName { get; set; }
    }
}
