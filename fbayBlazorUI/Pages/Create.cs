using fbayModels.DTOs.AdvertismentDTOs;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace fbayBlazorUI.Pages
{
    public partial class Create
    {
        [Inject]
        private HttpClient Http { get; set; }


        private CreateAdvertisementDTO advertismentToCreate = new CreateAdvertisementDTO { addressToTakes = new List<AddressToTakeDTO> { new AddressToTakeDTO() } };

        public TagDTO tagToCreate { get; set; } = new TagDTO();

        public static ObservableCollection<TagDTO> tags { get; set; } = new ObservableCollection<TagDTO>();

        protected async Task OnValidSubmit()
        {
            advertismentToCreate.keywords.AddRange(tags);

            await Http.PostAsJsonAsync("/api/Advertisement/CreateAdvertisement", advertismentToCreate);
        }

        private void AddToTagList()
        {
            if(tagToCreate != null)
            {
                tags.Add(new TagDTO { Title = tagToCreate.Title});
            }
        }

        private void RemoveFromTagList(TagDTO tag)
        {
            tags.Remove(tag);
        }
    }
}
