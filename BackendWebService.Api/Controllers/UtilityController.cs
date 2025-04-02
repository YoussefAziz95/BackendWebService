using Application.Contracts.Services;
using Application.DTOs.Utility;
using Application.Validators.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;
using System.Net;

namespace Presentation.Controllers
{
    /// <summary>
    /// Controller responsible for handling utility-related actions, such as file upload, deletion, and download.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UtilityController : AppControllerBase
    {
        private readonly IUtilityService _utilitService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilityController"/> class.
        /// </summary>
        /// <param name="utilitService">Service to handle utility operations.</param>
        public UtilityController(IUtilityService utilitService)
        {
            _utilitService = utilitService;
        }

        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("/upload")]
        [ModelValidator]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var request = new UploadRequest { File = file };
                var result = await _utilitService.UploadFile(request);

                return NewResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="request">The request details to delete a file.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("/delete")]
        [ModelValidator]
        public IActionResult Delete([FromBody] DeleteRequest request)
        {
            var result = _utilitService.DeleteFile(request);

            return NewResult(result);
        }

        /// <summary>
        /// Downloads a file.
        /// </summary>
        /// <param name="fileName">The name of the file to download.</param>
        /// <returns>The file to download.</returns>
        [HttpGet("/download/{fileName}")]
        public IActionResult Download([FromRoute] string fileName)
        {
            var result = _utilitService.DownloadFile(fileName);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NewResult(result);

            return File(System.IO.File.OpenRead(result.Data!.FilePath!), result.Data!.MimeType!, result.Data!.FileName);
        }
    }
}
