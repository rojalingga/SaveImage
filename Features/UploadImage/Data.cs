using Dom;

namespace SaveImage.Features.UploadImage
{
    public static class Data
    {
        internal static Task CreateNewImage(Dom.Image image)
        {
            return image.SaveAsync();
        }


    }
}
