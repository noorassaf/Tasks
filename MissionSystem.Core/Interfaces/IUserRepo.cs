using Microsoft.EntityFrameworkCore;
using MissionSystem.Core.Models;
using MissionSystem.Core.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core.Interfaces
{
    public interface IUserRepo:IBaseRepo<ApplicationUser>
    {
        Task<ApplicationUser> GetInfo(int Id);
       


    }
}
 