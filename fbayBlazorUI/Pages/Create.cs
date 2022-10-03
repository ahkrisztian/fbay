using fbayModels.DTOs.AdvertismentDTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Threading;

namespace fbayBlazorUI.Pages
{
    public partial class Create
    {
        [Inject]
        private HttpClient Http { get; set; }


        private CreateAdvertisementDTO advertismentToCreate = new CreateAdvertisementDTO { addressToTakes = new List<AddressToTakeDTO> { new AddressToTakeDTO() } };

        public TagDTO tagToCreate { get; set; } = new TagDTO();

        public static ObservableCollection<TagDTO> tags { get; set; } = new ObservableCollection<TagDTO>();

        List<ImageDTO> filesBase64 = new List<ImageDTO>();

        string message = "InputFile";

        bool isDisabled = false;
        protected async Task OnValidSubmit()
        {
            advertismentToCreate.keywords.AddRange(tags);

            advertismentToCreate.ImageUrls.AddRange(filesBase64);

            await Upload();

            await Http.PostAsJsonAsync("/api/Advertisement/CreateAdvertisement", advertismentToCreate);

            filesBase64.Clear();
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

            using (var msg = await Http.PostAsJsonAsync<List<ImageDTO>>("/api/Advertisement/Upload", filesBase64, CancellationToken.None))
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
