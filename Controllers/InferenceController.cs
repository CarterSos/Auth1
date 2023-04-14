using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Auth1.Data;

namespace Auth1.Controllers
{
    [ApiController]
    [Route("/score")]
    public class InferenceController : ControllerBase
    {
        private InferenceSession _session;

        public InferenceController(InferenceSession session)
        {
            _session = session;
        }

        [HttpPost]
        public ActionResult Score(MummyPredict data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
            Tensor<string> score = result.First().AsTensor<string>();
            var prediction = new Prediction { PredictedValue = score.First() };
            result.Dispose();
            return Ok(prediction);
        }
    }
}