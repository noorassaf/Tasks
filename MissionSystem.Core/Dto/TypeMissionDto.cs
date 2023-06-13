using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core.Dto
{
    public class TypeMissionDto
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
