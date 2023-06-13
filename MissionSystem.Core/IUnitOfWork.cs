using MissionSystem.Core.Interfaces;
using MissionSystem.Core.Models;
using MissionSystem.Core.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepo<TypeMission> TypeMission { get; }
        IBaseRepo<Mission> Mission { get; }
        IBaseRepo<UserMission> UserMission { get; }
        int Complete();
    }
}