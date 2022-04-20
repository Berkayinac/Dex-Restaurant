using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class PasswordReminder : IEntity
    {
        public int Id { get; set; }
        public string SecurityQuestion { get; set; }
    }
}
