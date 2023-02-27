using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeddingPlaceImagesController : ControllerBase
    {
        //IoC --> Inversion of Control
        private IWeddingPlaceImageService _weddingPlaceImageService;

        public WeddingPlaceImagesController(IWeddingPlaceImageService weddingPlaceImageService)
        {
            _weddingPlaceImageService = weddingPlaceImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _weddingPlaceImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _weddingPlaceImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getimagesbywpid")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _weddingPlaceImageService.GetImagesByWeddingPlaceId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] WeddingPlaceImage wpImage)
        {
            var result = _weddingPlaceImageService.Add(wpImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int id)
        {
            var carImage = _weddingPlaceImageService.GetById(id).Data;
            var result = _weddingPlaceImageService.Update(carImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
