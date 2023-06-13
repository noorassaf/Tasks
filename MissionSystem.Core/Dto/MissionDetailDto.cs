using MissionSystem.Core.Models.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core.Dto
{
    public class MissionDetailDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[]? Poster { get; set; } 
        public int Point { get; set; }
        public int TypeMissionId { get; set; }
        public string TypeMissionName { get; set; }
       
   
    }
}
