using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core.Dto
{
    public class UMDetailsDto
    {
        public string UserName { get; set; }
        public int MissionId { get; set; }
        public string MissionName { get; set; }
        public int MissionPoint { get; set; }
        public bool Complet { get; set; }
    }
}
