using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core.Models.Project
{
    public class UserMission
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int MissionId { get; set; }
        public Mission Mission { get; set; }
        public bool Complet { get; set; }
    }
}
