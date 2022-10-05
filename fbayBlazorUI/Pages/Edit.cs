using fbayModels.DTOs.AdvertismentDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace fbayBlazorUI.Pages
{
    public partial class Edit
    {
        [Inject]
        private HttpClient Http { get; set; }

        private ReadAdvertisementDTO? advertisement { get; set; }

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            string url = $"/api/Advertisement/GetAdvById/{Id}";

            advertisement = await Http.GetFromJsonAsync<ReadAdvertisementDTO>(url);
        }
    }
}
