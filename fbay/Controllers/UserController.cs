using AutoMapper;
using fbay.DTOs.UserDTOs;
using fbay.Models;
using fbay.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

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

        //Search User by Id --> JSON Body User-User Addresses and User Advertisements

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<ReadUserDTO>> GetUserById(int id)
        {

            var user = await _userRepo.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReadUserDTO>(user));
        }

        //Retruns all Users and Map to ReadUserDTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadUserDTO>>> GetAllUsers()
        {

            var user = await _userRepo.GetAllUsers();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ReadUserDTO>>(user));
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


        //Create a User from a Update DTO. Update DTO Map to User Object to create a User in Database.
        //Map the created User to User DTO and return a User by ID
        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserDTO usercreateDTO)
        {
            var user = _mapper.Map<User>(usercreateDTO);

            await _userRepo.CreateUser(user);

            var userReadDTO = _mapper.Map<ReadUserDTO>(user);

            return CreatedAtRoute(nameof(GetUserById),
                new { Id = userReadDTO.Id }, userReadDTO);
        }

        //Update User By Id.
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
