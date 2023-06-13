using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core.Models.Project
{
    public class Mission
    {
        public int Id { get; set; } 
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(2500)]
        public string Description { get; set; }
        public byte[]? Poster { get; set; }
        public int Point { get; set; }
        public int TypeMissionId { get; set; }
        public TypeMission TypeMission { get; set; }
        public List<UserMission> userMissions { get; set; }
        public List<Answer> Answers { get; set; }

    }
}
