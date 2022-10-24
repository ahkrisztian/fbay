using fbayModels.DTOs.AdvertismentDTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace fbayBlazorUI.Pages
{
    public partial class Edit
    {
        [Inject]
        private HttpClient Http { get; set; }

        private UpdateAdvertisementDTO advertisement = new UpdateAdvertisementDTO { addressToTakes = new List<AddressToTakeDTO> { new AddressToTakeDTO() } };
        public TagDTO tagToCreate { get; set; } = new TagDTO();

        public ObservableCollection<TagDTO> tags { get; set; } = new ObservableCollection<TagDTO>();

        public ObservableCollection<ImageDTO> filesBase64 = new ObservableCollection<ImageDTO>();

        string message = "InputFile";

        bool isDisabled = false;

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            string url = $"/api/Advertisement/GetAdvById/{Id}";

            advertisement = await Http.GetFromJsonAsync<UpdateAdvertisementDTO>(url);

            tags = new ObservableCollection<TagDTO>(advertisement.keywords);

            filesBase64 = new ObservableCollection<ImageDTO>(advertisement.ImageUrls);
        }

        protected async Task OnValidSubmit()
        {
            advertisement.keywords.Clear();
            advertisement.ImageUrls.Clear();

            advertisement.keywords.AddRange(tags.ToList());

            advertisement.ImageUrls.AddRange(filesBase64.ToList());

            await Upload();

            string output = JsonConvert.SerializeObject(advertisement);

            StringContent content = new StringContent(output, Encoding.UTF8, "application/json");

            string updateUrl = $"/api/Advertisement/UpdateAdvertisement/{Id}";

            using (var msg = await Http.PutAsync(updateUrl, content))
            {
                isDisabled = false;

                if (msg.IsSuccessStatusCode)
                {
                    message = $"{advertisement.Title} files uploaded";
                }

                message = "Error";
            }

            filesBase64.Clear();

            NavManager.NavigateTo("/");
        }

        private void AddToTagList()
        {
            if (tagToCreate != null)
            {
                tags.Add(new TagDTO { TagTitle = tagToCreate.TagTitle });
            }
        }

        private void RemoveFromTagList(TagDTO tag)
        {
            tags.Remove(tag);
        }

        private void RemoveFromImages(ImageDTO img)
        {
            filesBase64.Remove(img);
        }

        private async Task OnChange(InputFileChangeEventArgs e)
        {
            var files = e.GetMultipleFiles(); // get the files selected by the users

            foreach (var file in files)
            {
                var resizedFile = await file.RequestImageFileAsync(file.ContentType, 640, 480); // resize the image file

                var buf = new byte[resizedFile.Size]; // allocate a buffer to fill with the file's data
                using (var stream = resizedFile.OpenReadStream())
                {
                    await stream.ReadAsync(buf); // copy the stream to the buffer
                }
                filesBase64.Add(new ImageDTO { base64data = Convert.ToBase64String(buf), Url = $"{"http://127.0.0.1:8887/"}{file.Name}", Name = file.Name }); // convert to a base64 string!!
            }
        }

        private async Task Upload()
        {
            isDisabled = true;

            using (var msg = await Http.PostAsJsonAsync<List<ImageDTO>>("/api/Advertisement/Upload", filesBase64.ToList(), CancellationToken.None))
            {
                isDisabled = false;

                if (msg.IsSuccessStatusCode)
                {
                    message = $"{filesBase64.Count} files uploaded";
                }
            }
        }
    }
}
