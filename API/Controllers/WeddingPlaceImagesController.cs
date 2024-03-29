﻿using Microsoft.AspNetCore.Http;
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
        [HttpGet("getimagesbyweddingplaceid")]
        public IActionResult GetImagesByWeddingPlaceId(int id)
        {
            var result = _weddingPlaceImageService.GetImagesByWeddingPlaceId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("AddMultiple")]
        public IActionResult Add([FromForm] IFormFile[] images, [FromForm] int weddingPlaceId)
        {
            var result = _weddingPlaceImageService.AddMultiple(images, new WeddingPlaceImage { WeddingPlaceId= weddingPlaceId });
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

        [HttpPost("delete")]
        public IActionResult Delete(WeddingPlaceImage weddingPlaceImage)
        {
            var result = _weddingPlaceImageService.Delete(weddingPlaceImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
