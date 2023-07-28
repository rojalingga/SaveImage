using Dom;
using FluentValidation;

namespace UploadImage
{
    public class Request
    {
        public IFormFile Image { get; set; }

    }


    public class Validator : Validator<Request>
    {
        public Validator()
        {

            RuleFor(x => x.Image).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("product image is required!")
                .Must(x => IsAllowedSize(x.Length)).WithMessage("too small!")
                .Must(x => IsAllowedType(x.ContentType)).WithMessage("file type is invalid!");


        }
        public bool IsAllowedType(string contentType)
           => (new[] { "image/jpeg", "image/png" }).Contains(contentType.ToLower());

        public bool IsAllowedSize(long fileLength)
            => fileLength is >= 100 and <= 10485760;
    }
    public class Response
    {
        public string ImageID { get; set; }
        public string Message { get; set; }
    }
}
