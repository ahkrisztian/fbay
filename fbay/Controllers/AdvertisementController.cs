using AutoMapper;
using fbay.DTOs;
using fbay.DTOs.AdvertismentDTOs;
using fbay.Models;
using fbay.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbay.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateAdvertisementDTO advcreateDTO)
        {
            var adv = _mapper.Map<Advertisement>(advcreateDTO);

            await _advertisementRepo.CreateAdvertisement(adv);

            //var advReadDTO = _mapper.Map<ReadAdvertisementDTO>(adv);

            return NoContent();
        }

    }
}
