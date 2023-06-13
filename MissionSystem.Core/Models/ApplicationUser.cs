using Microsoft.AspNetCore.Identity;
using MissionSystem.Core.Models.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core.Models
{
    public class ApplicationUser:IdentityUser<int>
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public double Rate { get; set; }
        public int UserPoint { get; set; }
        public List<UserMission> UserMission { get; set; }
        public List<Answer> Answers { get; set; }

    }
}
