using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionSystem.Core.Dto;
using MissionSystem.Core.Models.Project;
using MissionSystem.Core;

namespace MissionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeMissionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       
        public TypeMissionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpPost("CreateTypeMission")]
        public async Task<IActionResult> Create([FromBody] TypeMissionDto dto)
        {
            var entity = await _unitOfWork.TypeMission.AddAsync(new TypeMission { Name = dto.Name });
            _unitOfWork.Complete();
            if (entity is null)
                return BadRequest("error Ocur");
            var typemissions = _mapper.Map<TypeMissionDetailsDto>(entity);
            return Ok(typemissions);
        }
        [HttpGet("GetAllTypeMission")]
        public async Task<IActionResult> GetAll()
        {
            var entity = await _unitOfWork.TypeMission.GetAllAsync();
            if (entity is null) return NotFound();

            var typemissions = _mapper.Map<IEnumerable<TypeMissionDetailsDto>>(entity);
            return Ok(typemissions);
        }
        [HttpGet("GetByIdTypeMission{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var entity = await _unitOfWork.TypeMission.GetByIdAsync(Id);
            if (entity is null) return NotFound();
            var typemissions = _mapper.Map<TypeMissionDetailsDto>(entity);
            return Ok(typemissions);
        }
        //[HttpGet("GetmissionByType{Id}")]
        //public async Task<IActionResult> GetmissionByType(int Id)
        //{
        //    var entity = await _unitOfWork.TypeMission.GetByIdAsync(Id);
        //    if (entity is null) return NotFound();
        //    var mission = await _unitOfWork.Mission.FindAllAsync(m => m.TypeMissionId == Id);

        //    mission = _mapper.Map<IEnumerable<MissionDetailDto>>(mission);
        //    return Ok(mission);
        //}
        [HttpPut("UpdateTypeMission{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] TypeMissionDto dto)
        {
            var typemission = await _unitOfWork.TypeMission.GetByIdAsync(Id);
            if (typemission is null)
                return NotFound();

            typemission.Name = dto.Name;
            var entity = _unitOfWork.TypeMission.Update(typemission);
            _unitOfWork.Complete();

            var typemissions = _mapper.Map<TypeMissionDetailsDto>(entity);
            return Ok(typemissions);
        }
        [HttpDelete("DeleteTypeMission{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var typemission = await _unitOfWork.TypeMission.GetByIdAsync(Id);
            if (typemission is null)
                return NotFound();

            _unitOfWork.TypeMission.Delete(typemission);
            _unitOfWork.Complete();

            var typemissions = _mapper.Map<TypeMissionDetailsDto>(typemission);
            return Ok(typemissions);
        }
    }
}
