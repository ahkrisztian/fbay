using AutoMapper;
using fbay.Controllers;
using fbayModels.DTOs.AdvertismentDTOs;
using fbay.Models;
using fbay.Profiles;
using fbay.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace fbayUnitTest
{
    public class AdvControllerTest : IDisposable
    {
        Mock<IAdvertisementRepo> _repo;
        AdvProfiles _profiles;
        MapperConfiguration _mapperConfiguration;
        IMapper _mapper;
        public AdvControllerTest()
        {
            _repo = new Mock<IAdvertisementRepo>();
            _profiles = new AdvProfiles();
            _mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfile(_profiles));
            _mapper = new Mapper(_mapperConfiguration);
        }
        public void Dispose()
        {
            _repo = null;
            _profiles = null;
            _mapperConfiguration = null;
            _mapper = null;
        }

        [Fact]
        public void GetAdvertisements_ReturnOk()
        {
            //Arrange

            _repo.Setup(x => x.GetAllAdvs().Result).Returns(GetAdvertisements(0));

            var advController = new AdvertisementController(_repo.Object, _mapper, null);

            //Act
            var result = advController.GetAllAdvs();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result.Result);



        }

        [Fact]
        public void AdvNotFound_Returns404NotFound()
        {
            //Arrange
            _repo.Setup(repo =>
                repo.GetAdvertisementById(0)).Returns(() => null);

            var controller = new AdvertisementController(_repo.Object, _mapper, null);

            //Act
            var result = controller.GetAdvById(2);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void AdvFound_Returns200()
        {
            //Arrange
            _repo.Setup(repo =>
                repo.GetAdvertisementById(1).Result).Returns(new Advertisement
                {
                    Id = 1,
                    Title = "Soda",
                    Description = "Cold with bubbles",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    UserId = 1,
                    addressToTakes = new List<AddressToTake>
                {
                    new AddressToTake
                    {
                        Id = 1,
                        AddressLine1 = "Bob Str. 1",
                        City = "Budapest",
                        Country = "Hungary",
                        ZipCode = "1000",
                        AdvertisementId = 1
                    }
                },
                    keywords = new List<Tag>
                {
                    new Tag
                    {
                        Id = 1,
                        TagTitle = "Cold",
                        AdvertisementId = 1
                    },
                    new Tag
                    {

                        Id = 2,
                        TagTitle = "Bubbles",
                        AdvertisementId = 1
                    }

                },

                    ImageUrls = new List<Image>
                {
                    new Image
                    {
                        Id = 1,
                        AdvertisementId = 1,
                        base64data = "",
                        Url = "",
                        Name = "Image1"
                    }
                }
                });

            var controller = new AdvertisementController(_repo.Object, _mapper, null);

            //Act
            var result = controller.GetAdvById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void AdvFound_Returns200_WithObject()
        {
            //Arrange
            _repo.Setup(repo =>
                repo.GetAdvertisementById(1).Result).Returns(new Advertisement
                {
                    Id = 1,
                    Title = "Soda",
                    Description = "Cold with bubbles",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    UserId = 1,
                    addressToTakes = new List<AddressToTake>
                {
                    new AddressToTake
                    {
                        Id = 1,
                        AddressLine1 = "Bob Str. 1",
                        City = "Budapest",
                        Country = "Hungary",
                        ZipCode = "1000",
                        AdvertisementId = 1
                    }
                },
                    keywords = new List<Tag>
                {
                    new Tag
                    {
                        Id = 1,
                        TagTitle = "Cold",
                        AdvertisementId = 1
                    },
                    new Tag
                    {

                        Id = 2,
                        TagTitle = "Bubbles",
                        AdvertisementId = 1
                    }

                },

                    ImageUrls = new List<Image>
                {
                    new Image
                    {
                        Id = 1,
                        AdvertisementId = 1,
                        base64data = "",
                        Url = "",
                        Name = "Image1"
                    }
                }
                });

            var controller = new AdvertisementController(_repo.Object, _mapper, null);

            //Act
            var result = controller.GetAdvById(1).Result;

            var model = result as OkObjectResult;
            //Assert
            Assert.IsType<ReadAdvertisementDTO>(model.Value);
        }

        private List<Advertisement> GetAdvertisements(int num)
        {
            var advs = new List<Advertisement>();

            if(num > 0)
            {
                advs.Add(new Advertisement
                {
                    Id = 1,
                    Title = "Soda",
                    Description = "Cold with bubbles",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    UserId = 1,
                    addressToTakes = new List<AddressToTake>
                {
                    new AddressToTake
                    {
                        Id = 1,
                        AddressLine1 = "Bob Str. 1",
                        City = "Budapest",
                        Country = "Hungary",
                        ZipCode = "1000",
                        AdvertisementId = 1
                    }
                },
                    keywords = new List<Tag>
                {
                    new Tag
                    {
                        Id = 1,
                        TagTitle = "Cold",
                        AdvertisementId = 1
                    },
                    new Tag
                    {

                        Id = 2,
                        TagTitle = "Bubbles",
                        AdvertisementId = 1
                    }

                },

                    ImageUrls = new List<Image>
                {
                    new Image
                    {
                        Id = 1,
                        AdvertisementId = 1,
                        base64data = "",
                        Url = "",
                        Name = "Image1"
                    }
                }

                });
            }
            

            return advs;
        }
    }
}