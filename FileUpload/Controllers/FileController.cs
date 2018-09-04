using System;
using API.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DealerTrackApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly IFileParser fileParser;
        private readonly ILogger logger;
        public FileController(IFileParser fileParser, ILogger<FileController> logger)
        {
            this.fileParser = fileParser;
            this.logger = logger;
        }

        [HttpPost("[action]"), DisableRequestSizeLimit]
        public ActionResult UploadCsv()
        {
            logger.LogDebug("UploadCsv: called");
            try
            {
                var file = Request.Form.Files[0];
                var result = fileParser.Parse(file);
                return Json(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return StatusCode(500, ex.Message);
            }
        }

    }
}
