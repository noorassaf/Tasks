using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MissionSystem.Core;
using MissionSystem.Core.Dto;
using MissionSystem.Core.DTO;
using MissionSystem.Core.Interfaces;
using MissionSystem.Core.Models.Project;
using MissionSystem.EF.Repositories;

namespace MissionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private new List<string> _allwExtention = new List<string> { "jpg", "png" };
        private long _maxAllowPosterSize = 1048576;

        public MissionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        [HttpPost("CreateMission")]
        public async Task<IActionResult> Create([FromForm]MissionDto dto)
        {
            //if (dto.Poster == null)
            //    return BadRequest("poster is rquierd");
            //if (!_allwExtention.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
            //    return BadRequest("only jpg or png are allowed");
            //if (dto.Poster.Length > _maxAllowPosterSize)
            //    return BadRequest("max allowed size for poste is 1MB");
            var isValidGenre = await _unitOfWork.TypeMission.FindAsync(m=>m.Id==dto.TypeMissionId);
            if (isValidGenre is null)
                return BadRequest("invalid TypeMission");
            var mission=_mapper.Map<Mission>(dto);
        
            if (dto.Poster != null)
            {
                if (!_allwExtention.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("only jpg or png are allowed");
                if (dto.Poster.Length > _maxAllowPosterSize)
                    return BadRequest("max allowed size for poste is 1MB");
                using var dataStream = new MemoryStream();
                await dto.Poster.CopyToAsync(dataStream);
                mission.Poster = dataStream.ToArray();
            }

            mission.Poster = null;

            await _unitOfWork.Mission.AddAsync(mission);
            _unitOfWork.Complete();
            var mis = _mapper.Map<MissionDetailDto>(mission);
            mis.Poster=mission.Poster;
            return Ok(mis);
            
        }
        [HttpGet("GetAllMission")]
        public async Task<IActionResult> GetAll()
        {
            var entity = await _unitOfWork.Mission.FindAllAsync(new[]{ "TypeMission" });
            if (entity is null) return NotFound();

          var missionDetailDtos = _mapper.Map<IEnumerable<MissionDetailDto>>(entity);
            
            return Ok(missionDetailDtos);
        }
        [HttpGet("GetByIdMission{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var entity = await _unitOfWork.Mission.GetByIdAsync(Id);
            if (entity is null) return NotFound();

            var missions = _mapper.Map<MissionDetailDto>(entity);

            return Ok(missions);
        }
        [HttpGet("GetmissionByType{Id}")]
        public async Task<IActionResult> GetmissionByType(int Id)
        {
            var type=await _unitOfWork.TypeMission.GetByIdAsync(Id);
            if (type is null) return NotFound();
            var entity = await _unitOfWork.Mission.FindAllAsync(m=>m.TypeMissionId==Id,new[] { "TypeMission" });
            if (entity is null) return NotFound();

            var missionDetailDtos = _mapper.Map<IEnumerable<MissionDetailDto>>(entity);

            return Ok(missionDetailDtos);
        }
        [HttpPut("UpdateMission{Id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] MissionDto dto)
        {
            var mission = await _unitOfWork.Mission.GetByIdAsync(Id);
            if (mission is null)
                return NotFound();
            var type=await _unitOfWork.TypeMission.GetByIdAsync(dto.TypeMissionId);
            if (type is null) return BadRequest();
            mission.Name = dto.Name;
            mission.Description = dto.Description;
            mission.TypeMissionId=dto.TypeMissionId;
            mission.Point = dto.Point;
            if (dto.Poster != null)
            {
                if (!_allwExtention.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("only jpg or png are allowed");
                if (dto.Poster.Length > _maxAllowPosterSize)
                    return BadRequest("max allowed size for poste is 1MB");
                using var dataStream = new MemoryStream();
                await dto.Poster.CopyToAsync(dataStream);
                mission.Poster = dataStream.ToArray();
            }
            mission.Poster = null;

            _unitOfWork.Mission.Update(mission);
            _unitOfWork.Complete();

            var MissionDetailDto = _mapper.Map<MissionDetailDto>(mission);
            return Ok(MissionDetailDto);
        }
        [HttpDelete("DeleteMission{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var mission = await _unitOfWork.Mission.GetByIdAsync(Id);
            if (mission is null)
                return NotFound();

            _unitOfWork.Mission.Delete(mission);
            _unitOfWork.Complete();

            var mis = _mapper.Map<MissionDetailDto>(mission);
            return Ok(mis);
        }

    }
}
