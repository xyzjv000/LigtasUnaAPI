using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ligtasUnaAPI.Models;
using Azure.Storage.Blobs;
using ligtasUnaAPI.Logics;

namespace ligtasUnaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileManagerLogic _fileManagerLogic;

        public FileController(IFileManagerLogic fileManagerLogic)
        {
            _fileManagerLogic = fileManagerLogic;
        }

        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] File model)
        {
            if (model.FileData != null)
            {
                await _fileManagerLogic.Upload(model);
            }
            return Ok();
        }


        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get(string fileName)
        {
            var imgBytes = await _fileManagerLogic.Get(fileName);
            return File(imgBytes, "image/webp");
        }

        [Route("download")]
        [HttpGet]
        public async Task<IActionResult> Download(string fileName)
        {
            var imagBytes = await _fileManagerLogic.Get(fileName);
            return new FileContentResult(imagBytes, "application/octet-stream")
            {
                FileDownloadName = Guid.NewGuid().ToString() + ".mp4",
            };
        }

    }


}
