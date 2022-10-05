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

        public ObservableCollection<TagDTO> tags { get; set; } = new ObservableCollection<TagDTO>();

        public ObservableCollection<ImageDTO> filesBase64 = new ObservableCollection<ImageDTO>();

        string message = "InputFile";

        bool isDisabled = false;
     
        protected async Task OnValidSubmit()
        {
            advertismentToCreate.keywords.AddRange(tags.ToList());

            advertismentToCreate.ImageUrls.AddRange(filesBase64.ToList());

            await Upload();

            using(var msg = await Http.PostAsJsonAsync("/api/Advertisement/CreateAdvertisement", advertismentToCreate))
            {
                isDisabled = false;

                if (msg.IsSuccessStatusCode)
                {
                    message = $"{advertismentToCreate.Title} files uploaded";
                }

                message = "Error";
            }

            filesBase64.Clear();

            NavManager.NavigateTo("/");
        }

        private void AddToTagList()
        {
            if(tagToCreate != null)
            {
                tags.Add(new TagDTO { TagTitle = tagToCreate.TagTitle});
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
