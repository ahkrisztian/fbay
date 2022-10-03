using fbayModels.DTOs.AdvertismentDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace fbayBlazorUI.Pages
{
    public partial class Advertisements
    {
        [Inject]
        private HttpClient Http { get; set; }

        private List<ReadAdvertisementDTO> advertisements;

        

        protected override async Task OnInitializedAsync()
        {
            advertisements = await Http.GetFromJsonAsync<List<ReadAdvertisementDTO>>("/api/Advertisement/GetAllAdvs");
        }
       
    }
}
