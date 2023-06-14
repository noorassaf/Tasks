using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionSystem.Core;
using MissionSystem.Core.Dto;
using MissionSystem.Core.Interfaces;
using MissionSystem.Core.Models.Project;
using MissionSystem.EF.Repositories;
using System.Reflection;
using System.Security;

namespace MissionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUserRepo userRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;   
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        [HttpGet("GetInfo{Id}")]
        public async Task<IActionResult> GetInfo(int Id)
        {
            var user =  await _userRepo.GetInfo(Id);
            if (user == null) return NotFound();
            var User = _mapper.Map<UserDetailsDto>(user);

            return Ok(User);
        }
        [HttpGet("GetMissionUser{Id}")]
        public async Task<IActionResult> GetMission(int Id)
        {
            var user = await _userRepo.GetInfo(Id);
            if (user == null) return NotFound();
            var userMission= await _unitOfWork.UserMission.FindAllAsync(m => m.UserId == Id, new[] { "Mission" } );
           var mis =  _mapper.Map<IEnumerable< UMDetailsDto>>(userMission);
            return Ok(mis);
        }
        [HttpPost("AddMissionToUSer/{UId}/{TId}")]
        public async Task<IActionResult> AddMissionToUSer(int UId,int TId)
        {
            var user = await _userRepo.GetInfo(UId);
            if (user == null) return NotFound();
            var mission=await _unitOfWork.Mission.GetByIdAsync(TId);
            if (mission == null) return NotFound();
           var um= await _unitOfWork.UserMission.FindAsync(um => um.UserId == UId & um.MissionId==TId);
           if(um != null) return BadRequest();
            var usermission = new UserMission
            {
                Mission = mission,
                User = user,
                UserId = UId,
                MissionId = TId
            };
            await _unitOfWork.UserMission.AddAsync(usermission);
            _unitOfWork.Complete();
            var mis = _mapper.Map<UMDetailsDto>(usermission);
            return Ok(mis);
        }
    }
}
