using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageClassification.DataModels;
using GarbageClassification.MLModels;
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

        public GarbageController(ILogger<GarbageController> logger,GarbageModel garbageModel)
        {
            _logger = logger;
            _garbageModel = garbageModel;
        }
        [HttpGet]
        public string Predict()
        {
            var path = @"C:\Users\Administrator\Desktop\ConsoleApp3\test\u=3638281207,2552637354&fm=26&gp=0.jpg";
            var input = new GarbageData()
            {
                ImageSource = path,
            };
           var result= _garbageModel.Predict(input);

           return result.Prediction;
        }
    }
}
