using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core.Dto
{
    public class UserDetailsDto
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int userPoint { get; set; }
        public double Rrate { get; set; }

    }
}
