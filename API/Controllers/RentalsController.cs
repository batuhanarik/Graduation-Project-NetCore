﻿using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase {
        IRentalService _rentalManager;

        public RentalsController(IRentalService rentalManager) {
            _rentalManager = rentalManager;
        }

        [HttpGet("get")]
        public IActionResult Get(int id) {
            var result = _rentalManager.Get(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {
            var result = _rentalManager.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetails")]
        public IActionResult GetDetails() {
            var result = _rentalManager.GetDetails();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getoccupieddates")]
        public IActionResult GetEmptyDates(int wpId) {
            var result = _rentalManager.GetOccupiedDates(wpId);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(RentWeddingPlaceDto rentWeddingPlaceDto) {
            var result = _rentalManager.Add(rentWeddingPlaceDto.Rental, rentWeddingPlaceDto.CreditCard);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental) {
            var result = _rentalManager.Delete(rental);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental) {
            var result = _rentalManager.Update(rental);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("receive-pdf")]
        public IActionResult ReceivePdf(IFormFile pdfFile)
        {
            if (pdfFile != null && pdfFile.Length > 0)
            {
                // PDF'i kaydetme işlemini gerçekleştirin
                var filePath = Path.Combine("pdf-files", pdfFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    pdfFile.CopyTo(stream);
                }

                return Ok();
            }

            return BadRequest("PDF dosyası bulunamadı.");
        }
    }
}
