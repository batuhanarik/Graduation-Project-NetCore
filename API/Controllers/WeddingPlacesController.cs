using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeddingPlacesController : ControllerBase
    {
        //IoC --> Inversion of Control
        private IWeddingPlaceService _weddingPlaceService;

        public WeddingPlacesController(IWeddingPlaceService weddingPlaceService)
        {
            _weddingPlaceService = weddingPlaceService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _weddingPlaceService.GetAll();
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _weddingPlaceService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(WeddingPlace weddingPlace)
        {
            var result = _weddingPlaceService.Add(weddingPlace);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(WeddingPlace weddingPlace)
        {
            var result = _weddingPlaceService.Delete(weddingPlace);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
