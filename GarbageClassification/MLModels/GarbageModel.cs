using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GarbageClassification.DataModels;
using Microsoft.Extensions.ML;
using Microsoft.ML;

namespace GarbageClassification.MLModels
{
    public class GarbageModel
    {
        private readonly PredictionEnginePool<GarbageData, GarbagePrediction> _predictionEngine;

        public GarbageModel(PredictionEnginePool<GarbageData, GarbagePrediction> predictionEngine)
        {
            _predictionEngine = predictionEngine;
        }
        /// <summary>
        /// 预测
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GarbagePrediction Predict(GarbageData input)
        {
            GarbagePrediction result = _predictionEngine.Predict(input);
            result.Prediction = LabelMapping.MapLabel(result.Prediction);
            return result;
        }
        
    }
}
