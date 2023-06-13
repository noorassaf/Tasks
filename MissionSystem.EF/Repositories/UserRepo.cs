using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissionSystem.Core.Interfaces;
using MissionSystem.Core.Models;
using MissionSystem.Core.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.EF.Repositories
{
    public class UserRepo : BaseRepo<ApplicationUser>, IUserRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRepo(ApplicationDbContext context, UserManager<ApplicationUser> userManager) :base(context)
        {
            _userManager = userManager;
        }
   
        public async Task<ApplicationUser> GetInfo(int Id)
        {
            var user =await _userManager.Users.FirstOrDefaultAsync(u=>u.Id==Id);
            return user;
        }
       
    }
}
