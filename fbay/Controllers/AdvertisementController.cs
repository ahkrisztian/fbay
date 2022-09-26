using AutoMapper;
using fbay.DTOs;
using fbay.DTOs.AdvertismentDTOs;
using fbay.Models;
using fbay.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbay.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IMapper _mapper;

        public AdvertisementController(IAdvertisementRepo advertisementRepo, IMapper mapper)
        {
            _advertisementRepo = advertisementRepo;
            _mapper = mapper;
        }

        //Create advertisement and retrun AdvReadDTO
        [HttpPost]
        public async Task<ActionResult> CreateAdvertisement(CreateAdvertisementDTO advcreateDTO)
        {
            var adv = _mapper.Map<Advertisement>(advcreateDTO);

            await _advertisementRepo.CreateAdvertisement(adv);

            var advReadDTO = _mapper.Map<ReadAdvertisementDTO>(adv);

            return CreatedAtRoute(nameof(GetAdvById),
                new { Id = advReadDTO.Id }, advReadDTO);

            //return Ok(advReadDTO);

        }


        //Returns all advertisements from User
        [HttpGet("{id}", Name = "GetAdvsByUserId")]
        public async Task<ActionResult<IEnumerable<Advertisement>>> GetAdvsByUserId(int id)
        {
            var advsById= await _advertisementRepo.GetAdvertisementByUserrId(id);

            if (advsById == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ReadAdvertisementDTO>>(advsById));
        }

        //Returns an advertisement by Id
        [HttpGet("{id}", Name = "GetAdvById")]
        public async Task<ActionResult> GetAdvById(int id)
        {
            var advsById = await _advertisementRepo.GetAdvertisementById(id);

            if (advsById == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<ReadAdvertisementDTO>(advsById));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdvertisement(int id, UpdateAdvertisementDTO updateAdvertisementDTO)
        {
            var advFromRepo = await _advertisementRepo.GetAdvertisementById(id);

            if (advFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(updateAdvertisementDTO, advFromRepo);

            await _advertisementRepo.UpdateAdvertisement(advFromRepo);

            return NoContent();
        }
    }
}
