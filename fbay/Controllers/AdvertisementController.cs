using AutoMapper;
using fbay.Models;
using fbay.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fbayModels.DTOs.AdvertismentDTOs;
using System.Net.Http.Headers;
using System.Web.Http.Description;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace fbay.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdvertisementController(IAdvertisementRepo advertisementRepo, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _advertisementRepo = advertisementRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
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
                return NotFound();
            }

            return Ok(_mapper.Map<ReadAdvertisementDTO>(advsById));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Advertisement>>> GetAllAdvs()
        {
            var alladvs = await _advertisementRepo.GetAllAdvs();

            if(alladvs == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ReadAdvertisementDTO>>(alladvs));
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

            await _advertisementRepo.UpdateAdvertisement();

            return NoContent();
        }


        //Upload images
        [HttpPost]
        public async Task<ActionResult> Upload([FromBody] ImageDTO[] files)
        {
            foreach (var file in files)
            {
                var buf = Convert.FromBase64String(file.base64data);
                await System.IO.File.WriteAllBytesAsync(_webHostEnvironment.ContentRootPath +"\\Uploads\\" + file.Name, buf);

            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdv(int id)
        {
            var advFromRepo = _advertisementRepo.GetAdvertisementById(id);

            if(advFromRepo.Result == null)
            {
                return NotFound();
            }

            await _advertisementRepo.DeleteAdvertisement(advFromRepo.Result);

            return NoContent();
        }
    }
}
