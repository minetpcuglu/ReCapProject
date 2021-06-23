using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImagesService _carImagesService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileHelper _file;

        public CarImagesController(IFileHelper file, ICarImagesService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImagesService = carImageService;
            _file = file;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, IFormFile file)
        {
            var imageResult = _file.Upload(file, _webHostEnvironment.WebRootPath + "\\uploads\\");
            if (imageResult.IsFaulted || imageResult.IsCanceled) return BadRequest(imageResult.Result.Message);
            carImage.ImagePath = imageResult.Result.Message;
            var result = _carImagesService.Add(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _carImagesService.GetAllCarImages();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
