using fbayModels.DTOs.AdvertismentDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace fbayBlazorUI.Pages
{
    public partial class Create
    {
        [Inject]
        private HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Http.GetFromJsonAsync<List<CreateAdvertisementDTO>>("/api/Advertisement/CreateAdvertisement");
        }
    }
}
