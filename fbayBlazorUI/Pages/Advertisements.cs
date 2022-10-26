using fbayModels.DTOs.AdvertismentDTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;

namespace fbayBlazorUI.Pages
{
    public partial class Advertisements
    {
        [Inject]
        private HttpClient Http { get; set; }

        private ObservableCollection<ReadAdvertisementDTO>? advertisements;
       
        protected override async Task OnInitializedAsync()
        {
            await JSRuntime.InvokeAsync<string>("localStorage.removeItem", "name");

            advertisements = await Http.GetFromJsonAsync<ObservableCollection<ReadAdvertisementDTO>>("/api/Advertisement/GetAllAdvs");
        }

        public async Task Navigate(int id)
        {
            NavManager.NavigateTo($"advertisements/{id}");
        }

        public async Task DeleteAdv(int id)
        {
            try
            {
                using (var msg = await Http.DeleteAsync($"/api/Advertisement/DeleteAdv/{id}"))
                {
                    if (msg.IsSuccessStatusCode)
                    {
                        Debug.WriteLine("Successfully deleted");

                        await OnInitializedAsync();
                    }
                    else
                    {
                        Debug.WriteLine("Non Http 2xx Response");
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
