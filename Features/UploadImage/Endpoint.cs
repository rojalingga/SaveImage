using UploadImage;

namespace SaveImage.Features.UploadImage
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("/Upload/Image");
            AllowFileUploads();
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var id = await Data.CreateNewItem(
                image: r.ToEntity(),
                files: new[] { r.Image});

            await SendAsync(new()
            {
                ImageID = id,
                Message = "new product created!"
            });
        }
    }
}
