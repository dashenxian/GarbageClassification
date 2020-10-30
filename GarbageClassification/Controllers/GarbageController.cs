using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageClassification.DataModels;
using GarbageClassification.MLModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GarbageClassification.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GarbageController : Controller
    {
        private readonly ILogger<GarbageController> _logger;
        private readonly GarbageModel _garbageModel;
        private readonly FileHelper _fileHelper;

        public GarbageController(ILogger<GarbageController> logger, GarbageModel garbageModel, FileHelper fileHelper)
        {
            _logger = logger;
            _garbageModel = garbageModel;
            _fileHelper = fileHelper;
        }
        [HttpPost]
        public async Task<string> Predict(IFormFile file)
        {
            var filePath = await _fileHelper.WriteFile(file, "temp");
            try
            {
                var absFilePath = _fileHelper.GetFilePath(filePath);
                var input = new GarbageData()
                {
                    ImageSource = absFilePath,
                };
                var result = _garbageModel.Predict(input);
                return result.Prediction;
            }
            finally
            {
                await _fileHelper.DeleteFile(filePath);
            }
        }
    }
}
