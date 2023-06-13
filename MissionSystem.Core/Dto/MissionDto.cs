using Microsoft.AspNetCore.Http;
using MissionSystem.Core.Models.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core.DTO
{
    public class MissionDto
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(2500)]
        public string Description { get; set; }
        public IFormFile? Poster { get; set; }
        public int Point { get; set; }
        public int TypeMissionId { get; set; }
    }
}
