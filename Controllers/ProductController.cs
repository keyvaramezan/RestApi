using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestApi.Application.Models.ProductDtos;
using RestApi.Domain;
using RestApi.Infrastructure.Data.Repositories.Contracts;

namespace RestApi.Controllers
{
    //[ApiVersion("1.3")]
    //[ApiVersion("1.2")]
    //[ApiVersion("1.1")]
    //[ApiVersion("1.0")]
    //[Route("v{version:apiVersion}/Product")]
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(
            IProductRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]//, MapToApiVersion("1.0")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetById(id);

            if (product == null)
            {
                return NotFound($"Id: {id} Not Found");
            }
            else
            {
                var productDto = _mapper.Map<ProductDto>(product);
                return Ok(productDto);
            }

        }
        //[HttpGet]//, MapToApiVersion("1.1")]
        //public async Task<IActionResult> GetProducts()
        //{
        //    var products = await  _repository.GetAll();
        //    var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        //    return Ok(productDtos);
        //}
        //[HttpGet("query/byminprice")]
        //public async Task<IActionResult> GetProductByMinPrice([FromQuery] int minPrice)
        //{
        //    var products = await _repository.GetByMinPrice(minPrice); 
        //    var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        //    return Ok(productDtos);
        //}
        //[HttpGet("query/bymaxprice")]
        //public async Task<IActionResult> GetProductByMaxPrice([FromQuery] int maxPrice)
        //{
        //    var products = await _repository.GetByMaxPrice(maxPrice);
        //    var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        //    return Ok(productDtos);
        //}
        //[HttpGet("query/byrangeprice")]
        //public async Task<IActionResult> GetProductByRangePrice([FromQuery] int minPrice,[FromQuery] int maxPrice)
        //{
        //    var products = await _repository.GetByQuery(minPrice, maxPrice);
        //    var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        //    return Ok(productDtos);
        //}
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] string filter)
        {
            var products = await _repository.Search(filter);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        [HttpPost]//, MapToApiVersion("1.1")]
        public async Task<IActionResult> AddNewProduct([FromBody] CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repository.AddNew(product);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [HttpPut("{id}")]//, MapToApiVersion("1.2")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = id;
            await _repository.Update(product);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [HttpDelete("{id}")]//, MapToApiVersion("1.3")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
            {
                return BadRequest($"Id: {id} Invalid Id");
            }
            else
            {
                await _repository.Remove(product);
                return Ok();
            }
        }
        [HttpPatch("price/{id}")]//, MapToApiVersion("1.2")]
        public async Task<IActionResult> UpdateProductPrice(int id,
            [FromBody] JsonPatchDocument<UpdateProductPriceDto> doc)
        {
            if (doc == null)
            {
                return BadRequest("Invalid Patch!");
            }

            var pricePatch = new UpdateProductPriceDto();
            doc.ApplyTo(pricePatch);
            var product = await _repository.GetById(id);
            product.Price = pricePatch.Price;
            await _repository.Update(product);
            return Ok(_mapper.Map <ProductDto>(product));

        }
     
    }
}
