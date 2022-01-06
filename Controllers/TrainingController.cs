using Microsoft.AspNetCore.Mvc;
using RestApi.Application.Service.Core;
using RestApi.Domain;

namespace RestApi.Controllers;
[Route("training")]
[ApiController]
public class TrainingController : ControllerBase
{
    [HttpGet]
    public string GetData1()
    {
        return "Hello World!";
    }
    [HttpGet("d2")]
    public string GetData2()
    {
        return "Sample Text";
    }
    [HttpGet("d3")]
    public int GetData3()
    {
        return 101;
    }
    [HttpGet("d4")]
    public Product GetData4()
    {
        return new Product
        {
            Id = 1,
            Name = "p1"
        };
    }
    [HttpGet("d5")]
    public List<Product> GetData5()
    {
        return new List<Product>
        {
            new Product
            {
                 Id = 1,
                Name = "p1"
            },
            new Product
            {
                 Id = 2,
                Name = "p2"
            },
            new Product
            {
                 Id = 3,
                Name = "p3"
            },

        };
    }
    [HttpGet("d6")]
    public IActionResult GetData6()
    {
        //return Created(nameof(GetData6), "New Product Created");
        // new OkObjectResult("Product Detail");
        //return BadRequest("Invalid Product Data");
        //return NotFound("Id Not Found");
        return StatusCode(406, "Sample Description");
    }
    [HttpGet("{id}")]
    public IActionResult GetData7(int id)
    {
        return Ok($"Id: {id}");
    }
    [HttpGet("{num1}/{num2}")]
    public IActionResult GetData8(int num1, int num2)
    {
        return Ok($"Number1: {num1}, Number2: {num2}");
    }
    [HttpGet("d9")]
    public IActionResult GetData9([FromQuery] string data1, [FromQuery] string data2)
    {
        return Ok($"Data1: {data1}, Data2: {data2}");
    }
    [HttpPost("d10")]
    public IActionResult GetData10([FromBody] Product product)
    {
        return Ok($"Product: {product.ToString()}");
    }
    [HttpPost("d11")]
    public IActionResult GetData11([FromHeader] string token)
    {
        return Ok($"Token: {token}");
    }
    [HttpGet("d12")]
    public IActionResult GetData12([FromServices] IService service)
    {
        return Ok($"Service Data: {service.GetData()}");
    }
    [HttpPost("d13/{id}/{data1}")]
    public IActionResult GetData13(
        int id,
        string data1,
        [FromQuery] string data2, [FromQuery] string data3,
        [FromBody] Product product,
        [FromHeader] string token,
        [FromServices] IService service
        )
    {
        return Ok($"Id: {id}, Data1: {data1}, Data2: {data2}, Data3: {data3}, Product {product.ToString()}, Token: {token},  Service Data: {service.GetData()}");
    }
    [HttpPost("d14")]
    public IActionResult GetData14([FromForm] string firstName, [FromForm] string lastName)
    {
        return Ok($"FirstName: {firstName}, LastName: {lastName}");
    }
    [HttpPost("d15")]
    public IActionResult GetData14([FromForm] Product product)
    {
        return Ok($"Product: {product.ToString()}");
    }

}


