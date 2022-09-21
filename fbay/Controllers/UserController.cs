using AutoMapper;
using fbay.DTOs;
using fbay.Models;
using fbay.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetUsererById")]
        public async Task<ActionResult<User>> GetUsererById(int id)
        {

            var user = await _userRepo.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {

            var user = await _userRepo.GetAllUsers();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteUser(int id)
        {
            var userFromRepo = await _userRepo.GetUserById(id);

            if (userFromRepo == null)
            {
                return NotFound();
            }

            await _userRepo.DeleteUser(userFromRepo);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UpdateUserDTO usercreateDTO)
        {
            var user = _mapper.Map<User>(usercreateDTO);

            await _userRepo.CreateUser(user);

            var userReadDTO = _mapper.Map<ReadUserDTO>(user);

            return CreatedAtRoute(nameof(GetUsererById),
                new { Id = userReadDTO.Id }, userReadDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UpdateUserDTO userupdateDTO)
        {
            var userFromRepo = await _userRepo.GetUserById(id);

            if (userFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(userupdateDTO, userFromRepo);

            await _userRepo.UpdateUser(userFromRepo);

            return NoContent();
        }
    }
}
