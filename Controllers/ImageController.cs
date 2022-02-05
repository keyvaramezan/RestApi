using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using RestApi.Application.Models.ImageDtos;
using RestApi.Application.Models.ProductDtos;
using RestApi.Domain;
using RestApi.Infrastructure.Data.Repositories.Contracts;

namespace RestApi.Controllers
{
    [Route("product/{productId}/image")]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IImageRepository _repository;
        private readonly IMapper _mapper;

        public ImageController(
            IWebHostEnvironment env,
            IImageRepository repository,
            IMapper mapper)
        {
            _env = env;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductImages(int productId)
        {
            var images = await _repository.Filter(images => images.ProductId == productId);
            var imageDto = _mapper.Map<IEnumerable<ImageDto>>(images);
            return Ok(imageDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddImageToProduct(int productId, [FromBody] CreateImageDto imageDto)
        {
            var image = _mapper.Map<Image>(imageDto);
            image.ProductId = productId;
            await _repository.AddNew(image);

            return Ok(_mapper.Map<ImageDto>(image));
        }
        [HttpDelete("imageId")]
        public async Task<IActionResult> DeleteImageFromProduct(int productId, int imageId)
        {
            var image = await _repository.GetById(imageId);
            if (image == null)
            {
                return BadRequest($"ImageId: {imageId} Invalid Id");
            }
            else
            {
                if (image.ProductId != productId)
                {
                    return BadRequest($"Invalid ProductId : {productId} and Image Id : {imageId}");
                }
                await _repository.Remove(image);

                return Ok();
            }
        }
        [HttpPut("imageId")]
        public async Task<IActionResult> UpdateImageFromProduct(int productId, int imageId, [FromBody] UpdateImageDto imageDto)
        {
            var image = _mapper.Map<Image>(imageDto);
            image.ProductId = productId;
            image.Id = imageId;
            await _repository.Update(image);

            return Ok(_mapper.Map<ImageDto>(image));
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(int productId, [FromForm] IEnumerable<IFormFile> files)
        {
            if (files != null)
            {

                var filelist = files.ToList();
                foreach (var file in filelist)
                {
                    _env.ContentRootPath = "wwwroot";
                    var ext = Path.GetExtension(file.FileName);
                    var name = Path.GetRandomFileName();
                    var path = Path.Combine(_env.ContentRootPath, "assets/images", name + ext);

                    await using FileStream fs = new(path, FileMode.Create);
                    await file.CopyToAsync(fs);

                    var image = new Image();
                    image.Name = $"/assets/images/{name + ext}";
                    image.ProductId = productId;

                    await _repository.AddNew(image);
                }
            }
            return Ok();
        }

    }

}
