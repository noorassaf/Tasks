using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using MissionSystem.Core;
using MissionSystem.Core.Interfaces;
using MissionSystem.Core.Models;
using MissionSystem.Core.Models.Project;
using MissionSystem.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepo<TypeMission> TypeMission { get;private set; }
        public IBaseRepo<Mission> Mission { get;private set; }
        public IBaseRepo<UserMission> UserMission { get;private set; }
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            TypeMission = new BaseRepo<TypeMission>(_context);
            Mission = new BaseRepo<Mission>(_context);
            UserMission=new BaseRepo<UserMission>(_context);


        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}