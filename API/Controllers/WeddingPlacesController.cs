﻿using Business.Abstract;
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
        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _weddingPlaceService.GetWeddingPlaceDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetailsbycity")]
        public IActionResult GetDetailsByCity(int id)
        {
            var result = _weddingPlaceService.GetWeddingPlaceDetailsByCity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
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

        [HttpGet("getdetailbyid")]
        public IActionResult GetDetailById(int wpId)
        {
            var result = _weddingPlaceService.GetWeddingPlaceDetail(wpId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("getdetailsbyfilter")]
        public IActionResult GetDetailsByFilter(FilterOptions filter)
        {
            var result = _weddingPlaceService.GetDetailsByFilter(filter);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getwpstats")]
        public IActionResult GetCarStats(int wpId)
        {
            var result = _weddingPlaceService.GetWeddingPlaceStats(wpId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
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
        [HttpPost("update")]
        public IActionResult Update(WeddingPlace weddingPlace)
        {
            var result = _weddingPlaceService.Update(weddingPlace);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
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
